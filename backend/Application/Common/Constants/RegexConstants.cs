using System.Text.RegularExpressions;

namespace Application.Common.Constants;

public static class RegexConstants
{
    public static readonly Regex Nickname = new Regex(@"^[a-zA-Z0-9]*$");
}