using Microsoft.Kinect;
using System.Collections.Generic;
using System.Linq;

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
            historico = new List<Skeleton>();
        }

        private void InicializaQuadrosChave()
        {
            QuadrosChave = new LinkedList<GestoQuadroChave>();
            QuadrosChave.AddFirst(new GestoQuadroChave(new AcenoMaoAposCotovelo(), 0,0));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoSobreCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAntesCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoSobreCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAposCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoSobreCotovelo(), 1, 25));
            QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAntesCotovelo(), 15, 25));
        }

        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            EstadoRastreamento estado = QuadroChaveAtual.Value.PoseChave.Rastrear(esqueletoUsuario);
            if (historico.Count != 0 && estado != EstadoRastreamento.EmExecucao)
            {
                foreach (Skeleton skeleton in historico)
                {
                    JointCollection joint = skeleton.Joints;
                    foreach (Joint j in joint)
                    {
                        System.Console.WriteLine(j.JointType + " X : " + j.Position.X);
                        System.Console.WriteLine(j.JointType + " X : " + j.Position.Y);
                        System.Console.WriteLine(j.JointType + " X : " + j.Position.Z);
                    }


                }
                historico.Clear();
            }
            return estado == EstadoRastreamento.Identificado;
        }
    }
}
