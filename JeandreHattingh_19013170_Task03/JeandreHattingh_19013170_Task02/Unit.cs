using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeandreHattingh_19013170_Task02
{
    abstract class Unit
    {
        //These are the Unit class's protected definitions
        protected int xPos;
        protected int yPos;
        protected int hp;
        protected int maxHP;
        protected int speed;
        protected int atk;
        protected int atkRange;
        protected string team;
        protected char symbol;
        protected bool engage;
        protected string name;

        protected Unit(int x, int y, int currentHP, int movement, int unitAtk, int unitRange, string unitTeam, char unitSym, bool unitEngage, string unitName)
        {
            this.xPos = x;
            this.yPos = y;
            this.hp = currentHP;
            this.maxHP = currentHP;
            this.speed = movement;
            this.atk = unitAtk;
            this.atkRange = unitRange;
            this.team = unitTeam;
            this.symbol = unitSym;
            this.engage = unitEngage;
            this.name = unitName;
        }

        protected Unit(int x, int y, int currentHP, int maxHP, int movement, int unitAtk, int unitRange, string unitTeam, char unitSym, bool unitEngage, string unitName)
        {
            this.xPos = x;
            this.yPos = y;
            this.hp = currentHP;
            this.maxHP = maxHP;
            this.speed = movement;
            this.atk = unitAtk;
            this.atkRange = unitRange;
            this.team = unitTeam;
            this.symbol = unitSym;
            this.engage = unitEngage;
            this.name = unitName;
        }

        //This is the Unit class's abstract method definitions

        public abstract string Move(Unit unitToEngage);

        public abstract void Combat(Unit attackingUnit);

        public abstract bool Engaging(Unit unitInRange);

        public abstract Unit EnemyPos(Unit[] unitClosetCheck);

        public abstract bool Death();

        public override abstract string ToString();

        public abstract void Save();
    }
}
