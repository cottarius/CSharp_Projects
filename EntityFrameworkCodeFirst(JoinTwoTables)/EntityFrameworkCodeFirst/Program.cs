using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    internal class Program
    {
        static int stateMenu;
                
        static void Main(string[] args)
        {
            Console.Clear();
            Menu();

            while(stateMenu != 0)
            {
                switch(stateMenu)
                {
                    case 1:
                        {
                            Console.Clear();
                            InfoMenu();

                            if(stateMenu > 4 || stateMenu < 0)
                            {
                                return;
                            }
                            switch(stateMenu)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        GetEmployee();
                                    }
                                    Console.ReadKey();
                                    Console.Clear();                                    
                                    break;

                                case 2:
                                    {
                                        Console.Clear();
                                        GetBranch();
                                    }
                                    Console.ReadKey();
                                    Console.Clear();                                    
                                    break;

                                case 3:
                                    {
                                        Console.Clear();
                                        FullStatistic();
                                    }
                                    Console.ReadKey();
                                    Console.Clear();                                    
                                    break;

                                case 4:
                                    {
                                        Console.Clear();
                                        Menu();
                                    }                                    
                                    break;

                            }

                        }
                        break;
                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine("**********Menu**********");
            Console.WriteLine("1. Info");
            Console.WriteLine("0. Exit");
            Console.Write("Input number: ");
            while(!Int32.TryParse(Console.ReadLine(), out stateMenu))
            {
                Console.Write("Incorrect number!");
            }
            if(stateMenu > 1 || stateMenu < 0)
            {
                Console.WriteLine("Incorrect number!");
                return;
            }
        }
        public static void InfoMenu()
        {
            Console.WriteLine("********Info Menu********");
            Console.WriteLine("1. List of Employees");
            Console.WriteLine("2. List of Branches");
            Console.WriteLine("3. Full List");
            Console.WriteLine("4. Back");
            Console.Write("Enter your choice: ");

            while (!Int32.TryParse(Console.ReadLine(), out stateMenu))
            {
                Console.WriteLine("Incorrect number!");
            }
        }
        public static void GetEmployee()
        {
            using (Bank db = new Bank())
            {
                Console.WriteLine("{0, -5}{1, -15}{2,-15}{3,-15}{4,-15}", "Id", "First Name", 
                    "Last Name", "Start Date", "Title");
                Console.WriteLine("----------------------------------------------------------" +
                    "-----------------");
                foreach (EMPLOYEE empl in db.EMPLOYEE)
                {
                    Console.WriteLine($"{empl.EMP_ID,-5}{empl.FIRST_NAME,-15}{empl.LAST_NAME,-15}" +
                        $"{empl.START_DATE.ToShortDateString(),-15}{empl.TITLE,-15}");
                }
            }
        }
        public static void GetBranch()
        {
            using (Bank db = new Bank())
            {
                Console.WriteLine("{0,-5}{1,-25}{2,-15}{3,-15}{4,-15}{5,-10}", "Id","Address","City","Name", "State", "Zip Code");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                foreach (BRANCH br in db.BRANCH)
                {
                    Console.WriteLine($"{br.BRANCH_ID,-5}{br.ADDRESS,-25}{br.CITY,-15}{br.NAME,-15}" +
                        $"{br.STATE,-15}{br.ZIP_CODE}");
                }
            }
        }
        public static void GetEmployeeWithBranch()
        {
            using (Bank db = new Bank())
            {
                var list = db.EMPLOYEE.Join(db.BRANCH, x => x.ASSIGNED_BRANCH_ID, y => y.BRANCH_ID, (x, y) => new
                {
                    EmpId = x.EMP_ID,
                    EmpFirstName = x.FIRST_NAME,
                    EmpLastName = x.LAST_NAME,
                    EmpStartDate = x.START_DATE,
                    EmpTitle = x.TITLE,
                    BranchName = y.NAME,
                    BranchCity = y.CITY,
                    BranchAdress = y.ADDRESS
                });

                foreach (var l in list)
                {
                    Console.WriteLine($"{l.EmpId,-5}{l.EmpFirstName,-15}{l.EmpLastName,-15}" +
                        $"{l.EmpTitle,-25}{l.BranchName,-15}{l.BranchCity,-15}");
                }
            }
        }
        public static void FullStatistic()
        {
            using (Bank db = new Bank())
            {
                var list = db.BRANCH
                    .Join(db.EMPLOYEE, b => b.BRANCH_ID, e => e.ASSIGNED_BRANCH_ID, (b, e) => new { e, b })
                    .Join(db.DEPARTMENT, ee => ee.e.DEPT_ID, d => d.DEPT_ID, (ee, d) => new
                    {
                        EmpFirstName = ee.e.FIRST_NAME,
                        EmpLastName = ee.e.LAST_NAME,
                        EmpTitle = ee.e.TITLE,
                        Dept = d.NAME,
                        BranchName = ee.b.NAME,
                        BranchCity = ee.b.CITY
                    });
                Console.WriteLine("{0,-15}{1,-15}{2,-22}{3,-17}{4,-15}{5,-15}", "First Name", "Last Name",
                    "Title", "Department", "Branch", "City");
                Console.WriteLine("------------------------------------------------------------------------" +
                    "---------------------");
                foreach (var l in list)
                {
                    Console.WriteLine($"{l.EmpFirstName,-15}{l.EmpLastName,-15}{l.EmpTitle,-22}{l.Dept,-17}" +
                        $"{l.BranchName,-15}{l.BranchCity,-15}");
                }
            }
        }
    }
}
