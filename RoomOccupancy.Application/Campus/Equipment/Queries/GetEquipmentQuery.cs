﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoomOccupancy.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoomOccupancy.Application.Campus.Equipment.Queries
{
    public class GetEquipmentQuery : IRequest<List<EquipmentModel>>
    {
        public class Handler : IRequestHandler<GetEquipmentQuery, List<EquipmentModel>>
        {
            private readonly IReservationDbContext context;
            private readonly IMapper mapper;

            public Handler(IReservationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public Task<List<EquipmentModel>> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
            {
                return context.Equipment
                    .AsNoTracking()
                    .ProjectTo<EquipmentModel>(mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
