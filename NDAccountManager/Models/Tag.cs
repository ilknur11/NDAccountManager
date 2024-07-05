public class Tag
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<TagAccountInfo>? TagAccountInfos { get; set; }
}
