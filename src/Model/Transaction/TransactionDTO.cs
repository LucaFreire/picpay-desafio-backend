namespace picpay_desafio_backend.Model;

public record TransactionDTO(
    decimal TransactionValue,
    int Payee,
    int Payer);