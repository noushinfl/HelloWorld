using System;
using System.Linq;
using System.IO;

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
        public bool IsValidName()
        {
            string[] words = fullName.Split(' ');
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
        private FullName [] names;
        public NameListSorter(FullName [] names)
        {
            this.names = names;
        }
        public void SortNames() 
        {
            if (!(this.IsValidList()))
             {
                throw new Exception("This file contains invalid names," +
                                     "a valid name comprises of a surname and 1 to 3 given names "); 
            }
            Array.Sort(names);
            this.PrintNames();
            this.PrintNamestoFile();
        }
        public void PrintNames()
        {
            foreach (FullName name in names)
                Console.WriteLine(name.GetName());
        }
        public void PrintNamestoFile()
        {
            StreamWriter writer = new StreamWriter("sorted-names-list.txt");
            foreach (FullName name in names)
            {
                writer.WriteLine(name.GetName());
            }
            writer.Close();
        }
        public bool IsValidList()
        {
            foreach(FullName name in names)
            {
                if (!( name.IsValidName()))
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
           if(args.Length == 0)
            {
                Console.WriteLine("Missing File Name in the arguments");
                return;
            }
            String file = args[0];
            if (File.Exists(file))
            {
                FullName [] names =
                    File.ReadAllLines(file)
                        .Select(line => new FullName(line)).ToArray();
                    NameListSorter sorter = new NameListSorter(names);
                try
                {
                    sorter.SortNames();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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
