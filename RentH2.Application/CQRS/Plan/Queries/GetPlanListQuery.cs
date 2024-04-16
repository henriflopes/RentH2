﻿using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSPlan.Queries
{
    public record GetPlanListQuery() : IRequest<ResponseModel>;
}
