using System;
using System.Collections.Generic;

namespace picpay_desafio_backend.Model;

public partial class User
{
    public int UserId { get; private set; }

    public string FullName { get; private set; }

    public string Document { get; private set; }

    public string Email { get; private set; }

    public decimal Balance { get; private set; }

    public int UserType { get; private set; }

    private User() { }
    public User(UserDTO userDTO)
    {
        FullName = userDTO.FullName;
        Document = userDTO.Document;
        Email = userDTO.Email;
        Balance = userDTO.Balance;
        UserType = (int)userDTO.UserType;
    }

    public virtual ICollection<Transaction> TransactionPayeeNavigations { get; private set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionPayerNavigations { get; private set; } = new List<Transaction>();
}
