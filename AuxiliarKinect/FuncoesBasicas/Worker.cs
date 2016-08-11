using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.FuncoesBasicas
{
    class Worker
    {
        List<Skeleton> esqueletos;

        public void DoWork()
        {
            while (!_shouldStop)
            {
                if (esqueletos != null)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\logkinectAceno.txt", true))
                    {
                        foreach (Skeleton esqueleto in esqueletos)
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
                RequestStop();
            }
        }


        public void setEsqueletos(List<Skeleton> esqueletos)
        {
            this.esqueletos = new List<Skeleton>();
            this.esqueletos = esqueletos;
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        private volatile bool _shouldStop;
    }
}
