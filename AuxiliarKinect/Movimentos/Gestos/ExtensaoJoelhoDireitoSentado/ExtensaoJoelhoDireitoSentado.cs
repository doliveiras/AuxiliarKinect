﻿using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.ExtensaoJoelhoDireitoSentado
{
    public class ExtensaoJoelhoDireitoSentado : Gesto
    {
        public ExtensaoJoelhoDireitoSentado()
        {
            InicializaQuadrosChave();
            Nome = "ExtensaoJoelhoDireitoSentado";
            ContadorQuadros = 0;
            QuadroChaveAtual = QuadrosChave.First;
        }

        private void InicializaQuadrosChave()
        {
            QuadrosChave = new LinkedList<GestoQuadroChave>();
            QuadrosChave.AddFirst(new GestoQuadroChave(new JoelhoDireitoReto(), 0, 1));
            QuadrosChave.AddLast(new GestoQuadroChave(new JoelhoDireitoEsticado(), 20, 80));
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
