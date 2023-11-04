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
        TransactionValue = transactionDTO.value;
        Payee = transactionDTO.payee;
        Payer = transactionDTO.payer;
    }

    [JsonIgnore]
    public virtual User PayeeNavigation { get; private set; }
    
    [JsonIgnore]
    public virtual User PayerNavigation { get; private set; }
}
