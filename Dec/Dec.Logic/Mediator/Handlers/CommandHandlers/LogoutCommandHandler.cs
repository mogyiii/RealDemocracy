using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dec.Logic.Identity;
using Dec.Logic.Mediator.Commands;

namespace Dec.Logic.Mediator.Handlers.CommandHandlers
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly AppSignInManager _signInManager;

        public LogoutCommandHandler(AppSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _signInManager.SignOutAsync();

            return Unit.Value;
        }
    }
}
