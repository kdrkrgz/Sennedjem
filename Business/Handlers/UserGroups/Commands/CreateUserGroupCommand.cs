﻿using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.UserGroups.Commands
{
  public class CreateUserGroupCommand : IRequest<IResult>
  {

    public int GroupId { get; set; }
    public int UserId { get; set; }

    public class CreateUserGroupCommandHandler : IRequestHandler<CreateUserGroupCommand, IResult>
    {
      private readonly IUserGroupDal _userGroupDal;

      public CreateUserGroupCommandHandler(IUserGroupDal userGroupDal)
      {
        _userGroupDal = userGroupDal;
      }

      public async Task<IResult> Handle(CreateUserGroupCommand request, CancellationToken cancellationToken)
      {
        var userGroup = new UserGroup
        {
          GroupId = request.GroupId,
          UserId = request.UserId
        };

        await _userGroupDal.AddAsync(userGroup);

        return new SuccessResult(Messages.UserGroupAdded);
      }
    }
  }
}