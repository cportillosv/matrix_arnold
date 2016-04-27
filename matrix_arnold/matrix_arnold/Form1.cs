using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matrix_arnold
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Validando que no vaya vacio
            if (string.IsNullOrEmpty(txtNum1.Text.Trim()))
            {
                MessageBox.Show("Digite un valor en N1");
            }
            else if (string.IsNullOrEmpty(txtNum2.Text.Trim()))
            {
                MessageBox.Show("Digite un valor en N2");
            }
            else
            {
                int num1 = Convert.ToInt32(txtNum1.Text);
                int num2 = Convert.ToInt32(txtNum2.Text);
                
                int last=0;
                //i= filas
                for (int i = 0; i < num1; i++)
                {
                    //j = columnas
                    for (int j = 0; j < num2; j++)
                    {
                        NumericUpDown numeric = new NumericUpDown();
                        numeric.Name = string.Concat("numeric", i, j);
                        numeric.Width = 50;
                
                        flowLayoutPanel1.Controls.Add(numeric);
                        last = j;
                    }
                   
                    //Obtenemos la ultima instancia, del NumericUpDown creado.
                    NumericUpDown currentNumeric = this.Controls.Find(string.Concat("numeric", i, last), true).FirstOrDefault() as NumericUpDown;
                    //Asignamos un salto de linea en el control flowLayoutControl
                    flowLayoutPanel1.SetFlowBreak(currentNumeric,true);
                }

            }
        }

        private void txtNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Solamente para que permita numeros, si no cancela el evento
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
