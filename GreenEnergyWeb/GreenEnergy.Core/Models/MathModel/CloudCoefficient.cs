using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathModel
{
    public class CloudCoefficient
    {
        public double cl_k(int cl_d, int m_cl_d, int s_d)
        {
            return (cl_d * 0.6 + m_cl_d * 0.2 + s_d * 0.85) / (cl_d + m_cl_d + s_d);
        }
    }
}
