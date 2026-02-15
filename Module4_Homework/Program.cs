using System;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n! транспортная система !");
            Console.WriteLine("1 - создать автомобиль");
            Console.WriteLine("2 - создать мотоцикл");
            Console.WriteLine("3 - создать грузовик");
            Console.WriteLine("4 - создать автобус");
            Console.WriteLine("5 - создать электросамокат");
            Console.WriteLine("0 - выход");
            Console.Write("ваш выбор: ");
            string? choice = Console.ReadLine();
            if (choice == "0")
                break;
            VehicleFactory? factory = null;
            switch (choice)
            {
                case "1":
                    Console.Write("введите марку: ");
                    string? carBrand = Console.ReadLine();
                    Console.Write("введите модель: ");
                    string? carModel = Console.ReadLine();
                    Console.Write("введите тип топлива: ");
                    string? fuelType = Console.ReadLine();
                    factory = new CarFactory(carBrand ?? "", carModel ?? "", fuelType ?? "");
                    break;
                case "2":
                    Console.Write("введите тип (спортивный/туристический): ");
                    string? motorcycleType = Console.ReadLine();
                    Console.Write("введите объем двигателя: ");
                    string? engineVolumeStr = Console.ReadLine();
                    int engineVolume = int.Parse(engineVolumeStr ?? "0");
                    factory = new MotorcycleFactory(motorcycleType ?? "", engineVolume);
                    break;
                case "3":
                    Console.Write("введите грузоподъемность (тонн): ");
                    string? capacityStr = Console.ReadLine();
                    double capacity = double.Parse(capacityStr ?? "0");
                    Console.Write("введите количество осей: ");
                    string? axlesStr = Console.ReadLine();
                    int axles = int.Parse(axlesStr ?? "0");
                    factory = new TruckFactory(capacity, axles);
                    break;
                case "4":
                    Console.Write("введите количество мест: ");
                    string? seatsStr = Console.ReadLine();
                    int seats = int.Parse(seatsStr ?? "0");
                    Console.Write("введите маршрут: ");
                    string? route = Console.ReadLine();
                    factory = new BusFactory(seats, route ?? "");
                    break;
                case "5":
                    Console.Write("введите максимальную скорость (км/ч): ");
                    string? speedStr = Console.ReadLine();
                    int maxSpeed = int.Parse(speedStr ?? "0");
                    Console.Write("введите запас хода (км): ");
                    string? rangeStr = Console.ReadLine();
                    int range = int.Parse(rangeStr ?? "0");
                    factory = new ScooterFactory(maxSpeed, range);
                    break;       
                default:
                    Console.WriteLine("неверный выбор");
                    continue;
            }           
            if (factory != null)
            {
                IVehicle vehicle = factory.CreateVehicle();
                Console.WriteLine();
                vehicle.Drive();
                vehicle.Refuel();
            }
        }
    }
}
public interface IVehicle
{
    void Drive();
    void Refuel();
}
public class Car : IVehicle
{
    private string brand;
    private string model;
    private string fuelType;
    public Car(string brand, string model, string fuelType)
    {
        this.brand = brand;
        this.model = model;
        this.fuelType = fuelType;
    }
    public void Drive()
    {
        Console.WriteLine($"автомобиль {brand} {model} едет по дороге");
    }   
    public void Refuel()
    {
        Console.WriteLine($"заправка автомобиля топливом: {fuelType}");
    }
}
public class Motorcycle : IVehicle
{
    private string motorcycleType;
    private int engineVolume;
    public Motorcycle(string motorcycleType, int engineVolume)
    {
        this.motorcycleType = motorcycleType;
        this.engineVolume = engineVolume;
    }
    public void Drive()
    {
        Console.WriteLine($"{motorcycleType} мотоцикл с двигателем {engineVolume}cc мчится по трассе");
    }   
    public void Refuel()
    {
        Console.WriteLine("заправка мотоцикла бензином");
    }
}
public class Truck : IVehicle
{
    private double loadCapacity;
    private int axles;
    public Truck(double loadCapacity, int axles)
    {
        this.loadCapacity = loadCapacity;
        this.axles = axles;
    }
    public void Drive()
    {
        Console.WriteLine($"грузовик грузоподъемностью {loadCapacity} тонн с {axles} осями везет груз");
    }    
    public void Refuel()
    {
        Console.WriteLine("заправка грузовика дизельным топливом");
    }
}

public class Bus : IVehicle
{
    private int seats;
    private string route;
    public Bus(int seats, string route)
    {
        this.seats = seats;
        this.route = route;
    }
    public void Drive()
    {
        Console.WriteLine($"автобус на {seats} мест едет по маршруту {route}");
    }   
    public void Refuel()
    {
        Console.WriteLine("заправка автобуса");
    }
}
public class Scooter : IVehicle
{
    private int maxSpeed;
    private int range;
    public Scooter(int maxSpeed, int range)
    {
        this.maxSpeed = maxSpeed;
        this.range = range;
    }
    public void Drive()
    {
        Console.WriteLine($"электросамокат движется со скоростью до {maxSpeed} км/ч, запас хода {range} км");
    }   
    public void Refuel()
    {
        Console.WriteLine("зарядка аккумулятора электросамоката");
    }
}
public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}
public class CarFactory : VehicleFactory
{
    private string brand;
    private string model;
    private string fuelType;
    public CarFactory(string brand, string model, string fuelType)
    {
        this.brand = brand;
        this.model = model;
        this.fuelType = fuelType;
    }   
    public override IVehicle CreateVehicle()
    {
        return new Car(brand, model, fuelType);
    }
}
public class MotorcycleFactory : VehicleFactory
{
    private string motorcycleType;
    private int engineVolume;
    public MotorcycleFactory(string motorcycleType, int engineVolume)
    {
        this.motorcycleType = motorcycleType;
        this.engineVolume = engineVolume;
    }   
    public override IVehicle CreateVehicle()
    {
        return new Motorcycle(motorcycleType, engineVolume);
    }
}
public class TruckFactory : VehicleFactory
{
    private double loadCapacity;
    private int axles;
    public TruckFactory(double loadCapacity, int axles)
    {
        this.loadCapacity = loadCapacity;
        this.axles = axles;
    }   
    public override IVehicle CreateVehicle()
    {
        return new Truck(loadCapacity, axles);
    }
}
public class BusFactory : VehicleFactory
{
    private int seats;
    private string route;
    public BusFactory(int seats, string route)
    {
        this.seats = seats;
        this.route = route;
    }   
    public override IVehicle CreateVehicle()
    {
        return new Bus(seats, route);
    }
}
public class ScooterFactory : VehicleFactory
{
    private int maxSpeed;
    private int range;
    public ScooterFactory(int maxSpeed, int range)
    {
        this.maxSpeed = maxSpeed;
        this.range = range;
    }   
    public override IVehicle CreateVehicle()
    {
        return new Scooter(maxSpeed, range);
    }
}