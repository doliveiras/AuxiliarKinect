using AuxiliarKinect.FuncoesBasicas;
using Microsoft.Kinect;

namespace AuxiliarKinect.Movimentos.Gestos.ExtensaoJoelhoDireitoSentado
{
    class JoelhoDireitoReto : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            double margemErroPosicao = 0.30;

            Joint joelhoDireito = esqueletoUsuario.Joints[JointType.KneeRight];

            Joint tornozeloDireito = esqueletoUsuario.Joints[JointType.AnkleRight];

            bool joelhoPe90Graus = Util.CompararComMargemErro(margemErroPosicao, joelhoDireito.Position.X, tornozeloDireito.Position.X);

            bool joelhoTornozeloAlinhado = Util.CompararComMargemErro(margemErroPosicao, joelhoDireito.Position.Z, tornozeloDireito.Position.Z);

            return joelhoPe90Graus && joelhoTornozeloAlinhado;
        }
    }
}
