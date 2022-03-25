namespace OrderShipping.UseCase
{
    public class OrderApprovalRequest
    {
        public int OrderId { get; set; }
        public bool IsApproved { get; set; }
    }
}
