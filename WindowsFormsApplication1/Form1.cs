using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MAIN mm1 = new MAIN();

            mm1.inizialisacion(Convert.ToDouble(txtLamda.Text.Trim()), Convert.ToDouble(txtMu.Text.Trim()), chkConstante.Checked);
            bool fin = false;

            int c_tiradas = 0;

            while (fin == false)
            {
                if (mm1.tiempos() == 0.0)
                {

                    mm1.getReloj();
                    mm1.getTue();
                    mm1.arribo();
                }
                else
                {
                    mm1.getReloj();
                    mm1.getTue();
                    mm1.partida();
                }

                if (mm1.getReloj() > Convert.ToInt32(textBox1.Text) || c_tiradas > Convert.ToInt32(textBox2.Text))
                {
                    fin = true;
                }
                c_tiradas++;

                mm1.getTue();
                mm1.getReloj();


            }


            double[,] matriz = mm1.getMatrizQ();
            mm1.getrand();
            txtPromN.Text = Convert.ToString(Math.Round( getPromGenteEnCola(mm1.acumN ,mm1.getCli_At()),2) );
            double sOcupado = mm1.acumSO;
            double ios = mm1.ios;
            if (mm1.n > 0)
                sOcupado +=mm1.getReloj()- ios  ;
            txtSO.Text = Convert.ToString(Math.Round (Convert.ToDecimal(sOcupado * 100) / Convert.ToDecimal(mm1.getReloj()),2));

            ////////////////Grafico
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = 0;

            this.chart1.Series[0].Points.AddXY(0, Convert.ToDouble(matriz[0, 1]));
            for (int i = 1; i < mm1.getContMdq() - 1; i++)
            {


                this.chart1.Series[0].Points.AddXY(Convert.ToDouble(matriz[i, 0]), Convert.ToDouble(matriz[i, 1]));

            }

            if (checkBox1.Checked)
            {
                chart2.Visible = true;

                chart2.Series[0].Points.Clear();
                double[,] matrizProm = calcularPromedioMatriz(matriz, mm1.getContMdq());
                this.chart2.Series[0].Points.AddXY(0, Convert.ToDouble(matriz[0, 1]));
                for (int i = 1; i < mm1.getContMdq() - 1; i++)
                {

                    this.chart2.Series[0].Points.AddXY(Convert.ToDouble(matriz[i, 0]), Convert.ToDouble(matrizProm[i, 1] ) / Convert.ToDouble(matriz[i, 0] ));
                }
            }
            else
            { chart2.Visible = false; }

            // calculo tiempo promedio esperado en cola por los clientes

            double tiempo_cola = 0;



            for (int i = 0; i < mm1.getC_Partida(); i++)
            {
                tiempo_cola += mm1.getT_Cola()[i];
            }

            tiempo_cola = tiempo_cola / mm1.getCli_At();

            this.txtTiempoCola.Text = tiempo_cola.ToString();

            // calculo el tiempo promedio de servicio

            double t_servicio = 0;
            
            for (int i = 0; i < mm1.getCli_At(); i++)
            {
                t_servicio += mm1.getTiempoServicio()[i, 1];
            }

            t_servicio = (t_servicio / mm1.getCli_At()) + tiempo_cola;

            this.txtTiempoServ.Text = t_servicio.ToString();



        }
        public double[,] calcularPromedioMatriz(double[,] m_mdq, int cant)
        {

            double[,] matrizProm = new double[cant, 2];
            for (int i = 0; i < cant - 1; i++)
            {//reloj
                if (i == 0)
                    matrizProm[i, 0] = m_mdq[i, 0];
                else
                    matrizProm[i, 0] = matrizProm[i - 1, 0] + m_mdq[i, 0];

                // N
                if (i == 0)
                    matrizProm[i, 1] = m_mdq[i, 1];
                else
                    matrizProm[i, 1] = matrizProm[i - 1, 1] + m_mdq[i, 1];


            }
            return matrizProm;
        }

        public decimal getPromGenteEnCola(int n, int tiradas)
        {
            decimal nProm = Convert.ToDecimal(n) / Convert.ToDecimal( tiradas );

            return nProm;
        }
    }
}
