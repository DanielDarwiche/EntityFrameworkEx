using System.Linq;

namespace EntityFrameworkEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkolaContext context = new SkolaContext();
            do
            {
                Console.WriteLine("Main Menu\nChoose by entering a number:\n1)View names");
                Console.WriteLine("2)View class  \n3)Add to staff  ");

                string val = Console.ReadLine();
                if (val == "1")
                {
                    ViewName(context);
                }
                else if (val == "2")
                {
                    ViewClass(context);
                }
                else if (val == "3")
                {
                    AddtoStaff(context);
                }
                else
                {
                    Console.WriteLine("You can only enter a numberin the menu");
                }

            } while (true == true);

        }
        public static void ViewName(SkolaContext context)
        {
            string nameview = " ";
            Console.WriteLine("View Students");
            Console.WriteLine("Choose order to see students, enter a number:");
            Console.WriteLine("1)First name ascending\n2)First name descending");
            Console.WriteLine("3)Last name ascending\n4)Last name descending");
            nameview = Console.ReadLine();

            if (nameview == "1")
            {
                var stud = context.Students
                .OrderBy(p => p.StudentName);
                foreach (Student item in stud)
                {
                    Console.WriteLine($"First name: {item.StudentName}");
                    Console.WriteLine($"Last name: {item.StudentLastName}");
                    Console.WriteLine($"class: {item.Class}");
                }
            }
            else if (nameview == "2")
            {
                var stud = context.Students
                .OrderByDescending(p => p.StudentName);
                foreach (Student item in stud)
                {
                    Console.WriteLine($"First name: {item.StudentName}");
                    Console.WriteLine($"Last name: {item.StudentLastName}");
                    Console.WriteLine($"class: {item.Class}\n");
                }
            }
            else if (nameview == "3")
            {
                var stud = context.Students
                .OrderBy(p => p.StudentLastName);
                foreach (Student item in stud)
                {
                    Console.WriteLine($"First name: {item.StudentName}");
                    Console.WriteLine($"Last name: {item.StudentLastName}");
                    Console.WriteLine($"class: {item.Class}\n");
                }
            }
            else if (nameview == "4")
            {
                var stud = context.Students
                .OrderByDescending(p => p.StudentLastName);
                foreach (Student item in stud)
                {
                    Console.WriteLine($"First name: {item.StudentName}");
                    Console.WriteLine($"Last name: {item.StudentLastName}");
                    Console.WriteLine($"class: {item.Class}\n");
                }
            }
            else
            {
                Console.WriteLine("You can only enter 1-4");
            }
        }
        public static void ViewClass(SkolaContext context)
        {
            bool sant = true;
            do
            {
                Console.WriteLine("Our school´s classes:");
                var stud = context.Students
                    .OrderBy(p => p.Class);
                List<string> koll = new List<string>();
                foreach (Student item in stud)
                {
                    if (koll.Contains(item.Class)) { }
                    else
                    {
                        Console.WriteLine($"Class: {item.Class}");
                        koll.Add(item.Class);
                    }
                }
                string classchoice = " ";
                Console.WriteLine("Enter class to see students");
                classchoice = Console.ReadLine().ToUpper();

                var sss = context.Students
                   .OrderBy(p => p.StudentLastName).Where(p => p.Class == classchoice);
                foreach (Student item in sss)
                {
                    Console.WriteLine($"First name: {item.StudentName}");
                    Console.WriteLine($"Last name: {item.StudentLastName}");
                    Console.WriteLine($"Class: {item.Class}\n");
                }

                if (!koll.Contains(classchoice))
                {
                    Console.WriteLine("\nPlease enter a valid class\n");
                }
                else
                {
                    sant = false;
                }

            } while (sant == true);

        }
        public static void AddtoStaff(SkolaContext context)
        {
            Console.WriteLine("You have chosen to add to staff");
            bool yes = true;
            string enteredname = " ";
            do
            {
                Console.WriteLine("Enter first name:");
                enteredname = Console.ReadLine();
                Console.WriteLine("You have entered:\n" + enteredname);
                Console.WriteLine("Are you sure {0} is correct?\nWrite 'Yes'/'No'", enteredname);
                string svar = Console.ReadLine().ToLower();
                if (svar == "yes")
                {
                    yes = false;
                }
                else if (svar == "no")
                {
                    yes = true;
                }
                else
                {
                    Console.WriteLine("Please enter only a simple 'Yes' or 'No'");
                }
            } while (yes == true);
            bool po = true;
            string job = " ";
            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Choose profession");
                Console.WriteLine("1)Teacher\n2)Administrator\n3)Principal");
                string prof = Console.ReadLine().ToLower();
                switch (prof)
                {
                    case "1":
                        job = "Teacher";
                        break;
                    case "2":
                        job = "Administrator";
                        break
                            ;
                    case "3":
                        job = "Principal";
                        break;
                    default:
                        Console.WriteLine("You can only enter 1,2 or 3");
                        break;
                }

                Console.WriteLine("Are you sure {0} is correct?\nWrite 'Yes'/'No'", job);
                string svar = Console.ReadLine().ToLower();
                if (svar == "yes")
                {
                    po = false;
                }
                else if (svar == "no")
                {
                    po = true;
                }
                else
                {
                    Console.WriteLine("Please enter only a simple 'Yes' or 'No'");
                }

            } while (po == true);

            staff peson = new staff()
            {
                StaffName = enteredname,
                StaffRole = job
            };
            context.staff.Add(peson);
            context.SaveChanges();

            Console.WriteLine("{0} is entered as a {1} in the register",enteredname,job);
        }
    }
}