
namespace picpay_desafio_backend.Services;

public class Notification : INotification
{
    public string ServiceURL { get; set; }

    public Task<bool> SendNotifications()
    {
        throw new NotImplementedException();
    }
}