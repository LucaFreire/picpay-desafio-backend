using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace picpay_desafio_backend.Model;

public partial class Transaction
{
    public int TransactionId { get; private set; }

    public decimal TransactionValue { get; private set; }

    public int Payee { get; private set; }

    public int Payer { get; private set; }

    private Transaction() { }

    public Transaction(TransactionDTO transactionDTO)
    {
        TransactionValue = transactionDTO.TransactionValue;
        Payee = transactionDTO.Payee;
        Payer = transactionDTO.Payer;
    }

    [JsonIgnore]
    public virtual User PayeeNavigation { get; private set; }
    
    [JsonIgnore]
    public virtual User PayerNavigation { get; private set; }
}
