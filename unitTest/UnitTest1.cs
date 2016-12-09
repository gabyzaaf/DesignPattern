using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MouseTools;

namespace unitTest
{
    [TestClass]
    public class UnitTest1
    {
        ConfigurationManager configuration = new MouseConfiguration();
        [TestMethod]
        public void ShouldVerifyConfigFileNotNull()
        {
            Assert.AreNotEqual(configuration.GetDicoSize(), 0);
        }

        [TestMethod]
        public void ShouldGetLogFile()
        {
            Assert.IsNotNull(configuration.GetLog());
            
        }

        [TestMethod]
        public void ShouldGetArrays()
        {
           string[] arr  = configuration.GetArray();
           int line = arr.GetLength(0);
           Assert.IsNotNull(arr);
           
        }

        [TestMethod]
        public void shouldInstanciatedNode()
        {
            Node node = new Node(3,5,'t');
            Assert.IsNotNull(node.successor);
        }

        [TestMethod]
        public void shouldCreateTheNodeIn2Dimension()
        {
           Node[,] nodes =  configuration.GetNodeArray();
            Assert.IsNotNull(nodes);
           Assert.AreEqual(nodes.GetLength(0), 4);
           Assert.AreEqual(nodes.GetLength(1), 10);
        }



    }
}
