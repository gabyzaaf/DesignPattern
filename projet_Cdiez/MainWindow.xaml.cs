using MouseTools;
using MouseTools.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TowerDefense.Classes;
using TowerDefense.Factory;

namespace projet_Cdiez
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int whichGame;
        
        //Initialisation des images en tant que BitmapImage
        public MainWindow()
        {
            InitializeComponent();
            
            //this.KeyDown += new KeyEventHandler(keydownEvent);
        }

        private void btnMouse_Click(object sender, RoutedEventArgs e)
        {
            whichGame = 1;
            new GamesGUI();
        }

        private void btnTowerD_Click(object sender, RoutedEventArgs e)
        {
            whichGame = 2;
            new GamesGUI();
        }

        private void btnSubwaySimul_Click(object sender, RoutedEventArgs e)
        {
            whichGame = 3;
            new GamesGUI();
        }
    }
}