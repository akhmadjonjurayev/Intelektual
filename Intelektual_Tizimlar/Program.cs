using Intelektual_Tizimlar;

var _service = new Service(SeedData.GetSeedData(1));
var result = _service.Canculation();
foreach(var group in result)
{
    Console.WriteLine("{0} - guruhning chegaralari", group.Key);
    foreach(var coordinate in group)
    {
        foreach (var cor in coordinate.Cor)
            Console.Write("{0} ", cor);
        Console.WriteLine("\n");
    }
}
Console.Read();