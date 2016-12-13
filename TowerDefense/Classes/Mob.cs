using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class Mob
    {
        public string Nom { get; set; }
        public string Type { get; set; }
        public int Hp { get; set; }
        public int Vitesse { get; set; }
        public Dictionary<int, int> Position { get; set; }

        public Mob(String unNom, String unType, int hp, int vitesse, Dictionary<int, int> position)
        {
            Nom = unNom;
            Type = unType;
            Hp = hp;
            Vitesse = vitesse;
            Position = position;
        }

        public void lancer()
        {
            int posX = Position.Keys.ElementAt(0);
            int posY = Position.Values.ElementAt(0);
            //Tant que le mob n'est pas mort il continue d'avancer
            while (Hp > 0)
            {
                posX++;
                posY++;
            }
        }
    }
}
