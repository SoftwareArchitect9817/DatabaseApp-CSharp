


using System;

using System.Windows.Forms;


namespace Senaka
{
    public partial class BayCalculatorForm : Form
    {
        private double m_longBase;
        private double m_shortBase;
        private double m_leftLeg;
        private double m_rightLeg;
        private double m_height;
        private double alpha;
        private double beta;
        private double delta;
        private double gamma;
        public BayCalculatorForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))&& !(textBox.TextLength>0 && e.KeyChar=='.') )
            {
                e.Handled = true;
            }
        }
        private void BayCalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
           // string a = "", b = "", c = "", d = "";
              if (textBoxSideA.Text != "" && textBoxSideB.Text != "" && textBoxSideC.Text != "" && textBoxSideD.Text != "")
              {
                  double a = double.Parse(textBoxSideA.Text), b = float.Parse(textBoxSideB.Text), c = float.Parse(textBoxSideC.Text), d = float.Parse(textBoxSideD.Text);
                  m_longBase = Math.Abs(a);
                  m_shortBase = Math.Abs(c);
                  m_leftLeg = Math.Abs(b);
                  m_rightLeg = Math.Abs(d);
                  m_height = GetHeight();
                  alpha = GetRightBaseDegreeAngle();
                  beta = GetLeftBaseDegreeAngle();
                  delta = 180 - alpha;
                  gamma = 180 - beta;
                  textBoxAlpha.Text = Math.Round(alpha,3).ToString();
                  textBoxBeta.Text = Math.Round(beta,3).ToString();
                  textBoxDelta.Text = Math.Round(delta,3).ToString();
                  textBoxGamma.Text = Math.Round(gamma,3).ToString();
                  textBoxHeight.Text = Math.Round(m_height,3).ToString();
                  double area = (m_shortBase + m_longBase) * m_height / 2;
                  textBoxArea.Text = Math.Round(area,3).ToString();

              }
              else if (textBoxAlpha.Text != "" && textBoxBeta.Text != "")
              {
                  alpha = Math.Round(float.Parse(textBoxAlpha.Text),3);
                  beta = Math.Round(float.Parse(textBoxBeta.Text), 3);
                  delta = 180 - alpha;
                  gamma = 180 - beta;
                  calculator();


              }
              else if (textBoxAlpha.Text != "" && textBoxGamma.Text != "")
              {
                  alpha = Math.Round(float.Parse(textBoxAlpha.Text), 3);
                  gamma = Math.Round(float.Parse(textBoxGamma.Text), 3);
                  delta = 180 - alpha;
                  beta = 180 - gamma;
                  calculator();
              }
              else if (textBoxDelta.Text != "" && textBoxBeta.Text != "")
              {
                  delta = Math.Round(float.Parse(textBoxDelta.Text), 3);
                  beta = Math.Round(float.Parse(textBoxBeta.Text), 3);
                  alpha = 180 - delta;
                  gamma = 180 - beta;
                  calculator();
              }
              else if (textBoxDelta.Text != "" && textBoxGamma.Text != "")
              {
                  delta = Math.Round(float.Parse(textBoxDelta.Text), 3);
                  gamma = Math.Round(float.Parse(textBoxGamma.Text), 3);
                  alpha = 180 - delta;
                  beta = 180 - gamma;
                  calculator();
              }
              else MessageBox.Show("Please enter more data");
           
        }
       
        public static double ConvertDegreesToRadians(double degrees)
        {
            double radians = (Math.PI / 180) * degrees;
            return (radians);
        }
        private void calculator() {
            if (textBoxSideA.Text != "" && textBoxSideB.Text != "")
            {
                double a = double.Parse(textBoxSideA.Text), b = float.Parse(textBoxSideB.Text);

                m_height = b * Math.Sin(ConvertDegreesToRadians(beta));
                m_leftLeg = m_height / Math.Sin(ConvertDegreesToRadians(delta));
                m_shortBase = (a * Math.Sin(ConvertDegreesToRadians(alpha)) - b * Math.Sin(ConvertDegreesToRadians(180 - alpha - beta))) / Math.Sin(ConvertDegreesToRadians(alpha));
                m_longBase = a;
                textBoxSideD.Text = Math.Round(m_leftLeg,3).ToString();
                textBoxSideC.Text = Math.Round(m_shortBase,3).ToString();

            }
            else if (textBoxSideB.Text != "" && textBoxSideC.Text != "")
            {
                double b = double.Parse(textBoxSideB.Text), c = float.Parse(textBoxSideC.Text);

                m_height = b * Math.Sin(ConvertDegreesToRadians(beta));
                m_leftLeg = m_height / Math.Sin(ConvertDegreesToRadians(delta));
                m_longBase = (b * Math.Sin(ConvertDegreesToRadians(180 - alpha - beta)) + c * Math.Sin(ConvertDegreesToRadians(alpha))) / Math.Sin(ConvertDegreesToRadians(alpha));
                textBoxSideD.Text = Math.Round(m_leftLeg,3).ToString();
                textBoxSideA.Text = Math.Round(m_longBase,3).ToString();
                m_shortBase = Math.Round(c, 3);

            }
            else if (textBoxSideC.Text != "" && textBoxSideD.Text != "")
            {
                double c = double.Parse(textBoxSideC.Text), d = float.Parse(textBoxSideD.Text);

                m_height = d * Math.Sin(ConvertDegreesToRadians(delta));

                m_rightLeg = m_height / Math.Sin(ConvertDegreesToRadians(beta));
                double b = m_rightLeg;
                m_longBase = (b * Math.Sin(ConvertDegreesToRadians(180 - alpha - beta)) + c * Math.Sin(ConvertDegreesToRadians(alpha))) / Math.Sin(ConvertDegreesToRadians(alpha));
                m_shortBase = Math.Round(c, 3);
                textBoxSideB.Text = Math.Round(m_rightLeg,3).ToString();
                textBoxSideA.Text = Math.Round(m_longBase,3).ToString();

            }
            else if (textBoxSideA.Text != "" && textBoxSideD.Text != "")
            {
                double a = double.Parse(textBoxSideA.Text), d = float.Parse(textBoxSideD.Text);

                m_height = d * Math.Sin(ConvertDegreesToRadians(delta));

                m_rightLeg = m_height / Math.Sin(ConvertDegreesToRadians(beta));
                double b = m_rightLeg;
                m_shortBase = (a * Math.Sin(ConvertDegreesToRadians(alpha)) - b * Math.Sin(ConvertDegreesToRadians(180 - alpha - beta))) / Math.Sin(ConvertDegreesToRadians(alpha)) ;
                m_longBase = Math.Round(a, 3);
                textBoxSideB.Text = Math.Round(m_rightLeg,3).ToString();
                textBoxSideC.Text = Math.Round(m_shortBase,3).ToString();

            }
            else if (textBoxSideA.Text != "" && textBoxSideC.Text != "")
            {
                double a = double.Parse(textBoxSideA.Text), c = float.Parse(textBoxSideC.Text);
                m_leftLeg = ((a * Math.Sin(ConvertDegreesToRadians(alpha)))-(c * (Math.Sin(ConvertDegreesToRadians(alpha))))) / Math.Sin(ConvertDegreesToRadians(180-alpha-beta));
               
                m_height = m_leftLeg * Math.Sin(ConvertDegreesToRadians(beta));

           
                double b = m_leftLeg;
                m_shortBase = (a * Math.Sin(ConvertDegreesToRadians(alpha)) - b * Math.Sin(ConvertDegreesToRadians(180 - alpha - beta))) / Math.Sin(ConvertDegreesToRadians(alpha));
                m_longBase = Math.Round(a, 3);
                m_rightLeg = m_height / Math.Sin(ConvertDegreesToRadians(beta));
                textBoxSideB.Text = Math.Round(m_leftLeg, 3).ToString();
                textBoxSideD.Text = Math.Round(m_rightLeg, 3).ToString();

            }
           


            /* else if (textBoxSideA.Text != "" && textBoxSideB.Text != "" && textBoxAlpha.Text != "" && textBoxGamma.Text != "")
             {
                 double a = double.Parse(textBoxSideA.Text), b = float.Parse(textBoxSideB.Text), alp = float.Parse(textBoxAlpha.Text), bet = float.Parse(textBoxBeta.Text);
                 alpha = float.Parse(textBoxAlpha.Text);
                 beta = Math.Round(float.Parse(textBoxBeta.Text), 3);
                 delta = 180 - alpha;
                 gamma = 180 - beta;
                 m_height = b * Math.Sin(ConvertDegreesToRadians(beta));
                 m_leftLeg = m_height / Math.Sin(ConvertDegreesToRadians(delta));
                 m_shortBase = (a * Math.Sin(ConvertDegreesToRadians(alpha)) - b * Math.Sin(ConvertDegreesToRadians(180 - alpha - beta))) / Math.Sin(ConvertDegreesToRadians(alpha));
                 textBoxSideD.Text = Math.Round(m_leftLeg,3).ToString();
                 textBoxSideC.Text = Math.Round(m_shortBase,3).ToString();
                 m_longBase = Math.Round(a, 3);
             }*/
            else MessageBox.Show("Please enter more data");
            double area = Math.Round((m_shortBase+m_longBase)*m_height/2, 3);
            textBoxArea.Text = area.ToString();
            textBoxAlpha.Text = Math.Round(alpha,3).ToString();
            textBoxBeta.Text = Math.Round(beta,3).ToString();
            textBoxDelta.Text = Math.Round(delta,3).ToString();
            textBoxGamma.Text = Math.Round(gamma,3).ToString();
            textBoxHeight.Text = Math.Round(m_height,3).ToString();
        }
       
        private double GetRightSmallBase()
        {
            return (Math.Pow(m_rightLeg, 2.0) - Math.Pow(m_leftLeg, 2.0) + Math.Pow(m_longBase, 2.0) + Math.Pow(m_shortBase, 2.0) - 2 * m_shortBase * m_longBase) / (2 * (m_longBase - m_shortBase));
        }

        public double GetHeight()
        {
            double x = GetRightSmallBase();
            return Math.Sqrt(Math.Pow(m_rightLeg, 2.0) - Math.Pow(x, 2.0));
        }

        public double GetSquare()
        {
            return GetHeight() * m_longBase / 2.0;
        }

        public double GetLeftBaseRadianAngle()
        {
            double sinX = GetHeight() / m_leftLeg;
            return Math.Round(Math.Asin(sinX), 3);
        }

        public double GetRightBaseRadianAngle()
        {
            double x = GetRightSmallBase();
            double cosX = (Math.Pow(m_rightLeg, 2.0) + Math.Pow(x, 2.0) - Math.Pow(GetHeight(), 2.0)) / (2 * x * m_rightLeg);
            return Math.Round(Math.Acos(cosX), 3);
        }

        public double GetLeftBaseDegreeAngle()
        {
            double x = GetLeftBaseRadianAngle() * 180 / 3.14;
            return Math.Round(x, 3);
        }

        public double GetRightBaseDegreeAngle()
        {
            double x = GetRightBaseRadianAngle() * 180 / 3.14;
            return Math.Round(x, 3);
        }

    }
}
