using ConsoleApp18.Exceptions;
using ConsoleApp20.Models;
using System.Text.RegularExpressions;
using System.Text;

namespace ConsoleApp20
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Quiz> Quizzes= new List<Quiz>();
            //List<Variant> Variants = new List<Variant>();
            Menu(ref Quizzes);
            //Variant v1 = new("asjd", true);
            //Variant v2 = new("asjd", true);
            //Variant v3 = new("asd", true);
            //Variant v4 = new("asjd", true);
            //Variants.Add(v1);
            //Variants.Add(v2);
            //Variants.Add(v3);
            //Variants.Add(v4);
            //Question q = new("asd",Variants);
            //q.ShowQuestion();
        }
        public static void Menu(ref List<Quiz> Quizzes)
        {
            Console.Clear();
            Console.WriteLine($@"
==========================
          Start
==========================

[1] Create new quiz
[2] Solve a quiz
[3] Show quizzes
[0] Exit
");
            Console.Write(">>>");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                choice++;
                Choose(choice, ref Quizzes);
            }
            else Menu(ref Quizzes);
        }
        public static void Choose(int choice, ref List<Quiz> Quizzes)
        {
            switch(choice)
            {
                case 1:
                    Console.WriteLine("#SeeYouAgain");
                    break;

                case 2:

                    try
                    {
                        Console.WriteLine("Enter Quiz name:");
                        Console.Write(">>> ");
                        string quizname = Console.ReadLine();

                        if(string.IsNullOrWhiteSpace(quizname))
                        {
                            throw new WrongInputException("Input is wrong");
                        }

                        List<Question> Questions = new List<Question>();
                        Console.WriteLine("How many question do you want to add?");
                        Console.Write(">>> ");
                        if (int.TryParse(Console.ReadLine(), out int questioncount) && questioncount>0)
                        {
                            

                            for (int i = 0; i < questioncount; i++)
                            {
                                List<Variant> variants = new List<Variant>();
                                Console.Write($"Question {i+1}: ");
                                string questionName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(questionName))
                                {
                                    throw new WrongInputException("Wrong Question");
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    
                                    Console.Write($"Variant {j + 1}: ");
                                    string variantName = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(variantName))
                                    {
                                        throw new WrongInputException("Variant's format is wrong");
                                    }

                                    Variant variant = new Variant(variantName, false);
                                    variants.Add(variant);
                                }

                                Question question = new(questionName, variants);
                                Questions.Add(question);

                                Console.WriteLine("Which variant is true?(Enter Id)");
                                if (!int.TryParse(Console.ReadLine(), out int answerId) || answerId <= 0) throw new WrongInputException("Wrong input");
                                variants[answerId - 1].IsTrue = true;
                                Console.WriteLine("===================");
                            }
                        }
                        else throw new WrongInputException("Input is wrong");


                        Quiz quiz = new(quizname,questioncount,Questions);
                        Quizzes.Add(quiz);
                        Console.WriteLine("===================");
                        Console.WriteLine("Quiz created successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("===================");

                        Console.WriteLine("[Press Enter]");
                        Console.ReadLine();

                        Menu(ref Quizzes);
                    }

                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Menu(ref Quizzes);
                    break;


                case 3:
                    try
                    {
                        if (Quizzes.Count <= 0)
                        {
                            throw new WrongInputException("There is no quiz yet");
                        }
                        else
                        {
                            foreach (Quiz quiz in Quizzes)
                            {
                                Console.WriteLine(quiz);
                            }
                            Console.Write("Istediyiniz quizin id-i daxil edin: ");
                            if(!int.TryParse(Console.ReadLine(),out int quizId) || quizId<=0)
                            {
                                throw new WrongInputException("Wrong Quiz Id");
                            }
                            foreach (Quiz quiz in Quizzes)
                            {
                                if (quiz.QuizId == quizId)
                                {
                                    int result = 0;
                                    for (int i = 0; i < quiz.Questions.Count; i++)
                                    {
                                        Console.WriteLine($"{i+1}) {quiz.Questions[i].QuestionText}");
                                        Console.WriteLine();
                                        for (int j = 0; j < quiz.Questions[i].Variants.Count; j++)
                                        {
                                            Console.WriteLine($"{j+1}) {quiz.Questions[i].Variants[j]}");
                                        }


                                        Console.WriteLine("Your Answer:");
                                        if(!int.TryParse(Console.ReadLine(),out int answer) || answer <= 0 || answer>4)
                                        {
                                            throw new WrongInputException("Incorrect input");
                                        }
                                        if (quiz.Questions[i].Variants[answer-1].IsTrue==true)
                                        {
                                            Console.WriteLine("Correct");
                                            result++;                                                                                           
                                        }
                                        else if(quiz.Questions[i].Variants[answer-1].IsTrue == false) Console.WriteLine("False");

                                        Console.WriteLine();

                                    }
                                    Console.WriteLine("======================");
                                    Console.WriteLine("========Result========");
                                    Console.WriteLine("======================");
                                    Console.WriteLine($"{result}/{quiz.QuestionCount}");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Menu(ref Quizzes);
                    break;
                case 4:

                    try
                    {
                        if (Quizzes.Count <= 0)
                        {
                            throw new WrongInputException("There is no quiz yet");
                        }
                        else
                        {
                            foreach (Quiz quiz in Quizzes)
                            {
                                Console.WriteLine(quiz);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Menu(ref Quizzes);
                    break;
            }

            
        }

        public static string Format(string word)
        {
            word = word.Trim();

            word = char.ToUpper(word[0]) + word.Substring(1).ToLower();
            
            string[] wordarray = word.Split(' ');

            StringBuilder result = new StringBuilder();

            foreach (var item in wordarray)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    result.Append(item + ' ');
                }
            }
            return result.ToString();
        }
        public static bool Check(Variant variant)
        {
            return variant.IsTrue;
        }
    }
}