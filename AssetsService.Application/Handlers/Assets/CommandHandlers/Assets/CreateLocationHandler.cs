using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, Location>
    {
        private readonly ILocationRepository _locationRepo;

        public CreateLocationHandler(ILocationRepository LocationRepository)
        {
            _locationRepo = LocationRepository;
        }
        public async Task<Location> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var LocationEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Location>(request);

            if (LocationEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            LocationEntitiy.IsActive = true;//set newly created customer as a active
            LocationEntitiy.CreatedOn = DateTime.Now;
            LocationEntitiy.LocationAddressId = 0;
            LocationEntitiy.LocationStatusId = 0;
            LocationEntitiy.DepartmentId = 0;
            LocationEntitiy.CreatedBy = "";
            LocationEntitiy.FuelProtectType = "";
            LocationEntitiy.GlobalTax = "";
            LocationEntitiy.ModifiedBy = "";
            LocationEntitiy.ModifiedOn = DateTime.Now;
            LocationEntitiy.TimeZone = "";
            LocationEntitiy.CreatedBy = request.UserId;
            LocationEntitiy.ModifiedOn = DateTime.Now;
            LocationEntitiy.Email = "";
            LocationEntitiy.AlternateMobileNumber = "";
            LocationEntitiy.LocationStatusId = request.LocationStatusId;
            LocationEntitiy.DepartmentId = request.DepartmentId;
            LocationEntitiy.LocationName = request.LocationName;
            LocationEntitiy.LocationAddress = new Core.Entities.LocationAddress()
            {
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Id = 0,
                CountryId = request.CountryId,
                CountryName = request.CountryName,
                StateId = request.StateId,
                StateName = request.StateName,
                CityId = request.CityId,
                CityName = request.CityName,
                PinCode = request.PinCode,
                ModifiedOn = DateTime.Now,
                CreatedBy = request.UserId,
                ModifiedBy = "",
                LandlineNumber = "",
                CreatedOn = DateTime.Now,
                IsActive = true
            };
            // LocationEntitiy.LocationStatus = new Core.Entities.LocationStatus()
            // {
            //     Id = request.LocationStatusId,
            //     LocationStatusName = request.LocationStatusName,
            //     ModifiedOn = DateTime.Now,
            //     CreatedOn = DateTime.Now,
            //     CreatedBy = "",
            //     ModifiedBy = ""
            // };
            // LocationEntitiy.Department = new Core.Entities.Department()
            // {
            //     Id = 0,
            //     ContactPersonName = request.ContactPersonNameDepartment,
            //     Address = request.Address,
            //     CreatedBy = "",
            //     CreatedOn = DateTime.Now,
            //     IsActive = true,
            //     ModifiedOn = DateTime.Now,
            //     DepartmentName = "",
            //     ModifiedBy = ""
            // };
            List<LocationSchedule> locationSchedules = new List<LocationSchedule>();
            for (int i = 0; i < request.locationScheduleCommand.Count(); i++)
            {
                locationSchedules.Add(new LocationSchedule()
                {
                    Id = 0,
                    CreatedBy = request.UserId,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    Day = request.locationScheduleCommand[i].Day,
                    LocationId = 0,
                    StartTime = request.locationScheduleCommand[i].StartTime,
                    EndTime = request.locationScheduleCommand[i].EndTime,
                    IsActive = true,
                    ModifiedBy = ""
                });
            }
            LocationEntitiy.LocationSchedule = locationSchedules;
            
            // List<OperatorUserMapper> operatorUserMapper = new List<OperatorUserMapper>();
            // for (int i = 0; i < request.operatorUserMapperCommand.Count(); i++)
            // {
            //     operatorUserMapper.Add(new OperatorUserMapper(){
            //     LocationId = 0,
            //     UserId = request.UserId,
            //     UserName = "",
            //     CreatedBy = request.UserId,
            //     ModifiedBy = "",
            //     ModifiedOn = DateTime.Now,
            //     CreatedOn = DateTime.Now,
            //     IsActive = true
            //   });
            // }
            // LocationEntitiy.OperatorUserMapper = operatorUserMapper;
            var location = await _locationRepo.CreateLocation(LocationEntitiy);
            // var mapLocationResponse = Mapper.Mappers.Map<LocationResponse>(addLocationResponse);
            return location;
        }

    }
}