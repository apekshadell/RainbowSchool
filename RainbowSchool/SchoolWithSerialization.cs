using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RainbowSchool
{

 [Serializable]
   public class Teacher
    {
       public int Id { get; set; }
        string Name { get; set; }
        int Class { get; set; }
        char Section { get; set; }
        public void input()
        {

            Console.WriteLine("Enter Teacher's ID");
            Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Teacher's Name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Teacher's Class");
            Class = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Teacher's Section");
            Section = char.Parse(Console.ReadLine());
        }
        public void output()
        {
            Console.WriteLine("Teacher's ID : {0}",Id);
            Console.WriteLine("Teacher's Name : {0}", Name);
            Console.WriteLine("Teacher's Class : {0}", Class);
            Console.WriteLine("Teacher's Section : {0}", Section);

        }
    }
    class FileHandeling
    {
        Stream stream;
        public void openFile(string fileName, string mode)
        {
          if (mode == "write")
            {
                if (!File.Exists(fileName))
                {
                    stream = new FileStream(fileName, FileMode.Create, FileAccess.Write); ;
                }
                else
                {
                    stream = new FileStream(fileName, FileMode.Append, FileAccess.Write); ;
                }
            }
            else if (mode == "read")
            {
                if (File.Exists(fileName))
                {

                    stream = new FileStream(fileName, FileMode.Open, FileAccess.Read); ;
                }
                else
                    Console.WriteLine(fileName + " does not exist");
            }
            else if (mode == "modify")
            {
                if (File.Exists(fileName))
                {

                    stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite); ;
                }
                else
                    Console.WriteLine(fileName + " does not exist");
            }
            else
                Console.WriteLine("Incorrect Mode");
        }
        public void CloseFile()
        {
            stream.Close();
        }
        public void Write(Teacher teacher)
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, teacher);
                Console.WriteLine("Object Written To file");
        }

        public void Read()
        {
            Teacher T = null;
            IFormatter formatter = new BinaryFormatter();
            while(stream.Length> stream.Position)
            {
                T = (Teacher)formatter.Deserialize(stream);
                T.output();

            }
            Console.WriteLine("Object readng from file");
        }
        public Teacher Search(int id)
        {
            Teacher T = null;
            IFormatter formatter = new BinaryFormatter();
            while (stream.Length > stream.Position)
            {
                T = (Teacher)formatter.Deserialize(stream);
                if (T.Id == id)
                    return T;
            } 
            return null;
        }
        public void Modify(int id)
        {
            Teacher T = null;
            IFormatter formatter = new BinaryFormatter();
            while (stream.Length > stream.Position)
            {
                long pos = stream.Position;
                T = (Teacher)formatter.Deserialize(stream);
                if (T.Id == id)
                {
                    T.input();
                    stream.Seek(pos,0);
                    Write(T);
                    break;
                }
            }
        }
    }
        class School
        {
            static void Main(string[] args)
            {
            char ans = 'y';
            int choice;
            Teacher teacher = new Teacher();
            FileHandeling file = new FileHandeling();

            do
            {
                Console.WriteLine("****Teacher Menu****");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Search");
                Console.WriteLine("3. Modify");
                Console.WriteLine("4. Read All");
                Console.WriteLine("Enter your choice");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        file.openFile("C:\\FSD\\new.txt", "write");
                        teacher.input();
                        file.Write(teacher);
                        file.CloseFile();
                        break;
                    case 2:
                        Console.WriteLine("Enter Teacher Id to search");
                        int id = int.Parse(Console.ReadLine());
                        file.openFile("C:\\FSD\\new.txt", "read");
                       Teacher T= file.Search(id);
                        if (T == null)
                            Console.WriteLine("ID not found");
                        else
                            T.output();
                        file.CloseFile();
                        break;
                    case 3:
                        Console.WriteLine("Enter Teacher Id to search");
                         id = int.Parse(Console.ReadLine());
                        file.openFile("C:\\FSD\\new.txt", "modify");
                       // teacher.input();
                        file.Modify(id);
                        file.CloseFile();

                        break;
                    case 4: file.openFile("C:\\FSD\\new.txt", "read");
                        file.Read();
                        file.CloseFile();
                        break;
                    default: Console.WriteLine("Wrong Choice");
                             break;
                }
                Console.WriteLine("Do you Want to continue(y/n)");
                ans = char.Parse(Console.ReadLine());

            } while (ans=='y');

            }
        }
    }
