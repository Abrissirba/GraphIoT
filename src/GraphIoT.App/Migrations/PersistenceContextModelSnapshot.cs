﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhilipDaubmeier.GraphIoT.App.Database;

namespace PhilipDaubmeier.GraphIoT.App.Migrations
{
    [DbContext(typeof(PersistenceContext))]
    partial class PersistenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromCircuit", b =>
                {
                    b.Property<string>("Dsuid")
                        .HasMaxLength(34);

                    b.HasKey("Dsuid");

                    b.ToTable("DsCircuits");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromEnergyHighresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("EnergyCurvesEveryMeter");

                    b.Property<DateTime>("Key")
                        .HasColumnName("Day");

                    b.HasKey("Id");

                    b.ToTable("DsEnergyHighresDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromEnergyLowresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CircuitId")
                        .HasMaxLength(34);

                    b.Property<string>("EnergyCurve")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Month");

                    b.HasKey("Id");

                    b.HasIndex("CircuitId");

                    b.ToTable("DsEnergyLowresDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromEnergyMidresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CircuitId")
                        .HasMaxLength(34);

                    b.Property<string>("EnergyCurve")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Day");

                    b.HasKey("Id");

                    b.HasIndex("CircuitId");

                    b.ToTable("DsEnergyMidresDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromSceneEventData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventStreamEncoded")
                        .HasMaxLength(10000);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Day");

                    b.HasKey("Id");

                    b.ToTable("DsSceneEventDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromZone", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Name")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("DsZones");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromZoneSensorLowresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HumidityCurve")
                        .HasMaxLength(800);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Month");

                    b.Property<string>("TemperatureCurve")
                        .HasMaxLength(800);

                    b.Property<int>("ZoneId");

                    b.HasKey("Id");

                    b.HasIndex("ZoneId");

                    b.ToTable("DsSensorLowresDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromZoneSensorMidresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HumidityCurve")
                        .HasMaxLength(800);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Day");

                    b.Property<string>("TemperatureCurve")
                        .HasMaxLength(800);

                    b.Property<int>("ZoneId");

                    b.HasKey("Id");

                    b.HasIndex("ZoneId");

                    b.ToTable("DsSensorDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Netatmo.Database.NetatmoMeasureLowresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Decimals");

                    b.Property<DateTime>("Key")
                        .HasColumnName("Month");

                    b.Property<string>("MeasureCurve")
                        .HasMaxLength(800);

                    b.Property<Guid>("ModuleMeasureId");

                    b.HasKey("Id");

                    b.HasIndex("ModuleMeasureId");

                    b.ToTable("NetatmoMeasureLowresDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Netatmo.Database.NetatmoMeasureMidresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Decimals");

                    b.Property<DateTime>("Key")
                        .HasColumnName("Day");

                    b.Property<string>("MeasureCurve")
                        .HasMaxLength(800);

                    b.Property<Guid>("ModuleMeasureId");

                    b.HasKey("Id");

                    b.HasIndex("ModuleMeasureId");

                    b.ToTable("NetatmoMeasureDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Netatmo.Database.NetatmoModuleMeasure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Decimals");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ModuleId")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<string>("ModuleName")
                        .HasMaxLength(30);

