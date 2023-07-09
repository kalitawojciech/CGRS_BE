namespace CGRS.Application.Users.Commands.ChangePassword
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
