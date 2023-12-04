class Program
{
    static void Main()
    {
        // Приклад використання для цілих чисел
        Calculator<int> intCalculator = new Calculator<int>(
            add: (a, b) => a + b,
            subtract: (a, b) => a - b,
            multiply: (a, b) => a * b,
            divide: (a, b) => a / b
        );

        Console.WriteLine($"Додавання: {intCalculator.PerformAddition(5, 3)}");
        Console.WriteLine($"Віднімання: {intCalculator.PerformSubtraction(5, 3)}");
        Console.WriteLine($"Множення: {intCalculator.PerformMultiplication(5, 3)}");
        Console.WriteLine($"Ділення: {intCalculator.PerformDivision(5, 3)}");

        // Приклад використання для дійсних чисел
        Calculator<double> doubleCalculator = new Calculator<double>(
            add: (a, b) => a + b,
            subtract: (a, b) => a - b,
            multiply: (a, b) => a * b,
            divide: (a, b) => a / b
        );

        Console.WriteLine($"Додавання: {doubleCalculator.PerformAddition(5.5, 3.2)}");
        Console.WriteLine($"Віднімання: {doubleCalculator.PerformSubtraction(5.5, 3.2)}");
        Console.WriteLine($"Множення: {doubleCalculator.PerformMultiplication(5.5, 3.2)}");
        Console.WriteLine($"Ділення: {doubleCalculator.PerformDivision(5.5, 3.2)}");
    }
}
