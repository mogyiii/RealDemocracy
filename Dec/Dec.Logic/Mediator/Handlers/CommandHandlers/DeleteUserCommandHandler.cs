using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dec.Logic.Interfaces.Managers;
using Dec.Logic.Mediator.Commands;
using Dec.Shared.Transaction;

namespace Dec.Logic.Mediator.Handlers.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, TransactionResult>
    {
        private readonly IPersonManager _userManager;

        public DeleteUserCommandHandler(IPersonManager userManager)
        {
            _userManager = userManager;
        }

        public Task<TransactionResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = _userManager.Delete(request.UserId);
            return Task.FromResult(result);
        }
    }
}
