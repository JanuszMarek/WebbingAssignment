namespace Webbing.Assignment.Service.Models
{
    public class CustomerUsageModel
    {
        public CustomerModel? Customer { get; set; }
        public int SimCount { get; set; }
        public long QuotaSum { get; set; }
    }
}
