﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace AuxiliarKinect.Movimentos
{
    public class Rastreador<T> : IRastreador where T : Movimento, new()
    {
        private T movimento;

        public EstadoRastreamento EstadoAtual { get; private set; }

        public event EventHandler MovimentoIdentificado;

        public event EventHandler MovimentoEmProgresso;

        public Rastreador()
        {
            EstadoAtual = EstadoRastreamento.NaoIdentificado;
            movimento = Activator.CreateInstance<T>();
        }

        public void Rastrear(Skeleton esqueletoUsuario)
        {
            EstadoRastreamento novoEstado = movimento.Rastrear(esqueletoUsuario);
            if (novoEstado == EstadoRastreamento.Identificado && EstadoAtual != EstadoRastreamento.Identificado)
            {
                EstadoAtual = EstadoRastreamento.Identificado;
                ChamarEvento(MovimentoIdentificado);
            }

            if (novoEstado == EstadoRastreamento.EmExecucao)
            {
                EstadoAtual = EstadoRastreamento.EmExecucao;
                ChamarEvento(MovimentoEmProgresso);
            } 
            

            if (EstadoAtual == EstadoRastreamento.NaoIdentificado)
            {
                EstadoAtual = EstadoRastreamento.NaoIdentificado;
                ChamarEvento(MovimentoEmProgresso);
            }
               
        }

        private void ChamarEvento(EventHandler evento)

        {
            if (evento != null) evento(movimento, new EventArgs());
        }
    }
}
