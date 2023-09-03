using System;
using System.Collections.Generic;

namespace picpay_desafio_backend.Model;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public decimal? TransactionValue { get; set; }

    public int? Payee { get; set; }

    public int? Payer { get; set; }

    public virtual User PayeeNavigation { get; set; }

    public virtual User PayerNavigation { get; set; }
}
