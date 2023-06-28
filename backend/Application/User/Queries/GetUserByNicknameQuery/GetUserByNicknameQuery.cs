using Domain;
using MediatR;

namespace Application.User.Queries.GetUserByNicknameQuery;

public record GetUserByNicknameQuery(string Nickname) : IRequest<AppUser?>;