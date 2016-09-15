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
            const double ANGULO_ESPERADO = 30;
            double margemErroPosicao = 0.30;
            double margemErroAngulo = 10;

            Joint cabeca = esqueletoUsuario.Joints[JointType.Head];

            Joint pescoco = esqueletoUsuario.Joints[JointType.ShoulderCenter];

            Joint ombro = esqueletoUsuario.Joints[JointType.ShoulderRight];

            double resultadoAngulo = Util.CalcularProdutoEscalar(cabeca, pescoco, ombro);

         //   Console.WriteLine("Angulo :" + resultadoAngulo);

            bool anguloCorreto = Util.CompararComMargemErro(margemErroAngulo, resultadoAngulo, ANGULO_ESPERADO);

            return (cabeca.Position.X < pescoco.Position.X) && anguloCorreto;
        }

    }
}
