using TheRealDealGym.Core.Models.Class;

namespace TheRealDealGym.Core.Models.Booking
{
    /// <summary>
    /// This ViewModel displays a booking made by the loged-in user
    /// </summary>
    public class BookingModel
    {
        public Guid Id { get; set; }

        public string Class { get; set; } = null!;

        public ClassModel ClassModel { get; set; } = null!;

    }
}
