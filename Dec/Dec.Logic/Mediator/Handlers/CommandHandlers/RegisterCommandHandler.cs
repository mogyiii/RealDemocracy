using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dec.Logic.DTOs;
using Dec.Logic.Identity;
using Dec.Logic.Mediator.Commands;
using Dec.Shared.Interfaces.UnitOfWork;

namespace Dec.Logic.Mediator.Handlers.CommandHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ActionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppIdentityPersonManager _identityUserManager;
        private readonly AppSignInManager _signInManager;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, AppIdentityPersonManager identityUserManager, AppSignInManager signInManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _identityUserManager = identityUserManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _unitOfWork.BeginTransaction();

            var appUser = _mapper.Map<AppIdentityPerson>(request.User);
            var result = await _identityUserManager.CreateAsync(appUser, request.Password);

            if (result.Succeeded)
            {
                var userPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var userId = int.Parse(_identityUserManager.GetUserId(userPrincipal));

                await _signInManager.SignInAsync(appUser, true);

                _unitOfWork.Commit();

                return new ActionResult { Suceeded = true };
            }
            else
            {
                _unitOfWork.Rollback();

                return new ActionResult
                {
                    Suceeded = false,
                    ErrorMessages = result.Errors.Select(x => x.Description).ToList()
                };
            }
        }
    }
}
