namespace Marketing_system.BL.Contracts.DTO
{
    public class MemberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public DateOnly Birthday { get; set; }
        public string Status { get; set; }
        public int MemberCard { get; set; }
        public CategoryDTO Category { get; set; }
        public int Instruktor_id { get; set; }
    }
}
