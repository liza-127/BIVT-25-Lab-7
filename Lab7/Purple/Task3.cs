namespace Lab7.Purple
{
    public class Task3
    {
        public struct Participant
        {
            //Name, Surname, Marks, Places, TopPlace и TotalMark поля
                        private string _name;
            private string _surname;
            private double[] _marks;// оценок за прыжки
            private int[] _places;// массива мест, полученных спортсменом у судей,
            private int _topplace;//наивысшего места
            private double _totalmark;//суммы полученных мест

            //свойства 
            public string Name => _name;
            public string Surname => _surname;   
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    double[] marks = new double[7];
                    for (int i = 0; i < marks.Length; i++)
                    {
                        marks[i] = _marks[i];
                    }
                    return marks;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    int[] places = new int[7];
                    for (int i = 0; i < places.Length; i++)
                    {
                        places[i] = _places[i];
                    }
                    return places;
                }
            }

            public int TopPlace
            {
                get
                {
               
                    int mn = 1000;
                    for (int i = 1; i < _places.Length; i++)
                    {
                        if (_places[i] < mn)
                        {
                            mn = _places[i];
                        }
                    }
                    _topplace = mn;

                    return _topplace;
                }
            }
            public double TotalMark
            {
                get
                {
                    double sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }

                    return sum;
                }
            }
            public int Score
            {
                get
                {
                    int itog = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        itog += _places[i];
                    }
                    return itog;
                }
            }
            // конструктор 
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _topplace = 0;
                _totalmark = 0;
            }
            int k = 0;
            //который добавляет оценку очередного судьи в массиd
            public void Evaluate(double result)
            {
                if (k < 7)
                {
                    _marks[k] = result;
                }

                k++;

            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;
                double[,] matrix = new double[participants.Length, 7];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = participants[i]._marks[j];
                    }
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int i1 = 0;
                    while (i1 < matrix.GetLength(0))
                    {
                        if (i1 == 0 || matrix[i1, j] <= matrix[i1 - 1, j])
                        {
                            i1++;
                        }
                        else
                        {
                            double tmp = matrix[i1, j];
                            matrix[i1, j] = matrix[i1 - 1, j];
                            matrix[i1 - 1, j] = tmp;
                            i1--;
                        }
                    }
                }

                int count = 0, _i = 0, _j = 0;
                while (count < matrix.Length)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (participants[_i]._marks[_j] == matrix[i, _j])
                        {
                            participants[_i]._places[_j] = i + 1;
                        }
                    }

                    count++;
                    _i++;
                    if (_i == matrix.GetLength(0))
                    {
                        _i = 0;
                        _j++;
                    }
                }

                int i2 = 0;
                while (i2 < participants.Length)
                {
                    if (i2 == 0 || participants[i2]._places[6] >= participants[i2 - 1]._places[6])
                    {
                        i2++;
                    }
                    else
                    {
                        Participant tmp = participants[i2];
                        participants[i2] = participants[i2 - 1];
                        participants[i2 - 1] = tmp;
                        i2--;
                    }
                }
            }
          
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length; j++)
                    {
                        if (array[j - 1].Score > array[j].Score)
                        {
                            (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        }
                        else if (array[j - 1].Score == array[j].Score)
                        {
                            for (int ii = 0; ii < array.Length;ii++)
                            {
                                for (int jj = 1; jj  < array.Length; jj++)
                                {
                                    if (array[jj - 1].TotalMark > array[jj].TotalMark)
                                    {
                                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
                                    }
                                }
                            }
                        }
                    }
                }

            }

         
            public void Print()
            {

                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(Score);
                Console.WriteLine(_topplace);
                Console.WriteLine(_totalmark);
                for (int i = 0; i < _marks.Length; i++)
                {
                    Console.Write(_marks[i] + " ");
                }
                Console.WriteLine();
                for (int i = 0; i < _places.Length; i++)
                {
                    Console.Write(_places[i] + " ");
                }
            }
        }
    }
}
