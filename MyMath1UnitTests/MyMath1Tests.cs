using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MyMathConsoleApp;

namespace MyMath1UnitTests
{
    [TestFixture]
    public class MyMath1Tests
    {
        [Test]
        public void Add_SumWithinByteRange_ReturnCorrectSum()
        {
            Assert.AreEqual(200, MyMathConsoleApp.MyMath1.Add(101, 99));
        }
        [Test]
        public void Add_SumOutsideByteRange_ReturnIncorrectSum()
        {
            Assert.AreEqual(302, MyMathConsoleApp.MyMath1.Add(101, 201));
        }
        [Test]
        public void Add_SumWithinByteRange_AlternateAssert()
        {
            Assert.That(MyMathConsoleApp.MyMath1.Add(101, 99), Is.EqualTo(200));
        }
        [Test]
        public void Add_SumOutsideByteRange_ThrowsException()
        {
            Assert.That(() => MyMathConsoleApp.MyMath1.Add(101, 201), Throws.Exception);
        }
    }
}
