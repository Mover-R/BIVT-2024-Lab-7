using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Lab_7.Purple_5;

namespace Lab_7
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal, _characterTrait, _concept;

            public Response(string animal, string trait, string concept)
            {
                _animal = animal;
                _characterTrait = trait;
                _concept = concept;
            }

            public string Animal { get { return _animal; } }
            public string CharacterTrait { get { return _characterTrait; } }
            public string Concept { get { return _concept; } }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null) return 0;
                if (questionNumber < 1 || questionNumber > 3)
                {
                    return 0;
                }
                int ans = 0;
                foreach (Response response in responses)
                {
                    switch (questionNumber)
                    {
                        case 1:
                            ans += ((response.Animal == null || response.Animal != _animal) ? 0 : 1);
                            break;
                        case 2:
                            ans += ((response.CharacterTrait == null || response.CharacterTrait != _characterTrait) ? 0 : 1);
                            break;
                        case 3:
                            ans += ((response.Concept == null || response.Concept != _concept) ? 0 : 1);
                            break;
                    }
                }
                return ans;
                // Тут изменение есть)
            }
            public void Print()
            {
                Console.WriteLine("{0}, {1}, {2}", _animal, _characterTrait, _concept);
            }

        }
        public struct Research{
            string _name;
            Response[] _responce;

            public string Name { get { return _name; } }
            public Response[] Responses { get { return (_responce == null ? null : (Response[])_responce.Clone()); } }
            public Research(string name)
            {
                _name = name;
                _responce = new Response[0];
            }
            public void Add(string[] answers)
            {
                if (answers == null || answers.Length != 3 || _responce == null) return;
                Response a = new Response(answers[0], answers[1], answers[2]);
                Array.Resize(ref _responce, _responce.Length + 1);
                _responce[_responce.Length - 1] = a;
            }
           
            public string[] GetTopResponses(int question)
            {
                if (_responce == null) return null;
                if (question < 1 || question > 3 || _responce == null)
                {
                    return null;
                }
                string[] resp = new string[_responce.Length];
                for (int i = 0; i<_responce.Length; i++)
                {
                    switch (question)
                    {
                        case 1:
                            resp[i] = _responce[i].Animal;
                            break;
                        case 2:
                            resp[i] = _responce[i].CharacterTrait;
                            break;
                        case 3:
                            resp[i] = _responce[i].Concept;
                            break;
                    }
                }

                var top = resp
                .Where(x => x != null)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(5)
                .Select(g => g.Key)
                .ToArray();

                return top;
            }
            public void Print()
            {
                Console.WriteLine(_name);
                if (_responce is null)
                    return;
                for (int i = 0; i < _responce.GetLength(0); i++)
                {
                    _responce[i].Print();
                }
            }
        }
        public class Report
        {
            private Research[] _researches;
            private static int _cnt;
            public Research[] Researches
            {
                get
                {
                    return _researches;
                }
            }
            static Report()
            {
                _cnt = 1;
            }
            public Report()
            {
                _researches = new Research[0];
            }
            public Research MakeResearch()
            {
                DateTime timeNow = DateTime.Now;

                string reseachName = $"No_{_cnt++}_{timeNow.Month:00}/{timeNow.Year % 100:00}";

                if (_researches is null) _researches = new Research[0];

                Array.Resize(ref _researches, _researches.Length + 1);

                Research newResearch = new Research(reseachName);

                _researches[_researches.Length - 1] = newResearch;

                return newResearch;
            }
            public (string, double)[] GetGeneralReport(int question)
            {
                if (question < 1 || question > 3 || _researches == null)
                    return null;
                var allResponses = _researches
                    .Where(r => r.Responses != null)
                    .SelectMany(r => r.Responses)
                    .Select(r => question switch
                    {
                        1 => r.Animal,
                        2 => r.CharacterTrait,
                        3 => r.Concept,
                        _ => null
                    })
                    .Where(r => !string.IsNullOrEmpty(r))
                    .ToArray();
                return allResponses
                    .GroupBy(r => r)
                    .OrderByDescending(g => g.Count())
                    .Select(g => (
                        response: g.Key,
                        percentage: Math.Round(g.Count() * 100.0 / allResponses.Length, 2)
                    ))
                    .ToArray();
            }
        }
    }
}
