using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeandreHattingh_19013170_Task02
{
    class FactoryBuilding : Building
    {
        GameEngine gameEngine = new GameEngine();
        private string unitType;
        private int unitProduction;
        private int spawnPoint;

        //Uses constructor initialisers to call “Building’s” constructor with relevant values for a specific Building
        public FactoryBuilding(int x, int y, string team, char sym, string unitToProduce, int speed) : base(x, y, 5, team, sym)
        {
            this.unitProduction = speed;
            this.unitType = unitToProduce;
            if (x != 19)
            {
                this.spawnPoint = x + 1;
            }
            else
            {
                this.spawnPoint = x - 1;
            }
        }

        public FactoryBuilding(int x, int y, int factoryHP, int factoryMaxHP, string team, char sym, string unitToProduce, int speed) : base(x, y, factoryHP, factoryMaxHP, team, sym)
        {
            this.unitProduction = speed;
            this.unitType = unitToProduce;
            if (x != 19)
            {
                this.spawnPoint = x + 1;
            }
            else
            {
                this.spawnPoint = x - 1;
            }
        }

        //A method to handle the generation of the units
        public Unit genUnit()
        {
            string teamName;
            string unitName = "";
            char symbol;
            int yPos;
            int teamNum;
            Unit returnUnit = null;
            Random rngod = new Random();

            switch (unitType)
            {
                case "MeleeUnit":
                    yPos = this.FbYPos;
                    unitName = "Knight";
                    teamNum = rngod.Next(0, 2);
                    if (teamNum == 0)
                    {
                        teamName = "Big Boys";
                        symbol = 'M';
                        ++gameEngine.MapTracker.NumberOfBigBoys;
                    }
                    else
                    {
                        teamName = "Lil Peeps";
                        symbol = 'm';
                        ++gameEngine.MapTracker.NumberOfLilPeeps;
                    }
                    returnUnit = new MeleeUnit(spawnPoint, yPos, teamName, symbol, false, unitName);
                    break;
                case "RangedUnit":
                    yPos = this.FbYPos;
                    unitName = "Archer";
                    teamNum = rngod.Next(0, 2);
                    if (teamNum == 0)
                    {
                        teamName = "Big Boys";
                        symbol = 'R';
                        ++gameEngine.MapTracker.NumberOfBigBoys;
                    }
                    else
                    {
                        teamName = "Lil Peeps";
                        symbol = 'r';
                        ++gameEngine.MapTracker.NumberOfLilPeeps;
                    }
                    returnUnit = new RangedUnit(spawnPoint, yPos, unitName, symbol, false, unitName);
                    break;
                default:
                    break;
                
            }

            return returnUnit;
        }

        //A method to handle the death/ destruction of this unit
        public override bool Death()
        {
            throw new NotImplementedException();
        }

        //A ToString() method to return a neatly formatted string showing all the unit information
        public override string ToString()
        {
            string returnVal = "";

            returnVal += "A new Factory building has spawned!" + Environment.NewLine;
            returnVal += "The buildins' X position is: " + this.FbXPos + Environment.NewLine;
            returnVal += "The buildins' Y position is: " + this.FbYPos + Environment.NewLine;
            returnVal += "The buildins' current HP is: " + this.FbHealth + Environment.NewLine;
            returnVal += "The buildins' team is: " + this.FbTeam + Environment.NewLine;
            returnVal += "The buildins' symbol is: " + this.FbTeam + Environment.NewLine;
            returnVal += "------------------------------------" + Environment.NewLine;
            returnVal += Environment.NewLine;

            return returnVal;
        }

        //A method to handle saving for the Building
        public override void Save()
        {
            string savedString = "";
            savedString += "Factory,";
            savedString += FbXPos + ",";
            savedString += FbYPos + ",";
            savedString += FbHealth + ",";
            savedString += FbMaxHealth + ",";
            savedString += FbTeam + ",";
            savedString += FbSymbol + ",";
            savedString += unitType + ",";
            savedString += FbProdution + ",";

            FileStream fs = new FileStream("SavedBuildings/buildingTextFile", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(savedString);

            writer.Close();
            fs.Close();
        }

        public int FbXPos { get => base.xPos; set => base.xPos = value; }
        public int FbYPos { get => base.yPos; set => base.yPos = value; }
        public int FbHealth { get => base.hp; set => base.hp = value; }
        public int FbMaxHealth { get => base.maxHP; }
        public string FbTeam { get => base.team; }
        public char FbSymbol { get => base.symbol; }
        public int FbProdution { get => unitProduction; }

    }
}
