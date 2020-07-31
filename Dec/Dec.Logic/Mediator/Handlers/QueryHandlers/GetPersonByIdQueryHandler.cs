using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dec.Logic.Interfaces.Repositories;
using Dec.Logic.Mediator.Queries;
using Dec.Shared.DTOs;

namespace Dec.Logic.Mediator.Handlers.QueryHandlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDTO>
    {
        private readonly IPersonRepository _userRepository;

        public GetPersonByIdQueryHandler(IPersonRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var user = _userRepository.Get(request.PersonId);
            return Task.FromResult(user);
        }
    }
}
