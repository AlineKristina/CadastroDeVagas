namespace Data.Candidate
{
    public class CandidateModel
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public Document? Document { get; set; }

        public Address? Address { get; set; }
    }

    public class Address
    {
        public string? City { get; set; }

        public string? Region { get; set; }

        public string? Country { get; set; }

        public string? Street { get; set; }

        public string? ZipCode { get; set; }

        public string? State { get; set; }
    }

    public class Document
    {
        public string? Number { get; set; }

        public string? Type { get; set; }
    }
}
