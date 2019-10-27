using System;
using System.Collections.Generic;
using System.Text;
using warriorWarsCopy.Enums;

namespace warriorWarsCopy.Equipment
{
    class Weapon
    {
        private const int HERO_WEAPON_POWER = 5;
        private const int Villian_WEAPON_POWER = 4;
        private int weaponPower;
        public int WeaponPower {
            get
            {
                return this.weaponPower;
            }
        }
        public Weapon(Identity identity)
        {
            switch (identity)
            {
                case Identity.Hero:
                    this.weaponPower = HERO_WEAPON_POWER;
                    break;
                case Identity.Villian:
                    this.weaponPower = Villian_WEAPON_POWER;
                    break;
            }
        }
    }
}
