namespace Regulator.Server.Models
{
    public class OperationsLog
    {
        public int Id { get; set; }
        public double FirstValue { get; set; }
        public double SecondValue { get; set; }
        public string Result { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
