namespace picpay_desafio_backend.Services;

public interface INotification
{
    string ServiceURL { get; set; }
    Task<bool> SendNotifications();
}