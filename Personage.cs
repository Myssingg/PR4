using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ПР4
{
    internal class Personage
    {
        private string _Name;
        private int _Level = 1;
        private int _Strength;
        private int _Agility;
        private int _Intellect;
        private Weapon _Weapon;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) _Name = "Безымянный персонаж";
                else _Name = value;
            }
        }
        public int Level
        {
            get { return _Level; }
            set
            {
                if (value > 0 && value <= 1000) _Level = value;
                else
                {
                    if (value > 1000) _Level = 1000;
                    else _Level = 1;
                }
            }
        }
        public int Strength
        {
            get { return _Strength; }
            set
            {
                if (value > 0 && value <= 1000) _Strength = value;
                else
                {
                    if (value > 1000) _Strength = 1000;
                    else _Strength = 1;
                }
            }
        }
        public int Agility
        {
            get { return _Agility; }
            set
            {
                if (value > 0 && value <= 1000) _Agility = value;
                else
                {
                    if (value > 1000) _Agility = 1000;
                    else _Agility = 1;
                }
            }
        }
        public int Intellect
        {
            get { return _Intellect; }
            set
            {
                if (value > 0 && value <= 1000) _Intellect = value;
                else
                {
                    if (value > 1000) _Intellect = 1000;
                    else _Intellect = 10;
                }
            }
        }
        public Weapon Weapon
        {
            get
            {
                if (_Weapon == null) return new Weapon();
                else return _Weapon;
            }
            set { _Weapon = value; }
        }

        public Personage(string name = "Безымянный персонаж", int level = 1, int strength = 1, int agility = 1, int intellect = 10, Weapon weapon = null)
        {
            Name = name;
            Level = level;
            Strength = strength;
            Agility = agility;
            Intellect = intellect;
            Weapon = weapon;
        }

        public double Power()
        {
            return ((Strength + Agility + Intellect) * Level) + (this.Weapon.Level * this.Weapon.Damage);
        }

        public override string ToString()
        {
            string String = "";
            double PowerSave = Power();
            if (Weapon.Name == "Меч")
            {
                if (PowerSave >= 0 && PowerSave < 50)
                {
                    String = "Просто мечник";
                }
                else
                {
                    if (PowerSave >= 50 && PowerSave < 100)
                    {
                        String = "Хороший мечник";
                    }
                    else
                    {
                        if (PowerSave >= 100 && PowerSave < 200)
                        {
                            String = "Отличный мечник";
                        }
                        else
                        {
                            if (PowerSave >= 200 && PowerSave < 400)
                            {
                                String = "Великолепный мечник";
                            }
                            else
                            {
                                String = "Безупречный мечник";
                            }
                        }
                    }
                }
            }
            else
            {
                if (Weapon.Name == "Клинки")
                {
                    if (PowerSave >= 0 && PowerSave < 50)
                    {
                        String = "Кадет";
                    }
                    else
                    {
                        if (PowerSave >= 50 && PowerSave < 100)
                        {
                            String = "Рядовой";
                        }
                        else
                        {
                            if (PowerSave >= 100 && PowerSave < 200)
                            {
                                String = "Ефрейтор";
                            }
                            else
                            {
                                if (PowerSave >= 200 && PowerSave < 400)
                                {
                                    String = "Младший капрал";
                                }
                                else
                                {
                                    String = "Капрал";
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Weapon.Name == "Щит")
                    {
                        if (PowerSave >= 0 && PowerSave < 50)
                        {
                            String = "Просто щитоносец";
                        }
                        else
                        {
                            if (PowerSave >= 50 && PowerSave < 100)
                            {
                                String = "Хороший щитоносец";
                            }
                            else
                            {
                                if (PowerSave >= 100 && PowerSave < 200)
                                {
                                    String = "Отличный щитоносец";
                                }
                                else
                                {
                                    if (PowerSave >= 200 && PowerSave < 400)
                                    {
                                        String = "Великолепный щитоносец";
                                    }
                                    else
                                    {
                                        String = "Безупречный щитоносец";
                                    }
                                }
                            }
                        }
                    }
                    else // Лук
                    {
                        if (PowerSave >= 0 && PowerSave < 50)
                        {
                            String = "Просто лучник";
                        }
                        else
                        {
                            if (PowerSave >= 50 && PowerSave < 100)
                            {
                                String = "Хороший лучник";
                            }
                            else
                            {
                                if (PowerSave >= 100 && PowerSave < 200)
                                {
                                    String = "Отличный лучник";
                                }
                                else
                                {
                                    if (PowerSave >= 200 && PowerSave < 400)
                                    {
                                        String = "Великолепный лучник";
                                    }
                                    else
                                    {
                                        String = "Безупречный лучник";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return String;
        }



    }
}
