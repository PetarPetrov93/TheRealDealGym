namespace TheRealDealGym.Core.Models.Job
{
    public class JobAdvertQueryModel
    {
        public int TotalJobAdvertsCount { get; set; }

        public IEnumerable<JobAdvertListModel> JobAdverts { get; set; } = new List<JobAdvertListModel>();
    }
}
