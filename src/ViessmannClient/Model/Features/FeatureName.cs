﻿using System.Collections.Generic;
using System.Linq;

namespace PhilipDaubmeier.ViessmannClient.Model.Features
{
    public class FeatureName
    {
        public enum Circuit
        {
            Circuit0 = 0,
            Circuit1 = 1,
            Circuit2 = 2
        }

        public enum Name
        {
            Device,
            DeviceSerial,
            Heating,
            HeatingBoiler,
            HeatingBoilerSensors,
            HeatingBoilerSerial,
            HeatingBoilerSensorsTemperatureCommonSupply,
            HeatingBoilerSensorsTemperatureMain,
            HeatingBoilerTemperature,
            HeatingBurner,
            HeatingBurnerAutomatic,
            HeatingBurnerModulation,
            HeatingBurnerStatistics,
            HeatingCircuits,
            HeatingCircuitsCircuit,
            HeatingCircuitsCirculation,
            HeatingCircuitsCirculationPump,
            HeatingCircuitsCirculationSchedule,
            HeatingCircuitsDhw,
            HeatingCircuitsDhwPumps,
            HeatingCircuitsDhwPumpsCirculation,
            HeatingCircuitsDhwPumpsCirculationSchedule,
            HeatingCircuitsDhwSchedule,
            HeatingCircuitsFrostprotection,
            HeatingCircuitsHeating,
            HeatingCircuitsHeatingCurve,
            HeatingCircuitsHeatingSchedule,
            HeatingCircuitsOperating,
            HeatingCircuitsOperatingModes,
            HeatingCircuitsOperatingModesActive,
            HeatingCircuitsOperatingModesDhw,
            HeatingCircuitsOperatingModesHeating,
            HeatingCircuitsOperatingModesDhwAndHeating,
            HeatingCircuitsOperatingModesForcedNormal,
            HeatingCircuitsOperatingModesForcedReduced,
            HeatingCircuitsOperatingModesStandby,
            HeatingCircuitsOperatingPrograms,
            HeatingCircuitsOperatingProgramsActive,
            HeatingCircuitsOperatingProgramsComfort,
            HeatingCircuitsOperatingProgramsEco,
            HeatingCircuitsOperatingProgramsExternal,
            HeatingCircuitsOperatingProgramsHoliday,
            HeatingCircuitsOperatingProgramsHolidayAtHome,
            HeatingCircuitsOperatingProgramsNormal,
            HeatingCircuitsOperatingProgramsReduced,
            HeatingCircuitsOperatingProgramsStandby,
            HeatingCircuitsSensors,
            HeatingCircuitsSensorsTemperature,
            HeatingCircuitsSensorsTemperatureRoom,
            HeatingCircuitsSensorsTemperatureSupply,
            HeatingCircuitsGeofencing,
            HeatingCo2,
            HeatingCo2Saving,
            HeatingConfiguration,
            HeatingConfigurationMultiFamilyHouse,
            HeatingConfigurationRegulation,
            HeatingControllerSerial,
            HeatingDevice,
            HeatingDeviceTime,
            HeatingDeviceTimeOffset,
            HeatingDhw,
            HeatingDhwCharging,
            HeatingDhwOneTimeCharge,
            HeatingDhwPumpsCirculation,
            HeatingDhwPumpsCirculationSchedule,
            HeatingDhwPumpsPrimary,
            HeatingDhwSchedule,
            HeatingDhwSensors,
            HeatingDhwSensorsTemperature,
            HeatingDhwSensorsTemperatureHotWaterStorage,
            HeatingDhwSensorsTemperatureHotWaterStorageBottom,
            HeatingDhwSensorsTemperatureHotWaterStorageTop,
            HeatingDhwSensorsTemperatureOutlet,
            HeatingDhwTemperature,
            HeatingDhwTemperatureLevels,
            HeatingDhwTemperatureMain,
            HeatingErrors,
            HeatingErrorsActive,
            HeatingErrorsHistory,
            HeatingFuelCell,
            HeatingFuelCellOperating,
            HeatingFuelCellOperatingModes,
            HeatingFuelCellOperatingModesActive,
            HeatingFuelCellOperatingModesEcological,
            HeatingFuelCellOperatingModesEconomical,
            HeatingFuelCellOperatingModesHeatControlled,
            HeatingFuelCellOperatingModesMaintenance,
            HeatingFuelCellOperatingModesStandby,
            HeatingFuelCellOperatingPhase,
            HeatingFuelCellPower,
            HeatingFuelCellPowerProduction,
            HeatingFuelCellSensors,
            HeatingFuelCellSensorsTemperature,
            HeatingFuelCellSensorsTemperatureReturn,
            HeatingFuelCellSensorsTemperatureSupply,
            HeatingFuelCellStatistics,
            HeatingGas,
            HeatingGasConsumption,
            HeatingGasConsumptionDhw,
            HeatingGasConsumptionFuelCell,
            HeatingGasConsumptionHeating,
            HeatingGasConsumptionTotal,
            HeatingHeat,
            HeatingHeatProduction,
            HeatingPower,
            HeatingPowerCumulativeProduced,
            HeatingPowerCumulativePurchased,
            HeatingPowerCumulativeSold,
            HeatingPowerProduction,
            HeatingPowerProductionCumulative,
            HeatingPowerProductionCurrent,
            HeatingPowerProductionDemandCoverage,
            HeatingPowerProductionDemandCoverageCurrent,
            HeatingPowerProductionDemandCoverageTotal,
            HeatingPowerProductionProductionCoverage,
            HeatingPowerProductionProductionCoverageCurrent,
            HeatingPowerProductionProductionCoverageTotal,
            HeatingPowerPurchase,
            HeatingPowerPurchaseCumulative,
            HeatingPowerPurchaseCurrent,
            HeatingPowerSold,
            HeatingPowerSoldCumulative,
            HeatingSensors,
            HeatingSensorsPower,
            HeatingSensorsPowerOutput,
            HeatingSensorsPressure,
            HeatingSensorsPressureSupply,
            HeatingSensorsTemperature,
            HeatingSensorsTemperatureHydraulicSeparator,
            HeatingSensorsTemperatureOutside,
            HeatingSensorsTemperatureReturn,
            HeatingSensorsVolumetricFlow,
            HeatingSensorsVolumetricFlowReturn,
            HeatingServiceTimeBased,
            HeatingServiceBurnerBased,
            HeatingService,
            HeatingSolar,
            HeatingSolarPowerProduction,
            HeatingSolarPumpsCircuit,
            HeatingSolarStatistics,
            HeatingSolarSensors,
            HeatingSolarSensorsTemperature,
            HeatingSolarSensorsTemperatureDhw,
            HeatingSolarSensorsTemperatureCollector,
            HeatingSolarPowerCumulativeProduced,
            HeatingSolarRechargeSuppression,
            Gateway,
            GatewayStatus,
            GatewayWifi,
            GatewayBmuconnection,
            GatewayDevices,
            GatewayFirmware
        }

