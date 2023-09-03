using System;
using System.Collections.Generic;

namespace picpay_desafio_backend.Model;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; }

    public string CpfCnpj { get; set; }

    public string UserEmail { get; set; }

    public decimal? Balance { get; set; }

    public int? UserType { get; set; }

    public virtual ICollection<Transaction> TransactionPayeeNavigations { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionPayerNavigations { get; set; } = new List<Transaction>();

    public virtual TypeUser UserTypeNavigation { get; set; }
}
