namespace picpay_desafio_backend.Model;

public record TransactionDTO(
    decimal TransactionValue,
    int Payee,
    int Payer);
public record TransferDTO(
    decimal TransactionValue,
    User Payee,
    User Payer);