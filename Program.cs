﻿using Lab_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BIVT_2024_Lab_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test_Purple_1();
            //Test_Purple_2();
            //Test_Purple_3();
            //Test_Purple_4_1();
            //Test_Purple_4_2();
            //Test_Purple_5();
            Test();
        }
        static void Test_Purple_1()
        {
            string[,] namesTask_1 = new string[,]
            {
                { "Дарья", "Тихонова" },
                { "Александр", "Козлов" },
                { "Никита", "Павлов" },
                { "Юрий", "Луговой" },
                { "Юрий", "Степанов" },
                { "Мария", "Луговая" },
                { "Виктор", "Жарков" },
                { "Марина", "Иванова" },
                { "Марина", "Полевая" },
                { "Максим", "Тихонов" }
            };

            double[,] coefficientsTask_1 = new double[,]
            {
            { 2.58, 2.90, 3.04, 3.43 },
            { 2.95, 2.63, 3.16, 2.89 },
            { 2.56, 3.40, 2.91, 2.69 },
            { 2.86, 2.90, 3.19, 3.14 },
            { 2.81, 2.64, 2.76, 3.20 },
            { 2.74, 3.30, 2.94, 3.27 },
            { 2.57, 2.79, 2.71, 3.46 },
            { 3.09, 2.67, 2.90, 3.50 },
            { 2.65, 3.47, 3.11, 3.39 },
            { 3.14, 3.46, 2.96, 2.76 }
            };

            int[,,] scores = new int[10, 4, 7]
            {
            {
                { 3, 4, 1, 2, 1, 3, 1 },
                { 5, 3, 4, 3, 3, 3, 3 },
                { 2, 4, 1, 5, 6, 1, 2 },
                { 6, 4, 3, 2, 2, 1, 1 },
                 },
                {
                { 3, 5, 4, 4, 5, 1, 4 },
                { 1, 6, 5, 2, 1, 4, 1 },
                { 6, 2, 4, 1, 2, 6, 5 },
                { 6, 5, 2, 2, 4, 3, 4 },
                 },
                {
                { 1, 1, 3, 5, 5, 5, 2 },
                { 4, 1, 1, 2, 2, 2, 5 },
                { 5, 2, 3, 3, 2, 2, 3 },
                { 3, 1, 3, 4, 2, 4, 5 },
                 },
                {
                { 3, 3, 5, 2, 1, 2, 4 },
                { 5, 5, 4, 2, 3, 2, 2 },
                { 6, 3, 1, 2, 2, 6, 6 },
                { 5, 1, 6, 6, 3, 2, 5 },
                 },
                {
                { 4, 3, 5, 4, 5, 1, 1 },
                { 5, 3, 4, 2, 1, 1, 2 },
                { 2, 2, 4, 2, 6, 3, 4 },
                { 3, 2, 1, 3, 5, 1, 5 },
                 },
                {
                { 6, 5, 5, 4, 2, 6, 4 },
                { 5, 4, 3, 2, 4, 6, 1 },
                { 1, 1, 3, 4, 4, 1, 6 },
                { 3, 1, 5, 1, 4, 3, 1 },
                 },
                {
                { 4, 6, 1, 4, 5, 3, 4 },
                { 1, 2, 3, 1, 5, 4, 3 },
                { 3, 6, 2, 3, 1, 6, 3 },
                { 3, 3, 6, 6, 3, 6, 6 },
                 },
                {
                { 6, 5, 3, 2, 6, 5, 3 },
                { 5, 4, 4, 2, 1, 2, 4 },
                { 4, 2, 2, 5, 1, 3, 1 },
                { 6, 5, 6, 1, 6, 3, 3 },
                 },
                {
                    { 3, 6, 3, 5, 4, 2, 3 },
                    { 4, 6, 1, 4, 2, 1, 5 },
                    { 1, 1, 3, 1, 3, 2, 6 },
                    { 1, 4, 4, 6, 6, 2, 5 },
                 },
                {
                    { 3, 3, 1, 4, 5, 6, 2 },
                    { 6, 4, 5, 4, 2, 3, 1 },
                    { 3, 3, 4, 2, 2, 3, 6 },
                    { 5, 1, 5, 5, 1, 3, 4 },
                }
            };

            Purple_1.Participant[] participants = new Purple_1.Participant[namesTask_1.GetLength(0)];
            for (int i = 0; i < namesTask_1.GetLength(0); i++)
            {
                Purple_1.Participant part = new Purple_1.Participant(namesTask_1[i, 0], namesTask_1[i, 1]);
                double[] coefs = new double[4];
                for (int j = 0; j < 4; j++)
                {
                    coefs[j] = coefficientsTask_1[i, j];
                    int[] marks = new int[7];
                    for (int k = 0; k < 7; k++)
                    {
                        marks[k] = scores[i, j, k];
                    }
                    part.Jump(marks);
                }
                part.SetCriterias(coefs);
                participants[i] = part;

            }
            Purple_1.Participant.Sort(participants);
            for (int i = 0; i < participants.Length; i++)
            {
                participants[i].Print();
            }
        }

        static void Test_Purple_2()
        {
            string[,] namesTask_2 = new string[,]
            {
                { "Оксана", "Сидорова" },
                { "Полина", "Полевая" },
                { "Дмитрий", "Полевой" },
                { "Евгения", "Распутина" },
                { "Савелий", "Луговой" },
                { "Евгения", "Павлова" },
                { "Егор", "Свиридов" },
                { "Степан", "Свиридов" },
                { "Анастасия", "Козлова" },
                { "Светлана", "Свиридова" },
            };
            int[] distancesTask_2 = new int[] { 135, 191, 147, 115, 112, 151, 186, 166, 112, 197 };
            int[,] marksTask_2 = new int[,]
            {
                { 15, 1, 3, 9, 15 },
                { 19, 14, 9, 11, 4 },
                { 20, 9, 1, 13, 6 },
                { 5, 20, 17, 9, 16 },
                { 19, 8, 1, 6, 17 },
                { 16, 12, 5, 20, 4 },
                { 5, 20, 3, 19, 18 },
                { 16, 12, 5, 4, 15 },
                { 7, 4, 19, 11, 12 },
                { 14, 3, 6, 17, 1 },
            };

            Purple_2.Participant[] participants = new Purple_2.Participant[10];
            for (int i = 0; i < participants.Length; i++)
            {
                Purple_2.Participant part = new Purple_2.Participant(namesTask_2[i, 0], namesTask_2[i, 1]);
                int[] marks = new int[5];
                for (int j = 0; j < 5; j++)
                {
                    marks[j] = marksTask_2[i, j];
                }
                part.Jump(distancesTask_2[i], marks, 0);
                part.Print();
                participants[i] = part;
            }
            Purple_2.Participant.Sort(participants);
            Console.WriteLine();

            for (int i = 0; i < participants.Length; i++)
                participants[i].Print();
        }

        static void Test_Purple_3()
        {
            string[,] namesTask_3 = new string[,]
            {
                { "Виктор", "Полевой" },
                { "Алиса", "Козлова" },
                { "Ярослав", "Зайцев" },
                { "Савелий", "Кристиан" },
                { "Алиса", "Козлова" },
                { "Алиса", "Луговая" },
                { "Александр", "Петров" },
                { "Мария", "Смирнова" },
                { "Полина", "Сидорова" },
                { "Татьяна", "Сидорова" },
            };
            double[,] marksTask_3 = new double[,]
            {
                { 5.93, 5.44, 1.2, 0.28, 1.57, 1.86, 5.89 },
                { 1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79 },
                { 2.93, 3.1, 5.46, 4.88, 3.99, 4.79, 5.56 },
                { 4.2, 4.69, 3.9, 1.67, 1.13, 5.66, 5.4 },
                { 3.27, 2.43, 0.9, 5.61, 3.12, 3.76, 3.73 },
                { 0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68 },
                { 3.78, 3.42, 3.84, 2.19, 1.2, 2.51, 3.51 },
                { 1.35, 3.4, 1.85, 2.02, 2.78, 3.23, 3.03 },
                { 0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77 },
                { 3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84 },
            };
            Purple_3.Participant[] participants = new Purple_3.Participant[10];

            for (int i = 0; i < participants.Length; i++)
            {
                Purple_3.Participant part = new Purple_3.Participant(namesTask_3[i, 0], namesTask_3[i, 1]);
                for (int j = 0; j < marksTask_3.GetLength(1); j++)
                {
                    part.Evaluate(marksTask_3[i, j]);
                }
                participants[i] = part;
            }
            Purple_3.Participant.SetPlaces(participants);
            Purple_3.Participant.Sort(participants);

            for (int i = 0; i < participants.Length; i++)
            {

                participants[i].Print();
            }
        }

        static void Test_Purple_4_1()
        {
            string[,] namesTask_4_1 = new string[,]
            {
                { "Полина", "Луговая" },
                { "Савелий", "Козлов" },
                { "Екатерина", "Жаркова" },
                { "Дмитрий", "Иванов" },
                { "Дмитрий", "Полевой" },
                { "Савелий", "Петров" },
                { "Евгения", "Распутина" },
                { "Екатерина", "Луговая" },
                { "Мария", "Иванова" },
                { "Степан", "Павлов" },
                { "Ольга", "Павлова" },
                { "Ольга", "Полевая" },
                { "Дарья", "Павлова" },
                { "Дарья", "Свиридова" },
                { "Евгения", "Свиридова" },
            };
            double[] distancesTask_4_1 = new double[] { 422.64, 142.05, 185.23, 294.32, 79.26, 230.63, 35.16, 376.12, 279.2, 292.38, 467.6, 473.82, 290.14, 368.6, 212.67 };


            string[,] namesTask_4_2 = new string[,]
            {
                { "Анастасия", "Жаркова" },
                { "Александр", "Павлов" },
                { "Степан", "Свиридов" },
                { "Игорь", "Сидоров" },
                { "Евгения", "Сидорова" },
                { "Мария", "Сидорова" },
                { "Лев", "Петров" },
                { "Савелий", "Козлов" },
                { "Егор", "Свиридов" },
                { "Оксана", "Жаркова" },
                { "Светлана", "Петрова" },
                { "Полина", "Петрова" },
                { "Екатерина", "Павлова" },
                { "Юлия", "Полевая" },
                { "Евгения", "Павлова" },
            };
            double[] distancesTask_4_2 = new double[] { 112.49, 472.11, 213.92, 102.13, 263.21, 350.75, 248.68, 325.28, 300.0, 252.16, 402.2, 397.33, 384.94, 8.09, 480.52 };

            Purple_4.Group group1 = new Purple_4.Group("First");
            Purple_4.Sportsman[] sportsmen1 = new Purple_4.Sportsman[namesTask_4_1.GetLength(0)];

            for (int i = 0; i < sportsmen1.Length; i++)
            {
                Purple_4.Sportsman sport = new Purple_4.Sportsman(namesTask_4_1[i, 0], namesTask_4_1[i, 1]);
                sport.Run(distancesTask_4_1[i]);
                sportsmen1[i] = sport;
                group1.Add(sport);
                //sportsmen1[i].Print();
            }

            Purple_4.Group group2 = new Purple_4.Group("Second");
            Purple_4.Sportsman[] sportsmen2 = new Purple_4.Sportsman[namesTask_4_2.GetLength(0)];

            for (int i = 0; i < sportsmen2.Length; i++)
            {
                Purple_4.Sportsman sport = new Purple_4.Sportsman(namesTask_4_2[i, 0], namesTask_4_2[i, 1]);
                sport.Run(distancesTask_4_2[i]);
                sportsmen2[i] = sport;
                group2.Add(sport);
                //sportsmen2[i].Print();
            }


            group1.Sort();
            group2.Sort();


            Purple_4.Group final = Purple_4.Group.Merge(group1, group2);

            Purple_4.Sportsman[] finalists = final.Sportsmen;

            for (int i = 0; i < finalists.Length; i++)
            {
                finalists[i].Print();
            }

        }
        static void Test_Purple_4_2()
        {
            string[,] namesTask_4_1 = new string[,]
            {
                { "Полина", "Луговая" },
                { "Савелий", "Козлов" },
                { "Екатерина", "Жаркова" },
                { "Дмитрий", "Иванов" },
                { "Дмитрий", "Полевой" },
                { "Савелий", "Петров" },
                { "Евгения", "Распутина" },
                { "Екатерина", "Луговая" },
                { "Мария", "Иванова" },
                { "Степан", "Павлов" },
                { "Ольга", "Павлова" },
                { "Ольга", "Полевая" },
                { "Дарья", "Павлова" },
                { "Дарья", "Свиридова" },
                { "Евгения", "Свиридова" },
            };
            double[] distancesTask_4_1 = new double[] { 422.64, 142.05, 185.23, 294.32, 79.26, 230.63, 35.16, 376.12, 279.2, 292.38, 467.6, 473.82, 290.14, 368.6, 212.67 };


            string[,] namesTask_4_2 = new string[,]
            {
                { "Анастасия", "Жаркова" },
                { "Александр", "Павлов" },
                { "Степан", "Свиридов" },
                { "Игорь", "Сидоров" },
                { "Евгения", "Сидорова" },
                { "Мария", "Сидорова" },
                { "Лев", "Петров" },
                { "Савелий", "Козлов" },
                { "Егор", "Свиридов" },
                { "Оксана", "Жаркова" },
                { "Светлана", "Петрова" },
                { "Полина", "Петрова" },
                { "Екатерина", "Павлова" },
                { "Юлия", "Полевая" },
                { "Евгения", "Павлова" },
            };
            double[] distancesTask_4_2 = new double[] { 112.49, 472.11, 213.92, 102.13, 263.21, 350.75, 248.68, 325.28, 300.0, 252.16, 402.2, 397.33, 384.94, 8.09, 480.52 };

            Purple_4.Group group1 = new Purple_4.Group("First");

            for (int i = 0; i < distancesTask_4_1.Length; i++)
            {
                Purple_4.Sportsman sport = new Purple_4.Sportsman(namesTask_4_1[i, 0], namesTask_4_1[i, 1]);
                sport.Run(distancesTask_4_1[i]);
                group1.Add(sport);
                //sportsmen1[i].Print();
            }

            Purple_4.Group group2 = new Purple_4.Group("Second");

            for (int i = 0; i < distancesTask_4_2.Length; i++)
            {
                Purple_4.Sportsman sport = new Purple_4.Sportsman(namesTask_4_2[i, 0], namesTask_4_2[i, 1]);
                sport.Run(distancesTask_4_2[i]);
                group2.Add(sport);
                //sportsmen2[i].Print();
            }


            group1.Add(group2);

            Purple_4.Sportsman[] finalists = group1.Sportsmen;

            for (int i = 0; i < finalists.Length; i++)
            {
                finalists[i].Print();
            }

        }

        static void Test_Purple_5()
        {
            string[,] responses = new string[,]
            {
                { "Макака", null,  "Манга" },
                { "Тануки", "Проницательность",  "Манга" },
                { "Тануки", "Скромность",  "Кимоно" },
                { "Кошка", "Внимательность",  "Суши" },
                { "Сима_энага", "Дружелюбность",  "Кимоно" },
                { "Макака", "Внимательность",  "Самурай" },
                { "Панда", "Проницательность",  "Манга" },
                { "Сима_энага", "Проницательность",  "Суши" },
                { "Серау", "Внимательность",  "Сакура" },
                { "Панда", null,  "Кимоно" },
                { "Сима_энага", "Дружелюбность",  "Сакура" },
                { "Кошка", "Внимательность",  "Кимоно" },
                { "Панда", null,  "Сакура" },
                { "Кошка", "Уважительность",  "Фудзияма" },
                { "Панда", "Целеустремленность",  "Аниме" },
                { "Серау", "Дружелюбность",  null },
                { "Панда", null,  "Манга" },
                { "Сима_энага", "Скромность",  "Фудзияма" },
                { "Панда", "Проницательность",  "Самурай" },
                { "Кошка", "Внимательность",  "Сакура" },
            };

            Purple_5.Research research = new Purple_5.Research("res");

            for (int i = 0; i < responses.GetLength(0); i++)
            {
                research.Add(new string[] { responses[i, 0], responses[i, 1], responses[i, 2] });
            }

            string[] res1 = research.GetTopResponses(1),
                res2 = research.GetTopResponses(2),
                res3 = research.GetTopResponses(3);

            for (int i = 0; i < res1.Length; i++)
            {
                Console.WriteLine(res1[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < res2.Length; i++)
            {
                Console.WriteLine(res2[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < res3.Length; i++)
            {
                Console.WriteLine(res3[i]);
            }
            Console.WriteLine();
        }

        static void Test()
        {
            double[] moods1 = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.1, 7.2 };
            double[] moods2 = new double[] { 0.1, 0.2, 0.3, 0.4, 0.5, 1.6, 3.2 };

            Purple_3.Participant p1 = new Purple_3.Participant("Pypa", "Lypa");
            Purple_3.Participant p2 = new Purple_3.Participant("Andrey", "Barmaley");
            Purple_3.Participant p3 = new Purple_3.Participant("Nick", "Vujicic");
            Purple_3.Participant p4 = new Purple_3.Participant("Bebra", "52-Bratyxa");

            Purple_3.FigureSkating figSkating = new Purple_3.FigureSkating(moods1);
            figSkating.Add(p1); figSkating.Add(p2);
            //figSkating.Print();

            Purple_3.IceSkating iceSkating = new Purple_3.IceSkating(moods2);
            iceSkating.Add(p3); iceSkating.Add(p4);
            //iceSkating.Print();
        }
    }
}
