using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Classes
{
    public class ZoneTir : AbstractTowerMob
    {
        public ZoneTir(string unNom, string unType, int unHp) : base(unNom, unType, unHp)
        {
        }

        public override void attaquer()
        {
            throw new NotImplementedException();
        }
    }
}
