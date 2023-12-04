using System;

public class Calculator<T>
{
    // Делегати для арифметичних операцій
    public delegate T AddDelegate(T a, T b);
    public delegate T SubtractDelegate(T a, T b);
    public delegate T MultiplyDelegate(T a, T b);
    public delegate T DivideDelegate(T a, T b);

    // Поля з делегатами
    public AddDelegate Add { get; set; }
    public SubtractDelegate Subtract { get; set; }
    public MultiplyDelegate Multiply { get; set; }
    public DivideDelegate Divide { get; set; }

    // Конструктор, який ініціалізує делегати
    public Calculator(AddDelegate add, SubtractDelegate subtract, MultiplyDelegate multiply, DivideDelegate divide)
    {
        Add = add;
        Subtract = subtract;
        Multiply = multiply;
        Divide = divide;
    }

    // Методи для виконання арифметичних операцій
    public T PerformAddition(T a, T b)
    {
        return Add(a, b);
    }

    public T PerformSubtraction(T a, T b)
    {
        return Subtract(a, b);
    }

    public T PerformMultiplication(T a, T b)
    {
        return Multiply(a, b);
    }

    public T PerformDivision(T a, T b)
    {
        if (EqualityComparer<T>.Default.Equals(b, default(T))) // Перевірка ділення на нуль
        {
            throw new ArgumentException("Ділення на нуль неможливе.");
        }
        return Divide(a, b);
    }
}