using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{


    class MAIN
    {
        double reloj;
       public double n; // clientes en cola
        int cli_at; // cantidad de clientes atendidos
        bool sOcupado; // estado del servidor
        double dq, db, dd; // diferenciales
        double[,] m_dq = new double[50000, 2];
        double tue; // tiempo de ultimo evento
        double ta; // vector de tiempo de arribo
       public double ios; // inicio de ocupacion del servidor
        double[] listEvent = new double[2]; // 0 Arribo , 1 Partida , se llena con tiempo
        int c_mdq;
        double[,] rand = new double[50000, 2];// 0 arribo 1 serv
        double lamda = 0.0;
        double mu = 0.0;
        public static Random randomTiempos = new Random();
        int rand1, rand2;
        Boolean constante = false;
        public double acumSO = 0; // acumulador de ocupacio del servidor
        public int acumN = 0; // acumulador de gente en el sistema
        public double tiempocola; // tiempo promedio en cola
        double[] a_cola = new double[50000]; // valor del reloj cuando se produce un arribo
        double[] t_cola = new double[50000]; // tiempo en cola que estuvo ese cliente( reloj - a_cola[partidas] - tiempo_servicio)
        public int c_partida; // cantidad de partidas, lo uso de indice para el array de tiempos en cola
        public int c_arribo; // cantidad de arrbios, indice para el array de arribos
        double[] t_servicio;// array de tiempos de servicio para dp sacar el promedio
         

        

        // Limpia todas las variables globales
        public void inizialisacion(double lamdaS, double muS, Boolean esConstante)
        {
            rand2 = 0;
            rand1 = 0;
            reloj = 0;
            n = 0;
            cli_at = 0;
            sOcupado = false;
            tiempocola = 0;
            c_arribo = 0;
            c_partida = 0;
            
            dq = 0;
            db = 0;
            dd = 0;
            tue = 0;
            ta = 0;
            ios = 0;
            c_mdq = 0;
            mu = muS;
            lamda = lamdaS;
            guardarListaEventos(0, generarArribo());
            guardarListaEventos(1, 10000000);
            constante = esConstante;
        }

        public double generarArribo()
        {
            // devuelve un numero entre 0 y 30, que representa el arribo de una persona
            double dev1 = 0;
            if (constante)
            {

                double log = Math.Log(randomTiempos.NextDouble(), Math.E);
                double lamdac = (1 / lamda);
                dev1 = (-1) * (log * lamdac);
            }
            else
                dev1 = randomTiempos.Next(2, 5);
            //double log = Math.Log(dev, 2);
            //double lamdac = (1 / lamda);
            //double tiempoArribo = lamdac * log;
            //double tiempoArribo = lamdac;
            //modelo estacionario

            double tiempoArribo = dev1;
            //matriz para ver los random q van saliendo
            rand[rand1, 0] = tiempoArribo;
            rand1++;
            return tiempoArribo;


        }

        public double generarTiempoServicio()
        {
            double dev1 = 0;
            // devuelve un numero entre 0 y 10, que representa el tiempo que tardo en atenderlo 
            if (constante)
            {
                double log = Math.Log(randomTiempos.NextDouble(), Math.E);
                double muc = (1 / mu );
                dev1 = (-1) *  (log*muc);
                
            }
            else
                dev1 = randomTiempos.Next(2, 5);
            // reever el -1 con Lara    
            //double tiempoServicio =  1 * (1 / mu) * (Math.Log(dev1, 2));
            //matriz para ver los random q van saliendo
            double tiempoServicio = dev1;
            rand[rand2, 1] = tiempoServicio;

            rand2++;

            

            return tiempoServicio;
        }

        public void guardarListaEventos(int evento, double tiempo)
        {

            listEvent[evento] = tiempo;

        }

        public double tiempos()
        {

            int rta = -1;
            if (listEvent[0] >= listEvent[1])
            {
                //Hay un partida
                rta = 1;
                reloj = listEvent[1];
            }
            else
            {
                //Hay una arribo
                rta = 0;
                reloj = listEvent[0];
            }

            return rta;
        }

        public void arribo()
        {

            if (sOcupado == false)
            {
                sOcupado = true;
               
                ios = reloj;
               
                cli_at++;

               
                guardarListaEventos(1, (generarTiempoServicio() + reloj));

            }
            else
            {
                a_cola[c_arribo] = reloj;
                n++;
                acumN++;
                //acumN += Convert.ToInt32(n);
                m_dq[c_mdq, 0] = reloj - (reloj - tue);
                m_dq[c_mdq, 1] = n;
                c_mdq++;
                c_arribo++;

                

                dq = dq + ((reloj - tue) * n);
                // ver que hacer con el ta.(preguntar)
            }

            guardarListaEventos(0, (generarArribo() + reloj));
            tue = reloj;

        }

        public void partida()
        {
            if (n > 0)
            {
                cli_at++;
                t_cola[c_partida] = reloj - a_cola[c_partida];
                c_partida++;
                guardarListaEventos(1, (generarTiempoServicio() + reloj));
                dd = dd + (reloj - ta);
                dq = dq + ((reloj - tue) * n);
                n--;
                //acumN += Convert.ToInt32(n);
                
                m_dq[c_mdq, 0] = reloj - (reloj - tue);
                m_dq[c_mdq, 1] = n;
                c_mdq++;
                
                
                

            }
            else
            {
                sOcupado = false;
                acumSO += reloj - ios;
                guardarListaEventos(1, 100000000);
                db = db + (reloj - ios);
            }

            tue = reloj;
        }



        #region Prop

        public double getReloj()
        {
            return reloj;
        }

        public decimal getB()
        {
            // Promedio de demora
            return Convert.ToDecimal(db / reloj);
        }

        public double[,] getMatrizQ()
        {
            return m_dq;
        }

        public double getTue()
        {
            return tue;
        }
        public double[,] getrand()
        {
            return rand;
        }
        public int getContMdq()
        {
            return c_mdq;
        }
        #endregion

        public double [] getT_Cola()
        {
            return t_cola;
        }

        public int getC_Arribo()
        {
            return c_arribo;
        }
        public int getC_Partida()
        {
            return c_partida;
        }

        public int getCli_At()
        {
            return cli_at;
        }

        public double[,] getTiempoServicio()
        {
            return rand;
        }

        public double promTiempoDeServicio { get; set; }
        //public double demPromedio { get; set; }
    }


}
