using System.Text;
namespace Q5{

    public delegate bool IsEligibleForScholarship(Student std);

    public class Student{

        public int RollNo{get; set;}
        public string? Name{get; set;}
        public int Marks{get; set;}
        public char SportsGrade{get; set;}

        public static string GetEligibilityStudents(List<Student> studentsList, IsEligibleForScholarship isEligible){

            StringBuilder sb = new StringBuilder();
            foreach(var student in studentsList){

                if(isEligible(student)){
                    if(sb.Length > 0){
                        sb.Append(", ");
                    }
                    sb.Append(student.Name);
                }                
            }

            return sb.ToString();

        }

    }

    public class Q5{

        public static void Main(String[] args){

            List<Student> students = new List<Student>();
            Student obj1 = new Student(){RollNo = 1, Name = "Raj", Marks = 75, SportsGrade = 'A'};
            Student obj2 = new Student(){RollNo = 2, Name = "Rahul", Marks = 82, SportsGrade = 'A'};
            Student obj3 = new Student(){RollNo = 3, Name = "Kiran", Marks = 89, SportsGrade = 'B'};
            Student obj4 = new Student(){RollNo = 4, Name = "Sunil", Marks = 86, SportsGrade = 'A'};

            students.Add(obj1);
            students.Add(obj2);
            students.Add(obj3);
            students.Add(obj4);

            IsEligibleForScholarship isEligible = new IsEligibleForScholarship(ScholarshipEligibility);

            string result = Student.GetEligibilityStudents(students,isEligible);

            Console.WriteLine(result);


        }

        public static bool ScholarshipEligibility(Student std){

                if(std.Marks > 80 && std.SportsGrade == 'A'){
                    return true;
                }
                
            return false;
        }
    }
}
