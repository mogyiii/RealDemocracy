using MediatR;
using System.Collections.Generic;

namespace Dec.Logic.Mediator.Queries
{
    public class IdentityOptionsQuery : IRequest<IList<string>>
    { }
}
