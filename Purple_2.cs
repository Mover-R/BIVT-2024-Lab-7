using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lab_7
{
    public class Purple_2
    {
        public struct Participant
        {
            private string _name, _surname;
            private int _distance, _result;
            private int[] _marks;
            private bool _flag;
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
                _result = 0;
            }
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Distance { get { return _distance; } }
            public int[] Marks { 
                get {
                    if (_marks == null) return null;
                    return (int[])_marks.Clone(); 
                } 
            }
            public int Result
            {
                get
                {
                    return _result;
                }
            }
            public void Jump(int distance, int[] marks, int target)
            {
                if (_marks == null || marks == null || marks.Length != 5) return;
                _distance = distance;
                for (int i = 0; i<5; i++)
                {
                    _marks[i] = marks[i];
                }

                int mn = 100000000, mx = -100000000;
                int sum = 0;
                for (int jump = 0; jump < 5; jump++)
                {
                    mn = Math.Min(mn, _marks[jump]);
                    mx = Math.Max(mx, _marks[jump]);
                    sum += _marks[jump];
                }
                sum -= mx; sum -= mn;

                sum += 60 + (_distance - target) * 2;

                _result = Math.Max(0, sum);
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                int n = array.Length;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 1; j<n-i; j++)
                    {
                        if (array[j].Result > array[j - 1].Result)
                        {
                            (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                if (_surname == "" || _name == "") return;
                Console.WriteLine("{0} {1} {2}", _name, _surname, this.Result);
            }
        }
        public abstract class SkiJumping
        {
            private string _nameCompetition;
            private int _distanceNorm;
            private Participant[] _participants;
            private int index = 0;
            public string Name => _nameCompetition;
            public int Standard => _distanceNorm;
            public Participant[] Participants 
            {
                get
                {
                    if (_participants == null) return null;
                    return _participants;
                }
            }

            public SkiJumping(string name, int norm)
            {
                _nameCompetition = name;
                _distanceNorm = norm;
                _participants = new Participant[0];
            }
            public void Add(Participant jumper)
            {
                if (_participants == null) _participants = new Participant[0];
                Array.Resize(ref _participants, _participants.Length + 1);
                _participants[_participants.Length - 1] = jumper;
            }
            public void Add(Participant[] jumpers)
            {
                if (_participants == null) _participants = new Participant[0];
                int n = _participants.Length;
                Array.Resize(ref _participants, _participants.Length + jumpers.Length);
                for (int i = n; i < _participants.Length; i++)
                {
                    _participants[i] = jumpers[i - n];
                }
            }
            public void Jump(int distance, int[] marks)
            {
                if (_participants == null) _participants = new Participant[0];
                if (index >= _participants.Length) return;
                _participants[index++].Jump(distance, marks, _distanceNorm);
            }
            public void Print()
            {
                Console.WriteLine($"Name: {_nameCompetition}, Standart: {_distanceNorm}");
                foreach(Participant participant in _participants) participant.Print();
            }

        }
        public class JuniorSkiJumping : SkiJumping
        {
            public JuniorSkiJumping() : base("100m", 100) { }
        }
        public class ProSkiJumping : SkiJumping
        {
            public ProSkiJumping() : base("150m", 150) { }
        }
    }
}
