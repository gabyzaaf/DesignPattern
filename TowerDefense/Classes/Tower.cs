using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Classes;

namespace TowerDefense
{
    public class Tower : AbstractTowerMob
    {
        public int Degat { get; set; }
        public int Range { get; set; }
        public Tower(String unNom, String unType, int hp, int degat, int range):base(unNom, unType, hp)
        {
            Degat = degat;
            Range = range;
        }
        
        public override void attaquer()
        {
            Console.WriteLine("tower attaque");
        }
        
    }
}
