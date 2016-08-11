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
            const double ANGULO_ESPERADO = 55;
            double margemErroPosicao = 0.30;
            double margemErroAngulo = 10;

            Joint pulsoDireito = esqueletoUsuario.Joints[JointType.WristRight];
            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];
            Joint ombroDireito = esqueletoUsuario.Joints[JointType.ShoulderRight];
            Joint cotoveloDireito = esqueletoUsuario.Joints[JointType.ElbowRight];
            Joint ombroCentro = esqueletoUsuario.Joints[JointType.ShoulderCenter];
            Joint espinha = esqueletoUsuario.Joints[JointType.Spine];

            double resultadoAngulo = Util.CalcularProdutoEscalar(ombroDireito, cotoveloDireito, maoDireita);
          //  System.Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%@ANTEBRACODIREITOMEIO%%%%%%%%%%%%%%%%%%%%%%%%%%");
          //  System.Console.WriteLine("Angulo: " + resultadoAngulo);

            bool anguloCorreto = Util.CompararComMargemErro(margemErroAngulo, resultadoAngulo, ANGULO_ESPERADO);
            //bool cotoveloDireitoCorreto = pulsoDireito.Position.X > espinha.Position.X;
            bool cotoveloDireitoCorreto = Util.CompararComMargemErro(margemErroPosicao, cotoveloDireito.Position.X, ombroDireito.Position.X);
            bool maoDireitaCorreta = Util.CompararComMargemErro(margemErroPosicao, maoDireita.Position.Y, cotoveloDireito.Position.Y);
            bool maoDireitaAlinhada = Util.CompararComMargemErro(margemErroPosicao, maoDireita.Position.X, cotoveloDireito.Position.X);
            bool maoDireitaFrenteCotovelo = maoDireita.Position.Z < cotoveloDireito.Position.Z;
          //  System.Console.WriteLine("anguloCorreto: " + anguloCorreto);
          //  System.Console.WriteLine("cotoveloDireitoCorreto: " + cotoveloDireitoCorreto);
          //  System.Console.WriteLine("maoDireitaCorreta: " + maoDireitaCorreta);
          //  System.Console.WriteLine("maoDireitaAlinhada: " + maoDireitaAlinhada);
          //  System.Console.WriteLine("maoDireitaFrenteCotovelo: " + maoDireitaFrenteCotovelo);
            return anguloCorreto &&
                  cotoveloDireitoCorreto &&
                  maoDireitaAlinhada &&
                  maoDireitaCorreta &&
                  maoDireitaFrenteCotovelo;
        }
    }
}
