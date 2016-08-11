using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace AuxiliarKinect.Movimentos.Gestos.AlavancaDeAntebracoDireito
{
    public class AlavancaDeAntebracoDireito : Gesto
    {
        public AlavancaDeAntebracoDireito()
        {
            InicializaQuadrosChave();
            Nome = "AlavancaDeAntebracoDireito";
            ContadorQuadros = 0;
            QuadroChaveAtual = QuadrosChave.First;
        }

        private void InicializaQuadrosChave()
        {
            QuadrosChave = new LinkedList<GestoQuadroChave>();
            QuadrosChave.AddFirst(new GestoQuadroChave(new AnteBracoDireitoDepois(), 0, 1));
            QuadrosChave.AddLast(new GestoQuadroChave(new AnteBracoDireitoMeio(), 15, 40));
            QuadrosChave.AddLast(new GestoQuadroChave(new AnteBracoDireitoAntes(), 15, 40));
            QuadrosChave.AddLast(new GestoQuadroChave(new AnteBracoDireitoMeio(), 15, 40));
            QuadrosChave.AddFirst(new GestoQuadroChave(new AnteBracoDireitoDepois(), 15, 25));
            InicializaHistorico();
        }

        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            EstadoRastreamento estado = QuadroChaveAtual.Value.PoseChave.Rastrear(esqueletoUsuario);
            return estado == EstadoRastreamento.Identificado;
        }

        protected void InicializaHistorico()
        {
            historico = new List<Skeleton>();
        }
    }
}
