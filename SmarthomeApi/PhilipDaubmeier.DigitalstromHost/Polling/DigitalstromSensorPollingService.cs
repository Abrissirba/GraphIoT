﻿using Microsoft.Extensions.Logging;
using PhilipDaubmeier.DigitalstromClient;
using PhilipDaubmeier.DigitalstromClient.Model.Core;
using PhilipDaubmeier.DigitalstromHost.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhilipDaubmeier.DigitalstromHost.Polling
{
    public class DigitalstromSensorPollingService : IDigitalstromPollingService
    {
        private readonly ILogger _logger;
        private readonly IDigitalstromDbContext _dbContext;
        private readonly DigitalstromDssClient _dsClient;

        public DigitalstromSensorPollingService(ILogger<DigitalstromSensorPollingService> logger, IDigitalstromDbContext databaseContext, DigitalstromDssClient dsClient)
        {
            _logger = logger;
            _dbContext = databaseContext;
            _dsClient = dsClient;
        }

        public async Task PollValues()
        {
            _logger.LogInformation($"{DateTime.Now} Digitalstrom Background Service is polling new sensor values...");
            
            try
            {
                await PollSensorValues();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now} Exception occurred in Digitalstrom sensor background worker: {ex.Message}");
            }
        }

        private async Task PollSensorValues()
        {
            var sensorValues = (await _dsClient.GetZonesAndSensorValues()).Zones;
            
            foreach (var zone in sensorValues)
                if (zone != null && zone.Sensor != null)
                    SaveZoneSensorValues(zone.ZoneID, zone.Sensor.ToDictionary(x => x.Type, x => x.Value));

            _dbContext.SaveChanges();
        }
        
        private void SaveZoneSensorValues(int zoneId, Dictionary<Sensor, double> sensorValues)
        {
            var time = DateTime.Now;
            var day = time.Date;
            var dbSensorSeries = _dbContext.DsSensorDataSet.Where(x => x.ZoneId == zoneId && x.Key == day).FirstOrDefault();
            if (dbSensorSeries == null)
            {
                var dbZone = _dbContext.DsZones.Where(x => x.Id == zoneId).FirstOrDefault();
                if (dbZone == null)
                    _dbContext.DsZones.Add(dbZone = new DigitalstromZone() { Id = zoneId });
                
                _dbContext.DsSensorDataSet.Add(dbSensorSeries = new DigitalstromZoneSensorMidresData() { ZoneId = zoneId, Zone = dbZone, Key = day });
            }

            if (sensorValues.ContainsKey(SensorType.TemperatureIndoors))
            {
                var series = dbSensorSeries.TemperatureSeries;
                series[time] = sensorValues[SensorType.TemperatureIndoors];
                dbSensorSeries.SetSeries(0, series);
            }

            if (sensorValues.ContainsKey(SensorType.HumidityIndoors))
            {
                var series = dbSensorSeries.HumiditySeries;
                series[time] = sensorValues[SensorType.HumidityIndoors];
                dbSensorSeries.SetSeries(1, series);
            }
        }
    }
}