    public class User
    {
        public int Id { get; set; } 
        public string? AzureAdId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
