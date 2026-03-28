public class TeslaModel3 : ElectricCar
{
    public TeslaModel3() : base("Tesla", "Model 3", 5, "Андроид Auto", 75, 500)
    {
    }

    public override CarType GetCarType() { return CarType.TeslaModel3; }
}

public class TeslaModelS : ElectricCar
{
    public TeslaModelS() : base("Tesla", "Model S", 5, "Андроид Auto", 100, 650)
    {
    }

    public override CarType GetCarType() { return CarType.TeslaModelS; }
}

public class BMWX5 : AutomaticCar
{
    public BMWX5() : base("BMW", "X5", 5, "iDrive 8", "Steptronic 8-speed", true)
    {
    }

    public override CarType GetCarType() { return CarType.BMWX5; }
}

public class BMWM3 : MechanicalCar
{
    public BMWM3() : base("BMW", "M3", 4, "iDrive 8", 6, "керамическое")
    {
    }

    public override CarType GetCarType() { return CarType.BMWM3; }
}

public class ToyotaCamry : AutomaticCar
{
    public ToyotaCamry() : base("Toyota", "Camry", 5, "Toyota Touch 2", "CVT", false)
    {
    }

    public override CarType GetCarType() { return CarType.ToyotaCamry; }
}

public class ToyotaLandCruiser : AutomaticCar
{
    public ToyotaLandCruiser() : base("Toyota", "Land Cruiser 300", 7, "Toyota Connect", "10-speed Automatic", true)
    {
    }

    public override CarType GetCarType() { return CarType.ToyotaLandCruiser; }
}
