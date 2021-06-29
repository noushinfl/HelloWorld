using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Tests
{
    [TestClass()]
    public class FullNameTests
    {
        [TestMethod()]
        public void blank_Name_Not_Valid()
        {
            Assert.AreEqual((new FullName("")).IsValidName(), false);

        }

        [TestMethod()]
        public void one_Word_Name_Not_Valid()
        {
            Assert.AreEqual((new FullName("Nooshin")).IsValidName(), false);
        }

        [TestMethod()]
        public void three_Word_Name_is_Valid()
        {
            Assert.AreEqual((new FullName("Nooshin Fallahpour Sichani")).IsValidName(), true);
        }
        [TestMethod()]
        public void two_Word_Name_is_Valid()
        {
            Assert.AreEqual((new FullName("Nooshin Sichani")).IsValidName(), true);
        }

        [TestMethod()]
        public void four_Word_Name_is_Valid()
        {
            Assert.AreEqual((new FullName("Nooshin Fallahpour Sichani Yazdi")).IsValidName(), true);
        }

        [TestMethod()]
        public void five_Word_Name_Not_Valid()
        {
            Assert.AreEqual((new FullName("Nooshin Fallahpour Sichani Yazdi Asl")).IsValidName(), false);
        }
        [TestMethod()]
        public void Jane_Doe_is_exact_match_for_Jane_Doe()
        {
            Assert.AreEqual((new FullName("Jane Doe"))
                .CompareTo((new FullName("Jane Doe"))), 0);
        }
        [TestMethod()]
        public void John_Doe_is_after_Jane_Doe()
        {
            Assert.AreEqual((new FullName("John Doe"))
                .CompareTo((new FullName("Jane Doe"))), 1);
        }
    }
}