using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Models
{
    internal class Question
    {
        static int _questionId = 0;

        public int Id { get; }

        public Question(string questionText, List<Variant> variants)
        {
            Id = ++_questionId;
            QuestionText = questionText;
            Variants = variants;
        }

        public string QuestionText { get; set; }

        public List<Variant> Variants { get; set; }



    }
}
