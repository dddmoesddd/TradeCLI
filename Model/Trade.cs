namespace TradeCLI.Model
{
    public class Trade
    {

        public int Id { get; set; }
        public int InstrumentId { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal LowPrice { get; set; }

        public decimal HighPrice { get; set; }
        public decimal OpenPrice { get; set; }

        public DateTime DateEn { get; set; }




    }
}
