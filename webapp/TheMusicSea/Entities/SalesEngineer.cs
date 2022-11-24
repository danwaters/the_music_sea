namespace TheMusicSea.Entities
{
    public class SalesEngineer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SpecialtyDepartmentID { get; set; }
        public string PhotoURI { get; set; }

        public SalesEngineer(int id, string firstName, string lastName, string email,
            string phone, int specialtyDepartmentId, string photoUri)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.SpecialtyDepartmentID = specialtyDepartmentId;
            this.PhotoURI = photoUri;
        }
    }
}
