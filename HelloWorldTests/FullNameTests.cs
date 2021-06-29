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
        public void BlankNameNotValid()
        {
            Assert.AreEqual((new FullName("")).IsValidName(), false);

        }

        [TestMethod()]
        public void OneWordNameNotValid()
        {
            Assert.AreEqual((new FullName("Nooshin")).IsValidName(), false);
        }

        [TestMethod()]
        public void ThreeWordNameisValid()
        {
            Assert.AreEqual((new FullName("Nooshin Fallahpour Sichani")).IsValidName(), true);
        }
        [TestMethod()]
        public void TwoWordNameisValid()
        {
            Assert.AreEqual((new FullName("Nooshin Sichani")).IsValidName(), true);
        }

        [TestMethod()]
        public void FourWordNameisValid()
        {
            Assert.AreEqual((new FullName("Nooshin Fallahpour Sichani Yazdi")).IsValidName(), true);
        }

        [TestMethod()]
        public void FiveWordNameNotValid()
        {
            Assert.AreEqual((new FullName("Nooshin Fallahpour Sichani Yazdi Asl")).IsValidName(), false);
        }
        [TestMethod()]
        public void CompareSameNames()
        {
            Assert.AreEqual((new FullName("Nooshin Sichani"))
                .CompareTo((new FullName("Nooshin Sichani"))), 0);
        }
        [TestMethod()]
        public void CompareSameSurNames()
        {
            Assert.AreEqual((new FullName("Nooshin Sichani"))
                .CompareTo((new FullName("Negar Sichani"))), 1);
        }
    }
}