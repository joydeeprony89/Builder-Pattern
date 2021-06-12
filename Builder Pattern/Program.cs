namespace Builder_Pattern
{
    public class IceCreamBuilder
    {
        string flavour;
        string topping;
        int size;

        public string Flavour => flavour;
        public string Topping => topping;
        public int Size => size;

        public IceCreamBuilder SetFlavour(string flavour)
        {
            this.flavour = flavour;
            return this;
        }

        public IceCreamBuilder SetSize(int size)
        {
            this.size = size;
            return this;
        }

        public IceCreamBuilder SetToppings(string topping)
        {
            this.topping = topping;
            return this;
        }

        public IceCream Build()
        {
            return IceCream.Build(this);
        }
    }

    public class IceCream
    {
        private IceCream() { }
        public string Flavour { get; private set; }
        public string Topping { get; private set; }
        public int Size { get; private set; }

        public static IceCream Build(IceCreamBuilder builder)
        {
            return new IceCream()
            {
                Flavour = builder.Flavour,
                Topping = builder.Topping,
                Size = builder.Size
            };
        }

        public void Show()
        {
            System.Console.WriteLine($"Ice cream flavour is of {Flavour} flavour, size = {Size} and topping = {Topping}");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            IceCreamBuilder builder = new IceCreamBuilder();
            IceCream chocoiceCream = builder.SetFlavour("Chocolote")
                    .SetSize(5)
                    .Build();
            chocoiceCream.Show();

            IceCream vanillaicecream = builder.SetFlavour("Vanilla")
                                            .SetSize(2)
                                            .SetToppings("Walnuts")
                                            .Build();
            vanillaicecream.Show();
            // ***************************************************************************************************************************************** //

            IVehicleBuilder carVehicleBuilder = new Car();
            Factory factory = new Factory();
            var car = factory.Assemble(carVehicleBuilder, "Car body", 4, 6, 6);

            car.Show();

            IVehicleBuilder bikeVehicleBuilder = new Bike();
            var bike = factory.Assemble(bikeVehicleBuilder, "Bike body", 2, 2, 2);
            bike.Show();
        }
    }


    // builder pattern with Interface/abstract class.

    public interface IVehicleBuilder
    {
        string Body { get; }
        int Lights { get; }
        int Seats { get; }
        int Wheels { get; }
        IVehicleBuilder AddBody(string body);
        IVehicleBuilder AddWheels(int wheels);
        IVehicleBuilder AddSeats(int seats);
        IVehicleBuilder AddLights(int lights);
        Vehicle Build();
    }

    public class Car : IVehicleBuilder
    {
        string body;
        int lights;
        int seats;
        int wheels;

        public string Body => body;
        public int Lights => lights;
        public int Seats => seats;
        public int Wheels => wheels;

        public IVehicleBuilder AddBody(string body)
        {
            this.body = body;
            return this;
        }

        public IVehicleBuilder AddLights(int lights)
        {
            this.lights = lights;
            return this;
        }

        public IVehicleBuilder AddSeats(int seats)
        {
            this.seats = seats;
            return this;
        }

        public IVehicleBuilder AddWheels(int wheels)
        {
            this.wheels = wheels;
            return this;
        }

        public Vehicle Build()
        {
            return Vehicle.Build(this);
        }
    }

    public class Bike : IVehicleBuilder
    {
        string body;
        int lights;
        int seats;
        int wheels;

        public string Body => body;
        public int Lights => lights;
        public int Seats => seats;
        public int Wheels => wheels;

        public IVehicleBuilder AddBody(string body)
        {
            this.body = body;
            return this;
        }

        public IVehicleBuilder AddLights(int lights)
        {
            this.lights = lights;
            return this;
        }

        public IVehicleBuilder AddSeats(int seats)
        {
            this.seats = seats;
            return this;
        }

        public IVehicleBuilder AddWheels(int wheels)
        {
            this.wheels = wheels;
            return this;
        }

        public Vehicle Build()
        {
            return Vehicle.Build(this);
        }
    }

    public class Vehicle
    {
        public string Body { get; private set; }
        public int Lights { get; private set; }
        public int Seats { get; private set; }
        public int Wheels { get; private set; }


        public static Vehicle Build(IVehicleBuilder builder)
        {
            return new Vehicle()
            {
                Body = builder.Body,
                Lights = builder.Lights,
                Wheels = builder.Wheels,
                Seats = builder.Seats
            };
        }

        public void Show()
        {
            System.Console.WriteLine($"Vehicle body = {Body}, wheels = {Wheels}, seats= {Seats}, lights = {Lights}");
        }
    }

    public class Factory
    {
        public Vehicle Assemble(IVehicleBuilder builder, string body, int wheels, int seats, int lights)
        {
            return builder.AddBody(body)
                    .AddWheels(wheels)
                    .AddSeats(seats)
                    .AddLights(lights)
                    .Build();
        }
    }
}
