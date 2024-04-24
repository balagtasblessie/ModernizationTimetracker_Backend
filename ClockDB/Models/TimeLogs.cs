namespace ClockDB.Models
{
    public class TimeLogs
    {
        public Guid TimeLogsId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
    }
}
