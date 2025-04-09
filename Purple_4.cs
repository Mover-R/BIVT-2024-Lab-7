using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Purple_4
    {
        public class Sportsman
        {
            private string _name, _surname;
            private double _time = 0.0;
            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }

            public void Run(double time)
            {
                if (_time == 0) _time = time;
            }
            public static void Sort(Sportsman[] sp)
            {
                int n = sp.Length;
                for (int i = 0; i<n; i++)
                {
                    for (int j = 1; j < n - i; j++)
                    {
                        if (sp[j - 1].Time > sp[j].Time)
                        {
                            (sp[j - 1], sp[j]) = (sp[j], sp[j - 1]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine("Name: {0}, Surname: {1}, Time: {2:f3}", _name, _surname, _time);
            }
        }

        public class SkiMan : Sportsman
        {
            public SkiMan(string name, string surname, double time) : base(name, surname) { Run(time); }
            public SkiMan(string name, string surname) : base(name, surname) { }
        }
        public class SkiWoman : Sportsman
        {
            public SkiWoman(string name, string surname, double time) : base(name, surname) { Run(time); }
            public SkiWoman(string name, string surname) : base(name, surname) { }
        }

        public class Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;
                    return (Sportsman[])_sportsmen.Clone();
                }
            }
            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group other)
            { 
                this._name = other._name;
                if (other.Sportsmen == null) this._sportsmen = null;
                else this._sportsmen = (Sportsman[])other._sportsmen.Clone();
            }
            public void Add(Sportsman s)
            {
                if (_sportsmen == null) return;
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = s;
            }
            public void Add(Sportsman[] s)
            {
                if (s == null || _sportsmen == null) return;
                int l = _sportsmen.Length;
                Array.Resize(ref _sportsmen, s.Length + l);
                Array.Copy(s, 0, _sportsmen, l, s.Length);
            }
            public void Add(Group g)
            {
                if (g.Sportsmen == null) return;
                if (_sportsmen == null) {
                    _sportsmen = new Sportsman[0];
                }
                int l = _sportsmen.Length;
                this.Add(g.Sportsmen);
            }
            // void Remove(string name)

            /*
            public void Remove(string name)
            {
                int cnt = 0;
                int n  = _sportsmen.Length;

                for (int i = 0; i < n; i++){
                    if (_sportsmen[i].Name == name)
                    {
                        cnt++;
                    }
                }

                Sportsman[] s = new Sportsman[n - cnt];

                cnt = 0;
                for (int i =0; i<n; i++)
                {
                    if (_sportsmen[i].Name == name)
                    {
                        continue;
                    }

                    s[cnt++] = _sportsmen[i];
                }

                _sportsmen = s;
            }*/

            public void Sort()
            {
                int n = _sportsmen.Length;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 1; j < n - i; j++)
                    {
                        if (_sportsmen[j].Time < _sportsmen[j - 1].Time)
                        {
                            (_sportsmen[j], _sportsmen[j - 1]) = (_sportsmen[j - 1], _sportsmen[j]);
                        }
                    }
                }
            }
            public static Group Merge(Group g1, Group g2)
            {
                if (g1.Sportsmen == null || g2.Sportsmen == null) return new Group("Финалисты");
                int i = 0, j = 0;
                Sportsman[] s1 = g1.Sportsmen, s2 = g2.Sportsmen;
                int l1 = s1.Length, l2 = s2.Length;
                int cnt = 0;

                Sportsman[] s = new Sportsman[l1 + l2];
                for (;i < l1 && j < l2;)
                {
                    if (s1[i].Time < s2[j].Time)
                    {
                        s[cnt++] = s1[i++];
                    } else
                    {
                        s[cnt++] = s2[j++];
                    }
                }
                while (i < l1)
                {
                    s[cnt++] = s1[i++];
                }
                while (j < l2)
                {
                    s[cnt++] = s2[j++];
                }
                Group g = new Group("Финалитсты");
                g.Add(s);
                return g;
            }
            public void Print()
            {
                Console.WriteLine("{0}", _name);
                for (int i = 0; i<_sportsmen.Length; i++) {
                    Console.Write("{0} ", _sportsmen[i]);
                }
                Console.WriteLine();
            }
            public void Split(out Sportsman[] men, out Sportsman[] women)
            {
                men = new Sportsman[0];
                women = new Sportsman[0];
                for (int i = 0; i<_sportsmen.Length; i++)
                {
                    if (_sportsmen[i] is SkiMan)
                    {
                        Array.Resize(ref men, men.Length + 1);
                        men[men.Length - 1] = _sportsmen[i];
                    } else
                    {
                        Array.Resize(ref women, women.Length + 1);
                        women[women.Length - 1] = _sportsmen[i];
                    }
                }
            }
            public void Shuffle()
            {
                Sort();
                Sportsman[] men, women;
                Split(out men, out women);
                Sportsman[] result = new Sportsman[men.Length + women.Length];

                int mind = 0, wind = 0, ind = 0;
                bool ManFirst = men[0].Time <= women[0].Time;
                while (mind < men.Length && wind < women.Length)
                {
                    if (ManFirst)
                    {
                        result[ind++] = men[mind++];
                        result[ind++] = women[wind++];
                    }
                    else
                    {
                        result[ind++] = women[wind++];
                        result[ind++] = men[mind++];
                    }
                }
                while (mind < men.Length)
                {
                    result[ind++] = men[mind++];
                }
                while (wind < women.Length)
                {
                    result[ind++] = women[wind++];
                }
                _sportsmen = result;
            }
        }
    }
}
