
using Intelekt_Infrastructure.Service;
var _service = new BaseIntelektService();
Console.WriteLine("Fazoni o'lchamini kiriting :");
int spaceCount = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Nuqtalar sonini kiriting :");
int pountCount = Convert.ToInt32(Console.ReadLine());

var data = SeedData.GetRandomKoordinates(spaceCount, pountCount);

var result = _service.K_Close_Neigbor_3(data);

_service.WriteConsole(result.GroupBy(l => l.Sequence));