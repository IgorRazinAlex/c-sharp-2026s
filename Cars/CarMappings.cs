using System;
using System.Collections.Generic;

public static class CarMappings
{
    public static readonly Dictionary<string, CarType> ModelDictionary = new Dictionary<string, CarType>(StringComparer.OrdinalIgnoreCase)
    {
        { "tesla", CarType.TeslaModel3 },
        { "tesla model 3", CarType.TeslaModel3 },
        { "model 3", CarType.TeslaModel3 },
        { "model3", CarType.TeslaModel3 },
        { "tesla model s", CarType.TeslaModelS },
        { "model s", CarType.TeslaModelS },
        { "models", CarType.TeslaModelS },
        { "bmw x5", CarType.BMWX5 },
        { "x5", CarType.BMWX5 },
        { "bmw m3", CarType.BMWM3 },
        { "m3", CarType.BMWM3 },
        { "toyota camry", CarType.ToyotaCamry },
        { "camry", CarType.ToyotaCamry },
        { "toyota land cruiser", CarType.ToyotaLandCruiser },
        { "land cruiser", CarType.ToyotaLandCruiser },
        { "cruiser", CarType.ToyotaLandCruiser }
    };
    
    public static readonly string AvailableModels = 
        "  - Tesla (Model 3)\n" +
        "  - Tesla Model S\n" +
        "  - BMW X5\n" +
        "  - BMW M3\n" +
        "  - Toyota Camry\n" +
        "  - Toyota Land Cruiser";
}
