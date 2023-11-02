using picpay_desafio_backend.Model;

public record UserDTO
{
    public int UserId;

    public string FullName;

    public string Document;

    public string Email;

    public decimal Balance;

    public UserType UserType;
}