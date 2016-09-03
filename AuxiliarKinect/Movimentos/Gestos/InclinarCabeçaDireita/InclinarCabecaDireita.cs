using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.InclinarCabeçaDireita
{
    class InclinarCabecaDireita: Gesto
    {
        public InclinarCabecaDireita()
        {
            InicializaQuadrosChave();
            Nome = "InclinarCabecaDireita";
            ContadorQuadros = 0;
            QuadroChaveAtual = QuadrosChave.First;
        }

        private void InicializaQuadrosChave()
        {
            QuadrosChave = new LinkedList<GestoQuadroChave>();
            QuadrosChave.AddFirst(new GestoQuadroChave(new CabecaAcimaPescoco(), 0, 1));
            QuadrosChave.AddLast(new GestoQuadroChave(new CabecaDireitaPescoco(), 30, 80));
            InicializaHistorico();
        }

        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            EstadoRastreamento estado = QuadroChaveAtual.Value.PoseChave.Rastrear(esqueletoUsuario);
            if (estado != EstadoRastreamento.NaoIdentificado) Console.WriteLine(estado);
            return estado == EstadoRastreamento.Identificado;
        }

        protected void InicializaHistorico()
        {
            historico = new List<Skeleton>();
        }
    }
}
