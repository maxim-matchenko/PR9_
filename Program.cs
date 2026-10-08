//****************************************************************************
//* Практическая работа N9                                                   *
//* Выполнил: Матченко M.C., группа 2-ИСП-оКФ                                *
//* Вариант 4                                                                *
//* Задание: Обработка одномерных массивов                                   *
//****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PR_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Практическая работа № 9.";
            Console.OutputEncoding = Encoding.UTF8; // важно 
            Console.Clear(); // очистка экрана
            Console.WriteLine("Здравствуйте!");
            try
            {
                string Select;// Переменная для контроля повторного запуска
                do // внешний цикл для повторного запуска 
                {
                    Console.WriteLine("\n--- Новый расчет ---");
                    // 1. Объявление и инициализация
                    const int m = 10; // задание размерности массива 
                    double[] array = new double[m]; // объявление одномерного массива 
                    double sum = 0; // инициализация суммы 
                    bool err = false; // флаг обнаружения ошибки при вводе элементов массива
                    int i = 0;
                    // 2. Заполнение массива с клавиатуры
                    while (i < array.Length)
                    {
                        err = false; // ошибки нет
                        Console.Write($"Введите {i} элемент: ");
                        try

                        {
                            array[i] = Convert.ToDouble(Console.ReadLine()); // запись числа в текущий элемент массива 
                        }
                        catch (FormatException e)// обработка исключений
                        {
                            err = true;// ошибка ввода
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Возникла ошибка. {e.Message}");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }                        
                        catch (OverflowException)//введенное число не помещается в ячейку памяти
                        {   
                            err = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка: Число слишком большое или слишком маленькое.");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }                        
                        if (!err) // если ошибки нет, переходим к следующему элементу массива
                            i++;
                    }
                    // 3. Подсчет суммы элементов массива 
                    for (i = 0; i < array.Length; i++)
                    {
                        sum += array[i];
                    }
                    // 4. Расчет среднего арифметического
                    double sarithmeticMean = sum / array.Length;
                    // 5. Расчет дисперсии
                    double sumOfSquares = 0;
                    for (i = 0; i < array.Length; i++)
                    {
                        sumOfSquares += Math.Pow(array[i] - sarithmeticMean, 2);
                    }
                    double variance = sumOfSquares / array.Length; // дисперсия
                    // 6. Расчет среднего квадратичного отклонения
                    double standardDeviation = Math.Sqrt(variance);
                    // 7. Вывод результатов на экран
                    Console.Write("\nИсходный массив: ");
                    for (i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + " ");// вывод элементов в одну строку
                    }
                    Console.WriteLine($"\nСреднее арифметическое: {(Math.Round(sarithmeticMean, 3))}");
                    Console.WriteLine($"Дисперсия: {(Math.Round(variance, 3))}");
                    Console.WriteLine($"Среднее квадратичное отклонение: {(Math.Round(standardDeviation, 3))}");
                    Console.Write("\nХотите выполнить программу еще раз? (да - 1/нет - любая клавиша): ");
                    Select = Console.ReadLine();
                }
                while (Select == "1");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Возникла ошибка. {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.ReadKey(); // задержка экрана
        }
    }
}