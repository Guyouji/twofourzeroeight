using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
        bool Stop = false;

        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        public void Notify(Model m)
        {
            if (((TwoZeroFourEightModel)m).GetOver() == true)
            {
                showOver.Text = "Game Over!!!";
            }
            UpdateBoard(((TwoZeroFourEightModel)m).GetBoard());
            showScore.Text = ((TwoZeroFourEightModel)m).GetScore();            
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            }
            else
            {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.PaleGoldenrod;
                    break;
                case 8:
                    l.BackColor = Color.Orange;
                    break;
                case 16:
                    l.BackColor = Color.OrangeRed;
                    break;
                default:
                    l.BackColor = Color.Red;
                    break;
            }
        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00, board[0, 0]);
            UpdateTile(lbl01, board[0, 1]);
            UpdateTile(lbl02, board[0, 2]);
            UpdateTile(lbl03, board[0, 3]);
            UpdateTile(lbl10, board[1, 0]);
            UpdateTile(lbl11, board[1, 1]);
            UpdateTile(lbl12, board[1, 2]);
            UpdateTile(lbl13, board[1, 3]);
            UpdateTile(lbl20, board[2, 0]);
            UpdateTile(lbl21, board[2, 1]);
            UpdateTile(lbl22, board[2, 2]);
            UpdateTile(lbl23, board[2, 3]);
            UpdateTile(lbl30, board[3, 0]);
            UpdateTile(lbl31, board[3, 1]);
            UpdateTile(lbl32, board[3, 2]);
            UpdateTile(lbl33, board[3, 3]);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (((TwoZeroFourEightModel)model).GetOver() == true)
            {
                if(Stop == true)
                {
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    Stop = false;
                }
                return;
            }
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (((TwoZeroFourEightModel)model).GetOver() == true)
            {
                if (Stop == true)
                {
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    Stop = false;
                }
                return;
            }
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (((TwoZeroFourEightModel)model).GetOver() == true)
            {
                if (Stop == true)
                {
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    Stop = false;
                }
                return;
            }
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (((TwoZeroFourEightModel)model).GetOver() == true)
            {
                if (Stop == true)
                {
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    Stop = false;
                }
                return;
            }
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
        }

        private void btnKeyborad(object sender, char e)
        {                        
            switch (e)
            {
                case 'w':
                    controller.ActionPerformed(TwoZeroFourEightController.UP);                    
                    break;
                case 'a':
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    break;
                case 's':
                    controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                    break;
                case 'd':
                    controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                    break;
            }
        }
        
        private void TwoZeroFourEightView_KeyDown(object sender, KeyEventArgs e)
        {
            if (Stop == true)
            {
                return;
            }
            else if (e.KeyCode == Keys.Up)
            {
                btnKeyborad(sender, 'w');
                if (((TwoZeroFourEightModel)model).GetOver() == true)
                {
                    Stop = true;
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                btnKeyborad(sender, 'a');
                if (((TwoZeroFourEightModel)model).GetOver() == true)
                {
                    Stop = true;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnKeyborad(sender, 's');
                if (((TwoZeroFourEightModel)model).GetOver() == true)
                {
                    Stop = true;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                btnKeyborad(sender, 'd');
                if (((TwoZeroFourEightModel)model).GetOver() == true)
                {
                    Stop = true;
                }
            }
        }

        private void TwoZeroFourEightView_Load(object sender, EventArgs e)
        {
           this.KeyPreview = true;            
        }
    }
}
