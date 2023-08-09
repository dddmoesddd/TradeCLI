
using Microsoft.Extensions.DependencyInjection;
using TradeCLI.DB;
using TradeCLI.Model;

var r = new Random();
var serviceProvider = new ServiceCollection().AddSingleton<DapperContext>().AddScoped<ITradeRepository, TradeRepository>().BuildServiceProvider();

GetConnctionStraing();

while (true)
{
    Console.WriteLine(" \n Enter Number  Of Records:");
    int numberOfRecord;
    var finalResult = int.TryParse(Console.ReadLine(), out numberOfRecord);

    if (!finalResult)
    {

        Console.WriteLine("Number of Recordsd Must Be Grather than 0 and  NoN string or Char!");
        Console.WriteLine("  Do You Want  To Countinue?(y/n)");
        ConsoleKey response = Console.ReadKey(false).Key; ;
        if (response == ConsoleKey.Y)
        {
            continue;
        }

        else if (response == ConsoleKey.N) { Console.WriteLine("\n GoodBay!!!"); break; }

    }

    else
    {
        try
        {



            var repo = serviceProvider.GetService<ITradeRepository>();

            var tradeList = new List<Trade>();
            var InstrumentIdArray = new[] { 1, 2, 5 };

            for (int i = 0; i < numberOfRecord; i++)
            {
                var trade = new Trade()
                {

                    Id = new Random().Next(),
                    InstrumentId = InstrumentIdArray[r.Next(InstrumentIdArray.Length)],
                    OpenPrice = r.Next(),
                    HighPrice = r.Next(),
                    LowPrice = r.Next(),
                    ClosePrice = r.Next(),
                    DateEn = RandomDay(),
                };
                tradeList.Add(trade);
            }


            if (tradeList.Count == 0)
            {
                Console.WriteLine("Number of Recordsd Must Be Grather than 0");
                Console.WriteLine("  Do You Want  To Countinue?(y/n)");
                ConsoleKey response = Console.ReadKey(false).Key; ;
                if (response == ConsoleKey.Y)
                {
                    continue;
                }

                else if (response == ConsoleKey.N) { Console.WriteLine("\n GoodBay!!!"); break; }

            }

            if (repo != null && tradeList.Count != 0)
            {
                var result = await repo.InsertAsync(tradeList);

                Console.WriteLine(" \n {0}  Records Inserted ", result);
                Console.WriteLine("\n  Do You Want  To Countinue?(y/n)");
                ConsoleKey response = Console.ReadKey(false).Key; ;
                if (response == ConsoleKey.Y)
                {
                    continue;
                }

                else if (response == ConsoleKey.N) { Console.WriteLine("\n GoodBay!!!"); break; }
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine(" \n Error  In Program More Detail:\n\n {0}", ex.Message);
            Console.WriteLine(" \n  {0}   Records Inserted ", 0);
            Console.Write(" \n Do You Want  To Countinue?(y/n)");
            ConsoleKey response = Console.ReadKey(false).Key; ;
            if (response == ConsoleKey.Y)
            {
          
                continue;
            }

            else if (response == ConsoleKey.N) { Console.WriteLine("\n GoodBay!!!"); break; }
        }
    }
}





DateTime RandomDay()
{
    DateTime start = new DateTime(2000, 1, 1);
    int range = (DateTime.Today - start).Days;
    return start.AddDays(r.Next(range));
}


void GetConnctionStraing()
{

    Console.WriteLine(" Please  Set Your Connection String:");
    Console.WriteLine(" Enter SqlServerName :");
    ConnectionString.Server = Console.ReadLine() ?? string.Empty;
    Console.WriteLine(" Enter DataBaseName :");
    ConnectionString.DataBaseName = Console.ReadLine() ?? string.Empty;
    Console.WriteLine(" Enter UserId :");
    ConnectionString.UserName = Console.ReadLine() ?? string.Empty;
    Console.WriteLine(" Enter Password :");
    ConnectionString.Password = Console.ReadLine() ?? string.Empty;


}

