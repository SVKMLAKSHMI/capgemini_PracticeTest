namespace Q1{

    public class Person{
        public string Name{get; set;}
        public string Address{get; set;}
        public int Age{get; set;}

    }

    public class PersonImplementation{

        public string GetName(IList<Person> person){
            string details = "";
            foreach(var detail in person){
                details += $"{detail.Name} {detail.Address} ";
            }
            return details;

        }

        public double Average(IList<Person> person){
            double average = 0, count = 0, sum = 0;
            foreach(var p in person){
                sum += p.Age;
                count++;
            }
            average = sum/count;
            return average;

            // return person.Average(p => p.Age);
        }

        public int Max(IList<Person> person){
            int max = 0;
            foreach(var p in person){
                if(p.Age > max){
                    max = p.Age;
                }
            }
            return max;

            // return person.Max(p => p.Average);
        }
    }

    public class Program{
        public static void Main(String[] args){

            IList<Person> p = new List<Person>();

            p.Add(new Person {Name = "Aarya", Address = "A2101", Age = 69});
            p.Add(new Person {Name = "Daniel", Address = "D104", Age = 40});
            p.Add(new Person {Name = "Ira", Address = "H801", Age=25});
            p.Add(new Person {Name = "Jennifer", Address = "I1704", Age = 33});

            PersonImplementation pi = new PersonImplementation();

            string details = pi.GetName(p);
            Console.WriteLine(details);

            double averageAge = pi.Average(p);
            Console.WriteLine(averageAge);

            int max = pi.Max(p);
            Console.WriteLine(max);
        }
    }
}
