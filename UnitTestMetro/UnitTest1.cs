using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetroLib;
using MetroWPF;
using System.IO;
using System.Text;
using MetroWPF.Strategy;

namespace UnitTestMetro
{
    [TestClass]
    public class UnitTest1
    {

        string[] tabStations = File.ReadAllLines("stations.data", Encoding.Default);
        string[] tabLignes = File.ReadAllLines("lignes.data", Encoding.Default);
        public ManagerPlan Manager { get; set; }

        MetroCheckExistError mcExist = new MetroCheckExistError();
        MetroCheckEmptyError mcEmpty = new MetroCheckEmptyError();
        MetroDataSource mds = new MetroDataSource();

        [TestMethod]
        public void CheckLignesDataFileExist()
        {
            Assert.AreEqual("exist", mcExist.checkLigne());
        }

        [TestMethod]
        public void CheckStationsDataFileExist()
        {
            Assert.AreEqual("exist", mcExist.checkStation());
        }

        [TestMethod]
        public void CheckLignesDataFileNoEmpty()
        {
            Assert.AreEqual("noEmpty", mcEmpty.checkLigne());
        }

        [TestMethod]
        public void CheckStationsDataFileNoEmpty()
        {
            Assert.AreEqual("noEmpty", mcEmpty.checkStation());
        }

        [TestMethod]
        public void CheckNameLigneIsNotNull()
        {
            Assert.IsNotNull(mds.nomFichierLignes);
        }

        [TestMethod]
        public void CheckNameStationIsNotNull()
        {
            Assert.IsNotNull(mds.nomFichierStations);
        }

        [TestMethod]
        public void CheckSourceLigneIsNotNull()
        {
            Assert.IsNotNull(mds.sourceLignes);
        }

        [TestMethod]
        public void CheckSourceStationIsNotNull()
        {
            Assert.IsNotNull(mds.sourceStation);
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
