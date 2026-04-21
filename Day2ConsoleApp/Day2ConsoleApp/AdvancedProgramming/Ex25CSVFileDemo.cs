//Code file is an empty C# file on which no boiler plate code is provided. 
//CSV file means Comma seperated value files where data is stored line based and each section seperated by , .Use other delimiters if required
using System.Collections.Generic;
using System.IO;
using System;

namespace AdvancedProgramming
{

    //Entity Layer
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<int> Marks { get; set; } = new List<int>();
    }

    //Data Layer
    class StudentRepo
    {
        private static string fileName = "Students.csv";
        public void AddStudent(Student student)
        {
            var strContent = $"{student.StudentId}, {student.StudentName}, ";
            foreach(var score in student.Marks)
            {
                strContent += $"{score}," ;
            }
            strContent.TrimEnd(',');
            strContent += "\n";
            File.AppendAllText(fileName, strContent);
            //Convert the student object to a string representation each property value seperated by comma.
            //saves the data to a CSV file.
            Logger.Information("Student details are saved");
        }

        public void UpdateStudent(Student student)
        {
            //Extracts the student info
            //Modifes the selected student
            //updates it to the file.
        }

        public void DeleteStudent(int studentId)
        {
            //Extract the student
            //Remove the student
            //Update the file
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            var lines = File.ReadAllLines(fileName);
            foreach(var line in lines)
            {
                var words = line.Split(',');
                Student student = new Student();
                student.StudentId = int.Parse(words[0]);
                student.StudentName = words[1];
                student.Marks = new List<int>();
                for(int i = 2; i < words.Length; i++)
                {
                    student.Marks.Add(int.Parse(words[i]));
                }
                students.Add(student);
            }
            return students;
        }

    }

    //UI Layer
    class MainProgram
    {
        static void Main(string[] args)
        {
            //todo: create a menu driven program and display the menu and process it.
            var repo = new StudentRepo();
            //repo.AddStudent(new Student { StudentId = 111, StudentName ="Phaniraj", Marks = new List<int> { 45,46,41 } });

            var data = repo.GetStudents();
            foreach(var student in data)
            {
                Console.WriteLine(student.StudentName);
                Console.WriteLine("Marks list:");
                foreach(var mark in student.Marks)
                {
                    Console.WriteLine($"\t{mark}");
                }
            }
        }
    }
}