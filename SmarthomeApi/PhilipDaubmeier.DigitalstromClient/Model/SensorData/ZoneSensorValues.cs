﻿using PhilipDaubmeier.DigitalstromClient.Model.Core;
using System.Collections.Generic;
using System.Linq;

namespace PhilipDaubmeier.DigitalstromClient.Model.SensorData
{
    public class ZoneSensorValues
    {
        public Zone Id { get; set; }
        public string Name { get; set; }
        public List<SensorValue> Values { get; set; }
        public TemperatureValue Temperature { get { return Values.Select(x => (TemperatureValue)x).FirstOrDefault(x => x != null); } }
        public HumidityValue Humidity { get { return Values.Select(x => (HumidityValue)x).FirstOrDefault(x => x != null); } }
        public CO2ConcentrationValue Co2concentration { get { return Values.Select(x => (CO2ConcentrationValue)x).FirstOrDefault(x => x != null); } }
        public BrightnessValue Brightness { get { return Values.Select(x => (BrightnessValue)x).FirstOrDefault(x => x != null); } }
    }
}