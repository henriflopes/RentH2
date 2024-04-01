﻿using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSMotorcycle.Queries
{
    public record GetMotorcycleByNumberPlateQuery(string numberPlate) : IRequest<MotorcycleModel>;
}