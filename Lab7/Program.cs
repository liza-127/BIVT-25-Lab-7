namespace прога1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal1 = new Animal(10, "петя");
            Cat cat1 = new Cat(12, "тифани", 8);
            //cat1.Method();// методы передаются по наследству 
            animal1.Method();
            cat1.Print();
            animal1.Print();
            Animal petya = new Cat(2, "марсель", 4);
            // если переопределили то сохраняется для нашец переменной petya принт - выведет для энимал ф метод будет для кот
            petya.Method();// cat method
            petya.Print();//марсель 4
            Cat cat2 = petya as Cat;// теперь в cat2  лежит petya  но теперь эта переменная класса котов а петя был animal
            cat2.Print(); //4 4 марсель 
        }
    }
    public class Animal
    {
        protected string _name;
        protected int _age;
        public Animal(int age, string name)
        {
            _age = age;
            _name = name;
        }
        public virtual void Method()
        {
            Console.WriteLine("method");
        }
        public virtual void Voice() //virtual для того чтобы изменить для кошек в наследниках
        {
            Console.WriteLine("?");
        }
        public void Print()
        {
            Console.WriteLine(_name + " " + _age);
        }
    }
    public class Cat: Animal
    {
        private int _voice;
        public int Voic => _voice;
        public Cat (int age, string name, int voice) : base(age, name) // (int age123, string name123, int voice123) : base(age123, name123)
        {
            _age += 2; // можно отредактировать из род класса если нужно и если род в классе доступно
            _voice = voice;
        }
        public override void Method()// переопределение - override 
        {
            Console.WriteLine("cat method");
        }
        public override void Voice()
        {
            Console.WriteLine("МЯУ");
        }
        public void Print()
        {
            Console.WriteLine(_voice + " " + _age + " " + _name);
        }
    }
    //public class Magazin
    //{
    //    protected string _namemagazin;
    //    public Magazin(string namemagazin)
    //        {
    //        _namemagazin = namemagazin;
    //    }
    //}
    //public class Bag
    //{ 
    //    protected string _color;
    //    private string _namebag;
    //    public Bag(string namebag, string color, string namemagazin) : base (namemagazin)
    //    {
    //        _color = color;
    //        _namebag = namebag;
    //    }
    //}


}
