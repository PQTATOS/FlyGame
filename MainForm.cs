using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FlyGame.Entities;

namespace FlyGame
{
    public partial class MainForm : Form
    {
        private Game Game;
        public MainForm()
        {         
            InitializeComponent();
            Game = new Game();
            
            Game.StageChanged += Game_OnStageChanged;
            ShowStartScreen();
        }

        private void Game_OnStageChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.Battle:
                    ShowBattleScreen();
                    break;
                default:
                    ShowStartScreen();
                    break;
            }
        }

        private void ShowStartScreen()
        {
            HideScreens();
            startControl.GameSetUp(Game);
            startControl.Show();
        }

        private void ShowBattleScreen()
        {
            HideScreens();
            battleControl.GameSetUp(Game);
            battleControl.Show();
        }

        private void HideScreens()
        {
            startControl.Hide();
            battleControl.Hide();
        }
    }
}
