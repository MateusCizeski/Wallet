namespace Services.Notification
{
    public interface IServNotification
    {
        Task NotifyTransferAsync(string receiverEmail, decimal amount);
    }
}
