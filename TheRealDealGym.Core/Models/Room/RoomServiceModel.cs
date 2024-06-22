namespace TheRealDealGym.Core.Models.Room
{
    /// <summary>
    /// This ViewModel is for Rooms entity.
    /// </summary>
    public class RoomServiceModel
    {
        
        public Guid Id { get; set; }

        
        public string Type { get; set; } = null!;

        public int Capacity { get; set; }

    }
}
