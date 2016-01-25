using System.Threading.Tasks;

namespace Mobile.ViewModel.Helpers
{
    public interface ITaskStatus
    {
        TaskStatus Status { get; }
    }
}