using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetroLib;
using System.IO;
using System.Text;


namespace UnitTestMetro
{
    [TestClass]
    public class UnitTest1
    {
        string[] tabStations = File.ReadAllLines("stations.data", Encoding.Default);
        string[] tabLignes = File.ReadAllLines("lignes.data", Encoding.Default);
        public ManagerPlan Manager { get; set; }
        

        [TestMethod]
        public void CheckNameGraphIsNotNull()
        {
            DataSourceElement eml = new DataSourceElement();
            Assert.IsNotNull(eml.Name);
        }

        [TestMethod]
        public void CheckStationDataIsNotNull()
        {
            Assert.IsNotNull(tabStations);
        }

        [TestMethod]
        public void CheckLigneDataIsNotNull()
        {
            Assert.IsNotNull(tabLignes);
        }

        [TestMethod]
        public void CheckNombredeLignesAreNotEqualZero()
        {
            Manager = new ManagerPlan("Plan Métro Parisien", tabStations, tabLignes);
            Assert.AreNotEqual(0,Manager.NombredeLignes);
        }

        [TestMethod]
        public void CheckNombredeStationsAreNotEqualZero()
        {
            Manager = new ManagerPlan("Plan Métro Parisien", tabStations, tabLignes);
            Assert.AreNotEqual(0, Manager.NombredeStations);
        }

        [TestMethod]
        public void CheckNombredeTunnelsAreNotEqualZero()
        {
            Manager = new ManagerPlan("Plan Métro Parisien", tabStations, tabLignes);
            Assert.AreNotEqual(0, Manager.NombredeTunnels);
        }



    }
}
