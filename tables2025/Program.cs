namespace tables2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\nwrite:\n1 - new student\n2 - print all students\n3 - change something\n4 - delete someone\n5 - exit \n");
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

                    Thread.Sleep(5000);
                }

                if (inp == "2")
                {
                    var students = db.Students.ToList();  
                    Console.WriteLine("Id  - FullName   -  Age - Grades  -  Email");
                    foreach (var st in students)
                    {
                      Console.WriteLine($"{st.Id} - {st.FullName} - {st.Age} - {st.Grades} - {st.Email}");
                    }
                    Thread.Sleep(5000);
                }

                if (inp == "3")
                {
                    Console.Write("Enter id of the student you want to change: ");
                    int par1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("what you want to change:\n 1 - FullName \n 2 - Age \n 3 - Grades \n 4 - Email ");
                    int par2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter new data: ");
                    var par3 = Console.ReadLine();
                    var students = db.Students.ToList();

                    foreach (var st in students)
                    {
                        if (st.Id == par1)
                        {
                            switch (par2)
                            {
                                case 1:
                                    st.FullName = par3;
                                    db.SaveChanges() ;
                                    Console.WriteLine("Done...");
                                    break;

                                case 2:
                                    st.Age = int.Parse(par3);
                                    db.SaveChanges();
                                    Console.WriteLine("Done...");
                                    break;

                                case 3:
                                    st.Grades = int.Parse(par3);
                                    db.SaveChanges();
                                    Console.WriteLine("Done...");
                                    break;

                                case 4:
                                    st.Email = par3;
                                    db.SaveChanges();
                                    Console.WriteLine("Done...");
                                    break;

                                default:
                                    break;
                            }

                        }
                    }

                    Thread.Sleep(5000);
                }

                if (inp == "4")
                {
                    Console.Write("Enter id of the student you want to delete: ");
                    int inp2 = int.Parse(Console.ReadLine());
                    var students = db.Students.ToList();

                    foreach (var st in students)
                    {
                        if (st.Id == inp2)
                        {
                            db.Students.Remove(st);
                            db.SaveChanges();
                        }
                    }
                    Thread.Sleep(5000);
                }

                if (inp == "5")
                {
                    break;
                }


                
            }


            //db.Students.Add(student);
            //db.SaveChanges();

            //var students = db.Students.ToList();


            //foreach (var st in students)
            //{
            //    if(st.Id == 3)
            //    {
            //        db.Students.Remove(st);
            //        db.SaveChanges();
            //    }
            //    Console.WriteLine($"Id: {st.Id} - {st.FullName} - {st.Age} - {st.Grades} - {st.Email} - ");
            //}
        }
    }
}
