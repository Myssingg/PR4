using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР4
{
    internal class Weapon
    {
        private string _Name;
        private int _Level;
        private double _Damage;
        private string _Type;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) _Name = "Безымянный щит";
                else _Name = value;
            }
        }
        public int Level
        {
            get { return _Level; }
            set
            {
                if (value > 0 && value <= 100) _Level = value;
                else
                {
                    if (value > 100) _Level = 100;
                    else _Level = 1;
                }
            }
        }

        public double Damage
        {
            get { return _Damage; }
            set
            {
                if (value > 10 && value <= 1000) _Damage = value;
                else
                {
                    if (value > 1000) _Damage = 1000;
                    else _Damage = 10;
                }
            }
        }

        public string Type
        {
            get { return _Type; }
            set
            {
                if (value == "0") _Type = "Меч";
                else if (value == "1") _Type = "Клинки";
                else if (value == "3") _Type = "Лук";
                else _Type = "Щит";
            }
        }


        public Weapon(string name = "Безымянный щит", int level = 1, double damage = 10, string type = "Щит")
        {
            this.Name = name;
            this.Level = level;
            this.Damage = damage;
            this.Type = type;
        }

        public static Weapon operator +(Weapon a, Weapon b)
        {
            if (a.Equals(b)) throw new Exception("Нельзя улучшить одно оружие!");
            if (a.Type != b.Type) throw new Exception("Нельзя улучшать оружия разных типов!");
            if (a.Level >= b.Level)
            {
                return new Weapon(a.Name + "+", a.Level++, a.Damage + b.Damage, a.Type);
            }
            else { return new Weapon(b.Name + "+", b.Level++, a.Damage + b.Damage, b.Type); }
        }

        public override string ToString()
        {
            return Type + " " + Name + ", " + Level + ", " + Damage;
        }
    }


}
