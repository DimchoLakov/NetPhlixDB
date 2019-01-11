﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDB.Data;
using NetPhlixDB.Services;
using NetPhlixDB.Services.Mapping.Profiles;
using NetPhlixDB.Services.Mapping.Profiles.Admin;
using Xunit;

namespace NetPhlixDB.Tests
{
    public class EventsServiceTests
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventsServiceTests()
        {
            var options = new DbContextOptionsBuilder<NetPhlixDbContext>()
                .UseInMemoryDatabase("Test")
                .Options;
            this._dbContext = new NetPhlixDbContext(options);
            var mappingConfig = new MapperConfiguration(
                mc =>
                {
                    mc.AddProfiles(
                        typeof(MoviesProfile),
                        typeof(UsersProfile),
                        typeof(CompaniesProfile),
                        typeof(ReviewsProfile),
                        typeof(PeopleProfile),
                        typeof(EventsProfile),
                        typeof(AdminProfile)
                    );
                });
            this._mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateEventShouldReturnOne()
        {
            var service = new EventsService(this._dbContext, this._mapper);

            var result = await service.CreateEvent(new CreateEventViewModel());

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetAllShouldReturnCorrectCount()
        {
            var service = new EventsService(this._dbContext, this._mapper);
            await service.CreateEvent(new CreateEventViewModel());
            await service.CreateEvent(new CreateEventViewModel());

            var allEvents = await service.GetAll();
            var count = allEvents.Count();
            
            Assert.Equal(2, count);
        }
    }
}
