using AuxiliarKinect.FuncoesBasicas;
using Microsoft.Kinect;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AuxiliarKinect.Movimentos.Gestos.Aceno
{
    public class Aceno : Gesto
    {
        public Aceno()
        {
            InicializaQuadrosChave();
            Nome = "Aceno";
            ContadorQuadros = 0;
            QuadroChaveAtual = QuadrosChave.First;
        }

        private void InicializaQuadrosChave()
        {
            QuadrosChave = new LinkedList<GestoQuadroChave>();
            QuadrosChave.AddFirst(new GestoQuadroChave(new AcenoMaoAposCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoSobreCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAntesCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoSobreCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAposCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoSobreCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAntesCotovelo(), 1, 25));
            InicializaHistorico();
        }

        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            EstadoRastreamento estado = QuadroChaveAtual.Value.PoseChave.Rastrear(esqueletoUsuario);
            if (inExecution && estado == EstadoRastreamento.Identificado)
            {
                Worker workerObject = new Worker();
                //Jogar Lista de esqueletos para ser processada
                workerObject.setEsqueletos(historico);

                Thread workerThread = new Thread(workerObject.DoWork);

                //Iniciar thread
                workerThread.Start();
                while (!workerThread.IsAlive);
                Thread.Sleep(1);
                workerObject.RequestStop();
                workerThread.Join();

            }
            return estado == EstadoRastreamento.Identificado;
        }

        protected void InicializaHistorico()
        {
            historico = new List<Skeleton>();
        }
    }
}
