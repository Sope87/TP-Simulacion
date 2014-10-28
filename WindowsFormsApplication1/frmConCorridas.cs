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
    public partial class frmConCorridas : Form
    {


        IList<MAIN> colMain;
        double demoraProm = 0;
        double varianza = 0;
        public frmConCorridas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int w = 0; w < 5; w++)
            {
                chart1.Series[w].Points.Clear();
            }

            int cnatCorridas= Convert.ToInt32(txtCantidaddecorridas.Text);
            colMain = new List<MAIN>();
            for (int p = 0; p < cnatCorridas; p++)
            {

                MAIN mm1 = new MAIN();

                mm1.inizialisacion(Convert.ToDouble(txtLamda.Text.Trim()), Convert.ToDouble(txtMu.Text.Trim()), true);
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

          
                

                    double tiempo_cola = 0;



                    for (int i = 0; i < mm1.getC_Partida(); i++)
                    {
                        tiempo_cola += mm1.getT_Cola()[i];
                    }

                    tiempo_cola = tiempo_cola / mm1.getCli_At();


                    double t_servicio = 0;

                    for (int i = 0; i < mm1.getCli_At(); i++)
                    {
                        t_servicio += mm1.getTiempoServicio()[i, 1];
                    }

                    t_servicio = (t_servicio / mm1.getCli_At()) + tiempo_cola;
                    mm1.promTiempoDeServicio = t_servicio;
                    demoraProm += t_servicio;

                   
                

                colMain.Add(mm1);
            }

            //double[,] matriz = mm1.getMatrizQ();
            //mm1.getrand();
          
            //double sOcupado = mm1.acumSO;
            //double ios = mm1.ios;
            //if (mm1.n > 0)
            //    sOcupado += mm1.getReloj() - ios;









            demoraProm = demoraProm / colMain.Count;
            double acumVar = 0;
            foreach (MAIN col in colMain)
            {
                acumVar += ((col.promTiempoDeServicio - demoraProm) * (col.promTiempoDeServicio - demoraProm));
            }
            varianza = acumVar / (colMain.Count-1);


            // calculo el tiempo promedio de servicio
          
           
            int[] ks = new int[5];
            ks[0] = Convert.ToInt32(txtParametroDespla1.Text);
            ks[1] = Convert.ToInt32(txtParametroDespla2.Text);
            ks[2] = Convert.ToInt32(txtParametroDespla3.Text);
            ks[3] = Convert.ToInt32(txtParametroDespla4.Text);
            ks[4] = Convert.ToInt32(txtParametroDespla5.Text);
            
            for (int p = 0; p < 5; p++)
            {
               double acumK = 0;
                for (int i = ks[p]; i < colMain.Count; i++)
                {
                    acumK += (((colMain[i - ks[p]].promTiempoDeServicio - demoraProm) * (colMain[i].promTiempoDeServicio - demoraProm))/colMain.Count) / varianza;
                    chart1.Series[p].Points.AddXY(Convert.ToDouble(i), acumK);
                }
                acumK = acumK * (1 / (colMain.Count - 1));
            }

        }
    }
}
