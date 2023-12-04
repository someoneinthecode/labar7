class Program
{
    static void Main()
    {
        // Приклад використання для рядків
        Repository<string> stringRepository = new Repository<string>();
        stringRepository.Add("Apple");
        stringRepository.Add("Banana");
        stringRepository.Add("Orange");

        Criteria<string> criteria = x => x.StartsWith("A");

        List<string> resultStrings = stringRepository.Find(criteria);

        Console.WriteLine("Елементи, що починаються з 'A':");
        foreach (string item in resultStrings)
        {
            Console.WriteLine(item);
        }

        // Приклад використання для цілих чисел
        Repository<int> intRepository = new Repository<int>();
        intRepository.Add(10);
        intRepository.Add(20);
        intRepository.Add(30);

        Criteria<int> intCriteria = x => x > 15;

        List<int> resultIntegers = intRepository.Find(intCriteria);

        Console.WriteLine("\nЕлементи, що більше 15:");
        foreach (int item in resultIntegers)
        {
            Console.WriteLine(item);
        }
    }
}
