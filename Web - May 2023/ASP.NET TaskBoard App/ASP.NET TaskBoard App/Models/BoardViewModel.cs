namespace ASP.NET_TaskBoard_App.Models
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            Tasks = new HashSet<TaskViewModel>();
        }

        public virtual ICollection<TaskViewModel> Tasks { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
