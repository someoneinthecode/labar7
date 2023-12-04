using System;
using System.Collections.Generic;

public class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

    public delegate TResult FuncDelegate(TKey key);

    public FuncDelegate CachedFunction { get; set; }

    public TimeSpan CacheDuration { get; set; }

    public FunctionCache(FuncDelegate function, TimeSpan cacheDuration)
    {
        CachedFunction = function;
        CacheDuration = cacheDuration;
    }

    public TResult GetResult(TKey key)
    {
        if (cache.TryGetValue(key, out var cacheItem))
        {
            // Перевірка часу дії кешованого результату
            if (DateTime.Now - cacheItem.TimeStamp <= CacheDuration)
            {
                Console.WriteLine($"Результат для ключа '{key}' взятий з кешу.");
                return cacheItem.Result;
            }
            else
            {
                // Якщо термін дії минув, видаляємо з кешу
                cache.Remove(key);
            }
        }

        // Викликаємо функцію, оновлюємо кеш і повертаємо результат
        TResult result = CachedFunction(key);
        cache[key] = new CacheItem(result, DateTime.Now);

        Console.WriteLine($"Результат для ключа '{key}' доданий в кеш.");
        return result;
    }