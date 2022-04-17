using Intelekt_Infrastructure.Models;

namespace Intelekt_Infrastructure.Service
{
    public class SeedData
    {
        public static List<Koordinate> GetSeedData()
        {
            var data = new List<Koordinate>();

            data.Add(new Koordinate(new double[] { -6, 1 }, 0));
            data.Add(new Koordinate(new double[] { 1, 12 }, 1));
            data.Add(new Koordinate(new double[] { 12, -6 }, 1));
            data.Add(new Koordinate(new double[] { 0, 1 }, 1));

            data.Add(new Koordinate(new double[] { -6, -3 }, 2));
            data.Add(new Koordinate(new double[] { -4, -2 }, 2));
            data.Add(new Koordinate(new double[] { -8, 7 }, 2));

            return data;
        }
        public static List<Koordinate> GetDataFromTextFile()
        {
            var data = new List<Koordinate>();
            var path = string.Format("{0}\\Data\\kmeans.txt", Directory.GetCurrentDirectory());
            using (var stream = File.OpenText(path))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    var cors = line.Split(',');
                    int classNumber = int.Parse(cors.Last().Replace('.', ','));
                    data.Add(new Koordinate(GetCoordinate(cors.Take(cors.Length - 1)).ToArray(), classNumber));
                }
            }

            return data;
        }

        public static List<Koordinate> GetRandomKoordinates(int spaceCount, int count)
        {
            var rand = new Random();
            var data = new List<Koordinate>();
            for (int i = 0; i < count; i++)
            {
                var cor = new double[spaceCount];
                for (int j = 0; j < spaceCount; j++)
                    cor[j] = rand.Next(-1 * count * 2, count * 2);
                data.Add(new Koordinate(cor));
            }
            return data;
        }

        private static IEnumerable<double> GetCoordinate(IEnumerable<string> data)
        {
            foreach (string c in data)
                yield return double.Parse(c.Replace('.', ','));
        }
    }
}
