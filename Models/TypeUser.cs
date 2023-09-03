using System;
using System.Collections.Generic;

namespace picpay_desafio_backend.Model;

public partial class TypeUser
{
    public int TypeId { get; set; }

    public string TypeName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
