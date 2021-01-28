using System.Threading.Tasks;

namespace Scheduler.Jobs
{
    public interface IJob
    {
        Task Run();
    }
}