using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class Graph
    {
        public bool[,] AdjacencyMatrix;
        public double[,] WeightMatrix;
        public static int n = 9;

        public void InitializeGraph()
        {
            // Матрица смежности графа
            AdjacencyMatrix = new bool[9, 9] {
            { false,  true, false, false,  true, false, false, false, false },
            {  true, false,  true, false, false, false, false, false, false },
            { false,  true, false,  true, false, false, false,  true, false },
            { false, false,  true, false,  true, false,  true, false, false },
            {  true, false, false,  true, false,  true, false, false, false },
            { false, false, false, false,  true, false,  true, false,  true },
            { false, false, false,  true, false,  true, false,  true, false },
            { false, false,  true, false, false, false,  true, false,  true },
            { false, false, false, false, false,  true, false,  true, false }
            };

            WeightMatrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (AdjacencyMatrix[i, j])
                        WeightMatrix[i, j] = 0;
                    else
                        WeightMatrix[i, j] = double.MaxValue; // Отсутствующее ребро
                }
            }
        }

        // Ввод ребер
        public void InputWeights()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++) 
                {
                    if (!AdjacencyMatrix[i, j]) continue; 

                    double distance;
                    while (true)
                    {
                        Console.WriteLine($"Введите расстояние между вершинами {i + 1} и {j + 1}: ");
                        if (double.TryParse(Console.ReadLine(), out distance) && distance > 0) // Только положительные значения
                            break;
                        Console.WriteLine("Ошибка! Введите положительное число.");
                    }
                    WeightMatrix[i, j] = distance;
                    WeightMatrix[j, i] = distance;
                }
            }
        }

        // Поиск кратчайшего пути
        public double FindShortestPath(int startVertex, int endVertex)
        {
            double[] distances = Dijkstra(WeightMatrix, startVertex);
            return distances[endVertex];
        }

        // Алгоритм Дейкстры
        private static double[] Dijkstra(double[,] a, int v0)
        {
            double[] dist = new double[n];
            bool[] vis = new bool[n];
            int unvis = n;
            int v;

            for (int i = 0; i < n; i++)
                dist[i] = Double.MaxValue;
            dist[v0] = 0.0;

            while (unvis > 0)
            {
                v = -1;
                for (int i = 0; i < n; i++)
                {
                    if (vis[i])
                        continue;
                    if ((v == -1) || (dist[v] > dist[i]))
                        v = i;
                }
                vis[v] = true;
                unvis--;
                for (int i = 0; i < n; i++)
                {
                    if (dist[i] > dist[v] + a[v, i])
                        dist[i] = dist[v] + a[v, i];
                }
            }
            return dist;
        }
    }
}
