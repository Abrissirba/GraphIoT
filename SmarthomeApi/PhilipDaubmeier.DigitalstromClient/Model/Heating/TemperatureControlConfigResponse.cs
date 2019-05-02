﻿using PhilipDaubmeier.DigitalstromClient.Model.Core;
using System.Collections.Generic;

namespace PhilipDaubmeier.DigitalstromClient.Model.Heating
{
    public class HeatingConfigZone
    {
        public Zone Id { get; set; }
        public string Name { get; set; }
        public DSUID ControlDSUID { get; set; }
        public bool IsConfigured { get; set; }
        public int? ControlMode { get; set; }
        public int? EmergencyValue { get; set; }
        public double? CtrlKp { get; set; }
        public int? CtrlTs { get; set; }
        public int? CtrlTi { get; set; }
        public int? CtrlKd { get; set; }
        public double? CtrlImin { get; set; }
        public double? CtrlImax { get; set; }
        public int? CtrlYmin { get; set; }
        public int? CtrlYmax { get; set; }
        public bool? CtrlAntiWindUp { get; set; }
        public bool? CtrlKeepFloorWarm { get; set; }
        public int? ReferenceZone { get; set; }
        public int? CtrlOffset { get; set; }
    }

    public class TemperatureControlConfigResponse : IWiremessagePayload<TemperatureControlConfigResponse>
    {
        public List<HeatingConfigZone> Zones { get; set; }
    }
}