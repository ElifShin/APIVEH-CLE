namespace car_API
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Color { get; set; }
    }

    public class Car : Vehicle
    {
        public int Wheels { get; set; }
        public int Headlights { get; set; }
    }

    public class Bus : Vehicle
    {
        public int Capacity { get; set; }
    }

    public class Boat : Vehicle
    {
        public int Length { get; set; }
    }
}