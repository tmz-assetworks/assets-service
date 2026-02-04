using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{


    public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, Location>
    {
        private readonly ILocationRepository _LocationRepo;

        public UpdateLocationHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }


        public async Task<Location> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {

            var LocationEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Location>(request);
            if (LocationEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var dispensery = await _LocationRepo.GetLocationByLocationId(request.LocationId.Trim());
            if (dispensery != null && dispensery.Id != LocationEntitiy.Id)
            {
                return new Location { Id = -1 };
            }
            LocationEntitiy.ModifiedBy = request.UserId;
            LocationEntitiy.CreatedOn = DateTime.Now;
            LocationEntitiy.ModifiedOn = DateTime.Now;
            LocationEntitiy.LocationAddress = new Core.Entities.LocationAddress()
            {
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Id = request.LocationAddressId,
                CountryId = request.CountryId,
                CountryName = request.CountryName,
                StateId = request.StateId,
                StateName = request.StateName,
                //CityId = request.CityId,
                CityName = request.CityName,
                PinCode = request.PinCode,
                ModifiedOn = DateTime.Now,
                ModifiedBy = request.UserId,
            };
             List<LocationSchedule> locationSchedules = new List<LocationSchedule>();
            for (int i = 0; i < request.locationScheduleCommand.Count(); i++)
            {
                locationSchedules.Add(new LocationSchedule()
                {
                    Id = request.locationScheduleCommand[i].Id,
                    ModifiedOn = DateTime.Now,
                    Day = request.locationScheduleCommand[i].Day,
                    LocationId = 0,
                    StartTime = request.locationScheduleCommand[i].IsOpenAlldays == true ? "" : request.locationScheduleCommand[i].StartTime,
                    EndTime = request.locationScheduleCommand[i].IsOpenAlldays == true ? "" : request.locationScheduleCommand[i].EndTime,
                    ModifiedBy = request.UserId,
                    IsOpenAlldays = request.locationScheduleCommand[i].IsOpenAlldays
                });
            }
            LocationEntitiy.LocationSchedule = locationSchedules;

            var updateLocation = await _LocationRepo.UpdateLocation(LocationEntitiy);
           // var mapUserResponse = Mapper.Mappers.Map<LocationResponse>(updateLocation.Result);
            return updateLocation;
        }

    }
}


