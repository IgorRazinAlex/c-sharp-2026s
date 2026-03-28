using System;

public static class CarFactory
{
    public static ICar CreateCar(CarType carType)
    {
        switch (carType)
        {
            case CarType.TeslaModel3:
                return new TeslaModel3();
            case CarType.TeslaModelS:
                return new TeslaModelS();
            case CarType.BMWX5:
                return new BMWX5();
            case CarType.BMWM3:
                return new BMWM3();
            case CarType.ToyotaCamry:
                return new ToyotaCamry();
            case CarType.ToyotaLandCruiser:
                return new ToyotaLandCruiser();
            default:
                throw new ArgumentException($"Неизвестный тип автомобиля: {carType}");
        }
    }
}
