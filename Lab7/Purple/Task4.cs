using static Lab7.Purple.Task4;

namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            // поля 
            private string _name;
            private string _surname;
            private double _time;
            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            // конструктор 
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
            }
            public void Run(double time)
            {
                _time = time;
            }
            public void Print()
            {
                Console.WriteLine(_name);
            }


        }
        // структура
        public struct Group
        {
            // поля Name и Sportsmen.
            private string _name;
            private Sportsman[] _sportsmen;
            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;
            // первый конструктор
            ////            Первый конструктор должен принимать название группы и инициализировать массив
            ////спортсменов.Второй конструктор должен принимать в себя группу и копировать её название и всех
            ////её спортсменов в свой массив спортсменов.
            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            // второй конструктор 
            public Group(Group group)
            {
                _name = group.Name;
                Sportsman[] array = new Sportsman[group._sportsmen.Length];
                for (int i = 0; i < group._sportsmen.Length; i++)
                {
                    array[i] = group._sportsmen[i];
                }

                _sportsmen = array;

            }
            // метод
            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }
            public void Add(Sportsman[] sportsman)
            {
                for (int i = 0;i < sportsman.Length;i++)
                {
                    Add(sportsman[i]); 
                }
            }
            public void Add(Group group)
            {
                for (int i = 0; i < group._sportsmen.Length;i++)
                {
                    Add(group._sportsmen[i]);
                }
            }
            //метод для сортировки массива участников группы 
            public void Sort()
            {
                for (int i = 0;i < _sportsmen.Length; i++)
                {
                    for (int j = 1; j <  _sportsmen.Length; j++)
                    {
                        if (_sportsmen[j-1].Time >  _sportsmen[j].Time)
                        {
                            (_sportsmen[j - 1], _sportsmen[j]) = (_sportsmen[j], _sportsmen[j-1]);
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                Group merge = new Group("финалисты");
                Sportsman[] sportsman = new Sportsman[group1._sportsmen.Length + group2._sportsmen.Length];
                for (int i = 0; i < group1._sportsmen.Length; i++)
                {
                    sportsman[i] = group1._sportsmen[i];
                }
                int k = 0;
                for (int i = group1._sportsmen.Length; i < sportsman.Length; i++)
                {
                    sportsman[i] = group2._sportsmen[k];
                    k++;
                }
                for (int i = 0; i < sportsman.Length; i++)
                {
                    for (int j = 1; j < sportsman.Length; j++)
                    {
                        if (sportsman[j - 1].Time >= sportsman[j].Time)
                        {
                            (sportsman[j - 1], sportsman[j]) = (sportsman[j], sportsman[j - 1]);
                        }
                    }
                }

                merge._sportsmen = sportsman;
                return merge;
            }
            public void Print()
            {
                Console.WriteLine(_name);
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    Console.Write(_sportsmen[i]);
                }
            }
        }
        






        }
    }
