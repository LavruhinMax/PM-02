using ExamApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph cityGraph = new Graph();
            cityGraph.InitializeGraph(); // Инициализация графа
            cityGraph.InputWeights(); // Ввод весов ребер

            Console.WriteLine("\n-- Поиск кратчайшего пути и расчет расхода топлива --\n");

            // Ввод расхода топлива
            Console.WriteLine("Введите расход топлива (л/100 км):");
            double fuelConsumptionPer100Km = double.Parse(Console.ReadLine());

            // Ввод начальной и конечной точек
            Console.WriteLine("Введите стартовую точку:");
            int startPoint = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную точку:");
            int endPoint = int.Parse(Console.ReadLine());

            // Поиск кратчайшего пути
            double shortestDistance = cityGraph.FindShortestPath(startPoint - 1, endPoint - 1);

            // Расчет расхода топлива
            double totalFuelConsumption = CalculateFuelConsumption(shortestDistance, fuelConsumptionPer100Km);

            // Вывод результатов
            Console.WriteLine($"\nРасстояние от точки {startPoint} до точки {endPoint}: {shortestDistance} км");
            Console.WriteLine($"Израсходовано топлива: {totalFuelConsumption} л");

            Console.Read();
        }

        //Метод нахождения расхода топлива
        private static double CalculateFuelConsumption(double distance, double consumption)
        {
            return (distance * consumption) / 100;
        }
    }
}