        private static readonly Dictionary<string, Name> _mapping = new Dictionary<string, Name>()
        {
            {"device", Name.Device},
            {"device.serial", Name.DeviceSerial},
            {"heating", Name.Heating},
            {"heating.boiler", Name.HeatingBoiler},
            {"heating.boiler.sensors", Name.HeatingBoilerSensors},
            {"heating.boiler.serial", Name.HeatingBoilerSerial},
            {"heating.boiler.sensors.temperature.commonSupply", Name.HeatingBoilerSensorsTemperatureCommonSupply},
            {"heating.boiler.sensors.temperature.main", Name.HeatingBoilerSensorsTemperatureMain},
            {"heating.boiler.temperature", Name.HeatingBoilerTemperature},
            {"heating.burner", Name.HeatingBurner},
            {"heating.burner.automatic", Name.HeatingBurnerAutomatic},
            {"heating.burner.modulation", Name.HeatingBurnerModulation},
            {"heating.burner.statistics", Name.HeatingBurnerStatistics},
            {"heating.circuits", Name.HeatingCircuits},
            {"heating.circuits.{circuit}", Name.HeatingCircuitsCircuit},
            {"heating.circuits.{circuit}.circulation", Name.HeatingCircuitsCirculation},
            {"heating.circuits.{circuit}.circulation.pump", Name.HeatingCircuitsCirculationPump},
            {"heating.circuits.{circuit}.circulation.schedule", Name.HeatingCircuitsCirculationSchedule},
            {"heating.circuits.{circuit}.dhw", Name.HeatingCircuitsDhw},
            {"heating.circuits.{circuit}.dhw.pumps", Name.HeatingCircuitsDhwPumps},
            {"heating.circuits.{circuit}.dhw.pumps.circulation", Name.HeatingCircuitsDhwPumpsCirculation},
            {"heating.circuits.{circuit}.dhw.pumps.circulation.schedule", Name.HeatingCircuitsDhwPumpsCirculationSchedule},
            {"heating.circuits.{circuit}.dhw.schedule", Name.HeatingCircuitsDhwSchedule},
            {"heating.circuits.{circuit}.frostprotection", Name.HeatingCircuitsFrostprotection},
            {"heating.circuits.{circuit}.heating", Name.HeatingCircuitsHeating},
            {"heating.circuits.{circuit}.heating.curve", Name.HeatingCircuitsHeatingCurve},
            {"heating.circuits.{circuit}.heating.schedule", Name.HeatingCircuitsHeatingSchedule},
            {"heating.circuits.{circuit}.operating", Name.HeatingCircuitsOperating},
            {"heating.circuits.{circuit}.operating.modes", Name.HeatingCircuitsOperatingModes},
            {"heating.circuits.{circuit}.operating.modes.active", Name.HeatingCircuitsOperatingModesActive},
            {"heating.circuits.{circuit}.operating.modes.dhw", Name.HeatingCircuitsOperatingModesDhw},
            {"heating.circuits.{circuit}.operating.modes.heating", Name.HeatingCircuitsOperatingModesHeating},
            {"heating.circuits.{circuit}.operating.modes.dhwAndHeating", Name.HeatingCircuitsOperatingModesDhwAndHeating},
            {"heating.circuits.{circuit}.operating.modes.forcedNormal", Name.HeatingCircuitsOperatingModesForcedNormal},
            {"heating.circuits.{circuit}.operating.modes.forcedReduced", Name.HeatingCircuitsOperatingModesForcedReduced},
            {"heating.circuits.{circuit}.operating.modes.standby", Name.HeatingCircuitsOperatingModesStandby},
            {"heating.circuits.{circuit}.operating.programs", Name.HeatingCircuitsOperatingPrograms},
            {"heating.circuits.{circuit}.operating.programs.active", Name.HeatingCircuitsOperatingProgramsActive},
            {"heating.circuits.{circuit}.operating.programs.comfort", Name.HeatingCircuitsOperatingProgramsComfort},
            {"heating.circuits.{circuit}.operating.programs.eco", Name.HeatingCircuitsOperatingProgramsEco},
            {"heating.circuits.{circuit}.operating.programs.external", Name.HeatingCircuitsOperatingProgramsExternal},
            {"heating.circuits.{circuit}.operating.programs.holiday", Name.HeatingCircuitsOperatingProgramsHoliday},
            {"heating.circuits.{circuit}.operating.programs.holidayAtHome", Name.HeatingCircuitsOperatingProgramsHolidayAtHome},
            {"heating.circuits.{circuit}.operating.programs.normal", Name.HeatingCircuitsOperatingProgramsNormal},
            {"heating.circuits.{circuit}.operating.programs.reduced", Name.HeatingCircuitsOperatingProgramsReduced},
            {"heating.circuits.{circuit}.operating.programs.standby", Name.HeatingCircuitsOperatingProgramsStandby},
            {"heating.circuits.{circuit}.sensors", Name.HeatingCircuitsSensors},
            {"heating.circuits.{circuit}.sensors.temperature", Name.HeatingCircuitsSensorsTemperature},
            {"heating.circuits.{circuit}.sensors.temperature.room", Name.HeatingCircuitsSensorsTemperatureRoom},
            {"heating.circuits.{circuit}.sensors.temperature.supply", Name.HeatingCircuitsSensorsTemperatureSupply},
            {"heating.circuits.{circuit}.geofencing", Name.HeatingCircuitsGeofencing},
            {"heating.co2", Name.HeatingCo2},
            {"heating.co2.saving", Name.HeatingCo2Saving},
            {"heating.configuration", Name.HeatingConfiguration},
            {"heating.configuration.multiFamilyHouse", Name.HeatingConfigurationMultiFamilyHouse},
            {"heating.configuration.regulation", Name.HeatingConfigurationRegulation},
            {"heating.controller.serial", Name.HeatingControllerSerial},
            {"heating.device", Name.HeatingDevice},
            {"heating.device.time", Name.HeatingDeviceTime},
            {"heating.device.time.offset", Name.HeatingDeviceTimeOffset},
            {"heating.dhw", Name.HeatingDhw},
            {"heating.dhw.charging", Name.HeatingDhwCharging},
            {"heating.dhw.oneTimeCharge", Name.HeatingDhwOneTimeCharge},
            {"heating.dhw.pumps.circulation", Name.HeatingDhwPumpsCirculation},
            {"heating.dhw.pumps.circulation.schedule", Name.HeatingDhwPumpsCirculationSchedule},
            {"heating.dhw.pumps.primary", Name.HeatingDhwPumpsPrimary},
            {"heating.dhw.schedule", Name.HeatingDhwSchedule},
            {"heating.dhw.sensors", Name.HeatingDhwSensors},
            {"heating.dhw.sensors.temperature", Name.HeatingDhwSensorsTemperature},
            {"heating.dhw.sensors.temperature.hotWaterStorage", Name.HeatingDhwSensorsTemperatureHotWaterStorage},
            {"heating.dhw.sensors.temperature.hotWaterStorage.bottom", Name.HeatingDhwSensorsTemperatureHotWaterStorageBottom},
            {"heating.dhw.sensors.temperature.hotWaterStorage.top", Name.HeatingDhwSensorsTemperatureHotWaterStorageTop},
            {"heating.dhw.sensors.temperature.outlet", Name.HeatingDhwSensorsTemperatureOutlet},
            {"heating.dhw.temperature", Name.HeatingDhwTemperature},
            {"heating.dhw.temperature.levels", Name.HeatingDhwTemperatureLevels},
            {"heating.dhw.temperature.main", Name.HeatingDhwTemperatureMain},
            {"heating.errors", Name.HeatingErrors},
            {"heating.errors.active", Name.HeatingErrorsActive},
            {"heating.errors.history", Name.HeatingErrorsHistory},
            {"heating.fuelCell", Name.HeatingFuelCell},
            {"heating.fuelCell.operating", Name.HeatingFuelCellOperating},
            {"heating.fuelCell.operating.modes", Name.HeatingFuelCellOperatingModes},
            {"heating.fuelCell.operating.modes.active", Name.HeatingFuelCellOperatingModesActive},
            {"heating.fuelCell.operating.modes.ecological", Name.HeatingFuelCellOperatingModesEcological},
            {"heating.fuelCell.operating.modes.economical", Name.HeatingFuelCellOperatingModesEconomical},
            {"heating.fuelCell.operating.modes.heatControlled", Name.HeatingFuelCellOperatingModesHeatControlled},
            {"heating.fuelCell.operating.modes.maintenance", Name.HeatingFuelCellOperatingModesMaintenance},
            {"heating.fuelCell.operating.modes.standby", Name.HeatingFuelCellOperatingModesStandby},
            {"heating.fuelCell.operating.phase", Name.HeatingFuelCellOperatingPhase},
            {"heating.fuelCell.power", Name.HeatingFuelCellPower},
            {"heating.fuelCell.power.production", Name.HeatingFuelCellPowerProduction},
            {"heating.fuelCell.sensors", Name.HeatingFuelCellSensors},
            {"heating.fuelCell.sensors.temperature", Name.HeatingFuelCellSensorsTemperature},
            {"heating.fuelCell.sensors.temperature.return", Name.HeatingFuelCellSensorsTemperatureReturn},
            {"heating.fuelCell.sensors.temperature.supply", Name.HeatingFuelCellSensorsTemperatureSupply},
            {"heating.fuelCell.statistics", Name.HeatingFuelCellStatistics},
            {"heating.gas", Name.HeatingGas},
            {"heating.gas.consumption", Name.HeatingGasConsumption},
            {"heating.gas.consumption.dhw", Name.HeatingGasConsumptionDhw},
            {"heating.gas.consumption.fuelCell", Name.HeatingGasConsumptionFuelCell},
            {"heating.gas.consumption.heating", Name.HeatingGasConsumptionHeating},
            {"heating.gas.consumption.total", Name.HeatingGasConsumptionTotal},
            {"heating.heat", Name.HeatingHeat},
            {"heating.heat.production", Name.HeatingHeatProduction},
            {"heating.power", Name.HeatingPower},
            {"heating.power.cumulativeProduced", Name.HeatingPowerCumulativeProduced},
            {"heating.power.cumulativePurchased", Name.HeatingPowerCumulativePurchased},
            {"heating.power.cumulativeSold", Name.HeatingPowerCumulativeSold},
            {"heating.power.production", Name.HeatingPowerProduction},
            {"heating.power.production.cumulative", Name.HeatingPowerProductionCumulative},
            {"heating.power.production.current", Name.HeatingPowerProductionCurrent},
            {"heating.power.production.demandCoverage", Name.HeatingPowerProductionDemandCoverage},
            {"heating.power.production.demandCoverage.current", Name.HeatingPowerProductionDemandCoverageCurrent},
            {"heating.power.production.demandCoverage.total", Name.HeatingPowerProductionDemandCoverageTotal},
            {"heating.power.production.productionCoverage", Name.HeatingPowerProductionProductionCoverage},
            {"heating.power.production.productionCoverage.current", Name.HeatingPowerProductionProductionCoverageCurrent},
            {"heating.power.production.productionCoverage.total", Name.HeatingPowerProductionProductionCoverageTotal},
            {"heating.power.purchase", Name.HeatingPowerPurchase},
            {"heating.power.purchase.cumulative", Name.HeatingPowerPurchaseCumulative},
            {"heating.power.purchase.current", Name.HeatingPowerPurchaseCurrent},
            {"heating.power.sold", Name.HeatingPowerSold},
            {"heating.power.sold.cumulative", Name.HeatingPowerSoldCumulative},
            {"heating.sensors", Name.HeatingSensors},
            {"heating.sensors.power", Name.HeatingSensorsPower},
            {"heating.sensors.power.output", Name.HeatingSensorsPowerOutput},
            {"heating.sensors.pressure", Name.HeatingSensorsPressure},
            {"heating.sensors.pressure.supply", Name.HeatingSensorsPressureSupply},
            {"heating.sensors.temperature", Name.HeatingSensorsTemperature},
            {"heating.sensors.temperature.hydraulicSeparator", Name.HeatingSensorsTemperatureHydraulicSeparator},
            {"heating.sensors.temperature.outside", Name.HeatingSensorsTemperatureOutside},
            {"heating.sensors.temperature.return", Name.HeatingSensorsTemperatureReturn},
            {"heating.sensors.volumetricFlow", Name.HeatingSensorsVolumetricFlow},
            {"heating.sensors.volumetricFlow.return", Name.HeatingSensorsVolumetricFlowReturn},
            {"heating.service.timeBased", Name.HeatingServiceTimeBased},
            {"heating.service.burnerBased", Name.HeatingServiceBurnerBased},
            {"heating.service", Name.HeatingService},
            {"heating.solar", Name.HeatingSolar},
            {"heating.solar.power.production", Name.HeatingSolarPowerProduction},
            {"heating.solar.pumps.circuit", Name.HeatingSolarPumpsCircuit},
            {"heating.solar.statistics", Name.HeatingSolarStatistics},
            {"heating.solar.sensors", Name.HeatingSolarSensors},
            {"heating.solar.sensors.temperature", Name.HeatingSolarSensorsTemperature},
            {"heating.solar.sensors.temperature.dhw", Name.HeatingSolarSensorsTemperatureDhw},
            {"heating.solar.sensors.temperature.collector", Name.HeatingSolarSensorsTemperatureCollector},
            {"heating.solar.power.cumulativeProduced", Name.HeatingSolarPowerCumulativeProduced},
            {"heating.solar.rechargeSuppression", Name.HeatingSolarRechargeSuppression},
            {"gateway", Name.Gateway},
            {"gateway.status", Name.GatewayStatus},
            {"gateway.wifi", Name.GatewayWifi},
            {"gateway.bmuconnection", Name.GatewayBmuconnection},
            {"gateway.devices", Name.GatewayDevices},
            {"gateway.firmware", Name.GatewayFirmware}
        };

