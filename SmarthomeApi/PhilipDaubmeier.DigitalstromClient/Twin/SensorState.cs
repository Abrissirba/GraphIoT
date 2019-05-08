﻿using PhilipDaubmeier.DigitalstromClient.Model.Core;
using PhilipDaubmeier.DigitalstromClient.Model.PropertyTree;

namespace PhilipDaubmeier.DigitalstromClient.Twin
{
    public class SensorState : AbstractState<SensorTypeAndValues>
    {
        public SensorState()
        {
            Value = new SensorTypeAndValues()
            {
                Type = SensorType.UnknownType,
                Time = 0,
                Value = 0
            };
        }
    }
}