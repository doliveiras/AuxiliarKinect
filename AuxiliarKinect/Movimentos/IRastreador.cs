using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos
{
    public interface IRastreador

    {
        //Método rastrear 
        void Rastrear(Skeleton esqueletoUsuario);

        //Estado atual do rastreamento (enum)
        EstadoRastreamento EstadoAtual { get; }
    }
}