        private readonly Name _name = Name.Heating;

        public Circuit CircuitNum { get; } = Circuit.Circuit0;

        public FeatureName(Name name, Circuit? circuit = null)
        {
            _name = name;
            CircuitNum = circuit ?? Circuit.Circuit0;
        }

        public static implicit operator string(FeatureName name)
        {
            var nameStr = _mapping.ToDictionary(x => x.Value, x => x.Key)[name._name];
            return nameStr.Replace(".{circuit}", $".{(int)name.CircuitNum}");
        }

        public static implicit operator FeatureName(string name)
        {
            var circuit = Circuit.Circuit0;
            if (name.Length >= 18 && int.TryParse(name.Replace("heating.circuits.", "").Substring(0, 1), out int circuitNum))
                circuit = (Circuit)circuitNum;

            var placeholder = ".{circuit}";
            name = name.Replace(".0", placeholder).Replace(".1", placeholder).Replace(".2", placeholder);

            if (!_mapping.TryGetValue(name, out Name enumName))
                return new FeatureName(Name.Heating);

            return new FeatureName(enumName, circuit);
        }

        public static implicit operator Name(FeatureName name)
        {
            return name._name;
        }

        public static implicit operator FeatureName(Name name)
        {
            return new FeatureName(name);
        }
    }
}