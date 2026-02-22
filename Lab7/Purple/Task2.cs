namespace Lab7.Purple
{
    public class Task2
    {
        // создаем публичную структуру
        public struct Participant
        {
            // приватные поля Name, Surname, Distance и Marks
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            // свойства 
            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    int[] marks = new int[_marks.Length];
                    for (int i = 0; i < marks.Length; i++)
                    {
                        marks[i] =_marks[i];
                    }
                    return marks;
                }
            }
            public int Result
            {
                get
                {
                    int mx = -1000;
                    int mn = 10000;
                    int sum = 0;
                    for (int i = 0; i < _marks.Length; i ++)
                    {
                        if (_marks[i] > mx)
                        {
                            mx = _marks[i];
                        }
                        if (_marks[i] < mn)
                        {
                            mn = _marks[i];
                        }
                        sum += _marks[i];
                    }
                    sum -= mx;
                    sum -= mn;
                    sum += 60;
                    if (_distance > 120)
                    {
                        sum += ((_distance - 120) * 2);
                    }
                    else if(_distance < 120)
                    {
                        sum -= ((120 - _distance) * 2);
                    }
                    if (sum < 0)
                    {
                        sum = 0;
                    }
                    return sum;
                }
                
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }
            public void Jump(int distance, int[] marks)
            {
                if (marks == null || marks.Length != 5) return;
                _distance = distance;
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0;i < array.Length;i++)
                {
                    for (int j = 1;j < array.Length;j++)
                    {
                        if (array[j-1].Result < array[j].Result)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
            }
        }

    }
}
