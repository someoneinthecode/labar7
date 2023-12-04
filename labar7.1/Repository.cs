using System;
using System.Collections.Generic;

public class Repository<T>
{
    private List<T> items;

    public Repository()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> Find(Criteria<T> criteria)
    {
        List<T> result = new List<T>();

        foreach (T item in items)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }

        return result;
    }
}

public delegate bool Criteria<T>(T item);