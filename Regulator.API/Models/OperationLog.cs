namespace Regulator.API.Models
{
    public class OperationLog
    {
        public int Id { get; set; }
        public double FirstValue { get; set; }
        public double SecondValue { get; set; }
        public string ResultMessage { get; set; }
        public double Result {  get; set; }
    }
}
