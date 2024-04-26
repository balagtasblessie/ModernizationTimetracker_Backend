    namespace ClockDB.Models
{   
    public class UserProject
    {
        public Guid UserProjectID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProjectId {  get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime Date { get; set; }
    }
}
