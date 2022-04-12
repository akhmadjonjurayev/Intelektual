using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar
{
    internal class Service
    {
        private readonly List<Koordinate> _koordinates;
        public Service(List<Koordinate> koordinates)
        {
            this._koordinates = koordinates; 
        }

        public IEnumerable<IGrouping<int, Koordinate>> Canculation()
        {
            var borders = new List<Koordinate>();
            foreach(var koordinate in _koordinates)
            {
                var distances = new List<ForDistance>();
                foreach(var forDistance in _koordinates)
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
                for(int i = 0; i < index; i++)
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
    }
}
