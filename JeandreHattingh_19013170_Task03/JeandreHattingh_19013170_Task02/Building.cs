using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeandreHattingh_19013170_Task02
{
    abstract class Building
    {
        //These are the Building class's protected definitions
        protected int xPos;
        protected int yPos;
        protected int hp;
        protected int maxHP;
        protected string team;
        protected char symbol;

        public Building(int x, int y, int currentHP, string buildingTeam, char buildingSym)
        {
            this.xPos = x;
            this.yPos = y;
            this.hp = currentHP;
            this.team = buildingTeam;
            this.symbol = buildingSym;
            this.maxHP = currentHP;
        }

        public Building(int x, int y, int currentHP, int maxHP, string buildingTeam, char buildingSym)
        {
            this.xPos = x;
            this.yPos = y;
            this.hp = currentHP;
            this.team = buildingTeam;
            this.symbol = buildingSym;
            this.maxHP = maxHP;
        }

        //This is the Building class's abstract method definitions

        public abstract bool Death();

        public override abstract string ToString();

        public abstract void Save();
    }
}
