using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PhilipDaubmeier.ViessmannClient.Tests
{
    public class ViessmannPlatformClientTest
    {
        [Fact]
        public async Task TestGetInstallations()
        {
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When($"{MockViessmannConnection.BaseUri}iot/v1/equipment/installations")
                    .Respond("application/json",
                    @"{
                        ""data"": [
                            {
                                ""id"": " + MockViessmannConnection.InstallationId + @",
                                ""description"": null,
                                ""address"": {
                                    ""street"": ""Long test street"",
                                    ""houseNumber"": ""1001"",
                                    ""zip"": ""12345"",
                                    ""city"": ""Unittest Town"",
                                    ""region"": null,
                                    ""country"": ""de"",
                                    ""phoneNumber"": null,
                                    ""faxNumber"": null,
                                    ""geolocation"": {
                                        ""latitude"": 37.377166,
                                        ""longitude"": -122.086966,
                                        ""timeZone"": ""Europe/Berlin""
                                    }
                                },
                                ""registeredAt"": ""2017-01-29T18:19:44.000Z"",
                                ""updatedAt"": ""2018-06-09T17:57:43.636Z"",
                                ""aggregatedStatus"": ""WorksProperly"",
                                ""servicedBy"": null,
                                ""heatingType"": null
                            }
                        ],
                        ""cursor"": {
                            ""next"": """"
                        }
                    }");

            using var viessmannClient = new ViessmannPlatformClient(mockHttp.AddAuthMock().ToMockProvider());

            var result = await viessmannClient.GetInstallations();

            Assert.Equal(MockViessmannConnection.InstallationId, result.First().LongId);
            Assert.Equal("Long test street", result.First().Address?.Street);
            Assert.Equal("1001", result.First().Address?.HouseNumber);
            Assert.Equal("12345", result.First().Address?.Zip);
            Assert.Equal("Unittest Town", result.First().Address?.City);
            Assert.Null(result.First().Address?.Region);
            Assert.Equal("de", result.First().Address?.Country);
            Assert.Null(result.First().Address?.PhoneNumber);
            Assert.Null(result.First().Address?.FaxNumber);
            Assert.Equal(37.377166d, result.First().Address?.Geolocation?.Latitude);
            Assert.Equal(-122.086966d, result.First().Address?.Geolocation?.Longitude);
            Assert.Equal("Europe/Berlin", result.First().Address?.Geolocation?.TimeZone);
            Assert.Equal("WorksProperly", result.First().AggregatedStatus);
            Assert.Null(result.First().ServicedBy);
            Assert.Null(result.First().HeatingType);
        }

        [Fact]
        public async Task TestGetGateways()
        {
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When($"{MockViessmannConnection.BaseUri}iot/v1/equipment/installations/{MockViessmannConnection.InstallationId}/gateways")
                    .Respond("application/json",
                    @"{
                        ""data"": [
                            {
                                ""serial"": """ + MockViessmannConnection.GatewayId + @""",
                                ""version"": ""1.4.0.0"",
                                ""firmwareUpdateFailureCounter"": 0,
                                ""autoUpdate"": false,
                                ""createdAt"": ""2016-08-01T16:34:22.856Z"",
                                ""producedAt"": ""2016-08-01T14:40:28.000Z"",
                                ""lastStatusChangedAt"": ""2020-03-22T06:07:56.595Z"",
                                ""aggregatedStatus"": ""WorksProperly"",
                                ""targetRealm"": ""Genesis"",
                                ""gatewayType"": ""VitoconnectOptolink"",
                                ""installationId"": " + MockViessmannConnection.InstallationId + @",
                                ""registeredAt"": ""2017-01-29T18:19:44.813Z""
                            }
                        ],
                        ""cursor"": {
                            ""next"": """"
                        }
                    }");

            using var viessmannClient = new ViessmannPlatformClient(mockHttp.AddAuthMock().ToMockProvider());

            var result = await viessmannClient.GetGateways(MockViessmannConnection.InstallationId);

            Assert.Equal(MockViessmannConnection.GatewayId, result.First().LongId);
            Assert.Equal(MockViessmannConnection.GatewayId.ToString(), result.First().Serial);
            Assert.Equal("1.4.0.0", result.First().Version);
            Assert.Equal(false, result.First().AutoUpdate);
            Assert.Equal("WorksProperly", result.First().AggregatedStatus);
            Assert.Equal("Genesis", result.First().TargetRealm);
            Assert.Equal("VitoconnectOptolink", result.First().GatewayType);
            Assert.Equal(MockViessmannConnection.InstallationId, (long?)result.First().InstallationId);
        }

        [Fact]
        public async Task TestGetDevices()
        {
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When($"{MockViessmannConnection.BaseUri}iot/v1/equipment/installations/{MockViessmannConnection.InstallationId}/gateways/{MockViessmannConnection.GatewayId}/devices")
                    .Respond("application/json",
                    @"{
                        ""data"": [
                            {
                                ""gatewaySerial"": """ + MockViessmannConnection.GatewayId + @""",
                                ""id"": """ + MockViessmannConnection.DeviceId + @""",
                                ""boilerSerial"": ""777555888999"",
                                ""boilerSerialEditor"": ""DeviceCommunication"",
                                ""bmuSerial"": ""000999888777"",
                                ""bmuSerialEditor"": ""DeviceCommunication"",
                                ""createdAt"": ""2018-06-08T00:08:10.199Z"",
                                ""editedAt"": ""2019-11-08T20:53:43.470Z"",
                                ""modelId"": ""VPlusHO1_40"",
                                ""status"": ""Online"",
                                ""deviceType"": ""heating""
                            }
                        ]
                    }");

            using var viessmannClient = new ViessmannPlatformClient(mockHttp.AddAuthMock().ToMockProvider());

            var result = await viessmannClient.GetDevices(MockViessmannConnection.InstallationId, MockViessmannConnection.GatewayId);

            Assert.Equal(MockViessmannConnection.DeviceId, result.First().LongId);
            Assert.Equal(MockViessmannConnection.GatewayId.ToString(), result.First().GatewaySerial);
            Assert.Equal(MockViessmannConnection.DeviceId.ToString(), result.First().Id);
            Assert.Equal("777555888999", result.First().BoilerSerial);
            Assert.Equal("DeviceCommunication", result.First().BoilerSerialEditor);
            Assert.Equal("000999888777", result.First().BmuSerial);
            Assert.Equal("DeviceCommunication", result.First().BmuSerialEditor);
            Assert.Equal("VPlusHO1_40", result.First().ModelId);
            Assert.Equal("Online", result.First().Status);
            Assert.Equal("heating", result.First().DeviceType);
        }

        [Fact]
        public async Task TestGetFeatures()
        {
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When($"{MockViessmannConnection.BaseUri}operational-data/v2/installations/{MockViessmannConnection.InstallationId}/gateways/{MockViessmannConnection.GatewayId}/devices/{MockViessmannConnection.DeviceId}/features?reduceHypermedia=true")
                    .Respond("application/json",
                    @"{
                          ""features"": [
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.boiler.temperature"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.688Z"",
                                  ""properties"": {
                                      ""value"": {
                                          ""type"": ""number"",
                                          ""value"": 47.6
                                      }
                                  },
                                  ""commands"": {},
                                  ""components"": []
                              },
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.circuits"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.688Z"",
                                  ""properties"": {
                                      ""enabled"": {
                                          ""type"": ""array"",
                                          ""value"": [ ""0"", ""1"" ]
                                      }
                                  },
                                  ""commands"": {},
                                  ""components"": [ ""0"", ""1"", ""2"" ]
                              },
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.circuits.0.circulation.pump"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.690Z"",
                                  ""properties"": {
                                      ""status"": {
                                          ""type"": ""string"",
                                          ""value"": ""on""
                                      }
                                  },
                                  ""commands"": {},
                                  ""components"": []
                              },
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.circuits.0.heating.curve"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.695Z"",
                                  ""properties"": {
                                      ""shift"": {
                                          ""type"": ""number"",
                                          ""value"": 5
                                      },
                                      ""slope"": {
                                          ""type"": ""number"",
                                          ""value"": 0.9
                                      }
                                  },
                                  ""commands"": {
                                      ""setCurve"": {
                                          ""uri"": """ + MockViessmannConnection.BaseUri + @"operational-data/v2/installations/" + MockViessmannConnection.InstallationId + @"/gateways/" + MockViessmannConnection.GatewayId + @"/devices/" + MockViessmannConnection.DeviceId + @"/features/heating.circuits.0.heating.curve/setCurve"",
                                          ""name"": ""setCurve"",
                                          ""isExecutable"": true,
                                          ""params"": {
                                              ""slope"": {
                                                  ""required"": true,
                                                  ""type"": ""number"",
                                                  ""constraints"": { ""min"": 0.2, ""max"": 3.5, ""stepping"": 0.1 }
                                              },
                                              ""shift"": {
                                                  ""required"": true,
                                                  ""type"": ""number"",
                                                  ""constraints"": { ""min"": -13, ""max"": 40, ""stepping"": 1 }
                                              }
                                          }
                                      }
                                  },
                                  ""components"": []
                              },
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.dhw.schedule"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.736Z"",
                                  ""properties"": {
                                      ""active"": {
                                          ""type"": ""boolean"",
                                          ""value"": true
                                      },
                                      ""entries"": {
                                          ""type"": ""Schedule"",
                                          ""value"": {
                                              ""mon"": [ { ""start"": ""00:00"", ""end"": ""24:00"", ""mode"": ""on"", ""position"": 0 } ],
                                              ""tue"": [ { ""start"": ""00:00"", ""end"": ""24:00"", ""mode"": ""on"", ""position"": 0 } ],
                                              ""wed"": [ { ""start"": ""00:00"", ""end"": ""24:00"", ""mode"": ""on"", ""position"": 0 } ],
                                              ""thu"": [ { ""start"": ""00:00"", ""end"": ""24:00"", ""mode"": ""on"", ""position"": 0 } ],
                                              ""fri"": [ { ""start"": ""00:00"", ""end"": ""24:00"", ""mode"": ""on"", ""position"": 0 } ],
                                              ""sat"": [ { ""start"": ""00:00"", ""end"": ""24:00"", ""mode"": ""on"", ""position"": 0 } ],
                                              ""sun"": [ { ""start"": ""00:00"", ""end"": ""24:00"", ""mode"": ""on"", ""position"": 0 } ],
                                          }
                                      }
                                  },
                                  ""commands"": {
                                      ""setSchedule"": {
                                          ""uri"": """ + MockViessmannConnection.BaseUri + @"operational-data/v2/installations/" + MockViessmannConnection.InstallationId + @"/gateways/" + MockViessmannConnection.GatewayId + @"/devices/" + MockViessmannConnection.DeviceId + @"/features/heating.dhw.schedule/setSchedule"",
                                          ""name"": ""setSchedule"",
                                          ""isExecutable"": true,
                                          ""params"": {
                                              ""newSchedule"": {
                                                  ""required"": true,
                                                  ""type"": ""Schedule"",
                                                  ""constraints"": {
                                                      ""maxEntries"": 4,
                                                      ""resolution"": 10,
                                                      ""modes"": [
                                                          ""on""
                                                      ],
                                                      ""defaultMode"": ""off""
                                                  }
                                              }
                                          }
                                      }
                                  },
                                  ""components"": []
                              },
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.dhw.temperature.main"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.740Z"",
                                  ""properties"": {
                                      ""value"": {
                                          ""type"": ""number"",
                                          ""value"": 50
                                      }
                                  },
                                  ""commands"": {
                                      ""setTargetTemperature"": {
                                          ""uri"": """ + MockViessmannConnection.BaseUri + @"operational-data/v2/installations/" + MockViessmannConnection.InstallationId + @"/gateways/" + MockViessmannConnection.GatewayId + @"/devices/" + MockViessmannConnection.DeviceId + @"/features/heating.dhw.temperature.main/setTargetTemperature"",
                                          ""name"": ""setTargetTemperature"",
                                          ""isExecutable"": true,
                                          ""params"": {
                                              ""temperature"": {
                                                  ""required"": true,
                                                  ""type"": ""number"",
                                                  ""constraints"": {
                                                      ""min"": 10,
                                                      ""max"": 60,
                                                      ""stepping"": 1
                                                  }
                                              }
                                          }
                                      }
                                  },
                                  ""components"": []
                              },
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.sensors.temperature.outside"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.741Z"",
                                  ""properties"": {
                                      ""status"": {
                                          ""type"": ""string"",
                                          ""value"": ""connected""
                                      },
                                      ""value"": {
                                          ""type"": ""number"",
                                          ""value"": 6
                                      }
                                  },
                                  ""commands"": {},
                                  ""components"": []
                              },
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.solar"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.742Z"",
                                  ""properties"": {
                                      ""active"": {
                                          ""type"": ""boolean"",
                                          ""value"": true
                                      }
                                  },
                                  ""commands"": {},
                                  ""components"": [ ""statistics"", ""sensors"", ""rechargeSuppression"" ]
                              },
                              {
                                  ""isEnabled"": true,
                                  ""isReady"": true,
                                  ""gatewayId"": """ + MockViessmannConnection.GatewayId + @""",
                                  ""feature"": ""heating.solar.power.production"",
                                  ""deviceId"": """ + MockViessmannConnection.DeviceId + @""",
                                  ""timestamp"": ""2020-03-23T12:19:28.742Z"",
                                  ""properties"": {
                                      ""day"": {
                                          ""type"": ""array"",
                                          ""value"": [ 9.914, 11.543 ]
                                      },
                                      ""week"": { ""type"": ""array"", ""value"": [] },
                                      ""month"": { ""type"": ""array"", ""value"": [] },
                                      ""year"": { ""type"": ""array"", ""value"": [] },
                                      ""unit"": {
                                          ""type"": ""string"",
                                          ""value"": ""kilowattHour""
                                      }
                                  },
                                  ""commands"": {},
                                  ""components"": []
                              }
                          ]
                      }");

            using var viessmannClient = new ViessmannPlatformClient(mockHttp.AddAuthMock().ToMockProvider());

            var result = await viessmannClient.GetFeatures(MockViessmannConnection.InstallationId, MockViessmannConnection.GatewayId, MockViessmannConnection.DeviceId);

            Assert.Equal(MockViessmannConnection.DeviceId.ToString(), result.First().DeviceId);
            Assert.Equal(9, result.Count());

            var feature1 = result.GetFeature(Model.Features.FeatureName.Name.HeatingBoilerTemperature);
            var feature2 = result.GetFeature(Model.Features.FeatureName.Name.HeatingCircuits);
            var feature3 = result.GetFeature(Model.Features.FeatureName.Name.HeatingCircuitsCirculationPump);
            var feature4 = result.GetFeature(Model.Features.FeatureName.Name.HeatingCircuitsHeatingCurve);
            var feature5 = result.GetFeature(Model.Features.FeatureName.Name.HeatingDhwSchedule);
            var feature6 = result.GetFeature(Model.Features.FeatureName.Name.HeatingDhwTemperatureMain);
            var feature7 = result.GetFeature(Model.Features.FeatureName.Name.HeatingSensorsTemperatureOutside);
            var feature8 = result.GetFeature(Model.Features.FeatureName.Name.HeatingSolar);
            var feature9 = result.GetFeature(Model.Features.FeatureName.Name.HeatingSolarPowerProduction);

            Assert.Equal("number", feature1?.Value?.Type);
            Assert.Equal(47.6, feature1?.Value?.Value);

            Assert.Equal("array", feature2?.Enabled?.Type);
            Assert.Equal(new[] { "0", "1" }.ToList<string?>(), feature2?.Enabled?.Value);

            Assert.Equal("string", feature3?.Status?.Type);
            Assert.Equal("on", feature3?.Status?.Value);

            Assert.Equal("number", feature4?.Shift?.Type);
            Assert.Equal(5m, feature4?.Shift?.Value);
            Assert.Equal("number", feature4?.Slope?.Type);
            Assert.Equal(0.9m, feature4?.Slope?.Value);

            Assert.Equal("boolean", feature5?.Active?.Type);
            Assert.Equal(true, feature5?.Active?.Value);
            Assert.Equal("Schedule", feature5?.Entries?.Type);
            Assert.Equal("00:00", feature5?.Entries?.Value?.Mon?.First()?.Start);
            Assert.Equal("24:00", feature5?.Entries?.Value?.Mon?.First()?.End);
            Assert.Equal("on", feature5?.Entries?.Value?.Mon?.First()?.Mode);
            Assert.Equal(0, feature5?.Entries?.Value?.Mon?.First()?.Position);

            Assert.Equal("number", feature6?.Value?.Type);
            Assert.Equal(50l, feature6?.Value?.Value);

            Assert.Equal("string", feature7?.Status?.Type);
            Assert.Equal("connected", feature7?.Status?.Value);
            Assert.Equal("number", feature7?.Value?.Type);
            Assert.Equal(6l, feature7?.Value?.Value);

            Assert.Equal("boolean", feature8?.Active?.Type);
            Assert.Equal(true, feature8?.Active?.Value);

            Assert.Equal("array", feature9?.Day?.Type);
            Assert.Equal(new[] { 9.914d, 11.543d }.ToList(), feature9?.Day?.Value.ToList());
            Assert.Equal(new List<double>(), feature9?.Week?.Value.ToList());
            Assert.Equal(new List<double>(), feature9?.Month?.Value.ToList());
            Assert.Equal(new List<double>(), feature9?.Year?.Value.ToList());
            Assert.Equal("string", feature9?.Unit?.Type);
            Assert.Equal("kilowattHour", feature9?.Unit?.Value);
        }
    }
}