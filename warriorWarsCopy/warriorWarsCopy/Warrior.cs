using System;
using System.Collections.Generic;
using System.Text;
using warriorWarsCopy.Enums;
using warriorWarsCopy.Equipment;

namespace warriorWarsCopy
{
    class Warrior
    {
        private const int HERO_INITIAL_HEALTH = 20;
        private const int VILLIAN_INITIAL_HEALTH = 20; 
        private readonly Identity identity; 

        private string name;
        private int health;
        private bool isAlive;
        private Armor armor;
        private Weapon weapon;
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
        }
        public Warrior(string name, Identity identity)
        {
            this.name = name;
            this.isAlive = true;
            this.identity = identity;

            switch (identity)
            {
                case Identity.Hero:
                    this.health = HERO_INITIAL_HEALTH;
                    this.weapon = new Weapon(identity);
                    this.armor = new Armor(identity);
                    break;
                case Identity.Villian:
                    this.health = VILLIAN_INITIAL_HEALTH;
                    this.weapon = new Weapon(identity);
                    this.armor = new Armor(identity);
                    break;
            }
        }

        public void attack(Warrior Enemy)
        {
           
        }

    }
}
