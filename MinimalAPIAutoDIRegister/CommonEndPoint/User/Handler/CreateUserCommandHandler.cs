﻿using AutoMapper;
using Domain.BaseDomain.DomainModels;
using Domain.Interfaces;
using MediatR;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, LoginUser>
    {
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
        public async Task<LoginUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

           
            // Simulate creating a new product
            //var user = new User
            //{
            //    Id = request.Id,
            //    LastName = request.LastName,
            //    Email = request.Email,
            //    FullName = request.FullName
                
            //};
            var user = _mapper.Map<LoginUser>(request);

            return await _userService.InsertAsync(user);
            // Return_ the newly created users ID
           
        }
    }

