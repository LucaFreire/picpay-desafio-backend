namespace picpay_desafio_backend.Model;

public partial class User
{
    public int UserId { get; private set; }

    public string FullName { get; private set; }

    public string Document { get; private set; }

    public string Email { get; private set; }

    public decimal Balance { get; private set; }

    public UserType UserType { get; private set; }

    public User(UserDTO userDTO)
    {
        userDTO.FullName = FullName;
        userDTO.Document = Document;
        userDTO.Email = Email;
        userDTO.Balance = Balance;
        userDTO.UserType = UserType;
    }

    public virtual ICollection<Transaction> TransactionPayeeNavigations { get; private set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionPayerNavigations { get; set; } = new List<Transaction>();

    public void AddMoney(decimal moneyAmount)
        => this.Balance += moneyAmount;

    public void RemoveMoney(decimal moneyAmount)
        => this.Balance -= moneyAmount;
}
