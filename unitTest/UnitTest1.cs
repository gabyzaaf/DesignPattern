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
        public void ShouldInstanciatedNode()
        {
            Node node = new Node(3,5,'t');
            Assert.IsNotNull(node.successor);
        }

        [TestMethod]
        public void ShouldCreateTheNodeIn2DimensionWithControl()
        {
           Node[,] nodes =  configuration.GetNodeArray();
            Assert.IsNotNull(nodes);
           Assert.AreEqual(nodes.GetLength(0), 4);
           //Assert.AreEqual(nodes.GetLength(1), 10);
        }

        [TestMethod]
        public void ShouldCreateConfigurationFactory()
        {
            ConfigurationManager configuration = Wrapper.GetConfiguration("mouse");
            Assert.IsNotNull(configuration);
            Node[,] nodeArray = configuration.GetNodeArray();
            Assert.IsNotNull(nodeArray);
           // Assert.AreEqual(nodeArray.GetLength(0), 4);
           // Assert.AreEqual(nodeArray.GetLength(1), 10);
        }

   

        [TestMethod]
        public void ShouldReturnRootPosition()
        {
            ConfigurationManager configuration = Wrapper.GetConfiguration("mouse");
            Assert.IsNotNull(configuration);
            Node[,] nodeArray = configuration.GetNodeArray();
            ToolsTree tools = new ToolsTree(nodeArray);
            Tuple<int, int> tuple = tools.GetRootPosition();
            Assert.IsNotNull(tuple);
            Assert.AreNotEqual(tuple.Item1, 0);
            Assert.AreNotEqual(tuple.Item2, 0);
        }


    }
}
