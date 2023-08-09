using Dapper;
using System.Data;
using TradeCLI.Model;

namespace TradeCLI.DB
{
    public  class TradeRepository: ITradeRepository
    {
        private readonly DapperContext _context;
        public TradeRepository(DapperContext context)
        {
            _context = context;
        }


        public  async Task<int>  InsertAsync (List<Trade>  trades)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var trans = connection.BeginTransaction();
                    await connection.ExecuteAsync(@"insert Trade(Id,InstrumentId,DateEn,ClosePrice,LowPrice,HighPrice,OpenPrice) values(@Id,@InstrumentId,@DateEn,@ClosePrice,@LowPrice,@HighPrice,@OpenPrice) ", trades, transaction: trans);
                    trans.Commit();
                    return trades.Count;
                }
            }
            catch (Exception ex)
            {

                throw ;
            }
 
        }

    }
}
