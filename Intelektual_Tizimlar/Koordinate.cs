using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar
{
    public class Koordinate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double[] Cor { get; set; }
        public string Sequence { get; set; }
        public Koordinate(double[] Cor,string Sequence)
        {
            this.Cor = Cor;
            this.Sequence = Sequence;
        }

        public static double Distance(Koordinate koordinate1, Koordinate koordinate2)
        {
            double Sum = 0;
            for (int i = 0; i < koordinate1.Cor.Length; i++)
                Sum += Math.Pow(koordinate1.Cor[i] - koordinate2.Cor[i],2);
            return Math.Sqrt(Sum);
        }
    }
}
