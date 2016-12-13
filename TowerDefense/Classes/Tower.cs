using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class Tower
    {
        public string Nom { get; set; }
        public string Type { get; set; }
        public int Hp { get; set; }
        public int Degat { get; set; }
        public Dictionary<int, int> Position { get; set; }
        public int Range { get; set; }
        public Tower(String unNom, String unType, int hp, int degat, Dictionary<int, int> position, int range)
        {
            Nom = unNom;
            Type = unType;
            Hp = hp;
            Degat = degat;
            Position = position;
            Range = range;
        }

        public void attaquer()
        {

        }
        
    }
}
