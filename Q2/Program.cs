namespace Q2{

    public class Program{

        public static void Main(String[] args){

            Console.WriteLine("Enter a value: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter b vakue");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter c value");
            int c = int.Parse(Console.ReadLine());

            int intAdd = Add(a,b,c);
            Console.WriteLine("Addition of integer values "+ intAdd);

            Console.WriteLine("Enter x value: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter y vakue");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter z value");
            double z = double.Parse(Console.ReadLine());

            double doubleAdd = Add(x,y,z);
            Console.WriteLine("Addition of double values: "+doubleAdd);

        }

        public static int Add(int a, int b, int c){

            int sum = a + b + c;
            return sum;
        }

        public static double Add(double a, double b, double c){

            double sum = a + b + c;
            return sum;
        }
    }
}
