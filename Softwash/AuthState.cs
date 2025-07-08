namespace Softwash
{
    public class AuthState
    {
        public bool IsAuthenticated { get; private set; }

        public void LogIn()
        {
            IsAuthenticated = true;
        }

        public void LogOut()
        {
            IsAuthenticated = false;
        }
    }

}
