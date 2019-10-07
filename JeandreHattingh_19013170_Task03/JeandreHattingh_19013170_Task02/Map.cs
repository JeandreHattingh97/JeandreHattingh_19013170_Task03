using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeandreHattingh_19013170_Task02
{
    class Map
    {
        Random rngod = new Random();
        public const int HEIGHT = 20;
        public const int WIDTH = 20;
        public char[,] mapVisuals = new char[WIDTH, HEIGHT];
        public Unit[] unitArr;
        public Building[] buildingArr;

        int unitAmount;
        int buildingAmount;
        private int numberOfBigBoys;
        private int numberOfLilPeeps;

        //A constructor that receives the number of units to create
        public int UnitAmount { get => unitAmount; set => unitAmount = value; }
        public int BuildingAmount { get => buildingAmount; set => buildingAmount = value; }
        public int NumberOfBigBoys { get => numberOfBigBoys; set => numberOfBigBoys = value; }
        public int NumberOfLilPeeps { get => numberOfLilPeeps; set => numberOfLilPeeps = value; }

        public Map(int numberOfUnits, int numberOfBuildings)
        {
            this.UnitAmount = numberOfUnits;
            unitArr = new Unit[numberOfUnits];
            this.BuildingAmount = numberOfBuildings;
            buildingArr = new Building[numberOfBuildings];
        }

        //A method that recieves the other methods
        public void genMap()
        {
            genUnits();
            genBuildings();
            populateWithUnits();
            populateWithBuildings();
            fillMap();
        }

        //A method to randomise the units' X and Y position
        private void genUnits()
        {
            string unitName;
            string teamName;
            char symbol;
            int xPos;
            int yPos;
            int teamNumber;

            for (int j = 0; j <= unitArr.Length - 1; j++)
            {
                int type = rngod.Next(0, 2);
                xPos = rngod.Next(0, 20);
                yPos = rngod.Next(0, 20);
                teamNumber = rngod.Next(0, 2);
                switch (type)
                {
                    case 0:
                        {
                            unitName = "Knight";
                            if (teamNumber == 0)
                            {
                                teamName = "Big Boys";
                                symbol = 'M';
                            }
                            else
                            {
                                teamName = "Lil Peeps";
                                symbol = 'm';
                            }
                            unitArr[j] = new MeleeUnit(xPos, yPos, teamName, symbol, false, unitName);
                            break;
                        }

                    case 1:
                        {
                            unitName = "Archer";
                            if (teamNumber == 0)
                            {
                                teamName = "Big Boys";
                                symbol = 'R';
                            }
                            else
                            {
                                teamName = "Lil Peeps";
                                symbol = 'r';
                            }
                            unitArr[j] = new RangedUnit(xPos, yPos, teamName, symbol, false, unitName);
                            break;
                        }
                }
            }
        }

        //A method to fill the map with buildings
        private void genBuildings()
        {
            string teamName;
            string unitType = "";
            char symbol;
            int xPos;
            int yPos;
            int avaliableResources;
            int genPerRound;
            int unitToProduce;

            for (int j = 0; j < 4; j++)
            {
                yPos = rngod.Next(0, HEIGHT - 1);
                xPos = rngod.Next(0, WIDTH - 1);
                switch (j)
                {
                    case 0:
                        teamName = "Big Boys";
                        symbol = 'G';
                        avaliableResources = 100;
                        genPerRound = 5;
                        mapVisuals[yPos, xPos] = symbol;
                        buildingArr[j] = new ResourceBuilding(xPos, yPos, teamName, symbol, genPerRound, avaliableResources);
                        break;
                    case 1:
                        teamName = "Lil peep";
                        symbol = 'g';
                        avaliableResources = 100;
                        genPerRound = 5;
                        mapVisuals[yPos, xPos] = symbol;
                        buildingArr[j] = new ResourceBuilding(xPos, yPos, teamName, symbol, genPerRound, avaliableResources);
                        break;
                    case 2:
                        teamName = "Big Boys";
                        symbol = 'F';
                        unitToProduce = rngod.Next(0, 2);
                        switch (unitToProduce)
                        {
                            case 0:
                                {
                                    unitType = "MeleeUnit";
                                    break;
                                }
                            case 1:
                                {
                                    unitType = "RangedUnit";
                                    break;
                                }

                        }
                        mapVisuals[yPos, xPos] = symbol;
                        buildingArr[j] = new FactoryBuilding(xPos, yPos, teamName, symbol, unitType, 5);
                        break;
                    case 3:
                        teamName = "Lil Peeps";
                        symbol = 'f';
                        unitToProduce = rngod.Next(0, 3);
                        switch (unitToProduce)
                        {
                            case 0:
                                {
                                    unitType = "MeleeUnit";
                                    break;
                                }
                            case 1:
                                {
                                    unitType = "RangedUnit";
                                    break;
                                }
                        }
                        mapVisuals[yPos, xPos] = symbol;
                        buildingArr[j] = new FactoryBuilding(xPos, yPos, teamName, symbol, unitType, 5);
                        break;
                    default:
                        break;
                }
            }

        }

        //A method to fill the map with units
        private void populateWithUnits()
        {
            foreach (Unit unit in unitArr)
            {
                string typeCheck = unit.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];
                switch (typeCheck)
                {
                    case "MeleeUnit":
                        MeleeUnit Mobj = (MeleeUnit)unit;
                        mapVisuals[Mobj.MuYPos, Mobj.MuXPos] = Mobj.MuSymbol;
                        break;
                    case "RangedUnit":
                        RangedUnit Robj = (RangedUnit)unit;
                        mapVisuals[Robj.RuYPos, Robj.RuXPos] = Robj.RuSymbol;
                        break;
                    default:
                        break;
                }
            }

        }

        private void populateWithBuildings()
        {
            foreach (Building building in buildingArr)
            {
                string typeCheck = building.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];
                switch (typeCheck)
                {
                    case "ResourceBuilding":
                        ResourceBuilding RBobj = (ResourceBuilding)building;
                        mapVisuals[RBobj.RbYPos, RBobj.RbXPos] = RBobj.RbSymbol;
                        break;
                    case "FactoryBuilding":
                        FactoryBuilding FBobj = (FactoryBuilding)building;
                        mapVisuals[FBobj.FbYPos, FBobj.FbXPos] = FBobj.FbSymbol;
                        break;
                    default:
                        break;
                }
            }

        }

        //A method to randomly generate a new battlefield
        public string drawMap()
        {
            string mapDraw = "";

            for (int i = 0; i <= HEIGHT - 1; i++)
            {
                for (int j = 0; j <= WIDTH - 1; j++)
                {
                    mapDraw += Convert.ToString(mapVisuals[j, i]);
                }
                mapDraw += Environment.NewLine;
            }

            return mapDraw;
        }

        //A method to fill the map with placeholders
        private void fillMap()
        {
            for (int i = 0; i <= HEIGHT - 1; i++)
            {
                for (int j = 0; j <= WIDTH - 1; j++)
                {
                    if (mapVisuals[i, j] != 'R' && mapVisuals[i, j] != 'r' && mapVisuals[i, j] != 'M' && mapVisuals[i, j] != 'm' && mapVisuals[i, j] != 'G' && mapVisuals[i, j] != 'g' && mapVisuals[i, j] != 'F' && mapVisuals[i, j] != 'f')
                    {
                        mapVisuals[i, j] = '.';
                    }

                }
            }
        }

        public void Read()
        {
            int index;
            int x;
            int y;
            int hp;
            int maxHP;
            int resourceGenerated;
            int resourcePool;
            int genPerRound;
            int productionSpeed;
            string name;
            string team;
            string resourceType;
            string unitType;
            char symbol;
            bool engaged;

            for (int b = 0; b <= HEIGHT - 1; b++)
            {
                for (int p = 0; p <= WIDTH - 1; p++)
                {
                    mapVisuals[b, p] = ' ';
                }
            }

            FileStream fsU = new FileStream("SavedUnits/unitTextFile", FileMode.Open, FileAccess.Read);
            StreamReader readerUnits = new StreamReader(fsU);

            string lineUnit = readerUnits.ReadLine();
            index = 0;
            while (lineUnit != null)
            {
                string[] splitArray = lineUnit.Split(',');

                switch (splitArray[0])
                {
                    case "Melee":
                        x = Convert.ToInt32(splitArray[1]);
                        y = Convert.ToInt32(splitArray[2]);
                        name = splitArray[3];
                        hp = Convert.ToInt32(splitArray[4]);
                        maxHP = Convert.ToInt32(splitArray[5]);
                        team = splitArray[9];
                        symbol = Convert.ToChar(splitArray[10]);
                        engaged = Convert.ToBoolean(splitArray[11]);

                        unitArr[index] = new MeleeUnit(x, y, hp, maxHP, team, symbol, engaged, name);
                        mapVisuals[y, x] = symbol;
                        break;
                    case "Ranged":
                        x = Convert.ToInt32(splitArray[1]);
                        y = Convert.ToInt32(splitArray[2]);
                        name = splitArray[3];
                        hp = Convert.ToInt32(splitArray[4]);
                        maxHP = Convert.ToInt32(splitArray[5]);
                        team = splitArray[9];
                        symbol = Convert.ToChar(splitArray[10]);
                        engaged = Convert.ToBoolean(splitArray[11]);

                        unitArr[index] = new RangedUnit(x, y, hp, maxHP, team, symbol, engaged, name);
                        mapVisuals[y, x] = symbol;

                        break;
                    default:
                        break;
                }

                index++;
                lineUnit = readerUnits.ReadLine();
            }

            FileStream fsB = new FileStream("SavedBuildings/buildingTextFile", FileMode.Open, FileAccess.Read);

            StreamReader readerBuildings = new StreamReader(fsB);

            string lineBuilding = readerBuildings.ReadLine();
            index = 0;
            while (lineBuilding != null)
            {
                string[] splitArray = lineBuilding.Split(',');
                if (splitArray[0] == "Resource")
                {
                    x = Convert.ToInt32(splitArray[1]);
                    y = Convert.ToInt32(splitArray[2]);
                    hp = Convert.ToInt32(splitArray[3]);
                    maxHP = Convert.ToInt32(splitArray[4]);
                    team = splitArray[5];
                    symbol = Convert.ToChar(splitArray[6]);
                    resourceType = splitArray[7];
                    resourceGenerated = Convert.ToInt32(splitArray[8]);
                    resourcePool = Convert.ToInt32(splitArray[9]);
                    genPerRound = Convert.ToInt32(splitArray[10]);

                    buildingArr[index] = new ResourceBuilding(x, y, hp, maxHP, team, symbol, genPerRound, resourcePool);
                    mapVisuals[y, x] = symbol;
                }
                else
                {
                    x = Convert.ToInt32(splitArray[1]);
                    y = Convert.ToInt32(splitArray[2]);
                    hp = Convert.ToInt32(splitArray[3]);
                    maxHP = Convert.ToInt32(splitArray[4]);
                    team = splitArray[5];
                    symbol = Convert.ToChar(splitArray[6]);
                    unitType = splitArray[7];
                    productionSpeed = Convert.ToInt32(splitArray[8]);

                    buildingArr[index] = new FactoryBuilding(x, y, hp, maxHP, team, symbol, unitType, productionSpeed);
                    mapVisuals[y, x] = symbol;
                }

                index++;
                lineBuilding = readerBuildings.ReadLine();
            }

            for (int b = 0; b <= HEIGHT - 1; b++)
            {
                for (int p = 0; p <= WIDTH - 1; p++)
                {
                    if (mapVisuals[b, p] == '\0')
                    {
                        mapVisuals[b, p] = '.';
                    }

                }
            }

            fsU.Close();
            fsB.Close();

        }
    }
    
}
