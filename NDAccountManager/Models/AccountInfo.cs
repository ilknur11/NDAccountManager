public class AccountInfo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? IpAddress { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public bool IsShared { get; set; }
    public string? SharedWith { get; set; }
    public DateTime? ShareExpiry { get; set; }

    // Navigation property
    public ICollection<TagAccountInfo>? TagAccountInfos { get; set; }
}
