namespace C03_HeThongTimGiupViec.ViewModels
{
    public class UserRole
    {
        public const string Admin = "Admin";
        public const string Host = "Host";
        public const string Handyman = "Handyman";

        public static readonly List<string> Roles = new List<string> { Admin, Host, Handyman };
    }
}
