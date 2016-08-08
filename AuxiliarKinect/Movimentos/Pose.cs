using AuxiliarKinect.FuncoesBasicas;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos
{
    public abstract class Pose : Movimento
    {
        protected int QuadroIdentificacao { get; set; }

        public override EstadoRastreamento Rastrear(Skeleton esqueletoUsuario)
        {
            EstadoRastreamento novoEstado; 

            if (esqueletoUsuario != null && PosicaoValida(esqueletoUsuario))
            {
                //if(historico != null) historico.Add(esqueletoUsuario);
                if(QuadroIdentificacao == ContadorQuadros)
                {
                   // printHistorico();
                    novoEstado = EstadoRastreamento.Identificado;
                    ContadorQuadros++;
                }

                else
                {
                    novoEstado = EstadoRastreamento.EmExecucao;
                    ContadorQuadros+= 1;
                }
            }

            else
            {
               // printHistorico();
                novoEstado = EstadoRastreamento.NaoIdentificado;
                ContadorQuadros = 0;
            }

            return novoEstado;
        }

        public int PercentualProgresso
        {
            get
            {
                return ContadorQuadros * 100 / QuadroIdentificacao;
            }
        }

        public void printHistorico()
        {
            Worker w = new Worker();
            w.setEsqueleto(historico);
            Thread workerThread = new Thread(w.DoWork);
            workerThread.Start();

            while (!workerThread.IsAlive) ;
            Thread.Sleep(1);
        }
    }
}
