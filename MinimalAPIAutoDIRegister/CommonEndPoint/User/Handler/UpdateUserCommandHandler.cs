using AutoMapper;
using Domain.BaseDomain.DomainModels;
using Domain.Interfaces;
using MediatR;


    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, LoginUser>
    {
        private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
        _mapper = mapper;
    }

        public async Task<LoginUser> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            if (request == null || request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var user = _mapper.Map<LoginUser>(request);
            return await _userService.UpdateAsync(user.Id, user);
        }

        //public async Task<User> HandleAsync(UpdateUserCommand request, CancellationToken cancellationToken)
        //{
           

        //    if (request == null || request == null)
        //    {
        //        throw new ArgumentNullException(nameof(request));
        //    }
        //return await _userService.UpdateAsync(request.UserId, request.User);
            
        //}
    }

