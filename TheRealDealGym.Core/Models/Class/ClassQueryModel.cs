namespace TheRealDealGym.Core.Models.Class
{
    public class ClassQueryModel
    {
        public int TotalClassesCount { get; set; }

        public IEnumerable<ClassScheduleModel> Classes { get; set; } = new List<ClassScheduleModel>();
    }
}
