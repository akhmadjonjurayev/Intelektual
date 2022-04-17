namespace Intelekt_Infrastructure.Models
{
    public class Koordinate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double[] Cor { get; set; }
        public int Sequence { get; set; } = 0;
        public Koordinate(double[] Cor, int Sequence)
        {
            this.Cor = Cor;
            this.Sequence = Sequence;
        }

        public Koordinate(double[] Cor)
        {
            this.Cor = Cor;
        }

        public static double Distance(Koordinate koordinate1, Koordinate koordinate2)
        {
            double Sum = 0;
            for (int i = 0; i < koordinate1.Cor.Length; i++)
                Sum += Math.Pow(koordinate1.Cor[i] - koordinate2.Cor[i], 2);
            return Math.Sqrt(Sum);
        }
    }
}
