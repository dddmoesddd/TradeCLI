using TradeCLI.Model;

namespace TradeCLI.DB
{
    public  interface ITradeRepository
    {
        Task<int> InsertAsync(List<Trade> trades);
    }
}
