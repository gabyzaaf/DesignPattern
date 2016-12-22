﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MouseTools;
using System.Collections.Generic;
using MouseTools.Strategy;
using MouseTools.Observor;
using MouseTools.Command;

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
        public void ShouldInstanciatedNode()
        {
            Node node = new Node(3,5,'t');
            Assert.IsNotNull(node.Successor);
        }

        [TestMethod]
        public void ShouldCreateTheNodeIn2DimensionWithControls()
        {
           Node[,] nodes =  configuration.GetNodeArray();
            Assert.IsNotNull(nodes);
           Assert.AreEqual(nodes.GetLength(0), 5);
           //Assert.AreEqual(nodes.GetLength(1), 10);
        }

        [TestMethod]
        public void ShouldCreateConfigurationFactory()
        {
            ConfigurationManager configuration = Wrapper.GetConfiguration("mouse");
            Assert.IsNotNull(configuration);
            Node[,] nodeArray = configuration.GetNodeArray();
            Assert.IsNotNull(nodeArray);
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
       
        [TestMethod]
        public void ShouldReturnRightNodeWithStrategyPattern()
        {
            ConfigurationManager configuration = Wrapper.GetConfiguration("mouse");
            Node[,] nodeArray = configuration.GetNodeArray();
            ToolsTree tools = new ToolsTree(nodeArray);
            Tuple<int,int> rootPosition =  tools.GetRootPosition();
            ChoiceNodeDirection choice = new ChoiceNodeDirection(new Right());
            Node node = choice.getNode(nodeArray, rootPosition.Item1, rootPosition.Item2);
            Assert.IsNotNull(node);
        }

        [TestMethod]
        public void ShouldListAllThePath()
        {
            ConfigurationManager configuration = Wrapper.GetConfiguration("mouse");
            Node[,] nodeArray = configuration.GetNodeArray();
            ToolsTree tools = new ToolsTree(nodeArray);
            List<Node> listeNode = tools.GetPathList();
            Assert.IsNotNull(listeNode);
        }

        [TestMethod]
        public void ShouldTestTheObservorError()
        {
            Subject subject = new Subject("Erreur de lecture de fichier");
            ErrorLogFile errorLogFile = new ErrorLogFile(subject);
            subject.NotifyAllObservers();
        }

        [TestMethod]
        public void ShouldTestTheLogPath()
        {
            ConfigurationManager configuration = Wrapper.GetConfiguration("mouse");
            Assert.AreEqual(configuration.GetLog().Path, @"C:\Users\Gabriel\Documents\DesignPaternDocument\");
        }


        [TestMethod]
        public void ShouldGetNodeArrayFromCommandPattern()
        {
            try
            {
                ToolsTreeCommand tools = new ToolsTreeCommand();
                Assert.IsNotNull(tools.ReadMap());
            }catch(Exception e)
            {
                Assert.Fail();
            }
           
        }

        [TestMethod]
        public void ShouldGetListPathFromCommandPattern()
        {
            try
            {
                ToolsTreeCommand tools = new ToolsTreeCommand();
                Node[,] nodes = tools.ReadMap();
                Assert.IsNotNull(tools.MousePath(nodes));
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void ShouldGetNodesArrayFromSwitchAction()
        {
            try
            {
                ToolsTreeCommand tools = new ToolsTreeCommand();
                SwitchAction switchAction = new SwitchAction();
                Assert.IsNotNull(switchAction.ExecuteReadMap(tools));
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }
    }
}
