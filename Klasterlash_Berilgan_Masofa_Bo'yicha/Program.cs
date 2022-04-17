
using Intelekt_Infrastructure.Service;

var _service = new BaseIntelektService();
Console.WriteLine("Fazo o'lchamini kiritng : ");
int countOfSpace = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Nuqtalar sonini kiritng : ");
int countOfKoordinate = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Berilgan masofani kiriting : ");
int distance = Convert.ToInt32(Console.ReadLine());

var data = SeedData.GetRandomKoordinates(countOfSpace, countOfKoordinate);
//var data = SeedData.GetSeedData();
int sequence = 0;
foreach(var koordinate in data)
{
    if (koordinate.Sequence != 0)
        continue;
    koordinate.Sequence = ++sequence;
    var neighbors = _service.K_Close_Neigbor_2(koordinate, data, distance);
    if(neighbors != null && neighbors.Any())
    {
        foreach(var neighbor in neighbors)
        {
            data.FirstOrDefault(l=>l.Id == neighbor.Id).Sequence = koordinate.Sequence;
        }
    }
}

_service.WriteConsole(data.GroupBy(l => l.Sequence));