                    b.Property<string>("StationName")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("NetatmoModuleMeasures");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Sonnen.Database.SonnenEnergyLowresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BatteryChargingCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("BatteryDischargingCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("BatteryUsocCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("ConsumptionPowerCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("DirectUsagePowerCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("GridFeedinCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("GridPurchaseCurve")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Month");

                    b.Property<string>("ProductionPowerCurve")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("SonnenEnergyLowresDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Sonnen.Database.SonnenEnergyMidresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BatteryChargingCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("BatteryDischargingCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("BatteryUsocCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("ConsumptionPowerCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("DirectUsagePowerCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("GridFeedinCurve")
                        .HasMaxLength(4000);

                    b.Property<string>("GridPurchaseCurve")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Day");

                    b.Property<string>("ProductionPowerCurve")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("SonnenEnergyDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Viessmann.Database.ViessmannHeatingLowresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BoilerTempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("BoilerTempMainCurve")
                        .HasMaxLength(800);

                    b.Property<string>("BurnerActiveCurve")
                        .HasMaxLength(100);

                    b.Property<string>("BurnerMinutesCurve")
                        .HasMaxLength(800);

                    b.Property<string>("BurnerModulationCurve")
                        .HasMaxLength(800);

                    b.Property<string>("BurnerStartsCurve")
                        .HasMaxLength(800);

                    b.Property<string>("Circuit0PumpCurve")
                        .HasMaxLength(100);

                    b.Property<string>("Circuit0TempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("Circuit1PumpCurve")
                        .HasMaxLength(100);

                    b.Property<string>("Circuit1TempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("DhwCirculationPumpCurve")
                        .HasMaxLength(100);

                    b.Property<string>("DhwPrimaryPumpCurve")
                        .HasMaxLength(100);

                    b.Property<string>("DhwTempCurve")
                        .HasMaxLength(800);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Month");

                    b.Property<string>("OutsideTempCurve")
                        .HasMaxLength(800);

                    b.HasKey("Id");

                    b.ToTable("ViessmannHeatingLowresTimeseries");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Viessmann.Database.ViessmannHeatingMidresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BoilerTempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("BoilerTempMainCurve")
                        .HasMaxLength(800);

                    b.Property<string>("BurnerActiveCurve")
                        .HasMaxLength(100);

                    b.Property<double>("BurnerHoursTotal");

                    b.Property<string>("BurnerMinutesCurve")
                        .HasMaxLength(800);

                    b.Property<string>("BurnerModulationCurve")
                        .HasMaxLength(800);

                    b.Property<string>("BurnerStartsCurve")
                        .HasMaxLength(800);

                    b.Property<int>("BurnerStartsTotal");

                    b.Property<string>("Circuit0PumpCurve")
                        .HasMaxLength(100);

                    b.Property<string>("Circuit0TempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("Circuit1PumpCurve")
                        .HasMaxLength(100);

                    b.Property<string>("Circuit1TempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("DhwCirculationPumpCurve")
                        .HasMaxLength(100);

                    b.Property<string>("DhwPrimaryPumpCurve")
                        .HasMaxLength(100);

                    b.Property<string>("DhwTempCurve")
                        .HasMaxLength(800);

                    b.Property<DateTime>("Key")
                        .HasColumnName("Day");

                    b.Property<string>("OutsideTempCurve")
                        .HasMaxLength(800);

                    b.HasKey("Id");

                    b.ToTable("ViessmannHeatingTimeseries");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Viessmann.Database.ViessmannSolarLowresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Key")
                        .HasColumnName("Month");

                    b.Property<string>("SolarCollectorTempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("SolarHotwaterTempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("SolarPumpStateCurve")
                        .HasMaxLength(100);

                    b.Property<string>("SolarSuppressionCurve")
                        .HasMaxLength(100);

                    b.Property<string>("SolarWhCurve")
                        .HasMaxLength(800);

                    b.HasKey("Id");

                    b.ToTable("ViessmannSolarLowresTimeseries");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Viessmann.Database.ViessmannSolarMidresData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Key")
                        .HasColumnName("Day");

                    b.Property<string>("SolarCollectorTempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("SolarHotwaterTempCurve")
                        .HasMaxLength(800);

                    b.Property<string>("SolarPumpStateCurve")
                        .HasMaxLength(100);

                    b.Property<string>("SolarSuppressionCurve")
                        .HasMaxLength(100);

                    b.Property<string>("SolarWhCurve")
                        .HasMaxLength(800);

                    b.Property<int?>("SolarWhTotal");

                    b.HasKey("Id");

                    b.ToTable("ViessmannSolarTimeseries");
                });

            modelBuilder.Entity("PhilipDaubmeier.TokenStore.Database.AuthData", b =>
                {
                    b.Property<string>("AuthDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataContent");

                    b.HasKey("AuthDataId");

                    b.ToTable("AuthDataSet");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromEnergyLowresData", b =>
                {
                    b.HasOne("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromCircuit", "Circuit")
                        .WithMany()
                        .HasForeignKey("CircuitId");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromEnergyMidresData", b =>
                {
                    b.HasOne("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromCircuit", "Circuit")
                        .WithMany()
                        .HasForeignKey("CircuitId");
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromZoneSensorLowresData", b =>
                {
                    b.HasOne("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromZone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromZoneSensorMidresData", b =>
                {
                    b.HasOne("PhilipDaubmeier.GraphIoT.Digitalstrom.Database.DigitalstromZone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Netatmo.Database.NetatmoMeasureLowresData", b =>
                {
                    b.HasOne("PhilipDaubmeier.GraphIoT.Netatmo.Database.NetatmoModuleMeasure", "ModuleMeasure")
                        .WithMany()
                        .HasForeignKey("ModuleMeasureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhilipDaubmeier.GraphIoT.Netatmo.Database.NetatmoMeasureMidresData", b =>
                {
                    b.HasOne("PhilipDaubmeier.GraphIoT.Netatmo.Database.NetatmoModuleMeasure", "ModuleMeasure")
                        .WithMany()
                        .HasForeignKey("ModuleMeasureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
