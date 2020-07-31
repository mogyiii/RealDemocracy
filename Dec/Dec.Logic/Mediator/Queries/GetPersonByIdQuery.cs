using MediatR;
using Dec.Shared.DTOs;

namespace Dec.Logic.Mediator.Queries
{
    public class GetPersonByIdQuery : IRequest<PersonDTO>
    {
        public int PersonId { get; set; }
    }
}
