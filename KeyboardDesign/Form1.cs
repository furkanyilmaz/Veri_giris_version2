using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriGirisEkrani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle = 0x08000000;
                return param;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void lettterA_Click(object sender, EventArgs e)
        {
            SendKeys.Send("A");
        }

        private void letterB_Click(object sender, EventArgs e)
        {
            SendKeys.Send("B");
        }

        private void letterC_Click(object sender, EventArgs e)
        {
            SendKeys.Send("C");
        }
        private void letterC2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Ç");
        }
        private void lettterD_Click(object sender, EventArgs e)
        {
            SendKeys.Send("D");
        }

        private void letterE_Click(object sender, EventArgs e)
        {
            SendKeys.Send("E");
        }
        private void lettterF_Click(object sender, EventArgs e)
        {
            SendKeys.Send("F");
        }
        private void lettterG_Click(object sender, EventArgs e)
        {
            SendKeys.Send("G");
        }
        private void lettterG2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Ğ");
        }
        private void lettterH_Click(object sender, EventArgs e)
        {
            SendKeys.Send("H");
        }
        private void lettterI_Click(object sender, EventArgs e)
        {
            SendKeys.Send("I");
        }
        private void lettter_i_Click(object sender, EventArgs e)
        {
            SendKeys.Send("İ");
        }
        private void lettterJ_Click(object sender, EventArgs e)
        {
            SendKeys.Send("J");
        }
        private void lettterK_Click(object sender, EventArgs e)
        {
            SendKeys.Send("K");
        }
        private void lettterL_Click(object sender, EventArgs e)
        {
            SendKeys.Send("L");
        }
        private void letterM_Click(object sender, EventArgs e)
        {
            SendKeys.Send("M");
        }
        private void letterN_Click(object sender, EventArgs e)
        {
            SendKeys.Send("N");
        }
        private void lettterO_Click(object sender, EventArgs e)
        {
            SendKeys.Send("O");
        }
        private void letterO2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Ö");
        }
        private void lettterP_Click(object sender, EventArgs e)
        {
            SendKeys.Send("P");
        }
        private void lettterR_Click(object sender, EventArgs e)
        {
            SendKeys.Send("R");
        }

        private void letterS_Click_1(object sender, EventArgs e)
        {
            SendKeys.Send("S");
        }
        private void lettterS2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Ş");
        }
        private void lettterT_Click(object sender, EventArgs e)
        {
            SendKeys.Send("T");
        }
        private void lettterU_Click(object sender, EventArgs e)
        {
            SendKeys.Send("U");
        }
        private void lettterU2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Ü");
        }
        private void letterW_Click(object sender, EventArgs e)
        {
            SendKeys.Send("W");
        }
        private void letterV_Click(object sender, EventArgs e)
        {
            SendKeys.Send("V");
        }
        private void letterX_Click(object sender, EventArgs e)
        {
            SendKeys.Send("X");
        }
        private void letterQ_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Q");
        }
        private void lettterY_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Y");
        }
        private void letterZ_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Z");
        }

        private void enter_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }
        private void space_button_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }



        //numberssss--------------------------------------------------------
        private void number0_Click(object sender, EventArgs e)
        {
            SendKeys.Send("0");
        }
        private void number1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("1");
        }
        private void number2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("2");
        }
        private void number3_Click(object sender, EventArgs e)
        {
            SendKeys.Send("3");
        }
        private void number4_Click(object sender, EventArgs e)
        {
            SendKeys.Send("4");
        }
        private void number5_Click(object sender, EventArgs e)
        {
            SendKeys.Send("5");
        }
        private void number6_Click(object sender, EventArgs e)
        {
            SendKeys.Send("6");
        }
        private void number7_Click(object sender, EventArgs e)
        {
            SendKeys.Send("7");
        }

        private void number8_Click(object sender, EventArgs e)
        {
            SendKeys.Send("8");
        }
        private void number9_Click(object sender, EventArgs e)
        {
            SendKeys.Send("9");
        }
        private void left_button_Click(object sender, EventArgs e)
        {
            /////??????????*
        }
        private void right_button_Click(object sender, EventArgs e)
        {
            /////??????????*
        }

































    }
}
