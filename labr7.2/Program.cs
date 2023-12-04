class Program
{
    static void Main()
    {
        // Приклад використання
        FunctionCache<string, int> cache = new FunctionCache<string, int>(CalculateStringLength, TimeSpan.FromSeconds(5));

        Console.WriteLine(cache.GetResult("Hello")); // Викликає функцію і кешує результат
        Console.WriteLine(cache.GetResult("Hello")); // Бере результат з кешу

        System.Threading.Thread.Sleep(6000); // Чекаємо 6 секунд, щоб термін дії кешу закінчився

        Console.WriteLine(cache.GetResult("Hello")); // Викликає функцію, оскільки термін дії кешу минув
    }

    static int CalculateStringLength(string str)
    {
        Console.WriteLine("Викликається функція для обчислення довжини рядка.");
        return str.Length;
    }
}
