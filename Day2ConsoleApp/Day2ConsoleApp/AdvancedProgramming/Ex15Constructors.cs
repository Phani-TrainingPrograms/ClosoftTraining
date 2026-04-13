using System;
using System.Security.Policy;

//Constructor is a sp function that is invoked (internally called by the .NET RUNTIME) when a new object is created in the program.
//It is typically used to set some values to the members of class instead of setting default values. Default values are set automatically in C#. 
//It has a sp signature: Constructor function shall have the name of the class. It does not have any return type. Not even void. It can have accessors: public, private, protected, internal...
//use ctor as short cut key to create Constructors. 

//If an object of the derived class is created, internally the object shall call the base class default constructor(With no args) and then calls its own constructor.
// if UR base class is parameterised, then if U want to explicitly call the specific constructor, then we use base keyword. base refers to immediate base class. 
namespace AdvancedProgramming
{
    internal class Ex15Constructors
    {
        static void Main(string[] args)
        {
            //Constructor is one but differenciated by the args U pass to it. This is called as COMPILE TIME POLYMORPHISM. 
            ////////////Example of using parameterized constructor//////////////////
            //Question question = new Question(1, "Who owns C# Programming language", "Open Source", "Sun Micro Systems", "Microsoft", "Oracle");
            //Console.WriteLine(question.QuestionDetails());

            ////////////Creating the derived class object and observe the constructor/////
            TechnicalQuestion q1 = new TechnicalQuestion(1, "Who owns C# Programming language", "Open Source", "Sun Micro Systems", "Microsoft", "Oracle", "C# Langauge");
            Console.WriteLine(q1.QuestionDetailwithTopic());
        }
    }

    class Question
    {
        protected int qId;
        protected string question, option1, option2, option3, option4;

        
        public Question()//U cannot have functions with the name of the class with return types. 
        {
            qId = 1;
            question = "No question is set";//It initializes the string to empty. 
            option1 = option2 = option3 = option4 = string.Empty;//not a good practise.
            Console.WriteLine("Default Base Question is set"); 
        }

        public Question(int qId, string question, string option1, string option2, string option3, string option4)
        {
            this.qId = qId;
            this.question = question;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
            this.option4 = option4;
            Console.WriteLine("Parameterized Question is set");
        }

        public string QuestionDetails()
        {
            if(question == "No question is set")
            {
                return "Question is not set"; //exiting the function...
            }
            return $"{qId}. {question}\na. {option1}\nb. {option2}\nc.{option3}\nd.{option4}.\n";
        }
    }

    class TechnicalQuestion : Question
    {
        protected string topic;
        public TechnicalQuestion(int qId, string question, string option1, string option2, string option3, string option4, string topic) 
                : base(qId, question, option1, option2, option3, option4)
        {
            this.topic = topic;
        }

        public string QuestionDetailwithTopic()
        {
            var oldFormat = this.QuestionDetails();
            var newFormat  = oldFormat + $"Topic: {topic}\n";
            return newFormat;
        }
        //Method overriding shall be used to allow your child classes to reimplement the function created by the base classes. 
    }
}
//LINTING Tools shall help in maintaining the coding stds and enforce them in UR code. FxCop can be used to enforce coding stds in UR code. Coverity can also be used.
