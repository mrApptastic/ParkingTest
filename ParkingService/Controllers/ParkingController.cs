using Microsoft.AspNetCore.Mvc;
using ParkingService.Models;

namespace ParkingService.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingController : ControllerBase
{
    private readonly ILogger<ParkingController> _logger;
    public ParkingController(ILogger<ParkingController> logger) {
        _logger = logger;
    }
    
    [HttpGet]
    public List<Parking> GetParkings()
    {
        return ParkingTempData.TempStoredParkings;
    }

    [HttpGet("{licensePlate}/{parkingLot}")]
    public Parking GetSpecificParking([FromRoute]string licensePlate, [FromRoute]string parkingLot)
    {
        return ParkingTempData.TempStoredParkings.FirstOrDefault(x => x.LicensePlate == licensePlate && x.LotNumber == parkingLot);
    }

    [HttpPost]
    public void CreateParking([FromBody]Parking parking)
    {
        ParkingTempData.TempStoredParkings.Add(parking);
    }

    
    [HttpDelete("{licensePlate}/{parkingLot}")]
    public void DeleteParking([FromRoute]string licensePlate, [FromRoute]string parkingLot)
    {
        var parking = this.GetSpecificParking(licensePlate, parkingLot);

        if (parking != null) {
            ParkingTempData.TempStoredParkings.Remove(parking);
        }
    }
}
