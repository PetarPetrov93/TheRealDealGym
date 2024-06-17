namespace TheRealDealGym.Core.Models.Class
{
    /// <summary>
    /// This ViewModel is used for the filtering and sorting.
    /// </summary>
    public class ClassQueryModel
    {
        public int TotalClassesCount { get; set; }

        public IEnumerable<ClassScheduleModel> Classes { get; set; } = new List<ClassScheduleModel>();
    }
}
