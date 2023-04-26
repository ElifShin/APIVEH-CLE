using car_API;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/vehicles")]
public class VehicleController : ControllerBase
{
    private readonly List<Vehicle> _vehicles = new List<Vehicle>
    {
        new Car { Id = 1, Color = "red", Wheels = 4, Headlights = 2 },
        new Bus { Id = 2, Color = "blue", Capacity = 50 },
        new Car { Id = 3, Color = "red", Wheels = 4, Headlights = 0 },
        new Boat{ Id = 4, Color = "black", Length = 30 },
        new Bus { Id = 5, Color = "blue", Capacity = 40 }
    };

    [HttpGet("cars")]
    public IActionResult GetCarsByColor(string color)
    {
        if (string.IsNullOrEmpty(color))
        {
            return BadRequest("Color parameter is missing or invalid.");
        }

        var cars = _vehicles.OfType<Car>().Where(c => c.Color == color).ToList();

        if (cars.Count == 0)
        {
            return NotFound($"No cars with color '{color}' were found.");
        }

        return Ok(cars);
    }

    [HttpGet("buses")]
    public IActionResult GetBusesByColor(string color)
    {
        if (string.IsNullOrEmpty(color))
        {
            return BadRequest("Color parameter is missing or invalid.");
        }

        var buses = _vehicles.OfType<Bus>().Where(b => b.Color == color).ToList();

        if (buses.Count == 0)
        {
            return NotFound($"No buses with color '{color}' were found.");
        }

        return Ok(buses);
    }

    [HttpGet("boats")]
    public IActionResult GetBoatsByColor(string color)
    {
        if (string.IsNullOrEmpty(color))
        {
            return BadRequest("Color parameter is missing or invalid.");
        }

        var boats = _vehicles.OfType<Boat>().Where(b => b.Color == color).ToList();

        if (boats.Count == 0)
        {
            return NotFound($"No boats with color '{color}' were found.");
        }

        return Ok(boats);
    }

    [HttpPost("cars/{id}/headlights")]
    public IActionResult TurnCarHeadlights(int id, [FromBody] bool on)
    {
        var car = _vehicles.OfType<Car>().SingleOrDefault(c => c.Id == id);

        if (car == null)
        {
            return NotFound($"No car with ID '{id}' was found.");
        }

        car.Headlights = on ? 2 : 0;

        return Ok();
    }

    [HttpDelete("cars/{id}")]
    public IActionResult DeleteCar(int id)
    {
        var car = _vehicles.OfType<Car>().SingleOrDefault(c => c.Id == id);

        if (car == null)
        {
            return NotFound($"No car with ID '{id}' was found.");
        }

        _vehicles.Remove(car);

        return Ok();
    }
}