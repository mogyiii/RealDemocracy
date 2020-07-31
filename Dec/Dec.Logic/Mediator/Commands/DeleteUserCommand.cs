using MediatR;
using Dec.Shared.Transaction;

namespace Dec.Logic.Mediator.Commands
{
    public class DeleteUserCommand : IRequest<TransactionResult>
    {
        public int UserId { get; set; }
    }
}
