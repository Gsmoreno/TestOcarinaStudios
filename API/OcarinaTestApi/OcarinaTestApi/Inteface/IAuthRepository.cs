namespace OcarinaTestApi.Inteface
{
    public interface IAuthRepository
    {
        public Task<string> Login(string username, string password);
    }
}
