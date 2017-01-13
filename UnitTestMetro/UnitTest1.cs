using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetroLib;
using MetroWPF;
using System.IO;
using System.Text;
using MetroWPF.Strategy;
using MetroLib.Factory;

namespace UnitTestMetro
{
    [TestClass]
    public class UnitTest1
    {

        MetroCheck mcheckEmpty = new MetroCheck(new MetroCheckEmptyError());
        MetroCheck mcheckExist = new MetroCheck(new MetroCheckExistError());

        public ManagerPlan Manager { get; set; }
        string[] tabStations = File.ReadAllLines(MetroDataSource.nomFichierStations(), Encoding.Default);
        string[] tabLignes = File.ReadAllLines(MetroDataSource.nomFichierLignes(), Encoding.Default);


        [TestMethod]
        public void CheckLignesDataFileExist()
        {
            Assert.AreEqual("exist", mcheckExist.checkLigne());
        }

        [TestMethod]
        public void CheckStationsDataFileExist()
        {
            Assert.AreEqual("exist", mcheckExist.checkStation());
        }

        [TestMethod]
        public void CheckLignesDataFileNoEmpty()
        {
            Assert.AreEqual("noEmpty", mcheckEmpty.checkLigne());
        }

        [TestMethod]
        public void CheckStationsDataFileNoEmpty()
        {
            Assert.AreEqual("noEmpty", mcheckEmpty.checkStation());
        }

        [TestMethod]
        public void CheckNameLigneIsNotNull()
        {
            Assert.IsNotNull(MetroDataSource.nomFichierLignes());
        }

        [TestMethod]
        public void CheckNameStationIsNotNull()
        {
            Assert.IsNotNull(MetroDataSource.nomFichierStations());
        }

        [TestMethod]
        public void CheckSourceLigneIsNotNull()
        {
            Assert.IsNotNull(MetroDataSource.sourceLignes());
        }

        [TestMethod]
        public void CheckSourceStationIsNotNull()
        {
            Assert.IsNotNull(MetroDataSource.sourceStation());
        }

        [TestMethod]
        public void CheckNombredeLignesAreNotEqualZero()
        {
            Manager = ManagerPlanFactory.createManager("Plan Métro Parisien", tabStations, tabLignes);
            Assert.AreNotEqual(0,Manager.NombredeLignes);
        }

        [TestMethod]
        public void CheckNombredeStationsAreNotEqualZero()
        {
            Manager = ManagerPlanFactory.createManager("Plan Métro Parisien", tabStations, tabLignes);
            Assert.AreNotEqual(0, Manager.NombredeStations);
        }

        [TestMethod]
        public void CheckNombredeTunnelsAreNotEqualZero()
        {
            Manager = ManagerPlanFactory.createManager("Plan Métro Parisien", tabStations, tabLignes);
            Assert.AreNotEqual(0, Manager.NombredeTunnels);
        }



    }
}
