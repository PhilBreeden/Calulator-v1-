using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /********************************/
        /******* Public Variables *******/
        /********************************/

        public char opSign = '@';
        public double dblFirstNum = 0;
        public double dblSecNum = 0;
        public double result = 0;
        public double lastResult = 0;
        public string strFirstNum = "";
        public string strSecNum = "";
        public string histResult = null;

        /**********************************/
        /************ Methods *************/
        /**********************************/

        public void changeCalcType(ToolStripMenuItem calcType)
        {
            switch(calcType.Name.ToString())
            {
                case "menuStandard":
                    this.Size = new System.Drawing.Size(402, 350);
                    tbDisplay2.Size = new System.Drawing.Size(324, 40);
                    break;

                case "menuAdvanced":
                    this.Size = new System.Drawing.Size(469, 401);
                    tbDisplay2.Size = new System.Drawing.Size(390, 40);
                    break;

                case "menuScientific":
                    this.Size = new System.Drawing.Size(469, 401);
                    tbDisplay2.Size = new System.Drawing.Size(390, 40);
                    break;
            }
        }

        public void checkCalcType(ToolStripMenuItem calcType)
        {
            switch(calcType.Name.ToString())
            {
                case "menuStandard":
                    menuStandard.Checked = true;
                    menuAdvanced.Checked = false;
                    menuScientific.Checked = false;
                    break;
                case "menuAdvanced":
                    menuStandard.Checked = false;
                    menuAdvanced.Checked = true;
                    menuScientific.Checked = false;
                    break;
                case "menuScientific":
                    menuStandard.Checked = false;
                    menuAdvanced.Checked = false;
                    menuScientific.Checked = true;
                    break;
            }
        }

        public void runAllClear()
        {
            tbDisplay2.Clear();
            lblHistory.Text = "";
        }

        public void visibleButtons(bool visCheck)
        {
            btn00.Visible = visCheck;
            btnPercent.Visible = visCheck;
            btnSqRoot.Visible = visCheck;
            btnSquared.Visible = visCheck;
            btnPower.Visible = visCheck;
            btnAllClear.Visible = visCheck;
            btnMemClear.Visible = visCheck;
            btnMemRecall.Visible = visCheck;
            btnMemPlus.Visible = visCheck;
            btnMemMinus.Visible = visCheck;
        }

        public void changeOperator(char keyChar)
        {
            switch(keyChar)
            {
                case '+':
                    opSign = '+';
                    break;
                case '-':
                    opSign = '-';
                    break;
                case '*':
                    opSign = '*';
                    break;
                case '/':
                    opSign = '/';
                    break;
            }

            lblHistory.Text = dblFirstNum + " " + opSign + " ";
            tbDisplay2.Text = "";
        }

        public void getResult(double firstNum, double secNum, char opSign)
        {
            switch(opSign)
            {
                case '+':
                    result = firstNum + secNum;
                    break;
                case '-':
                    result = firstNum - secNum;
                    break;
                case '*':
                    result = firstNum * secNum;
                    break;
                case '/':
                    result = firstNum / secNum;
                    break;
            }
            
            lblHistory.Text = firstNum + " " + opSign + " " + secNum + " = " + result;

            if (lblHistory.Text.Length >= 35)
            {
                lblHistory.Text = result.ToString();
            }

            lastResult = result;
            tbDisplay2.Text = "";
        }

        public void clearNumbers()
        {
            opSign = '@';
            dblFirstNum = 0;
            dblSecNum = 0;
            strFirstNum = "";
            strSecNum = "";
            result = 0;
        }

        public void backSpaceNum()
        {
            if (tbDisplay2.Text.Length == 1 || tbDisplay2.Text == "")
            {
                tbDisplay2.Text = "";
            } else
            {
                tbDisplay2.Text = tbDisplay2.Text.Substring(0, tbDisplay2.Text.Length - 1);
            }
        }

        public void determineKeyPress (char keyPressed)
        {
            if (keyPressed == Convert.ToChar(Keys.Enter))
            {
                btnEquals.PerformClick();

            }
            else if (keyPressed == Convert.ToChar(Keys.Back))
            {
                backSpaceNum();

            }
            else if (tbDisplay2.TextLength == tbDisplay2.MaxLength)
            {
                //If tbDisplay2 text length is greater than or equal to the max length, do nothing
                ////tbDisplay2 max length is not working; this function corrects this
                switch (keyPressed)
                {
                    case '+':
                        btnPlus.PerformClick();
                        break;
                    case '-':
                        btnMinus.PerformClick();
                        break;
                    case '*':
                        btnMultiply.PerformClick();
                        break;
                    case '/':
                        btnDivide.PerformClick();
                        break;
                    case '=':
                        btnEquals.PerformClick();
                        break;
                }
            } else
            {
                if (tbDisplay2.Text.Length > 0 && tbDisplay2.Text.Substring(0, 1) == "0")
                {
                    if (keyPressed != 0)
                    {
                        tbDisplay2.Text = "";
                    }
                }

                switch (keyPressed)
                {
                    case '1':
                        btn1.PerformClick();
                        break;
                    case '2':
                        btn2.PerformClick();
                        break;
                    case '3':
                        btn3.PerformClick();
                        break;
                    case '4':
                        btn4.PerformClick();
                        break;
                    case '5':
                        btn5.PerformClick();
                        break;
                    case '6':
                        btn6.PerformClick();
                        break;
                    case '7':
                        btn7.PerformClick();
                        break;
                    case '8':
                        btn8.PerformClick();
                        break;
                    case '9':
                        btn9.PerformClick();
                        break;
                    case '0':
                        btn0.PerformClick();
                        break;
                    case '.':
                        btnDecimal.PerformClick();
                        break;
                    case '+':
                        btnPlus.PerformClick();
                        break;
                    case '-':
                        btnMinus.PerformClick();
                        break;
                    case '*':
                        btnMultiply.PerformClick();
                        break;
                    case '/':
                        btnDivide.PerformClick();
                        break;
                    case '=':
                        btnEquals.PerformClick();
                        break;
                    default:
                        break;
                }
            }
            
        }

        /*********************************/
        /************ Events *************/
        /*********************************/

        private void menuStandard_Click(object sender, EventArgs e)
        {
            checkCalcType(menuStandard);
            visibleButtons(false);
            changeCalcType(menuStandard);
        }

        private void menuAdvanced_Click(object sender, EventArgs e)
        {
            checkCalcType(menuAdvanced);
            visibleButtons(true);
            changeCalcType(menuAdvanced);
        }

        private void menuScientific_Click(object sender, EventArgs e)
        {
            checkCalcType(menuScientific);
            visibleButtons(true);
            changeCalcType(menuScientific);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkCalcType(menuStandard);
            visibleButtons(false);
            changeCalcType(menuStandard);
            lblHistory.Text = "";
            tbDisplay2.Clear();
            btnEquals.Select();
        }

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            lblHistory.Text = "";
            tbDisplay2.Clear();
            btnEquals.Focus();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "1";
            btnEquals.Focus();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "2";
            btnEquals.Focus();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "3";
            btnEquals.Focus();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "4";
            btnEquals.Focus();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "5";
            btnEquals.Focus();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "6";
            btnEquals.Focus();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "7";
            btnEquals.Focus();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "8";
            btnEquals.Focus();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            tbDisplay2.Text += "9";
            btnEquals.Focus();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            btnEquals.Focus();
            if (tbDisplay2.Text == "")
            {
                tbDisplay2.Text = "0";
            } else if (tbDisplay2.Text.Substring(0, 1) == "0")
            {
                // Do Nothing
            }
            else
            {
                tbDisplay2.Text += "0";
            }
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            btnEquals.Focus();
            if (tbDisplay2.Text != null)
            {
                tbDisplay2.Text += "00";
            }
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            btnEquals.Focus();

            if (tbDisplay2.Text == "")
            {
                tbDisplay2.Text += "0.";
            }
            else if (tbDisplay2.Text.Contains("."))
            {
                
            } else
            {
                tbDisplay2.Text += ".";
            }
        }

        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            btnEquals.Focus();
            
            if (tbDisplay2.TextLength == tbDisplay2.MaxLength)
            {
                //Do Nothing

            } else if (tbDisplay2.Text == "")
            {
                tbDisplay2.Text = "-";

            } else
            {
                switch (tbDisplay2.Text.Substring(0, 1))
                {
                    case "-":
                        tbDisplay2.Text = tbDisplay2.Text.Substring(1/*, tbDisplay2.Text.Length - 1*/);
                        break;
                    default:
                        tbDisplay2.Text = "-" + tbDisplay2.Text;
                        break;
                }

            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            btnEquals.Focus();

            // If (1) tbDisplay is blank and the cbHistory text is blank or (2) there's a "+" at the end of tbDisplay, do nothing
            if (tbDisplay2.Text == "" && lblHistory.Text == "")
            {
                
            }
            // If lblHistory has an operator at the end of it that isn't a "+", change it
            else if ((opSign == '@' || opSign != '+') && strFirstNum != "")
            {
                changeOperator('+');
            }
            // If tbDisplay is blank, but the cbHistory text isn't, and "+" is entered, move the result to the tbDisplay and add a "+"
            else if ((tbDisplay2.Text != "" && opSign == '@') || strFirstNum == "")
            {
                if (lblHistory.Text.IndexOf('=').ToString() != "-1" || lblHistory.Text == lastResult.ToString())
                {
                    if (tbDisplay2.Text == "")
                    {
                        dblFirstNum = lastResult;
                        strFirstNum = Convert.ToString(lastResult);

                        changeOperator('+');
                        lblHistory.Text = dblFirstNum + " " + opSign + " ";
                    } else
                    {
                        strFirstNum = tbDisplay2.Text;
                        dblFirstNum = Convert.ToDouble(strFirstNum);

                        changeOperator('+');
                    }

                } else
                {
                    strFirstNum = tbDisplay2.Text;
                    dblFirstNum = Convert.ToDouble(strFirstNum);

                    changeOperator('+');
                }
            }
            else if ((tbDisplay2.Text != "" && lblHistory.Text != "") || Convert.ToChar(lblHistory.Text.Substring(lblHistory.Text.Length - 2, 1)) == '+')
            {
                strSecNum = tbDisplay2.Text;
                dblSecNum = Convert.ToDouble(strSecNum);

                opSign = '+';
                    
                getResult(dblFirstNum, dblSecNum, opSign);
                clearNumbers();

                dblFirstNum = lastResult;
                strFirstNum = Convert.ToString(lastResult);
                changeOperator('+');
            }

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            btnEquals.Focus();

            // If (1) tbDisplay is blank and the cbHistory text is blank or (2) there's a "+" at the end of tbDisplay, do nothing
            if (tbDisplay2.Text == "" && lblHistory.Text == "")
            {

            }
            // If lblHistory has an operator at the end of it that isn't a "+", change it
            else if ((opSign == '@' || opSign != '-') && strFirstNum != "")
            {
                changeOperator('-');
            }
            // If tbDisplay is blank, but the cbHistory text isn't, and "+" is entered, move the result to the tbDisplay and add a "+"
            else if ((tbDisplay2.Text != "" && opSign == '@') || strFirstNum == "")
            {
                if (lblHistory.Text.IndexOf('=').ToString() != "-1" || lblHistory.Text == lastResult.ToString())
                {
                    if (tbDisplay2.Text == "")
                    {
                        dblFirstNum = lastResult;
                        strFirstNum = Convert.ToString(lastResult);

                        changeOperator('-');
                        lblHistory.Text = dblFirstNum + " " + opSign + " ";
                    }
                    else
                    {
                        strFirstNum = tbDisplay2.Text;
                        dblFirstNum = Convert.ToDouble(strFirstNum);

                        changeOperator('-');
                    }

                }
                else
                {
                    strFirstNum = tbDisplay2.Text;
                    dblFirstNum = Convert.ToDouble(strFirstNum);

                    changeOperator('-');
                }
            }
            else if ((tbDisplay2.Text != "" && lblHistory.Text != "") || Convert.ToChar(lblHistory.Text.Substring(lblHistory.Text.Length - 2, 1)) == '-')
            {
                strSecNum = tbDisplay2.Text;
                dblSecNum = Convert.ToDouble(strSecNum);

                opSign = '-';

                getResult(dblFirstNum, dblSecNum, opSign);
                clearNumbers();

                dblFirstNum = lastResult;
                strFirstNum = Convert.ToString(lastResult);
                changeOperator('-');
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            btnEquals.Focus();

            // If (1) tbDisplay is blank and the cbHistory text is blank or (2) there's a "+" at the end of tbDisplay, do nothing
            if (tbDisplay2.Text == "" && lblHistory.Text == "")
            {

            }
            // If lblHistory has an operator at the end of it that isn't a "+", change it
            else if ((opSign == '@' || opSign != '*') && strFirstNum != "")
            {
                changeOperator('*');
            }
            // If tbDisplay is blank, but the cbHistory text isn't, and "+" is entered, move the result to the tbDisplay and add a "+"
            else if ((tbDisplay2.Text != "" && opSign == '@') || strFirstNum == "")
            {
                if (lblHistory.Text.IndexOf('=').ToString() != "-1" || lblHistory.Text == lastResult.ToString())
                {
                    if (tbDisplay2.Text == "")
                    {
                        dblFirstNum = lastResult;
                        strFirstNum = Convert.ToString(lastResult);

                        changeOperator('*');
                        lblHistory.Text = dblFirstNum + " " + opSign + " ";
                    }
                    else
                    {
                        strFirstNum = tbDisplay2.Text;
                        dblFirstNum = Convert.ToDouble(strFirstNum);

                        changeOperator('*');
                    }

                }
                else
                {
                    strFirstNum = tbDisplay2.Text;
                    dblFirstNum = Convert.ToDouble(strFirstNum);

                    changeOperator('*');
                }
            }
            else if ((tbDisplay2.Text != "" && lblHistory.Text != "") || Convert.ToChar(lblHistory.Text.Substring(lblHistory.Text.Length - 2, 1)) == '*')
            {
                strSecNum = tbDisplay2.Text;
                dblSecNum = Convert.ToDouble(strSecNum);

                opSign = '*';

                getResult(dblFirstNum, dblSecNum, opSign);
                clearNumbers();

                dblFirstNum = lastResult;
                strFirstNum = Convert.ToString(lastResult);
                changeOperator('*');
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            btnEquals.Focus();

            // If (1) tbDisplay is blank and the cbHistory text is blank or (2) there's a "+" at the end of tbDisplay, do nothing
            if (tbDisplay2.Text == "" && lblHistory.Text == "")
            {

            }
            // If lblHistory has an operator at the end of it that isn't a "+", change it
            else if ((opSign == '@' || opSign != '/') && strFirstNum != "")
            {
                changeOperator('/');
            }
            // If tbDisplay is blank, but the cbHistory text isn't, and "+" is entered, move the result to the tbDisplay and add a "+"
            else if ((tbDisplay2.Text != "" && opSign == '@') || strFirstNum == "")
            {
                if (lblHistory.Text.IndexOf('=').ToString() != "-1" || lblHistory.Text == lastResult.ToString())
                {
                    if (tbDisplay2.Text == "")
                    {
                        dblFirstNum = lastResult;
                        strFirstNum = Convert.ToString(lastResult);

                        changeOperator('/');
                        lblHistory.Text = dblFirstNum + " " + opSign + " ";
                    }
                    else
                    {
                        strFirstNum = tbDisplay2.Text;
                        dblFirstNum = Convert.ToDouble(strFirstNum);

                        changeOperator('/');
                    }

                }
                else
                {
                    strFirstNum = tbDisplay2.Text;
                    dblFirstNum = Convert.ToDouble(strFirstNum);

                    changeOperator('/');
                }
            }
            else if ((tbDisplay2.Text != "" && lblHistory.Text != "") || Convert.ToChar(lblHistory.Text.Substring(lblHistory.Text.Length - 2, 1)) == '/')
            {
                strSecNum = tbDisplay2.Text;
                dblSecNum = Convert.ToDouble(strSecNum);

                opSign = '/';

                getResult(dblFirstNum, dblSecNum, opSign);
                clearNumbers();

                dblFirstNum = lastResult;
                strFirstNum = Convert.ToString(lastResult);
                changeOperator('/');
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblHistory.Text = "";
            tbDisplay2.Text = null;

            clearNumbers();
            btnEquals.Focus();
        }
        
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (tbDisplay2.Text != "" && lblHistory.Text != "" && opSign != '@')
            {
                strSecNum = tbDisplay2.Text;
                dblSecNum = Convert.ToDouble(strSecNum);
                getResult(dblFirstNum, dblSecNum, opSign);
                clearNumbers();
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            
            determineKeyPress(e.KeyChar);
        }

        private void tbDisplay2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn0_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btn00_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnPlus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnMinus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnMultiply_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnDivide_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnClear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnEquals_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnMemPlus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnMemRecall_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnMemClear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnMemMinus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnSquared_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnAllClear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnSqRoot_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void btnPosNeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            determineKeyPress(e.KeyChar);

            this.Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 frmAbout = new AboutBox1();
            frmAbout.Show();
        }
    }
}
