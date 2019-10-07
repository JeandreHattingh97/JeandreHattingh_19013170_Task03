using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JeandreHattingh_19013170_Task02
{
    public partial class frmBattleSim : Form
    {
        GameEngine gameEngine = new GameEngine();
        int timerTicks;
        string gameInfo = "";

        public frmBattleSim()
        {
            InitializeComponent();
        }

        //The displayInfo() method is used to display the game's information to the rich text box
        private void displayInfo()
        {
            gameInfo = "";
            foreach (Unit unit in gameEngine.MapTracker.unitArr)
            {
                string typeCheck = unit.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)unit;
                    gameInfo += obj.ToString();
                }
                else
                {
                    RangedUnit obj = (RangedUnit)unit;
                    gameInfo += obj.ToString();
                }
            }

            foreach (Building building in gameEngine.MapTracker.buildingArr)
            {
                string typeCheck = building.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "ResourceBuilding")
                {
                    ResourceBuilding obj = (ResourceBuilding)building;
                    gameInfo += obj.ToString();
                }
                else
                {
                    FactoryBuilding obj = (FactoryBuilding)building;
                    gameInfo += obj.ToString();
                }
            }
            rtbGameInfo.Text = gameInfo;
        }

        //The btnStart is used to start the simulation when pressed and resume it when paused
        private void btnStart_Click(object sender, EventArgs e)
        {
            timerRoundTimer.Start();
        }

        //The btnPause is used to pause the game the simulation
        private void btnPause_Click(object sender, EventArgs e)
        {
            timerRoundTimer.Stop();
        }

        //The timerRoundTimer is used to tick up the rounds as the simulation progresses
        private void timerRoundTimer_Tick(object sender, EventArgs e)
        {
            rtbGameInfo.Text = "";
            timerTicks++;
            lblTimer.Text = timerTicks.ToString();
            gameEngine.gameRun();
            lblGameMap.Text = gameEngine.MapTracker.drawMap();
            displayInfo();
        }

        private void frmBattleSim_Load(object sender, EventArgs e)
        {
            gameEngine.MapTracker.genMap();
            lblGameMap.Text = gameEngine.MapTracker.drawMap();
            displayInfo();
        }

        //Saves the games data
        private void btnSave_Click(object sender, EventArgs e)
        {
            FileStream fsU = new FileStream("SavedUnits/unitTextFile", FileMode.Create, FileAccess.Write);
            fsU.Close();
            FileStream fsB = new FileStream("SavedBuildings/buildingTextFile", FileMode.Create, FileAccess.Write);
            fsB.Close();

            foreach (Unit unit in gameEngine.MapTracker.unitArr)
            {
                string typeCheck = unit.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)unit;
                    obj.Save();
                }
                else
                {
                    RangedUnit obj = (RangedUnit)unit;
                    obj.Save();
                }
            }

            foreach (Building temp in gameEngine.MapTracker.buildingArr)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "ResourceBuilding")
                {
                    ResourceBuilding obj = (ResourceBuilding)temp;
                    obj.Save();
                }
                else
                {
                    FactoryBuilding obj = (FactoryBuilding)temp;
                    obj.Save();
                }
            }
        }

        //Loads the games data
        private void btnLoad_Click(object sender, EventArgs e)
        {
            FileStream fsU = new FileStream("SavedUnits/unitTextFile", FileMode.Open, FileAccess.Read);
            fsU.Close();
            FileStream fsB = new FileStream("SavedBuildings/buildingTextFile", FileMode.Open, FileAccess.Read);
            fsB.Close();

            gameEngine.MapTracker.Read();
            lblGameMap.Text = gameEngine.MapTracker.drawMap();
            displayInfo();
        }
    }
}
