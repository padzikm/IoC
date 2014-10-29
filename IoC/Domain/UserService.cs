using System;
using System.Security.Principal;

namespace Domain
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogRepository _logRepository;
        private ILogConfiguration _logConfiguration;

        public ILogConfiguration LogConfiguration {
            get
            {
                if (_logConfiguration == null)
                    _logConfiguration = new LogConfiguration();

                return _logConfiguration;
            }
            set
            {
                if(value == null) 
                    throw new ArgumentNullException("LogConfiguration");
                
                if(_logConfiguration != null)
                    throw new InvalidOperationException("LogConfiguration not null");

                _logConfiguration = value;
            } 
        }

        public UserService(IUserRepository userRepository, ILogRepository logRepository)
        {
            _userRepository = userRepository;
            _logRepository = logRepository;
        }

        public IUser GetUser(IIdentity principal)
        {
            return _userRepository.Find(principal.Name);
        }

        public void LogUser(string log)
        {
            var formattedLog = string.Format(LogConfiguration.Format, log);

            _logRepository.Save(formattedLog);
        }

        public void LogUser(string log, ILogConfiguration configuration)
        {
            if(configuration == null)
                throw new ArgumentNullException("configuration");

            var formattedLog = string.Format(configuration.Format, log);

            _logRepository.Save(formattedLog);
        }
    }
}
