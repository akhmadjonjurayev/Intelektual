
using Intelekt_Infrastructure.Service;

var _service = new BaseIntelektService();
//Console.WriteLine("Fazo o'lchamini kiritng : ");
//int countOfSpace = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Nuqtalar sonini kiritng : ");
//int countOfKoordinate = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Berilgan masofani kiriting : ");
int distance = Convert.ToInt32(Console.ReadLine());

//var data = SeedData.GetRandomKoordinates(countOfSpace, distance);
var data = SeedData.GetSeedData(); ;
var basicKoordinate = data[0];

basicKoordinate = _service.DetermineClassOfGivenPoint(basicKoordinate, data.Where(l => l.Id != basicKoordinate.Id), distance);
if (basicKoordinate == null)
    Console.WriteLine("berilgan masofa bo'yicha tanlangan nuqta hech qaysi sinfga kirmaydi");
else Console.WriteLine("tanlangan nuqta {0} - sinfga tegishli", basicKoordinate.Sequence);

Console.ReadKey();