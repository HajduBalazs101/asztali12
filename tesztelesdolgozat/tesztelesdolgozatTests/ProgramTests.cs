using Microsoft.VisualStudio.TestTools.UnitTesting;
using tesztelesdolgozat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesztelesdolgozat.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void Atlagx2Test()
        {
            int[] tomb = { 1, 2, 3, 4, 5 };
            double eredmeny = Program.Atlagx2(tomb);
            double elvart = 6;
            Assert.AreEqual(elvart, eredmeny);
        }
        [TestMethod()]
        public void NegativSzamlalasTest()
        {
            int[] tomb = { -1, 2, -3, 4, -5 };
            int eredmeny = Program.NegativSzamlalas(tomb);
            int elvart = 3;
            Assert.AreEqual(elvart, eredmeny);
        }
        [TestMethod()]
        public void OszthatonegyTest()
        {
            int[] tomb = { 4, 8, 15, 16, 23, 42 };
            bool eredmeny = Program.vane4gyeloszthato(tomb);
            Assert.IsTrue(eredmeny);
        }
        [TestMethod()]
        public void HetesTest()
        {
            int[] tomb = { 7, 14, 15, 22, 28, 33 };
            List<int> eredmeny = Program.hetes(tomb);
            List<int> elvart = new List<int> { 7, 14, 28 };
            CollectionAssert.AreEqual(elvart, eredmeny);
        }
    }
}