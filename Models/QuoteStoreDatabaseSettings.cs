namespace APIK8S.Models
{
    public class QuoteStoreDatabaseSettings
    {
        public string DbUrl { get; set; } = null!;

        public string User { get; set; } = null!;

        public string Pwd { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string QuoteCollectionName { get; set; } = null!;
    }
}
