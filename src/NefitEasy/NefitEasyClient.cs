namespace NefitEasy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Enumerations;
    using Extensions;
    using Models;
    using Models.Internal;
    using Parsing;

    public class NefitEasyClient : INefitEasyClient
    {
        private readonly INefitEasyGateway _gateway;

        public event EventHandler<ClientStatus> OnStatusChanged;

        public ClientStatus Status { get; private set; }

        public NefitEasyClient(NefitEasyCredentials credentials)
        {
            _gateway = new NefitEasyGateway(credentials);
            _gateway.OnClientStatusChanged += (sender, status) =>
            {
                Status = status;
                OnStatusChanged?.Invoke(this, status);
            };
        }

        public void Connect() => ConnectAsync().GetAwaiter().GetResult();

        public async Task ConnectAsync(CancellationToken token = default(CancellationToken))
        {
            await _gateway.ConnectAsync(token).ConfigureAwait(false);
        }

        public void Disconnect() => DisconnectAsync().GetAwaiter().GetResult();

        public async Task DisconnectAsync(CancellationToken token = default(CancellationToken))
        {
            await _gateway.DisconnectAsync(token).ConfigureAwait(false);
        }

        public int GetActiveProgram() => GetActiveProgramAsync().GetAwaiter().GetResult();

        public async Task<int> GetActiveProgramAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<int>(NefitEndpointConstants.USER_PROGRAM_ACTIVE_PROGRAM_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public ICollection<ProgramSwitch> GetProgram(int programNumber) => GetProgramAsync(programNumber).GetAwaiter().GetResult();

        public async Task<ICollection<ProgramSwitch>> GetProgramAsync(int programNumber, CancellationToken token = default(CancellationToken))
        {
            if (programNumber < 0 || programNumber > 2) return null;

            var programs = await _gateway
                .GetAsync<ICollection<NefitEasyProgram>>($"{NefitEndpointConstants.USER_PROGRAM_PROGRAM_ENDPOINT_PATH}{programNumber}", token)
                .ConfigureAwait(false);

            return !programs.Any() ? null : new NefitEasyProgramParser().Execute(programs);
        }

        public string GetSwitchPointName(int nameIndex) => GetSwitchPointNameAsync(nameIndex).GetAwaiter().GetResult();

        public async Task<string> GetSwitchPointNameAsync(int nameIndex, CancellationToken token = default(CancellationToken))
        {
            if (nameIndex < 1 || nameIndex > 2) return null;

            return await _gateway
                .GetAsync<string>($"{NefitEndpointConstants.USER_PROGRAM_USER_SWITCHPOINT_NAME_ENDPOINT_PATH}{nameIndex}", token)
                .ConfigureAwait(false);
        }

        public bool? IsFirePlaceFunctionActive() => IsFirePlaceFunctionActiveAsync().GetAwaiter().GetResult();

        public async Task<bool?> IsFirePlaceFunctionActiveAsync(CancellationToken token = default(CancellationToken))
        {
            return new NefitEasyBoolParser().Execute(
                await _gateway
                    .GetAsync<string>(NefitEndpointConstants.USER_PROGRAM_PREHEATING_ENDPOINT_PATH, token)
                    .ConfigureAwait(false));
        }

        public bool? IsPreheatingActive() => IsPreheatingActiveAsync().GetAwaiter().GetResult();

        public async Task<bool?> IsPreheatingActiveAsync(CancellationToken token = default(CancellationToken))
        {
            return new NefitEasyBoolParser().Execute(
                await _gateway
                    .GetAsync<string>(NefitEndpointConstants.USER_PROGRAM_PREHEATING_ENDPOINT_PATH, token)
                    .ConfigureAwait(false));
        }

        public double GetOutdoorTemperature() => GetOutdoorTemperatureAsync().GetAwaiter().GetResult();

        public async Task<double> GetOutdoorTemperatureAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<double>(NefitEndpointConstants.SENSORS_TEMPERATURES_OUTDOOR_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public string GetEasyServiceStatus() => GetEasyServiceStatusAsync().GetAwaiter().GetResult();

        public async Task<string> GetEasyServiceStatusAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<string>(NefitEndpointConstants.REMOTE_SERVICESTATE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public bool? IgnitionStatus() => IgnitionStatusAsync().GetAwaiter().GetResult();

        public async Task<bool?> IgnitionStatusAsync(CancellationToken token = default(CancellationToken))
        {
            return new NefitEasyBoolParser().Execute(
                await _gateway
                    .GetAsync<string>(NefitEndpointConstants.PM_IGNITION_STATUS_ENDPOINT_PATH, token)
                    .ConfigureAwait(false));
        }

        public bool? RefillNeededStatus() => RefillNeededStatusAsync().GetAwaiter().GetResult();

        public async Task<bool?> RefillNeededStatusAsync(CancellationToken token = default(CancellationToken))
        {
            return new NefitEasyBoolParser().Execute(
                await _gateway
                    .GetAsync<string>(NefitEndpointConstants.PM_REFILL_NEEDED_STATUS_ENDPOINT_PATH, token)
                    .ConfigureAwait(false));
        }

        public bool? ClosingValveStatus() => ClosingValveStatusAsync().GetAwaiter().GetResult();

        public async Task<bool?> ClosingValveStatusAsync(CancellationToken token = default(CancellationToken))
        {
            return new NefitEasyBoolParser().Execute(
                await _gateway
                    .GetAsync<string>(NefitEndpointConstants.PM_CLOSING_VALVE_STATUS_ENDPOINT_PATH, token)
                    .ConfigureAwait(false));
        }

        public bool? ShortTappingStatus() => ShortTappingStatusAsync().GetAwaiter().GetResult();

        public async Task<bool?> ShortTappingStatusAsync(CancellationToken token = default(CancellationToken))
        {
            return new NefitEasyBoolParser().Execute(
                await _gateway
                    .GetAsync<string>(NefitEndpointConstants.PM_SHORT_TAPPING_STATUS_ENDPOINT_PATH, token)
                    .ConfigureAwait(false));
        }

        public bool? SystemLeadingStatus() => SystemLeadingStatusAsync().GetAwaiter().GetResult();

        public async Task<bool?> SystemLeadingStatusAsync(CancellationToken token = default(CancellationToken))
        {
            return new NefitEasyBoolParser().Execute(
                await _gateway
                    .GetAsync<string>(NefitEndpointConstants.PM_SYSTEM_LEAKING_STATUS_ENDPOINT_PATH, token)
                    .ConfigureAwait(false));
        }

        public bool? ThermalDesinfectEnabled() => ThermalDesinfectEnabledAsync().GetAwaiter().GetResult();

        public async Task<bool?> ThermalDesinfectEnabledAsync(CancellationToken token = default(CancellationToken))
        {
            return new NefitEasyBoolParser().Execute(
                await _gateway
                    .GetAsync<string>(NefitEndpointConstants.DHWA_THERMAL_DESINFECT_STATE_ENDPOINT_PATH, token)
                    .ConfigureAwait(false));
        }

        public DateTime GetNextThermalDesinfect() => GetNextThermalDesinfectAsync().GetAwaiter().GetResult();

        public async Task<DateTime> GetNextThermalDesinfectAsync(CancellationToken token = default(CancellationToken))
        {
            var nextTermalTime = await _gateway
                .GetAsync<int>(NefitEndpointConstants.DHWA_THERMAL_DESINFECT_TIME_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            var nextTermalDay = await _gateway
                .GetAsync<string>(NefitEndpointConstants.DHWA_THERMAL_DESINFECT_WEEKDAY_ENDPOINT_PATH, token)
                .ConfigureAwait(false);

            return nextTermalDay != null ? new NefitEasyDateParser().GetNextDate(nextTermalDay, nextTermalTime) : new DateTime();
        }

        public double GetSystemPressure() => GetSystemPressureAsync().GetAwaiter().GetResult();

        public async Task<double> GetSystemPressureAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<double>(NefitEndpointConstants.APPLIANCE_SYSTEM_PRESSURE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public double GetCentralHeatingSupplyTemperature() => GetCentralHeatingSupplyTemperatureAsync().GetAwaiter().GetResult();

        public async Task<double> GetCentralHeatingSupplyTemperatureAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<double>(NefitEndpointConstants.HC1_ACTUAL_SUPPLY_TEMPERATURE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public StatusCode GetStatusCode() => GetStatusCodeAsync().GetAwaiter().GetResult();

        public async Task<StatusCode> GetStatusCodeAsync(CancellationToken token = default(CancellationToken))
        {
            var displayCode = await _gateway
                .GetAsync<string>(NefitEndpointConstants.APPLIANCE_DISPLAY_CODE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            var causeCode = await _gateway
                .GetAsync<string>(NefitEndpointConstants.APPLIANCE_CAUSE_CODE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            return new StatusCode(displayCode, int.Parse(causeCode));
        }

        public ProgramSwitch GetCurrentSwitchPoint() => GetCurrentSwitchPointAsync().GetAwaiter().GetResult();

        public async Task<ProgramSwitch> GetCurrentSwitchPointAsync(CancellationToken token = default(CancellationToken))
        {
            var switches = await _gateway
                .GetAsync<ICollection<NefitSwitch>>(NefitEndpointConstants.DHWA_CURRENT_SWITCHPOINT_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            return switches.Any() ? new ProgramSwitch(switches.First()) : null;
        }

        public ProgramSwitch GetNextSwitchPoint() => GetNextSwitchPointAsync().GetAwaiter().GetResult();

        public async Task<ProgramSwitch> GetNextSwitchPointAsync(CancellationToken token = default(CancellationToken))
        {
            var switches = await _gateway
                .GetAsync<ICollection<NefitSwitch>>(NefitEndpointConstants.DHWA_NEXT_SWITCHPOINT_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            return switches.Any() ? new ProgramSwitch(switches.First()) : null;
        }

        public Location GetLocation() => GetLocationAsync().GetAwaiter().GetResult();

        public async Task<Location> GetLocationAsync(CancellationToken token = default(CancellationToken))
        {
            var latitude = await _gateway
                .GetAsync<double>(NefitEndpointConstants.LOCATION_LATITUDE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            var longitude = await _gateway
                .GetAsync<double>(NefitEndpointConstants.LOCATION_LONGITUDE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            return new Location(latitude, longitude);
        }

        public ICollection<GasSample> GetGasUsage() => GetGasUsageAsync().GetAwaiter().GetResult();

        public async Task<ICollection<GasSample>> GetGasUsageAsync(CancellationToken token = default(CancellationToken))
        {
            var hasValidSamples = true;
            var currentPage = 1;

            var gasSamples = new List<GasSample>();

            while (hasValidSamples)
            {
                var samples = await _gateway.GetAsync<ICollection<NefitEasyGasSample>>(
                    $"{NefitEndpointConstants.RECORDINGS_GAS_USAGE_ENDPOINT_PATH}?page={currentPage}", token);
                if (samples.Any())
                {
                    foreach (var sample in samples)
                    {
                        if (sample.d != "255-256-65535")
                        {
                            gasSamples.Add(new GasSample(Convert.ToDateTime(sample.d), sample.hw / 10.0, sample.ch / 10.0, sample.T / 10.0));
                        }
                        else
                        {
                            hasValidSamples = false;
                            break;
                        }
                    }

                    currentPage++;
                }
                else
                {
                    hasValidSamples = false;
                }
            }

            return gasSamples;
        }

        public UiStatus GetUiStatus() => GetUiStatusAsync().GetAwaiter().GetResult();

        public async Task<UiStatus> GetUiStatusAsync(CancellationToken token = default(CancellationToken))
        {
            var status = await _gateway
                .GetAsync<NefitEasyStatus>(NefitEndpointConstants.UISTATUS_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            return status != null ? new UiStatus(status) : default(UiStatus);
        }

        public ICollection<string> GetOwnerInfo() => GetOwnerInfoAsync().GetAwaiter().GetResult();

        public async Task<ICollection<string>> GetOwnerInfoAsync(CancellationToken token = default(CancellationToken))
        {
            var ownerInformation = await _gateway
                .GetAsync<string>(NefitEndpointConstants.PERSONAL_DETAILS_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            return ownerInformation?.Split(';');
        }

        public ICollection<string> GetInstallerInfo() => GetInstallerInfoAsync().GetAwaiter().GetResult();

        public async Task<ICollection<string>> GetInstallerInfoAsync(CancellationToken token = default(CancellationToken))
        {
            var installerDetails = await _gateway
                .GetAsync<string>(NefitEndpointConstants.INSTALLER_DETAILS_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
            return installerDetails?.Split(';');
        }

        public string GetEasySerial() => GetEasySerialAsync().GetAwaiter().GetResult();

        public async Task<string> GetEasySerialAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<string>(NefitEndpointConstants.SERIAL_NUMBER_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public string GetEasyFirmware() => GetEasyFirmwareAsync().GetAwaiter().GetResult();

        public async Task<string> GetEasyFirmwareAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<string>(NefitEndpointConstants.VERSION_FIRMWARE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public string GetEasyHardware() => GetEasyHardwareAsync().GetAwaiter().GetResult();

        public async Task<string> GetEasyHardwareAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<string>(NefitEndpointConstants.VERSION_HARDWARE_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public string GetEasyUuid() => GetEasyUuidAsync().GetAwaiter().GetResult();

        public async Task<string> GetEasyUuidAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<string>(NefitEndpointConstants.UUID_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public EasyUpdateStrategy GetEasyUpdateStrategy() => GetEasyUpdateStrategyAsync().GetAwaiter().GetResult();

        public async Task<EasyUpdateStrategy> GetEasyUpdateStrategyAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<EasyUpdateStrategy>(NefitEndpointConstants.UPDATE_STRATEGY_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public string GetCentralHeatingSerial() => GetCentralHeatingSerialAsync().GetAwaiter().GetResult();

        public async Task<string> GetCentralHeatingSerialAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<string>(NefitEndpointConstants.APPLIANCE_SERIAL_NUMBER_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public string GetCentralHeatingVersion() => GetCentralHeatingVersionAsync().GetAwaiter().GetResult();

        public async Task<string> GetCentralHeatingVersionAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<string>(NefitEndpointConstants.APPLIANCE_VERSION_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public string GetCentralHeatingBurnerMake() => GetCentralHeatingBurnerMakeAsync().GetAwaiter().GetResult();

        public async Task<string> GetCentralHeatingBurnerMakeAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<string>(NefitEndpointConstants.EMS_BRANDBIT_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public EasySensitivity GetEasySensitivity() => GetEasySensitivityAsync().GetAwaiter().GetResult();

        public async Task<EasySensitivity> GetEasySensitivityAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<EasySensitivity>(NefitEndpointConstants.PIR_SENSITIVITY_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public double GetEasyTemperatureStep() => GetEasyTemperatureStepAsync().GetAwaiter().GetResult();

        public async Task<double> GetEasyTemperatureStepAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<double>(NefitEndpointConstants.TEMPERATURE_STEP_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public double GetEasyTemperatureOffset() => GetEasyTemperatureOffsetAsync().GetAwaiter().GetResult();

        public async Task<double> GetEasyTemperatureOffsetAsync(CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .GetAsync<double>(NefitEndpointConstants.HC1_TEMPERATURE_ADJUSTMENT_ENDPOINT_PATH, token)
                .ConfigureAwait(false);
        }

        public bool SetHotWaterModeClockProgram(bool enable) => SetHotWaterModeClockProgramAsync(enable).GetAwaiter().GetResult();

        public async Task<bool> SetHotWaterModeClockProgramAsync(bool enable, CancellationToken token = default(CancellationToken))
        {
            var switchMode = enable ? nameof(Switch.On) : nameof(Switch.Off);
            return await _gateway
                .PutAsync(NefitEndpointConstants.DHWA_OPERATION_CLOCK_MODE_ENDPOINT_PATH, switchMode.ToJson(), token)
                .ConfigureAwait(false);
        }

        public bool SetHotWaterModeManualProgram(bool enable) => SetHotWaterModeManualProgramAsync(enable).GetAwaiter().GetResult();

        public async Task<bool> SetHotWaterModeManualProgramAsync(bool enable, CancellationToken token = default(CancellationToken))
        {
            var switchMode = enable ? nameof(Switch.On) : nameof(Switch.Off);
            return await _gateway
                .PutAsync(NefitEndpointConstants.DHWA_OPERATION_MANUAL_MODE_ENDPOINT_PATH, switchMode.ToJson(), token)
                .ConfigureAwait(false);
        }

        public bool SetUserMode(UserModes userMode) => SetUserModeAsync(userMode).GetAwaiter().GetResult();

        public async Task<bool> SetUserModeAsync(UserModes userMode, CancellationToken token = default(CancellationToken))
        {
            return await _gateway
                .PutAsync(NefitEndpointConstants.HC1_USERMODE_ENDPOINT_PATH, userMode.ToString().ToJson(), token)
                .ConfigureAwait(false);
        }

        public bool SetTemperature(double temperature) => SetTemperatureAsync(temperature).GetAwaiter().GetResult();

        public async Task<bool> SetTemperatureAsync(double temperature, CancellationToken token = default(CancellationToken))
        {
            var result = await _gateway
                .PutAsync(NefitEndpointConstants.HC1_TEMPERATURE_ROOM_MANUAL_ENDPOINT_PATH, temperature.ToJson(), token)
                .ConfigureAwait(false);

            if (result)
            {
                result = await _gateway
                    .PutAsync(NefitEndpointConstants.HC1_MANUAL_TEMPERATURE_OVERRIDE_STATUS_ENDPOINT_PATH, nameof(Switch.On).ToJson(), token)
                    .ConfigureAwait(false);
            }

            if (result)
            {
                result = await _gateway
                    .PutAsync(NefitEndpointConstants.HC1_MANUAL_TEMPERATURE_OVERRIDE, temperature.ToJson(), token)
                    .ConfigureAwait(false);
            }

            return result;
        }
    }
}