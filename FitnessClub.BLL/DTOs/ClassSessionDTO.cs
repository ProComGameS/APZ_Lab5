namespace FitnessClub.BLL.DTOs
{
    public class ClassSessionDTO
    {
        public int Id { get; set; }
        public DateTime SessionDateTime { get; set; }
        public int Capacity { get; set; }
        public int ClubId { get; set; }
    }
}