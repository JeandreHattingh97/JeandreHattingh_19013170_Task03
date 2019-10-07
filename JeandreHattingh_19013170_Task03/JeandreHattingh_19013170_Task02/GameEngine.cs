using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeandreHattingh_19013170_Task02
{
    class GameEngine
    {
        int numberOfRounds = 0;
        Map mapTracker = new Map(20, 4);

        public Map MapTracker { get => mapTracker; set => mapTracker = value; }

        //A method that runs the game and movement of the Units
        public void gameRun()
        {
            ++numberOfRounds;
            bool unitDead;
            string moveDirection;

            foreach (Unit unit in MapTracker.unitArr)
            {
                string typeCheck = unit.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)unit;
                    unitDead = obj.Death();
                    if (unitDead == false)
                    {
                        if (numberOfRounds % obj.MuMovementSpeed == 0)
                        {
                            if (obj.MuHealth > (0.25 * obj.MuMaxHealth))
                            {
                                Unit closest = obj.EnemyPos(MapTracker.unitArr);

                                if (obj.MuEngaging == false && obj.Engaging(closest) == false)
                                {
                                    moveDirection = obj.Move(closest);
                                    moveMeleeUnitCloser(obj, moveDirection);
                                }
                                else if (obj.Engaging(closest) == true)
                                {
                                    obj.MuEngaging = true;
                                    obj.Combat(closest);
                                }
                            }
                            else
                            {
                                randomMoveMeleeUnit(obj);
                            }
                        }
                    }
                }
                else
                {
                    RangedUnit obj = (RangedUnit)unit;
                    unitDead = obj.Death();
                    if (unitDead == false)
                    {
                        if (numberOfRounds % obj.RuMovementSpeed == 0)
                        {
                            if (obj.RuHealth > (0.25 * obj.RuMaxHealth))
                            {
                                Unit closest = obj.EnemyPos(MapTracker.unitArr);

                                if (obj.RuEngaging == false && obj.Engaging(closest) == false)
                                {
                                    moveDirection = (obj.Move(closest));
                                    moveRangedUnitCloser(obj, moveDirection);
                                }
                                else if (obj.Engaging(closest) == true)
                                {
                                    obj.RuEngaging = true;
                                    obj.Combat(closest);
                                }
                            }
                            else
                            {
                                randomMoveRangedUnit(obj);
                            }
                        }
                    }
                }
            }
        }

        //A method that handles the random movement of the randged units
        private void randomMoveRangedUnit(RangedUnit obj)
        {
            switch (obj.RandomMove())
            {
                case "Right":
                    {
                        obj.RuXPos++;
                        MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                        mapTracker.mapVisuals[obj.RuYPos, obj.RuXPos - 1] = '.';
                        break;
                    }
                case "Left":
                    {
                        obj.RuXPos--;
                        MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                        mapTracker.mapVisuals[obj.RuYPos, obj.RuXPos + 1] = '.';
                        break;
                    }
                case "Up":
                    {
                        obj.RuYPos++;
                        MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                        mapTracker.mapVisuals[obj.RuYPos - 1, obj.RuXPos] = '.';
                        break;
                    }
                case "Down":
                    {
                        obj.RuYPos--;
                        MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                        mapTracker.mapVisuals[obj.RuYPos + 1, obj.RuXPos] = '.';
                        break;
                    }
            }
        }

        //A method that handles the targeting of the ranged units
        private void moveRangedUnitCloser(RangedUnit obj, string direction)
        {
            switch (direction)
            {
                case "Right":
                    {
                        if (obj.RuXPos != 20)
                        {
                            MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                            mapTracker.mapVisuals[obj.RuYPos, obj.RuXPos - 1] = '.';
                        }
                        else
                        {
                            obj.RuXPos = 0;
                            MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                            mapTracker.mapVisuals[obj.RuYPos, 19] = '.';
                        }
                        break;
                    }
                case "Left":
                    {
                        if (obj.RuXPos != -1)
                        {
                            MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                            mapTracker.mapVisuals[obj.RuYPos, obj.RuXPos + 1] = '.';
                        }
                        else
                        {
                            obj.RuXPos = 19;
                            MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                            mapTracker.mapVisuals[obj.RuYPos, 0] = '.';
                        }
                        break;
                    }
                case "Up":
                    {
                        if (obj.RuYPos != 20)
                        {
                            MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                            mapTracker.mapVisuals[obj.RuYPos - 1, obj.RuXPos] = '.';
                        }
                        else
                        {
                            obj.RuYPos = 0;
                            MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                            mapTracker.mapVisuals[19, obj.RuXPos] = '.';
                        }
                        break;
                    }
                case "Down":
                    {
                        if (obj.RuYPos != 0)
                        {
                            MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                            mapTracker.mapVisuals[obj.RuYPos + 1, obj.RuXPos] = '.';
                        }
                        else
                        {
                            obj.RuYPos = 19;
                            MapTracker.mapVisuals[obj.RuYPos, obj.RuXPos] = obj.RuSymbol;
                            mapTracker.mapVisuals[0, obj.RuXPos] = '.';
                        }
                        break;
                    }
            }
        }

        //A method that handles the random movement of the randged units
        private void randomMoveMeleeUnit(MeleeUnit obj)
        {
            switch (obj.RandomMove())
            {
                case "Right":
                    {
                        obj.MuXPos++;
                        MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                        mapTracker.mapVisuals[obj.MuYPos, obj.MuXPos - 1] = '.';
                        break;
                    }
                case "Left":
                    {
                        obj.MuXPos--;
                        MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                        mapTracker.mapVisuals[obj.MuYPos, obj.MuXPos + 1] = '.';
                        break;
                    }
                case "Up":
                    {
                        obj.MuYPos++;
                        MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                        mapTracker.mapVisuals[obj.MuYPos - 1, obj.MuXPos] = '.';
                        break;
                    }
                case "Down":
                    {
                        obj.MuYPos--;
                        MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                        mapTracker.mapVisuals[obj.MuYPos + 1, obj.MuXPos] = '.';
                        break;
                    }
            }
        }

        //A method that handles the targeting of the ranged units
        private void moveMeleeUnitCloser(MeleeUnit obj, string direction)
        {
            switch (direction)
            {
                case "Right":
                    {
                        if (obj.MuXPos != 20)
                        {
                            MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                            mapTracker.mapVisuals[obj.MuYPos, obj.MuXPos - 1] = '.';
                        }
                        else
                        {
                            obj.MuXPos = 0;
                            MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                            mapTracker.mapVisuals[obj.MuYPos, 19] = '.';
                        }
                        break;
                    }
                case "Left":
                    {
                        if (obj.MuXPos != -1)
                        {
                            MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                            mapTracker.mapVisuals[obj.MuYPos, obj.MuXPos + 1] = '.';
                        }
                        else
                        {
                            obj.MuXPos = 19;
                            MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                            mapTracker.mapVisuals[obj.MuYPos, 0] = '.';
                        }
                        break;
                    }
                case "Up":
                    {
                        if (obj.MuYPos != 20)
                        {
                            MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                            mapTracker.mapVisuals[obj.MuYPos - 1, obj.MuXPos] = '.';
                        }
                        else
                        {
                            obj.MuYPos = 0;
                            MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                            mapTracker.mapVisuals[19, obj.MuXPos] = '.';
                        }
                        break;
                    }
                case "Down":
                    {
                        if (obj.MuYPos != 0)
                        {
                            MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                            mapTracker.mapVisuals[obj.MuYPos + 1, obj.MuXPos] = '.';
                        }
                        else
                        {
                            obj.MuYPos = 19;
                            MapTracker.mapVisuals[obj.MuYPos, obj.MuXPos] = obj.MuSymbol;
                            mapTracker.mapVisuals[0, obj.MuXPos] = '.';
                        }
                        break;
                    }
            }
        }

        //A method that handles the buildings logic
        private void buildingLogic()
        {
            foreach (Building temp in mapTracker.buildingArr)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "ResourceBuilding")
                {
                    ResourceBuilding resource = (ResourceBuilding)temp;
                    resource.genResources();
                }
                else
                {
                    FactoryBuilding factory = (FactoryBuilding)temp;
                    if (numberOfRounds % factory.FbProdution == 0)
                    {
                        Array.Resize(ref mapTracker.unitArr, mapTracker.unitArr.Length + 1);
                        Unit generatedUnit = factory.genUnit();
                        mapTracker.unitArr[mapTracker.unitArr.Length - 1] = generatedUnit;

                        typeCheck = generatedUnit.GetType().ToString();
                        splitArray = typeCheck.Split('.');
                        typeCheck = splitArray[splitArray.Length - 1];

                        switch (typeCheck)
                        {
                            case "MeleeUnit":
                                {
                                    MeleeUnit MUnit = (MeleeUnit)generatedUnit;
                                    mapTracker.mapVisuals[MUnit.MuYPos, MUnit.MuXPos] = MUnit.MuSymbol;
                                }
                                break;
                            case "RangedUnit":
                                {
                                    RangedUnit RUnit = (RangedUnit)generatedUnit;
                                    mapTracker.mapVisuals[RUnit.RuYPos, RUnit.RuXPos] = RUnit.RuSymbol;
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}
