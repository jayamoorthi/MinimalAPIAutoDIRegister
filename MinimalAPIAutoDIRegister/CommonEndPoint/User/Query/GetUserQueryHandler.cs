using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace MinimalAPIAutoDIRegister.CommonEndPoint.User.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoQueryResponse>
    {
        private readonly IUserService _userService;
       // private readonly IMapper _mapper;


        //private readonly List<User> _users = new List<User>
        //{
        //    new User { Id = Guid.NewGuid(), LastName = "A",FullName = "Product A", Email = "aproduct@gmail.com" },
        //    new User { Id = Guid.NewGuid(), LastName = "B",FullName = "Product B", Email =  "bproduct@gmail.com" },
        //    // Add more fake user as needed
        //};

        public GetUserQueryHandler( IUserService userService
           // , IMapper mapper
            )
        {
            _userService = userService;
           // _mapper = mapper;
        }
        public async Task<GetUserInfoQueryResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(request.UserId);


            if(user == null)
            {
                throw new NotFoundException($"Product with ID {request.UserId} not found.");
            }

            return await Task.FromResult( new GetUserInfoQueryResponse() { Email = user.Email, Id = user.Id, FullName = user.FullName, LastName = user.LastName} );
        }


    }
}
