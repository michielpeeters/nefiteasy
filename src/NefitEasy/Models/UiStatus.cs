namespace NefitEasy.Models
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Enumerations;
    using Internal;
    using Parsing;

    public class UiStatus
    {
        public ClockProgram ClockProgram { get; }
        public InHouseStatus InHouseStatus { get; }
        public double InHouseTemperature { get; }
        public BoilerIndicator BoilerIndicator { get; }
        public ControlMode Control { get; }
        public double TempOverrideDuration { get; }
        public int CurrentProgramSwitch { get; }
        public bool PowerSaveMode { get; }
        public bool FireplaceMode { get; }
        public bool HotWaterAvailable { get; }
        public bool TempOverride { get; }
        public bool HolidayMode { get; }
        public bool BoilerBlock { get; }
        public bool DayAsSunday { get; }
        public bool BoilerLock { get; }
        public bool BoilerMaintenance { get; }
        public double TemperatureSetpoint { get; }
        public double TemperatureOverrideSetpoint { get; }
        public double TemparatureManualSetpoint { get; }
        public bool HedEnabled { get; }
        string HedDeviceName { get; }
        public bool HedDeviceAtHome { get; }
        public UserModes UserMode { get; }

        internal UiStatus(NefitEasyStatus stat)
        {
            var boolParser = new NefitEasyBoolParser();

            UserMode = (UserModes) Enum.Parse(typeof(UserModes), stat.UMD, true);
            ClockProgram = (ClockProgram) Enum.Parse(typeof(ClockProgram), stat.CPM, true);
            InHouseStatus = (InHouseStatus) Enum.Parse(typeof(InHouseStatus), stat.IHS, true);
            Control = (ControlMode) Enum.Parse(typeof(ControlMode), stat.CTR, true);
            BoilerIndicator = EnumHelper.ToArray<BoilerIndicator>()
                .FirstOrDefault(bi => (int) bi == (int) (BoilerIndicatorRef) Enum.Parse(typeof(BoilerIndicatorRef), stat.BAI, true));
            InHouseTemperature = double.Parse(stat.IHT, CultureInfo.InvariantCulture);
            TempOverrideDuration = double.Parse(stat.TOD, CultureInfo.InvariantCulture);
            CurrentProgramSwitch = Convert.ToInt32(stat.CSP);
            PowerSaveMode = boolParser.Execute(stat.ESI);
            FireplaceMode = boolParser.Execute(stat.FPA);
            TempOverride = boolParser.Execute(stat.TOR);
            HolidayMode = boolParser.Execute(stat.HMD);
            BoilerBlock = boolParser.Execute(stat.BBE);
            DayAsSunday = boolParser.Execute(stat.DAS);
            BoilerLock = boolParser.Execute(stat.BLE);
            BoilerMaintenance = boolParser.Execute(stat.BMR);
            TemperatureSetpoint = double.Parse(stat.TSP, CultureInfo.InvariantCulture);
            TemperatureOverrideSetpoint = double.Parse(stat.TOT, CultureInfo.InvariantCulture);
            TemparatureManualSetpoint = double.Parse(stat.MMT, CultureInfo.InvariantCulture);
            HedEnabled = boolParser.Execute(stat.HED_EN);
            HedDeviceAtHome = boolParser.Execute(stat.HED_DEV);
            HotWaterAvailable = boolParser.Execute(stat.DHW);
            HedDeviceName = stat.HED_DB;
        }
    }
}