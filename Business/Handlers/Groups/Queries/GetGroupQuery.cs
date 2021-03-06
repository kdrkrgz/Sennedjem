﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Groups.Queries
{
    public class GetGroupQuery : IRequest<IDataResult<Group>>
    {
        public int GroupId { get; set; }

        public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, IDataResult<Group>>
        {
            private readonly IGroupRepository _groupDal;

            public GetGroupQueryHandler(IGroupRepository groupDal)
            {
                _groupDal = groupDal;
            }

            public async Task<IDataResult<Group>> Handle(GetGroupQuery request, CancellationToken cancellationToken)
            {
                var group = await _groupDal.GetAsync(x => x.Id == request.GroupId);

                return new SuccessDataResult<Group>(group);
            }
        }
    }
}
