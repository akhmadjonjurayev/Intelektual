using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar
{
    internal static class SeedData
    {
        public static List<Koordinate> GetSeedData(int count)
        {
            var data = new List<Koordinate>();
            //data.Add(new Koordinate(new double[] { 1, 1 }, 1));
            //data.Add(new Koordinate(new double[] { 2, 2 }, 1));
            //data.Add(new Koordinate(new double[] { 3, 3 }, 1));
            //data.Add(new Koordinate(new double[] { 1, 3 }, 1));
            //data.Add(new Koordinate(new double[] { -1, 3 }, 1));
            //data.Add(new Koordinate(new double[] { 3, 4 }, 1));
            //data.Add(new Koordinate(new double[] { 2, 4 }, 1));
            //data.Add(new Koordinate(new double[] { 1, 4 }, 1));
            //data.Add(new Koordinate(new double[] { -1, 4 }, 1));
            //data.Add(new Koordinate(new double[] { 2, 5 }, 1));
            //data.Add(new Koordinate(new double[] { 1, 6 }, 1));


            //data.Add(new Koordinate(new double[] { 4, 1 }, 2));
            //data.Add(new Koordinate(new double[] { 3, 2 }, 2));
            //data.Add(new Koordinate(new double[] { 5, 2 }, 2));
            //data.Add(new Koordinate(new double[] { 7, 2 }, 2));
            //data.Add(new Koordinate(new double[] { 4, 3 }, 2));
            //data.Add(new Koordinate(new double[] { 6, 3 }, 2));
            //data.Add(new Koordinate(new double[] { 5, 4 }, 2));
            //data.Add(new Koordinate(new double[] { 7, 4 }, 2));
            //data.Add(new Koordinate(new double[] { 6, 5 }, 2));
            //data.Add(new Koordinate(new double[] { 7, 6 }, 2));

            data.Add(new Koordinate(new double[] { 2, -1 }, 1));
            data.Add(new Koordinate(new double[] { 12, 1 }, 1));
            data.Add(new Koordinate(new double[] { 9, 11 }, 1));

            data.Add(new Koordinate(new double[] { -11, -10 }, 2));
            data.Add(new Koordinate(new double[] { 3, -9 }, 2));
            data.Add(new Koordinate(new double[] { 0, -9 }, 2));
            return data;
        }

        public static List<Koordinate> GetDataFromTextFile()
        {
            var data = new List<Koordinate>();
            var path = string.Format("{0}\\Data\\kmeans.txt", Directory.GetCurrentDirectory());
            using (var stream = File.OpenText(path))
            {
                string line;
                while((line = stream.ReadLine()) != null)
                {
                    var cors = line.Split(',');
                    int classNumber = int.Parse(cors.Last().Replace('.', ','));
                    data.Add(new Koordinate(GetCoordinate(cors.Take(cors.Length - 1)).ToArray(), classNumber));
                }
            }

            return data;
        }

        public static IEnumerable<double> GetCoordinate(IEnumerable<string> data)
        {
            foreach(string c in data)
                yield return double.Parse(c.Replace('.', ','));
        }
    }
}
