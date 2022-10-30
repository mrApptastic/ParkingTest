using Microsoft.Extensions.Logging;
using ParkingService.Controllers;
using ParkingService.Models;
using Moq;
using Xunit;

namespace ParkingServiceTest {
    public class ParkingTest
    {
        [Fact]
        public void RegisterParking()
        {
            var test = new ParkingController(Mock.Of<ILogger<ParkingController>>());

            var parking1 = new Parking() {
                LicensePlate = "AB23445",
                LotNumber = "1"
            };

            test.CreateParking(parking1);

            var parkingTotal = test.GetParkings();

            Assert.Equal(1, parkingTotal.Count());

            test.DeleteParking(parking1.LicensePlate, parking1.LotNumber);
        }

        [Fact]
        public void DeleteParking()
        {
            var test = new ParkingController(Mock.Of<ILogger<ParkingController>>());

            var parking1 = new Parking() {
                LicensePlate = "AB23446",
                LotNumber = "2"
            };

            test.CreateParking(parking1);

            test.DeleteParking(parking1.LicensePlate, parking1.LotNumber);

            var parkingTotal = test.GetParkings();

            Assert.Equal(0, parkingTotal.Count());
        }

        [Fact]
        public void GetParking()
        {
            var test = new ParkingController(Mock.Of<ILogger<ParkingController>>());

            var parking1 = new Parking() {
                LicensePlate = "AB23447",
                LotNumber = "3"
            };

            test.CreateParking(parking1);

            var parking = test.GetSpecificParking(parking1.LicensePlate, parking1.LotNumber);

            Assert.Equal(parking1.LicensePlate, parking.LicensePlate);
            Assert.Equal(parking1.LotNumber, parking.LotNumber);
            Assert.Equal(parking1.MobilePhone, parking.MobilePhone);
            Assert.Null(parking.ParkingEnded);
            Assert.True(parking.ParkingStarted < DateTime.Now);

            test.DeleteParking(parking1.LicensePlate, parking1.LotNumber);
        }
    }
}

