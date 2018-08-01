namespace NefitEasy
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Enumerations;
    using Models;

    public interface INefitEasyClient
    {
        ClientStatus Status { get; }

        void Connect();
        Task ConnectAsync(CancellationToken token = default(CancellationToken));
        void Disconnect();
        Task DisconnectAsync(CancellationToken token = default(CancellationToken));

        int GetActiveProgram();
        Task<int> GetActiveProgramAsync(CancellationToken token = default(CancellationToken));
        ICollection<ProgramSwitch> GetProgram(int programNumber);
        Task<ICollection<ProgramSwitch>> GetProgramAsync(int programNumber, CancellationToken token = default(CancellationToken));
        string GetSwitchPointName(int nameIndex);
        Task<string> GetSwitchPointNameAsync(int nameIndex, CancellationToken token = default(CancellationToken));
        bool? IsFirePlaceFunctionActive();
        Task<bool?> IsFirePlaceFunctionActiveAsync(CancellationToken token = default(CancellationToken));
        bool? IsPreheatingActive();
        Task<bool?> IsPreheatingActiveAsync(CancellationToken token = default(CancellationToken));
        double GetOutdoorTemperature();
        Task<double> GetOutdoorTemperatureAsync(CancellationToken token = default(CancellationToken));
        string GetEasyServiceStatus();
        Task<string> GetEasyServiceStatusAsync(CancellationToken token = default(CancellationToken));
        bool? IgnitionStatus();
        Task<bool?> IgnitionStatusAsync(CancellationToken token = default(CancellationToken));
        bool? RefillNeededStatus();
        Task<bool?> RefillNeededStatusAsync(CancellationToken token = default(CancellationToken));
        bool? ClosingValveStatus();
        Task<bool?> ClosingValveStatusAsync(CancellationToken token = default(CancellationToken));
        bool? ShortTappingStatus();
        Task<bool?> ShortTappingStatusAsync(CancellationToken token = default(CancellationToken));
        bool? SystemLeadingStatus();
        Task<bool?> SystemLeadingStatusAsync(CancellationToken token = default(CancellationToken));
        bool? ThermalDesinfectEnabled();
        Task<bool?> ThermalDesinfectEnabledAsync(CancellationToken token = default(CancellationToken));
        DateTime GetNextThermalDesinfect();
        Task<DateTime> GetNextThermalDesinfectAsync(CancellationToken token = default(CancellationToken));
        double GetSystemPressure();
        Task<double> GetSystemPressureAsync(CancellationToken token = default(CancellationToken));
        double GetCentralHeatingSupplyTemperature();
        Task<double> GetCentralHeatingSupplyTemperatureAsync(CancellationToken token = default(CancellationToken));
        StatusCode GetStatusCode();
        Task<StatusCode> GetStatusCodeAsync(CancellationToken token = default(CancellationToken));
        ProgramSwitch GetCurrentSwitchPoint();
        Task<ProgramSwitch> GetCurrentSwitchPointAsync(CancellationToken token = default(CancellationToken));
        ProgramSwitch GetNextSwitchPoint();
        Task<ProgramSwitch> GetNextSwitchPointAsync(CancellationToken token = default(CancellationToken));
        Location GetLocation();
        Task<Location> GetLocationAsync(CancellationToken token = default(CancellationToken));
        ICollection<GasSample> GetGasUsage();
        Task<ICollection<GasSample>> GetGasUsageAsync(CancellationToken token = default(CancellationToken));
        UiStatus GetUiStatus();
        Task<UiStatus> GetUiStatusAsync(CancellationToken token = default(CancellationToken));
        ICollection<string> GetOwnerInfo();
        Task<ICollection<string>> GetOwnerInfoAsync(CancellationToken token = default(CancellationToken));
        ICollection<string> GetInstallerInfo();
        Task<ICollection<string>> GetInstallerInfoAsync(CancellationToken token = default(CancellationToken));
        string GetEasySerial();
        Task<string> GetEasySerialAsync(CancellationToken token = default(CancellationToken));
        string GetEasyFirmware();
        Task<string> GetEasyFirmwareAsync(CancellationToken token = default(CancellationToken));
        string GetEasyHardware();
        Task<string> GetEasyHardwareAsync(CancellationToken token = default(CancellationToken));
        string GetEasyUuid();
        Task<string> GetEasyUuidAsync(CancellationToken token = default(CancellationToken));
        EasyUpdateStrategy GetEasyUpdateStrategy();
        Task<EasyUpdateStrategy> GetEasyUpdateStrategyAsync(CancellationToken token = default(CancellationToken));
        string GetCentralHeatingSerial();
        Task<string> GetCentralHeatingSerialAsync(CancellationToken token = default(CancellationToken));
        string GetCentralHeatingVersion();
        Task<string> GetCentralHeatingVersionAsync(CancellationToken token = default(CancellationToken));
        string GetCentralHeatingBurnerMake();
        Task<string> GetCentralHeatingBurnerMakeAsync(CancellationToken token = default(CancellationToken));
        EasySensitivity GetEasySensitivity();
        Task<EasySensitivity> GetEasySensitivityAsync(CancellationToken token = default(CancellationToken));
        double GetEasyTemperatureStep();
        Task<double> GetEasyTemperatureStepAsync(CancellationToken token = default(CancellationToken));
        double GetEasyTemperatureOffset();
        Task<double> GetEasyTemperatureOffsetAsync(CancellationToken token = default(CancellationToken));
        bool SetHotWaterModeClockProgram(bool enable);
        Task<bool> SetHotWaterModeClockProgramAsync(bool enable, CancellationToken token = default(CancellationToken));
        bool SetHotWaterModeManualProgram(bool enable);
        Task<bool> SetHotWaterModeManualProgramAsync(bool enable, CancellationToken token = default(CancellationToken));
        bool SetUserMode(UserModes userMode);
        Task<bool> SetUserModeAsync(UserModes userMode, CancellationToken token = default(CancellationToken));
        bool SetTemperature(double temperature);
        Task<bool> SetTemperatureAsync(double temperature, CancellationToken token = default(CancellationToken));
    }
}