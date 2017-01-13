using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetroLib;
using System.Reflection;

namespace MetroWPF
{
    public partial class MainWindow : Window
    {
        readonly MetroViewModel MVM = new MetroViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = MVM;
            double ratioX = 1;
            double ratioY = 0.8;

            DessineTouteLesLignes(ratioX, ratioY);
            DessineToutesLesStations(ratioX, ratioY);
        }

        private Brush PickRandomBrush(Random rnd)
        {
            Brush result = Brushes.Transparent;
            Type brushesType = typeof(Brushes);
            PropertyInfo[] properties = brushesType.GetProperties();
            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);
            return result;
        }

        private void DessineToutesLesStations(double ratioX, double ratioY)
        {
            Random rdm = new Random();
            foreach (var uneStation in MVM.Manager.DicoStations.Values)
            {
                Ellipse r = new Ellipse
                {
                    //Fill = PickRandomBrush(rdm),
                    Fill = Brushes.BlueViolet,
                    Width = 6,
                    Height = 6,
                    ToolTip = uneStation.Nom
                    
                };
                Canvas.SetLeft(r, uneStation.X*ratioX - 3);
                Canvas.SetTop(r, uneStation.Y*ratioY - 3);
                Surface.Children.Add(r);
            }
        }

        private void DessineTouteLesLignes(double ratioX, double ratioY)
        {
            foreach (var uneLigne in MVM.Manager.DicoLignes.Values)
            {
                Station stationPrecedente = null;

                foreach (var uneStation in uneLigne.StationsList)
                {
                    if (stationPrecedente != null)
                    {
                        Line r = new Line
                        {
                            Stroke = Brushes.Gray,
                            X1 = stationPrecedente.X * ratioX,
                            Y1 = stationPrecedente.Y * ratioY,
                            X2 = uneStation.X * ratioX,
                            Y2 = uneStation.Y * ratioY
                        };
                        Surface.Children.Add(r);
                        
                    }
                    stationPrecedente = uneStation;
                }
            }
        }
    }
}
