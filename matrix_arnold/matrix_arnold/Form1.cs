using System;
using System.Data;
using System.Linq;
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
            //Removemos los controls previamente, generados
            this.flowLayoutPanel1.Controls.Clear();

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
                        numeric.Name = string.Concat(i,"-", j);
                        numeric.Width = 50;
                
                        flowLayoutPanel1.Controls.Add(numeric);
                        last = j;
                    }
                   
                    //Obtenemos la ultima instancia, del NumericUpDown creado.
                    NumericUpDown currentNumeric = this.Controls.Find(string.Concat(i,"-", last), true).FirstOrDefault() as NumericUpDown;
                    //Asignamos un salto de linea en el control flowLayoutControl
                    flowLayoutPanel1.SetFlowBreak(currentNumeric,true);
                }

                txtNum1.Enabled = false;
                txtNum2.Enabled = false;
                btnLeer.Enabled = true;
                btnGenerate.Enabled = false;
                btnReGenerar.Enabled = true;
                
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

        private void btnLeer_Click(object sender, EventArgs e)
        {
            int nRow;
            int nColum;

            //TODO: Asegurarse de que las cajas de texto tenga valores para crear la matriz
            if (int.TryParse(txtNum1.Text,out nRow) && int.TryParse(txtNum2.Text, out nColum))
            {


                var matrix = new decimal[nRow, nColum];
                var numerics = flowLayoutPanel1.Controls.OfType<NumericUpDown>();

                foreach (NumericUpDown ctrl in numerics)
                {

                    var indices = ctrl.Name.Split('-');
                    matrix[Convert.ToInt32(indices[0]),Convert.ToInt32(indices[1])] = ctrl.Value;
                        
                    
                }

               
                //Average (Media)
                decimal average;
                decimal total = matrix.Cast<decimal>().Sum();
                average = total / (nRow * nColum);
             
                //Average per row
                //decimal columTotal;
               
                //for (int row = 0; row < nRow; row++)
                //{
                //    columTotal = 0;
                //    for (int col = 0; col < nColum; col++)
                //    {
                //        columTotal += matrix[row, col];
                //    }

                //    average = columTotal / nColum;
                //}
                
            }
           

           
        }

        private void btnReGenerar_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            txtNum1.Enabled = true;
            txtNum2.Enabled = true;
            btnLeer.Enabled = false;
            btnGenerate.Enabled =true;
            btnReGenerar.Enabled = false;

        }
    }
}
