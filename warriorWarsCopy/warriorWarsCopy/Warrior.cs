using System;
using System.Collections.Generic;
using System.Text;
using warriorWarsCopy.Enums;

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
        public Warrior(string name, Identity identity)
        {
            this.name = name;
            this.isAlive = true;
            this.identity = identity;

            switch (identity)
            {
                case Identity.Hero:
                    this.health = HERO_INITIAL_HEALTH;
                    break;
                case Identity.Villian:
                    this.health = VILLIAN_INITIAL_HEALTH;
                    break;
            }
        }

    }
}
