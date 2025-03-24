using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Purple_1
    {
        public class Participant
        {
            private string _name, _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpIndex;
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                for (int i = 0; i<4; i++) _coefs[i] = 2.5;
                _marks = new int[4,7];
                _jumpIndex = 0;
            }

            public string Name { get { return _name; } }
            public string Surname => _surname;
            public double[] Coefs { 
                get
                {
                    if (_coefs == null) return null;
                    return (double[])_coefs.Clone();
                } 
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    return (int[,])_marks.Clone();
                }
            }
            public double TotalScore
            {
                get
                {
                    if (_marks == null || _coefs == null) return 0;
                    double totalsum = 0;
                    for (int jump = 0; jump<4; jump++)
                    {
                        int sum = 0;
                        int mn = 1000000, mx = -100000000;
                        for (int i = 0; i<7; i++) {
                            mn = Math.Min(mn, _marks[jump,i]);
                            mx = Math.Max(mx, _marks[jump,i]);
                            sum += _marks[jump, i];
                        }
                        //Console.Write("{0:d}, {1:f4}, {2:d}, {3:d}    ", sum, _coefs[jump], mx, mn);
                        sum -= mx; sum -= mn;
                        totalsum += (double)sum * _coefs[jump];
                        //Console.WriteLine("{0:d}, {1:f4}", sum, _coefs[jump]);
                    }

                    return totalsum;
                }
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length != 4 || _coefs == null)
                {
                    return;
                }
                for (int i = 0; i < 4; i++) if (coefs[i] > 3.5 || coefs[i] < 2.5) return;
                Array.Copy(coefs, _coefs, 4);
            }
            public void Jump(int[] marks)
            {
                if (_marks == null) return; 
                if (_jumpIndex >= 4)
                {
                    return;
                }
                if (marks == null || marks.Length != 7)
                {
                    return;
                }
                for (int i = 0; i<7; i++) if (marks[i] > 6 || marks[i] < 1) return;
                for (int i = 0; i<7; i++)
                {
                    _marks[_jumpIndex, i] = marks[i];
                }
                _jumpIndex++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                int n = array.Length;
                for (int i = 0; i<n; i++)
                {
                    for (int j = 1; j<n - i; j++)
                    {
                        if (array[j].TotalScore > array[j - 1].TotalScore)
                        {
                            (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine("{0}, {1}", _name, _surname);
                foreach (double c in _coefs){
                    Console.Write("{0}, ", c);
                }
                Console.WriteLine();
                Console.WriteLine(TotalScore);
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j< _marks.GetLength(1); j++)
                    {
                        Console.Write("{0:d} ", _marks[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public class Judge
        {
            private string _name;
            private int[] _marks;
            private int cnt = 0;

            public string Name => _name;
            public Judge(string name, int[] marks)
            {
                _name = name;
                _marks = marks;
            }
            public int CreateMark()
            {
                return _marks[(cnt++) % _marks.Length];
            }

            public void Print()
            {
                Console.WriteLine(_name);
                foreach (int i in _marks)
                {
                    Console.Write($"{i}, ");
                }
                Console.WriteLine();
            }
        }

        public class Competition
        {
            private Judge[] _judges;
            private Participant[] _participants;

            public Judge[] Judges => _judges;
            public Participant[] Participants => _participants;

            public Competition(Judge[] judges)
            {
                _judges = judges;
                _participants = new Participant[0];
            }

            public void Evaluate(Participant jumper)
            {
                int[] marks = new int[_judges.Length];
                for (int i = 0; i < marks.Length; i++)
                {
                    marks[i] = _judges[i].CreateMark();
                }
            }
            
            public void Add(Participant jumper)
            {
                Evaluate(jumper);
                Array.Resize(ref _participants, _participants.Length + 1);
                _participants[_participants.Length - 1] = jumper;
            }
            public void Add(Participant[] jumpers)
            {
                for (int i = 0; i<jumpers.Length; i++) Evaluate(jumpers[i]);
                int n = _participants.Length;
                Array.Resize(ref _participants, _participants.Length + jumpers.Length);
                for (int i = n; i<_participants.Length; i++)
                {
                    _participants[i] = jumpers[i - n];
                }
            }
            public void Sort()
            {
                Participant.Sort(_participants);
            }
        }
    }
}
