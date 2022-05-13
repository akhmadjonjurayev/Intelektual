using Intelekt_Infrastructure.Models;
using Intelekt_Infrastructure.Service;

var _service = new BaseIntelektService();
Console.WriteLine("Fazoni o'lchamini kiriting : ");
int spaceCount = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Sinflar sonini kiriting : ");
int countOfClass = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Nuqtalar sonini kiriting : ");
int countOfKoordinates = Convert.ToInt32(Console.ReadLine());

//var data = SeedData.GetRandomKoordinates(spaceCount, countOfKoordinates);
var data = SeedData.GetSeedData();
var centerKoordinations = new List<Koordinate>();
for (int i = 0; i < countOfClass; i++)
{
    data[i].Sequence = i + 1;
    centerKoordinations.Add(data[i]);
}
foreach (var koordinate in data)
{
    if (koordinate.Sequence != 0)
        continue;
    var result = _service.K_Close_Neighbor(koordinate, centerKoordinations);
    if(result != null)
    {
        koordinate.Sequence = result.Sequence;
    }
}

_service.WriteConsole(data.GroupBy(l => l.Sequence));
