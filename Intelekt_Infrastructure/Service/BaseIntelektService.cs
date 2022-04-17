using Intelekt_Infrastructure.Models;

namespace Intelekt_Infrastructure.Service
{
    public class BaseIntelektService
    {
        private readonly List<Koordinate> _koordinates;
        public BaseIntelektService(List<Koordinate> koordinates)
        {
            this._koordinates = koordinates;
        }

        public BaseIntelektService()
        {

        }

        public IEnumerable<IGrouping<int, Koordinate>> Canculation()
        {
            var borders = new List<Koordinate>();
            foreach (var koordinate in _koordinates)
            {
                var distances = new List<ForDistance>();
                foreach (var forDistance in _koordinates)
                {
                    distances.Add(new ForDistance
                    {
                        Id = forDistance.Id,
                        Distance = Koordinate.Distance(koordinate, forDistance),
                        Sequence = forDistance.Sequence
                    });
                }
                distances = distances.OrderBy(l => l.Distance).ToList();
                //var result = distances[distances.IndexOf(distances.FirstOrDefault(l => l.Sequence != koordinate.Sequence)) - 1];
                var qoshni = distances.FirstOrDefault(l => l.Sequence != koordinate.Sequence);
                var index = distances.IndexOf(qoshni);
                var distance2 = new List<ForDistance>();
                for (int i = 0; i < index; i++)
                {
                    distance2.Add(new ForDistance
                    {
                        Id = distances[i].Id,
                        Distance = Koordinate.Distance(_koordinates.FirstOrDefault(l => l.Id == distances[i].Id),
                        _koordinates.FirstOrDefault(l => l.Id == qoshni.Id)),
                        Sequence = distances[i].Sequence
                    });
                }
                distance2 = distance2.OrderBy(l => l.Distance).ToList();
                var yaqinQoshni = distance2.FirstOrDefault();
                borders.Add(_koordinates.FirstOrDefault(l => l.Id == yaqinQoshni.Id));
            }
            borders = borders.Distinct().ToList();
            return borders.GroupBy(l => l.Sequence);
        }

        public Koordinate K_Close_Neighbor(Koordinate basicKoordinate, IEnumerable<Koordinate> koordinates)
        {
            var distances = new List<ForDistance>();
            foreach (var forDistance in koordinates)
            {
                distances.Add(new ForDistance
                {
                    Id = forDistance.Id,
                    Distance = Koordinate.Distance(basicKoordinate, forDistance),
                    Sequence = forDistance.Sequence
                });
            }
            distances = distances.OrderBy(l => l.Distance).ToList();
            var close_neighbor = distances.FirstOrDefault(l => l.Sequence != basicKoordinate.Sequence);
            if(close_neighbor == null)
            {
                close_neighbor = distances.LastOrDefault(l => l.Id != basicKoordinate.Id);
            }
            return koordinates.FirstOrDefault(l => l.Id == close_neighbor.Id);
        }

        public IEnumerable<Koordinate> K_Close_Neigbor_2(Koordinate basicKoordinate ,IEnumerable<Koordinate> koordinates, double distance)
        {
            var result = new List<Koordinate>();
            foreach(var koordinate in koordinates)
            {
                if (basicKoordinate.Id == koordinate.Id && koordinate.Sequence != 0)
                    continue;
                
                var distance_k = Koordinate.Distance(basicKoordinate, koordinate);
                if (distance >= distance_k)
                {
                    var check_distance = K_Close_Neighbor(koordinate, koordinates);
                    if (check_distance.Id == basicKoordinate.Id)
                        result.Add(koordinate);
                }
            }
            return result;
        }

        public IEnumerable<Koordinate> K_Close_Neigbor_3(IEnumerable<Koordinate> koordinates)
        {
            int sequence = 0;
            foreach(var koordinate in koordinates)
            {
                if (koordinate.Sequence != 0)
                    continue;
                var neigbor = K_Close_Neighbor_For_Near(koordinate, koordinates);
                if (neigbor.Sequence != 0)
                    koordinate.Sequence = neigbor.Sequence;
                else
                {
                    koordinate.Sequence = ++sequence;
                    neigbor.Sequence = koordinate.Sequence;
                }
            }
            return koordinates;
        }

        public Koordinate DetermineClassOfGivenPoint(Koordinate basicKoordinate, IEnumerable<Koordinate> koordinates, double distance)
        {
            var distanes = new List<ForDistance>();
            foreach(var koordinate in koordinates)
            {
                distanes.Add(new ForDistance
                {
                    Id = koordinate.Id,
                    Sequence = koordinate.Sequence,
                    Distance = Koordinate.Distance(basicKoordinate, koordinate)
                });
            }

            var result = distanes.Where(l => l.Distance <= distance).GroupBy(l => l.Sequence).OrderByDescending(l => l.Count())
                .Select(l => l.Key).FirstOrDefault();
            if (result == 0)
                return null;
            basicKoordinate.Sequence = result;
            return basicKoordinate;
        }

        private Koordinate K_Close_Neighbor_For_Near(Koordinate basicKoordinate, IEnumerable<Koordinate> koordinates)
        {
            var distances = new List<ForDistance>();
            foreach (var forDistance in koordinates)
            {
                distances.Add(new ForDistance
                {
                    Id = forDistance.Id,
                    Distance = Koordinate.Distance(basicKoordinate, forDistance),
                    Sequence = forDistance.Sequence
                });
            }
            distances = distances.OrderBy(l => l.Distance).ToList();
            var close_neighbor = distances.FirstOrDefault(l => l.Id != basicKoordinate.Id);
            
            return koordinates.FirstOrDefault(l => l.Id == close_neighbor.Id);
        }

        public void WriteConsole(IEnumerable<IGrouping<int, Koordinate>> koordinates)
        {
            foreach (var group in koordinates)
            {
                Console.WriteLine("{0} - guruhning chegaralari", group.Key);
                foreach (var coordinate in group)
                {
                    foreach (var cor in coordinate.Cor)
                        Console.Write("{0} ", cor);
                    Console.WriteLine("\n");
                }
            }
            Console.Read();
        }
    }
}
