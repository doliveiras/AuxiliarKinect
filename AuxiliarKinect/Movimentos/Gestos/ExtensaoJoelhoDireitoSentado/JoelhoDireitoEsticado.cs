using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using AuxiliarKinect.FuncoesBasicas;

namespace AuxiliarKinect.Movimentos.Gestos.ExtensaoJoelhoDireitoSentado
{
    class JoelhoDireitoEsticado : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            double margemErroPosicao = 0.20;

            Joint joelhoDireito = esqueletoUsuario.Joints[JointType.KneeRight];

            Joint tornozeloDireito = esqueletoUsuario.Joints[JointType.AnkleRight];

            bool joelhoPeReto = Util.CompararComMargemErro(margemErroPosicao, joelhoDireito.Position.Y, tornozeloDireito.Position.Y);

            bool tornozeloFrenteJoelho = tornozeloDireito.Position.Z < joelhoDireito.Position.Z;

            bool tornozeloAlinhadoJoelho = Util.CompararComMargemErro(margemErroPosicao, joelhoDireito.Position.X, tornozeloDireito.Position.X);

            return joelhoPeReto && tornozeloFrenteJoelho && tornozeloAlinhadoJoelho;
        }
    }
}
