namespace LeaveManagementWebApp.Data
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
