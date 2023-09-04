namespace picpay_desafio_backend.DTO;

public class TransactionDTO
{
    public int PayeeId { get; set; }
    public int PayerId { get; set; }
    public decimal? Value { get; set; }
}
