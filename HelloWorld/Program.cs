using System;
using System.IO;
using System.Collections.Generic;

namespace HelloWorld
{
    /* Class FullName
     * Separates FullName to First name , Middle Names and a Surname
     * Overrides CompareTo method to compare full names based on Surnames first
    */
    public class FullName : IComparable
    {
        private String surName;
        private String fullName;
        private String givenName;
        public static bool IsValidName(String name)
        {
            string[] words = name.Split(' ');
            if (words.Length < 2) return false;
            if (words.Length > 4) return false;
            return true;
        }
        public FullName(String name)
        {
            fullName = name;
            string[] words = name.Split(' ');
            surName = words[words.Length - 1];
            surName.ToUpper();
            surName.Trim();
            foreach(String w in words)
               givenName = String.Concat(givenName,w);
            givenName.ToUpper();
        }
        public String GetName()
        {
            return fullName;
        }
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;
            FullName otherName = (FullName)obj;
            int surNameCompare;
            if((surNameCompare = String.Compare(this.surName, otherName.surName)) != 0 )
                return surNameCompare;
            return String.Compare(this.givenName, otherName.givenName);
        }
    }
    class NameListSorter {
        private List<FullName> names;
        public NameListSorter(String fileName)
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
            writer.Close();
        }
        public static bool IsValidList(String fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            String name;
            while ((name = reader.ReadLine()) != null)
            {
                if (!( FullName.IsValidName(name)))
                {
                    Console.WriteLine(name);
                    return false;
                }

            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String file = args[0];
            if (File.Exists(file))
            {
                if (!(NameListSorter.IsValidList(file)))
                {
                   Console.WriteLine("This is not a valid Name list file") ;
                }
                else {
                    NameListSorter sorter = new NameListSorter(file);
                    sorter.SortNames();
                    sorter.PrintNames();
                    sorter.PrintNamestoFile();
                }
            }
            else
            {
                Console.WriteLine("File does not exist in the current directory!");
                Console.WriteLine("Current Direcotry is :" + Path.GetFullPath("."));
            }
        }
    }
}
