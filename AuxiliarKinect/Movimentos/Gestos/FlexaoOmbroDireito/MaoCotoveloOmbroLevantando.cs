using AuxiliarKinect.FuncoesBasicas;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.FlexaoOmbroDireito
{
    class MaoCotoveloOmbroLevantando : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            const double ANGULO_ESPERADO = 30;
            double margemErroPosicao = 0.30;
            double margemErroAngulo = 20;

            Joint ombro = esqueletoUsuario.Joints[JointType.ShoulderRight];

            Joint cotovelo = esqueletoUsuario.Joints[JointType.ElbowRight];

            Joint mao = esqueletoUsuario.Joints[JointType.HandRight];

            double resultadoAngulo = Util.CalcularProdutoEscalar(ombro, cotovelo, mao);

            Console.WriteLine("Angulo :" + resultadoAngulo);

            bool anguloCorreto = Util.CompararComMargemErro(margemErroAngulo, resultadoAngulo, ANGULO_ESPERADO);

            bool maoFrenteCotovelo = mao.Position.Z < cotovelo.Position.Z;

            bool cotoveloFrenteOmbro = cotovelo.Position.Z < ombro.Position.Z;

            bool maoCotoveloAlinhado = Util.CompararComMargemErro(margemErroAngulo, mao.Position.X, cotovelo.Position.X);

            bool cotoveloOmbroAlinhado = Util.CompararComMargemErro(margemErroAngulo, cotovelo.Position.X, ombro.Position.X);

            return anguloCorreto && maoFrenteCotovelo && cotoveloFrenteOmbro && maoCotoveloAlinhado && cotoveloOmbroAlinhado;
        }
    }
}
