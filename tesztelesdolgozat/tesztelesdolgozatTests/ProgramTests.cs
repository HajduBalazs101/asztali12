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
            double eredmeny = Program.Atlagx3(tomb);
            double elvart = 12;
            Assert.AreEqual(elvart, eredmeny);
        }
        [TestMethod()]
        public void NegativSzamlalasTest()
        {
            int[] tomb = { 150, 200, 75, 90, 120, 45 };
            int eredmeny = Program.NagyobbmintszazSzamlalas(tomb);
            int elvart = 3;
            Assert.AreEqual(elvart, eredmeny);
        }
        [TestMethod()]
        public void OszthatonegyTest()
        {
            int[] tomb = { 2, 4, 6, 8, 10, -5};
            bool eredmeny = Program.vane5teloszthatopoz(tomb);
            Assert.IsTrue(eredmeny);
        }
        [TestMethod()]
        public void HetesTest()
        {
            int[] tomb = { 7, 14, 21, 28, 160, 35, 42, 30};
            List<int> eredmeny = Program.tizes(tomb);
            List<int> elvart = new List<int>() { 160, 30 };
            CollectionAssert.AreEqual(elvart, eredmeny);
        }
    }
}