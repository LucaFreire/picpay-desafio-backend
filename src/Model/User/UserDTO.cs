using picpay_desafio_backend.Model;

public record UserDTO(
    string FullName,
    string Document,
    string Email,
    decimal Balance,
    UserType UserType);