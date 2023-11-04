namespace picpay_desafio_backend.Model;

public record TransactionDTO(
    decimal value,
    int payee,
    int payer
    );