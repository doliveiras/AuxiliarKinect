using AuxiliarKinect.FuncoesBasicas;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.InclinarCabeçaDireita
{
    class CabecaDireitaPescoco : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            double margemErroPosicao = 0.20;

            Joint cabeca = esqueletoUsuario.Joints[JointType.Head];

            Joint pescoco = esqueletoUsuario.Joints[JointType.ShoulderCenter];

            return cabeca.Position.X < pescoco.Position.X;
        }

    }
}
