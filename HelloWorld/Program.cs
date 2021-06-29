using System;
using System.IO;
using System.Collections.Generic;

namespace HelloWorld
{
    public class FullName : IComparable
    {
        private String surName;
        private String fullName;
        public FullName(String name)
        {
            fullName = name;
            string[] words = name.Split(' ');
            surName = words[words.Length - 1];
        }
        public String GetName()
        {
            return fullName;
        }
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;
            FullName otherName = (FullName)obj;
            return String.Compare(this.surName, otherName.surName);
        }
    }
    class NameSorter {
        private List<FullName> names;
        public NameSorter(String fileName)
        {
            names = new List<FullName>();
            StreamReader reader = new StreamReader(fileName);
            String name;
            while ((name = reader.ReadLine()) != null)
            {

                names.Add(new FullName(name));
            }
        }
        public void SortNames()
        {
            names.Sort();
        }
        public void PrintNames()
        {
            foreach (FullName name in names)
                Console.WriteLine(name.GetName());
        }
        public void PrintNamestoFile()
        {
            StreamWriter writer = new StreamWriter("sorted-names.txt");
           foreach (FullName name in names)
            {
                writer.WriteLine(name.GetName());
            }             
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String file = args[0];
            if (File.Exists(file))
            {
                NameSorter sorter = new NameSorter(file);
                sorter.SortNames();
                sorter.PrintNames();
                sorter.PrintNamestoFile();
            }
            else
            {
                Console.WriteLine("File does not exist in the current directory!");
            }
        }
    }
}
