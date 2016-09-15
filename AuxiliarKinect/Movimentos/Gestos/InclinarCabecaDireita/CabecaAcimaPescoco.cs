using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using AuxiliarKinect.FuncoesBasicas;

namespace AuxiliarKinect.Movimentos.Gestos.InclinarCabeçaDireita
{
    class CabecaAcimaPescoco: Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            double margemErroPosicao = 0.20;

            Joint cabeca = esqueletoUsuario.Joints[JointType.Head];

            Joint pescoco = esqueletoUsuario.Joints[JointType.ShoulderCenter];

            return Util.CompararComMargemErro(margemErroPosicao, cabeca.Position.X, pescoco.Position.X); ;
        }

    }
}
