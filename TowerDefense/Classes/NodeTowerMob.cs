using MouseTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Classes
{
    public class NodeTowerMob : Node
    {
        public List<AbstractTowerMob> Type { get; set; }
        public NodeTowerMob(int height, int width, char value, List<AbstractTowerMob> type) : base(height, width, value)
        {
            Type = type;
        }
    }
}
