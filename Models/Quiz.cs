using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Models
{
    internal class Quiz
    {
        static int _quizId = 0;
        public int QuizId { get; }
        public string Name { get; set; }

        public int QuestionCount { get; set; }

        public List<Question> Questions { get; set; }

        public Quiz(string name, int questionCount, List<Question> questions)
        {
            QuizId = ++_quizId;
            Name = name;
            QuestionCount = questionCount;
            Questions = questions;
        }




        public override string ToString()
        {
            return $"Id: {QuizId}   |   Name: {Name}";
        }


    }
}
