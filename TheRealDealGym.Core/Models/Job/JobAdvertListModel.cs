using System.ComponentModel.DataAnnotations;

namespace TheRealDealGym.Core.Models.Job
{
    /// <summary>
    /// This ViewModel is used for displaying a summarized information in the list of job adverts.
    /// </summary>
    public class JobAdvertListModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}
