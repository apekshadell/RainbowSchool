//using System;
//using System.IO;

//namespace RainbowSchool
//{
//    class Teacher
//    {
//        int Id { get; set; }
//        string Name { get; set; }
//        int Class { get; set; }
//        char Section { get; set; }
//        public void input()
//        {
//            Console.WriteLine("Enter Teacher's ID");

//            Console.WriteLine("Enter Teacher's Name");

//            Console.WriteLine("Enter Teacher's Class");

//            Console.WriteLine("Enter Teacher's Section");

//        }
//        public void output()
//        {

//        }
//    }
//    class FileHandeling
//    {
//        public static void openFile(string fileName, string mode)
//        {
//            //      string filename =  "c:\\Teacher.txt";


//            if (mode == "write")
//            {
//                if (!File.Exists(fileName))
//                {
//                    Console.WriteLine(fileName + " exists");
//                    using (StreamWriter wrt = File.CreateText(fileName))
//                    {

//                    }
//                }
//                else
//                {
//                    using (StreamWriter wrt = File.AppendText(fileName))
//                    {

//                    }
//                }
//            }
//            else if (mode == "read")
//            {
//                if (File.Exists(fileName))
//                {

//                    using (StreamReader wrt = File.OpenText(fileName))
//                    {

//                    }

//                }
//                else
//                    Console.WriteLine(fileName + " does not exist");
//            }

//        }
//        class School
//        {
//            static void Main(string[] args)
//            {
//                Console.WriteLine("Hello World!");
//            }
//        }
//    }
//}