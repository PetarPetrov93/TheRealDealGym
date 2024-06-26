namespace TheRealDealGym.Core.Models.Sport
{
    public class SportQueryModel
    {
        public int SportsCount { get; set; }

        public IEnumerable<SportInfoModel> Sports { get; set; } = new List<SportInfoModel>();
    }
}
