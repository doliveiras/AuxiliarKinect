using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using AuxiliarKinect.FuncoesBasicas;

namespace AuxiliarKinect.Movimentos.Gestos.AlavancaDeAntebracoDireito
{
    public class AnteBracoDireitoAntes : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            const double ANGULO_ESPERADO = 50;
            double margemErroPosicao = 0.30;
            double margemErroAngulo = 10;

            Joint pulsoDireito = esqueletoUsuario.Joints[JointType.WristRight];
            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];
            Joint ombroDireito = esqueletoUsuario.Joints[JointType.ShoulderRight];
            Joint cotoveloDireito = esqueletoUsuario.Joints[JointType.ElbowRight];
            Joint ombroCentro = esqueletoUsuario.Joints[JointType.ShoulderCenter];
            Joint espinha = esqueletoUsuario.Joints[JointType.Spine];

            double resultadoAngulo = Util.CalcularProdutoEscalar(ombroCentro, espinha, maoDireita);
            System.Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@ANTEBRACODIREITOANTES@@@@@@@@@@@@@@@@@@");
            System.Console.WriteLine("Angulo: " + resultadoAngulo);

            bool anguloCorreto = Util.CompararComMargemErro(margemErroAngulo, resultadoAngulo, ANGULO_ESPERADO);
            bool maoDireitaPosicaoCorreta = Util.CompararComMargemErro(margemErroPosicao, pulsoDireito.Position.Z, ombroDireito.Position.Z);
            bool maoDireitaAntesCotovelo = pulsoDireito.Position.X < cotoveloDireito.Position.X;

            System.Console.WriteLine("anguloCorreto: " + anguloCorreto);
            System.Console.WriteLine("maoDireitaPosicaoCorreta: " + maoDireitaPosicaoCorreta);
            System.Console.WriteLine("maoDireitaAntesCotovelo: " + maoDireitaAntesCotovelo);
            return anguloCorreto &&
                  maoDireitaAntesCotovelo &&
                  maoDireitaPosicaoCorreta;
        }
    }
}
