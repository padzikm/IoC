using System.Collections.Generic;

namespace Domain
{
    public interface ILogRepository
    {
        IEnumerable<string> GetAll();

        void Save(string log);
    }
}
