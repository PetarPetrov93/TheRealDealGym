using TheRealDealGym.Core.Models.Class;

namespace TheRealDealGym.Core.Models.Booking
{
    /// <summary>
    /// This ViewModel displays a booking made by the loged-in user in his "My Bookings" page.
    /// </summary>
    public class BookingModel
    {
        public Guid Id { get; set; }
        public string Class { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string Time { get; set; } = null!;
    }
}
