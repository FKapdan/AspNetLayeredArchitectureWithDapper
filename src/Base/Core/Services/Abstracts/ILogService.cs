using Core.Entities.General;

namespace Core.Services.Abstracts
{
    public interface ILogService
    {
        public void Log(LogModel logModel);
    }
}
