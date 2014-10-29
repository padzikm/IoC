namespace Domain
{
    public interface IUserRepository
    {
        IUser Find(string name);
    }
}
