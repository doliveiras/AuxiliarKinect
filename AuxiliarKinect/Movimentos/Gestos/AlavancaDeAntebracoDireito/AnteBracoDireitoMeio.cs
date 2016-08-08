using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using AuxiliarKinect.FuncoesBasicas;

namespace AuxiliarKinect.Movimentos.Gestos.AlavancaDeAntebracoDireito
{
    class AnteBracoDireitoMeio : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            const double ANGULO_ESPERADO = 25;
            double margemErroPosicao = 0.30;
            double margemErroAngulo = 10;

            Joint pulsoDireito = esqueletoUsuario.Joints[JointType.WristRight];
            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];
            Joint ombroDireito = esqueletoUsuario.Joints[JointType.ShoulderRight];
            Joint cotoveloDireito = esqueletoUsuario.Joints[JointType.ElbowRight];
            Joint ombroCentro = esqueletoUsuario.Joints[JointType.ShoulderCenter];
            Joint espinha = esqueletoUsuario.Joints[JointType.Spine];

            double resultadoAngulo = Util.CalcularProdutoEscalar(ombroDireito, maoDireita, espinha);
            System.Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%@ANTEBRACODIREITOMEIO%%%%%%%%%%%%%%%%%%%%%%%%%%");
            System.Console.WriteLine("Angulo: " + resultadoAngulo);

            bool anguloCorreto = Util.CompararComMargemErro(margemErroAngulo, resultadoAngulo, ANGULO_ESPERADO);
            bool cotoveloDireitoCorreto = pulsoDireito.Position.X > espinha.Position.X;

            System.Console.WriteLine("anguloCorreto: " + anguloCorreto);
            System.Console.WriteLine("maoDireitaAntesCotovelo: " + cotoveloDireitoCorreto);
            return anguloCorreto &&
                  cotoveloDireitoCorreto;
        }
    }
}
