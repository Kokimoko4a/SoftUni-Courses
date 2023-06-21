namespace ASP.NET_TaskBoard_App.Models
{
    public class TaskDetailModel : TaskViewModel
    {
        public string CreatedOn { get; set; } = null!;

        public string Board { get; set; } = null!;
    }
}
