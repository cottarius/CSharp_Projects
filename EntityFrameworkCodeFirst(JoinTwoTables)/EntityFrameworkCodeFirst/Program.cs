﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    internal class Program
    {
        public static void GetEmployee()
        {
            using (Bank db = new Bank())
            {
                foreach (EMPLOYEE empl in db.EMPLOYEE)
                {
                    Console.WriteLine($"{empl.EMP_ID,-5}{empl.FIRST_NAME,-15}{empl.LAST_NAME,-15}{empl.START_DATE.ToShortDateString(),-15}" +
                        $"{empl.TITLE,-15}");
                }
            }
        }
        public static void GetBranch()
        {
            using (Bank db = new Bank())
            {
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
                var list = db.EMPLOYEE.Join(db.BRANCH, x => x.ASSIGNED_BRANCH_ID, y => y.BRANCH_ID, (x, y)  => new
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

                foreach(var l in list)
                {
                    Console.WriteLine($"{l.EmpId,-5}{l.EmpFirstName,-15}{l.EmpLastName,-15}" +
                        $"{l.EmpTitle,-25}{l.BranchName,-15}{l.BranchCity,-15}");
                }                
            }
        }
        static void Main(string[] args)
        {
            GetBranch();
            Console.WriteLine();
            GetEmployee();
            Console.WriteLine();
            GetEmployeeWithBranch();
            Console.ReadKey();
        }
    }
}