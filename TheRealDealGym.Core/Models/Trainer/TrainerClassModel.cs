namespace TheRealDealGym.Core.Models.Trainer
{
    /// <summary>
    /// This ViewModel is for the classes which the logged-in trainer has created on his "My Profile" page.
    /// </summary>
    public class TrainerClassModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string Time { get; set; } = null!;
    }
}
