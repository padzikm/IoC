namespace Domain
{
    public class LogConfiguration : ILogConfiguration
    {
        public string Format { get { return "standard log: {0}"; } }
    }
}
