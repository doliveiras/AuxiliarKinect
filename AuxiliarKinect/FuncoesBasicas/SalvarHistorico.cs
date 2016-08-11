using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.FuncoesBasicas
{
    public  class SalvarHistorico
    {
        public void ProcessarHistorico(List<Skeleton> dados)
        {
            if (dados != null)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("logkinectAceno.txt"))
                {
                    foreach (Skeleton esqueleto in dados)
                    {
                        JointCollection joint = esqueleto.Joints;
                        foreach (Joint j in joint)
                        {
                            file.WriteLine("Joint: " + j.JointType);
                            file.WriteLine("Position X: " + j.Position.X);
                            file.WriteLine("Position Y: " + j.Position.Y);
                            file.WriteLine("Position Z: " + j.Position.Z);
                        }
                    }
                }
            }
        }
            
    }
}
