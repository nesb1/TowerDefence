using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TowerDefence.Controller;
using TowerDefence.Model;

namespace TowerDefence
{
    public class TDForm : Form
    {
        private ScenePainter scenePainter;
        private ScaledViewPanel scaledViewPanel;
        private readonly Timer timer;
        private readonly MainController mainController;
        private TextBox textBoxGold, textBoxLives,level;
        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            WindowState = FormWindowState.Maximized;
            Text = "Click on any empty cell to run BFS";
            KeyPreview = true;
        }

        public TDForm()
        {
            KeyPreview = true;
            mainController = new MainController();
            var map = mainController.CurrentMap;
            scenePainter = new ScenePainter(new[] {map});
            scaledViewPanel = new ScaledViewPanel(scenePainter) {Dock = DockStyle.Fill};
            level = new TextBox()
            {
                Dock = DockStyle.Left,
                Enabled = false,
                ForeColor = Color.Black,
                BackColor = Color.Black,
                Width = 300,
                Font = new Font(SystemFonts.DefaultFont.FontFamily, 16)
            };
            textBoxGold = new TextBox
            {
                Dock = DockStyle.Left,
                Enabled = false,
                ForeColor = Color.Black,
                BackColor = Color.Black,
                Width = 300,
                Font = new Font(SystemFonts.DefaultFont.FontFamily, 16)
            };
            textBoxLives = new TextBox
            {
                Dock = DockStyle.Left,
                Enabled = false,
                ForeColor = Color.Chartreuse,
                BackColor = Color.Black,
                Width = 300,
                Font = new Font(SystemFonts.DefaultFont.FontFamily, 16),
            };
            textBoxLives.Padding= new Padding{Top = 100};
            level.Padding = new Padding(Top = 100);

            UpdateLevel(mainController.level);
            UpdateLives(mainController.Lives);
            UpdateGold(mainController.Gold);
            Controls.Add(scaledViewPanel);
            Controls.Add(textBoxGold);
            Controls.Add(textBoxLives);
            Controls.Add(level);
            timer = new Timer {Interval = 100};
            timer.Tick += TimerTick;
            timer.Start();
            DoubleBuffered = true;
        }

        private void UpdateLevel(int mainControllerLevel)
        {
            level.Text = "Уровень " + mainControllerLevel;
        }

        private void UpdateLives(int i)
        {
            textBoxLives.Text = "Жизни: " + i;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            mainController.OnKeyDown(e.KeyCode);
        }

        private void UpdateGold(int newGold)
        {
            textBoxGold.Text ="Золото: " +  newGold;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (mainController.isGameEnd)
            {
                timer.Stop();
                textBoxGold.Text = "Вы проиграли";
                return;
                
            }

            scaledViewPanel.Invalidate();
            var newMap = mainController.OnTick();
            scenePainter.currentMap = newMap;
            UpdateGold(mainController.Gold);
            UpdateLives(mainController.Lives);
            UpdateLevel(mainController.level);
        }
    }
}