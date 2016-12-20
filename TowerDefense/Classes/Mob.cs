using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Classes;

namespace TowerDefense
{
    public class Mob : AbstractTowerMob
    {
        public int Vitesse { get; set; }

        public Mob(String unNom, String unType, int hp,int vitesse) : base(unNom, unType, hp)
        {
            Vitesse = vitesse;
        }

        public void lancer()
        {
            //Tant que le mob n'est pas mort il continue d'avancer
        }

        public override void attaquer()
        {
            Console.WriteLine("mob attaque");
        }
    }
}
