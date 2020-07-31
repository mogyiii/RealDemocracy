using MediatR;
using Dec.Logic.DTOs;
using Dec.Shared.DTOs;

namespace Dec.Logic.Mediator.Commands
{
    public class RegisterCommand : IRequest<ActionResult>
    {
        public PersonDTO User { get; set; }

        public string Password { get; set; }
    }
}
