namespace picpay_desafio_backend.Model;

public record TransactionDTO
{
    public int TransactionId;

    public decimal TransactionValue;

    public int Payee;

    public int Payer;
}
