using Application.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Text;

namespace Application.Common.Helpers
{
    public static class IdentityHelper
    {
        public static CustomHttpException GetIdentityErrors(IdentityResult result)
        {
            var errors = new StringBuilder();

            foreach (var error in result.Errors)
            {
                errors.AppendLine($"{error.Code} - {error.Description}");
            }

            return new CustomHttpException(errors.ToString(), HttpStatusCode.BadRequest);
        }
    }
}
