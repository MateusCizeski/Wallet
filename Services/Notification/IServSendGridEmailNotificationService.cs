namespace Services.Notification
{
    public interface IServSendGridEmailNotificationService
    {
        Task NotifyTransferAsync(string receiverEmail, decimal amount);
    }
}
