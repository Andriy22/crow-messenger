using System.Text.RegularExpressions;

namespace Client.Consts
{
    public static class RegexConsts
    {
        public static readonly Regex UserName = new Regex(@"^[a-zA-Z0-9]*$");
        public static readonly Regex Email = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
    }
}
