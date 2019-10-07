using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeandreHattingh_19013170_Task02
{
    class ResourceBuilding : Building
    {
        GameEngine gameEngine = new GameEngine();
        private int resourceGen;
        private int resourcePerRound;
        private int resourcePool;

        //Uses constructor initialisers to call “Building’s” constructor with relevant values for a specific Building
        public ResourceBuilding(int x, int y, string team, char sym, int eachRound, int avaliableAmount) : base(x, y, 5, team, sym)
        {
            this.resourcePerRound = eachRound;
            this.resourcePool = avaliableAmount;
        }

        public ResourceBuilding(int x, int y, int resourceHP, int resourceMaxHP, string team, char sym, int eachRound, int avaliableAmount) : base(x, y, resourceHP, resourceMaxHP, team, sym)
        {
            this.resourcePerRound = eachRound;
            this.resourcePool = avaliableAmount;
        }

        //A method that lets the Building generate resources
        public void genResources()
        {
            if (Death() == false && resourcePool > 0)
            {
                resourceGen += resourcePerRound;
                resourcePool -= resourcePerRound;
            }
        }

        //A method to handle the death/ destruction of this unit
        public override bool Death()
        {
            bool died;
            if (this.RbHealth <= 0)
            {
                died = true;
            }
            else
            {
                died = false;
            }

            return died;
        }

        //A ToString() method to return a neatly formatted string showing all the unit information
        public override string ToString()
        {
            string returnVal = "";

            returnVal += "A new Resource building has spawned!" + Environment.NewLine;
            returnVal += "The buildings' X position is: " + this.RbXPos + Environment.NewLine;
            returnVal += "The buildings' Y position is: " + this.RbYPos + Environment.NewLine;
            returnVal += "The buildings' current HP is: " + this.RbHealth + Environment.NewLine;
            returnVal += "The buildings' team is: " + this.RbTeam + Environment.NewLine;
            returnVal += "The buildings' symbol is: " + this.RbSymbol + Environment.NewLine;
            returnVal += "The buildings' resources generated per round is: " + this.resourcePerRound + Environment.NewLine;
            returnVal += "The buildings' total generated resources: " + this.resourceGen + "/" + this.resourcePool + Environment.NewLine;
            returnVal += "------------------------------------------" + Environment.NewLine;
            returnVal += Environment.NewLine;

            return returnVal;
        }

        //A method to handle saving for the Building
        public override void Save()
        {
            string savedString = "";
            savedString += "Resource,";
            savedString += RbXPos + ",";
            savedString += RbYPos + ",";
            savedString += RbHealth + ",";
            savedString += RbMaxHealth + ",";
            savedString += RbTeam + ",";
            savedString += RbSymbol + ",";
            savedString += resourceGen + ",";
            savedString += resourcePool + ",";
            savedString += resourcePerRound + ",";

            FileStream fs = new FileStream("SavedBuildings/buildingTextFile", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(savedString);

            writer.Close();
            fs.Close();
        }

        //Accessors for the specific class
        public int RbXPos { get => base.xPos; set => base.xPos = value; }
        public int RbYPos { get => base.yPos; set => base.yPos = value; }
        public int RbHealth { get => base.hp; set => base.hp = value; }
        public int RbMaxHealth { get => base.maxHP; }
        public string RbTeam { get => base.team; }
        public char RbSymbol { get => base.symbol; }
    }
}
