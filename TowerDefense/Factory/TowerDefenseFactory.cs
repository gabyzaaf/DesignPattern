using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Classes;

namespace TowerDefense.Factory
{
    public class TowerDefenseFactory
    {
        public static Mob buildMob(String nom, String type, int hp, int vitesse)
        {
            return new Mob(nom, type, hp, vitesse);
        }


        public static Tower buildTower(String nom, String type, int hp, int degat, int range)
        {
            return new Tower(nom, type, hp, degat, range);
        }

        public static AbstractTowerMob buildMobOrTower(String nom, String type, int hp, int vitesse, int degat, int range)
        {
            if (nom == "Tower")
            {
                return new Tower(nom, type, hp, degat, range);
            }
            if (nom == "Mob")
            {
                return new Mob(nom, type, hp, vitesse);
            }
            return null;
        }
    }
}
