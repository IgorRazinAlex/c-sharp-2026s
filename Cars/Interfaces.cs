public interface ICar
{
    string GetDescription();
    CarType GetCarType();
}

public interface IElectric
{
    int GetBatteryCapacity();
    int GetRange();
}

public interface IMechanicalVehicle
{
    int GetNumberOfGears();
    string GetClutchType();
}

public interface IAutomatical
{
    string GetTransmissionType();
    bool HasPaddleShifters();
}

public enum CarType
{
    TeslaModel3,
    TeslaModelS,
    BMWX5,
    BMWM3,
    ToyotaCamry,
    ToyotaLandCruiser
}
