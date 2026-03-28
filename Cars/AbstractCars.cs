public abstract class ACar : ICar
{
    protected string Brand { get; set; }
    protected string Model { get; set; }
    protected int Seats { get; set; }
    protected string InfotainmentSystem { get; set; }

    protected ACar(string brand, string model, int seats, string infotainmentSystem)
    {
        Brand = brand;
        Model = model;
        Seats = seats;
        InfotainmentSystem = infotainmentSystem;
    }

    public virtual string GetDescription()
    {
        return $"{Brand} {Model}: {GetPowerTrainType()} с {GetTransmissionDescription()}, " +
               $"{Seats} местами, {InfotainmentSystem} на борту";
    }

    public abstract CarType GetCarType();
    protected abstract string GetPowerTrainType();
    protected abstract string GetTransmissionDescription();
}

public abstract class ElectricCar : ACar, IElectric
{
    protected int BatteryCapacity { get; set; }
    protected int Range { get; set; }

    protected ElectricCar(string brand, string model, int seats, string infotainmentSystem, 
                         int batteryCapacity, int range) 
        : base(brand, model, seats, infotainmentSystem)
    {
        BatteryCapacity = batteryCapacity;
        Range = range;
    }

    protected override string GetPowerTrainType() 
    { 
        return "электрический автомобиль"; 
    }
    
    protected override string GetTransmissionDescription()
    {
        return "автоматической коробкой передач (одноступенчатая)";
    }

    public int GetBatteryCapacity() { return BatteryCapacity; }
    public int GetRange() { return Range; }

    public override string GetDescription()
    {
        return base.GetDescription() + $", батарея {BatteryCapacity} кВт⋅ч, запас хода {Range} км";
    }
}

public abstract class AutomaticCar : ACar, IAutomatical
{
    protected string TransmissionType { get; set; }
    protected bool HasPaddles { get; set; }

    protected AutomaticCar(string brand, string model, int seats, string infotainmentSystem,
                          string transmissionType, bool hasPaddles)
        : base(brand, model, seats, infotainmentSystem)
    {
        TransmissionType = transmissionType;
        HasPaddles = hasPaddles;
    }

    protected override string GetTransmissionDescription() 
    { 
        return $"автоматической коробкой передач ({TransmissionType})";
    }
    
    protected override string GetPowerTrainType() 
    { 
        return "автомобиль с ДВС";
    }

    public string GetTransmissionType() { return TransmissionType; }
    public bool HasPaddleShifters() { return HasPaddles; }
}

public abstract class MechanicalCar : ACar, IMechanicalVehicle
{
    protected int NumberOfGears { get; set; }
    protected string ClutchType { get; set; }

    protected MechanicalCar(string brand, string model, int seats, string infotainmentSystem,
                           int numberOfGears, string clutchType)
        : base(brand, model, seats, infotainmentSystem)
    {
        NumberOfGears = numberOfGears;
        ClutchType = clutchType;
    }

    protected override string GetTransmissionDescription() 
    { 
        return $"механической коробкой передач ({NumberOfGears} ступеней, сцепление {ClutchType})";
    }

    protected override string GetPowerTrainType() 
    { 
        return "автомобиль с ДВС";
    }

    public int GetNumberOfGears() { return NumberOfGears; }
    public string GetClutchType() { return ClutchType; }
}
