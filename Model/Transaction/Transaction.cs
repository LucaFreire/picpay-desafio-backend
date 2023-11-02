namespace picpay_desafio_backend.Model;

public partial class Transaction
{
    public int TransactionId { get; private set; }

    public decimal TransactionValue { get; private set; }

    public int Payee { get; private set; }

    public int Payer { get; private set; }

    public Transaction(TransactionDTO transactionDTO)
    {
        transactionDTO.TransactionValue = TransactionValue;
        transactionDTO.Payee = Payee;
        transactionDTO.Payer = Payer;
    }

    public virtual User PayeeNavigation { get; private set; }

    public virtual User PayerNavigation { get; private set; }
}
