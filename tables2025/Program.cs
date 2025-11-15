using EP_P32.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace tables2025
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var db = new AppDbContext();

            while (true) {
                

                Console.WriteLine("\nwrite:\n1 - operation with student\n2 - operation with author\n3 - operation with book\n4 - exit \n");
                var inp = Console.ReadLine();
                if (inp == "1")
                {
                    Console.WriteLine("\nwrite:\n1 - new student\n2 - print all students\n3 - change something\n4 - delete someone\n5 - exit \n");
                    var inp1 = Console.ReadLine();
                    if (inp1 == "1")
                    {
                        prog1();
                    }

                    if (inp1 == "2")
                    {
                        prog2();
                    }

                    if (inp1 == "3")
                    {
                        prog3();
                    }

                    if (inp1 == "4")
                    {
                        prog4();
                    }

                    if (inp1 == "5")
                    {
                        break;
                    }
                }

                if (inp == "2")
                {
                    Console.WriteLine("\nwrite:\n1 - new autor\n2 - print all authors\n3 - change something\n4 - delete someone\n5 - exit \n");
                    var inp1 = Console.ReadLine();
                    if (inp1 == "1")
                    {
                        Console.WriteLine("Enter some data:\n");
                        Console.Write("FullName: ");
                        var data1 = Console.ReadLine();


                        var author = new Author
                        {
                            Name = data1
                        };
                        db.Authors.Add(author);
                        db.SaveChanges();
                    }

                    if (inp1 == "2")
                    {
                        var authorss = db.Authors.Include(a => a.Books).ToList();

                        foreach (var author in authorss)
                        {

                            Console.WriteLine($"{author.Id} - {author.Name}");
                            foreach (var book in author.Books)
                            {
                                Console.WriteLine($"{book.Title} - {book.Year}");
                            }

                        }
                    }

                    if (inp1 == "3")
                    {
                        
                        Console.Write("Enter id of the author you want to change: ");
                        int par1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name: FullName");
                        var par2 = Console.ReadLine();


                        var authorss = db.Authors.Include(a => a.Books).ToList();

                        foreach (var author in authorss)
                        {
                            if (author.Id == par1)
                            {
                                author.Name = par2;
                                db.SaveChanges();
                            }

                        }
                       
                    }

                    if (inp1 == "4")
                    {
                        Console.Write("Enter id of the author you want to delete: ");
                        int par1 = int.Parse(Console.ReadLine());
                        


                        var authorss = db.Authors.Include(a => a.Books).ToList();

                        foreach (var author in authorss)
                        {
                            if (author.Id == par1)
                            {
                                db.Authors.Remove(author);
                                db.SaveChanges();
                            }

                        }
                    }

                    if (inp1 == "5")
                    {
                        break;
                    }
                }

                if (inp == "3")
                {
                    Console.WriteLine("\nwrite:\n1 - new book\n2 - print all books\n3 - change something\n4 - delete something\n5 - exit \n");
                    var inp1 = Console.ReadLine();
                    if (inp1 == "1")
                    {
                        Console.WriteLine("Enter some data:\n");
                        Console.Write("Tile: ");
                        var data1 = Console.ReadLine();
                        Console.Write("\nYear: ");
                        var data2 = int.Parse(Console.ReadLine());
                        Console.Write("\nAuthorId: ");
                        var data3 = int.Parse(Console.ReadLine());
                        Console.Write("\nEmail: ");
                        var data4 = Console.ReadLine();


                        var book = new Book
                        {
                            Title = data1,
                            Year = data2,
                            AuthorId = data3, 
                        };

                        db.Books.Add(book);
                        db.SaveChanges();
                    }

                    if (inp1 == "2")
                    {
                        var books = db.Books.ToList();

                        foreach (var b in books)
                        {
                          Console.WriteLine($"{b.Title} - {b.Year} - {b.AuthorId}");
                        }
                    }

                    if (inp1 == "3")
                    {

                        Console.Write("Enter id of the book you want to change: ");
                        int par1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("what you want to change:\n 1 - Title \n 2 - Year \n 3 - AuthorId");
                        int par2 = int.Parse(Console.ReadLine());
                        Console.Write("Enter new data: ");
                        var par3 = Console.ReadLine();
                        var books = db.Books.ToList();

                        foreach (var b in books)
                        {
                            if (b.Id == par1)
                            {
                                switch (par2)
                                {
                                    case 1:
                                        b.Title = par3;
                                        db.SaveChanges();
                                        Console.WriteLine("Done...");
                                        break;

                                    case 2:
                                        b.Year = int.Parse(par3);
                                        db.SaveChanges();
                                        Console.WriteLine("Done...");
                                        break;

                                    case 3:
                                        b.AuthorId = int.Parse(par3);
                                        db.SaveChanges();
                                        Console.WriteLine("Done...");
                                        break;

                                    default:
                                        break;
                                }

                            }
                        }

                    }

                    if (inp1 == "4")
                    {
                        Console.Write("Enter id of the book you want to delete: ");
                        int par1 = int.Parse(Console.ReadLine());



                        var books = db.Books.ToList();

                        foreach (var b in books)
                        {
                            if (b.Id == par1)
                            {
                                db.Books.Remove(b);
                                db.SaveChanges();
                            }

                        }
                    }

                    if (inp1 == "5")
                    {
                        break;
                    }
                }
                               
                if (inp == "4")
                {
                    break;
                }



            }










































            //var author1 = new Author
            //{
            //    Name = "J. K. Rowling",
            //};

            //var author2 = new Author
            //{
            //    Name = "Fenimor Kuper",
            //};

            //var book1 = new Book
            //{
            //    Title = "Harry Potter",
            //    Year = 1997,
            //    Author = author1,
            //};

            //var book2 = new Book
            //{
            //    Title = "Harry Potter 2",
            //    Year = 1999,
            //    Author = author1,
            //};

            //var book3 = new Book
            //{
            //    Title = "Mystery job",
            //    Year = 2009,
            //    Author = author2,
            //};


            //db.AddRange(author1, author2, book1, book2, book3);
            //db.SaveChanges();


            //var authors = db.Authors.Include(a => a.Books).ToList();

            //foreach (var author in authors) { 
            
            //    Console.WriteLine($"{author.Id} - {author.Name}");
            //    foreach(var book in author.Books)
            //    {
            //        Console.WriteLine($"{book.Title} - {book.Year}");
            //    }

            //}


            //var student = new Student
            //{
            //    FullName = "Ivan",
            //    Age = 27,
            //    Grades = 12,
            //    Email = "test@gmail.com",
            //};

            var rep = new StRepository();

            //rep.Add(student);

            //var Students = rep.GetAll();

            //foreach(var st in Students)
            //{
            //    Console.WriteLine($"Id: {st.Id} - {st.FullName} - {st.Age} - {st.Grades} - {st.Email} - ");
            //}

            //var st1 = rep.GetById(1);

            //st1.FullName = "sashabyriy";
            //rep.Update(st1);

            //while (true)
            //{
            //    Console.Clear();

            //    Console.WriteLine("\nwrite:\n1 - new student\n2 - print all students\n3 - change something\n4 - delete someone\n5 - exit \n");
            //    var inp = Console.ReadLine();
            //    if (inp == "1")
            //    {
            //        prog1();
            //    }

            //    if (inp == "2")
            //    {
            //        prog2();
            //    }

            //    if (inp == "3")
            //    {
            //        prog3();
            //    }

            //    if (inp == "4")
            //    {
            //        Program.prog4();
            //    }

            //    if (inp == "5")
            //    {
            //        break;
            //    }



            //}

            




            


            //db.Students.Add(student);
            //db.SaveChanges();

            //var students = db.Students.ToList();


            //foreach (var st in students)
            //{
            //    if (st.Id == 3)
            //    {
            //        db.Students.Remove(st);
            //        db.SaveChanges();
            //    }
            //    Console.WriteLine($"Id: {st.Id} - {st.FullName} - {st.Age} - {st.Grades} - {st.Email} - ");
            //}

            //while (true)
            //{
            //    Console.Clear();

            //    Console.WriteLine("\nwrite:\n1 - new student\n2 - print all students\n3 - change something\n4 - delete someone\n5 - exit \n");
            //    var inp = Console.ReadLine();
            //    if (inp == "1")
            //    {
            //        Console.WriteLine("Enter some data:\n");
            //        Console.Write("FullName: ");
            //        var data1 = Console.ReadLine();
            //        Console.Write("\nAge: ");
            //        var data2 = int.Parse(Console.ReadLine());
            //        Console.Write("\nGrades: ");
            //        var data3 = int.Parse(Console.ReadLine());
            //        Console.Write("\nEmail: ");
            //        var data4 = Console.ReadLine();


            //        var student = new Student
            //        {
            //            FullName = data1,
            //            Age = data2,
            //            Grades = data3,
            //            Email = data4,
            //        };

            //        db.Students.Add(student);
            //        db.SaveChanges();

            //        Thread.Sleep(5000);
            //    }

            //    if (inp == "2")
            //    {
            //        var students = db.Students.ToList();
            //        Console.WriteLine("Id  - FullName   -  Age - Grades  -  Email");
            //        foreach (var st in students)
            //        {
            //            Console.WriteLine($"{st.Id} - {st.FullName} - {st.Age} - {st.Grades} - {st.Email}");
            //        }
            //        Thread.Sleep(5000);
            //    }

            //    if (inp == "3")
            //    {
            //        Console.Write("Enter id of the student you want to change: ");
            //        int par1 = int.Parse(Console.ReadLine());
            //        Console.WriteLine("what you want to change:\n 1 - FullName \n 2 - Age \n 3 - Grades \n 4 - Email ");
            //        int par2 = int.Parse(Console.ReadLine());
            //        Console.Write("Enter new data: ");
            //        var par3 = Console.ReadLine();
            //        var students = db.Students.ToList();

            //        foreach (var st in students)
            //        {
            //            if (st.Id == par1)
            //            {
            //                switch (par2)
            //                {
            //                    case 1:
            //                        st.FullName = par3;
            //                        db.SaveChanges();
            //                        Console.WriteLine("Done...");
            //                        break;

            //                    case 2:
            //                        st.Age = int.Parse(par3);
            //                        db.SaveChanges();
            //                        Console.WriteLine("Done...");
            //                        break;

            //                    case 3:
            //                        st.Grades = int.Parse(par3);
            //                        db.SaveChanges();
            //                        Console.WriteLine("Done...");
            //                        break;

            //                    case 4:
            //                        st.Email = par3;
            //                        db.SaveChanges();
            //                        Console.WriteLine("Done...");
            //                        break;

            //                    default:
            //                        break;
            //                }

            //            }
            //        }

            //        Thread.Sleep(5000);
            //    }

            //    if (inp == "4")
            //    {
            //        Console.Write("Enter id of the student you want to delete: ");
            //        int inp2 = int.Parse(Console.ReadLine());
            //        var students = db.Students.ToList();

            //        foreach (var st in students)
            //        {
            //            if (st.Id == inp2)
            //            {
            //                db.Students.Remove(st);
            //                db.SaveChanges();
            //            }
            //        }
            //        Thread.Sleep(5000);
            //    }

            //    if (inp == "5")
            //    {
            //        break;
            //    }



            //}
        }


        static void prog1()
        {
            var rep = new StRepository();
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

            rep.Add(student);

            Thread.Sleep(5000);
        }

        static void prog2()
        {
            var rep = new StRepository();

            var students = rep.GetAll();
            Console.WriteLine("Id  - FullName   -  Age - Grades  -  Email");
            foreach (var st in students)
            {
                Console.WriteLine($"{st.Id} - {st.FullName} - {st.Age} - {st.Grades} - {st.Email}");
            }
            Thread.Sleep(5000);
        }

        static void prog3()
        {
            var rep = new StRepository();
            Console.Write("Enter id of the student you want to change: ");
            int par1 = int.Parse(Console.ReadLine());
            Console.WriteLine("what you want to change:\n 1 - FullName \n 2 - Age \n 3 - Grades \n 4 - Email ");
            int par2 = int.Parse(Console.ReadLine());
            Console.Write("Enter new data: ");
            var par3 = Console.ReadLine();
            var students = rep.GetAll();

            foreach (var st in students)
            {
                if (st.Id == par1)
                {
                    switch (par2)
                    {
                        case 1:
                            st.FullName = par3;
                            rep.Update(st);
                            Console.WriteLine("Done...");
                            break;

                        case 2:
                            st.Age = int.Parse(par3);
                            rep.Update(st);
                            Console.WriteLine("Done...");
                            break;

                        case 3:
                            st.Grades = int.Parse(par3);
                            rep.Update(st);
                            Console.WriteLine("Done...");
                            break;

                        case 4:
                            st.Email = par3;
                            rep.Update(st);
                            Console.WriteLine("Done...");
                            break;

                        default:
                            break;
                    }

                }
            }

            Thread.Sleep(5000);
        }

        static void prog4()
        {
            var rep = new StRepository();

            Console.Write("Enter id of the student you want to delete: ");
            int inp2 = int.Parse(Console.ReadLine());
            var students = rep.GetAll();

            foreach (var st in students)
            {
                if (st.Id == inp2)
                {
                    rep.Delete(st);
                }
            }
            Thread.Sleep(5000);
        }
    }   






}
