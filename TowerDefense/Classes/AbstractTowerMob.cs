using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Classes
{
    public abstract class AbstractTowerMob
    {
        public string Nom { get; set; }
        public string Type { get; set; }
        public int Hp { get; set; }

        public AbstractTowerMob(string unNom, string unType, int unHp)
        {
            Nom = unNom;
            Type = unType;
            Hp = unHp;
        }

        public abstract void attaquer();
        

    }
}
