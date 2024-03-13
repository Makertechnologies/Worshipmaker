namespace Worshipmaker.Core.Accounts
{
    public class Organization : BaseCustomizableEntity
    {
        public string OrganizationID { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string URL { get; set; }
        public string Logo { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        public Organization() : base()
        {
            this.OrganizationID = Guid.NewGuid().ToString();
            this.Name = string.Empty;
            this.Address = new Address();
            this.URL = string.Empty;
            this.Logo = string.Empty;
            this.Active = true;
            this.DateCreated = DateTime.UtcNow;
            this.DateModified = DateTime.UtcNow;
            this.DateDeleted = null;
        }

        /// <summary>
        /// Returns a list of organizations.
        /// </summary>
        /// <returns></returns>
        public static List<Organization> List()
        {
            var organizations = new List<Organization>();
            return organizations;
        }

        /// <summary>
        /// Returns an organization by the specified ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Organization FindByID(string id)
        {
            return new Organization();
        }

        /// <summary>
        /// Adds an organization record.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Insert(Organization entity)
        {
            return false;
        }

        /// <summary>
        /// Updates an organization record.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Update(Organization entity)
        {
            return false;
        }

        /// <summary>
        /// Deletes an organization record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(string id)
        {
            return false;
        }
    }
}