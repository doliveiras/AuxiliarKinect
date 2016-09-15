﻿using AuxiliarKinect.FuncoesBasicas;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.FlexaoCotoveloDireito
{
    class MaoCotoveloOmbroReto : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            double margemErroPosicao = 0.30;

            Joint ombro = esqueletoUsuario.Joints[JointType.ShoulderRight];

            Joint cotovelo = esqueletoUsuario.Joints[JointType.ElbowRight];

            Joint mao = esqueletoUsuario.Joints[JointType.HandRight];

            bool cotoveloAlinhadoOmbro = Util.CompararComMargemErro(margemErroPosicao, ombro.Position.X, cotovelo.Position.X);

            bool ombroAlinhadoMao = Util.CompararComMargemErro(margemErroPosicao, mao.Position.X, cotovelo.Position.X);

            bool ombroMaoReto = Util.CompararComMargemErro(margemErroPosicao, mao.Position.Y, cotovelo.Position.Y);

            return cotoveloAlinhadoOmbro && ombroAlinhadoMao && ombroMaoReto;
        }
    }
}