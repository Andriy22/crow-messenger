using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Queries.GetUserByNicknameQuery;

public class GetUserByNicknameQueryHandler : IRequestHandler<GetUserByNicknameQuery, AppUser?>
{
    private readonly IDataContext _dataContext;

    public GetUserByNicknameQueryHandler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AppUser?> Handle(GetUserByNicknameQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(x => x.Nickname.ToLower() == request.Nickname.ToLower(), cancellationToken: cancellationToken);
    }
}