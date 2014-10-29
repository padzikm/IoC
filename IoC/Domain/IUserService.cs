using System.Security.Principal;

namespace Domain
{
    public interface IUserService
    {
        IUser GetUser(IIdentity principal);

        ILogConfiguration LogConfiguration { get; set; }

        void LogUser(string log);

        void LogUser(string log, ILogConfiguration configuration);
    }
}
