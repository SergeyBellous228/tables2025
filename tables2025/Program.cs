namespace tables2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();
            while (true)
            {

                Console.WriteLine("\nwrite: 1 - new student\n 2 - print all students \n 'exit' to exit \n");
                var inp = Console.ReadLine();
                if (inp == "1")
                {
                    Console.WriteLine("Enter some data:\n");
                    Console.Write("FullName: ");
                    var data1 = Console.ReadLine();
                    Console.Write("\nAge: ");
                    var data2 = int.Parse(Console.ReadLine());
                    Console.Write("\nGrades: ");
                    var data3 = int.Parse(Console.ReadLine());
                    Console.Write("\nEmail: ");
                    var data4 = Console.ReadLine();


                    var student = new Student
                    {
                        FullName = data1,
                        Age = data2,
                        Grades = data3,
                        Email = data4,
                    };

                    db.Students.Add(student);
                    db.SaveChanges();
                }

                if (inp == "2")
                {
                    var students = db.Students.ToList();  
                    Console.WriteLine("Id  - FullName   -  Age - Grades  -  Email");
                    foreach (var st in students)
                    {
                      Console.WriteLine($"{st.Id} - {st.FullName} - {st.Age} - {st.Grades} - {st.Email}");
                    }

                }

                if (inp == "exit")
                {
                    break;
                }
            }
            //db.Students.Add(student);
            //db.SaveChanges();

            //var students = db.Students.ToList();

            //foreach(var st in students)
            //{
            //    Console.WriteLine($"Id: {st.Id} - {st.FullName} - {st.Age} - {st.Grades} - {st.Email} - ");
            //}
        }
    }
}
