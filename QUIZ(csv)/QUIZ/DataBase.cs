using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ
{
    public class DataBase
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }

        public DataBase(string question, string answer) 
        {
            Question = question;
            Answer = answer;
        }
        public DataBase() { }

        public override string ToString()
        {
            return $"{Question} - {Answer}";
        }
    }
}
