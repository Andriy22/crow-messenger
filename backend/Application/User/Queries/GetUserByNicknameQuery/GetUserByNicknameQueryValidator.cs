using Application.Common.Constants;
using FluentValidation;

namespace Application.User.Queries.GetUserByNicknameQuery;

public class GetUserByNicknameQueryValidator : AbstractValidator<GetUserByNicknameQuery>
{
    public GetUserByNicknameQueryValidator()
    {
        RuleFor(x => x.Nickname).NotEmpty().MinimumLength(4).Matches(RegexConstants.Nickname);
    }
}