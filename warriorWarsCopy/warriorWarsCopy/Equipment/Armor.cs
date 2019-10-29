using System;
using System.Collections.Generic;
using System.Text;
using warriorWarsCopy.Enums;

namespace warriorWarsCopy.Equipment
{
    class Armor
    {
        private const int VILLIAN_DAMAGE = 5;
        private const int HERO_DAMAGE = 5;
        private int damage;

        public int Damage{
            get
            {
                return damage;
            }
        }

        public Armor(Identity identity)
        {
            switch (identity)
            {
                case Identity.Hero:
                    this.damage = HERO_DAMAGE;
                    break;
                case Identity.Villian:
                    this.damage = VILLIAN_DAMAGE;
                    break;
            }
        }
    }
}
