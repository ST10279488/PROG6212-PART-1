namespace LecturerClaims.Models
{
    public class document
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public string FilePath { get; set; }
        public Claim Claim { get; set; }
    }
}
