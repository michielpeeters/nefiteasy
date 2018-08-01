namespace NefitEasy
{
    public static class NefitEndpointConstants
    {
        public const string USER_PROGRAM_ACTIVE_PROGRAM_ENDPOINT_PATH = "/ecus/rrc/userprogram/activeprogram";
        public const string USER_PROGRAM_PROGRAM_ENDPOINT_PATH = "/ecus/rrc/userprogram/program";
        public const string USER_PROGRAM_USER_SWITCHPOINT_NAME_ENDPOINT_PATH = "/ecus/rrc/userprogram/userswitchpointname";
        public const string USER_PROGRAM_PREHEATING_ENDPOINT_PATH = "/ecus/rrc/userprogram/preheating";
        public const string PM_IGNITION_STATUS_ENDPOINT_PATH = "/ecus/rrc/pm/ignition/status";
        public const string PM_REFILL_NEEDED_STATUS_ENDPOINT_PATH = "/ecus/rrc/pm/refillneeded/status";
        public const string PM_CLOSING_VALVE_STATUS_ENDPOINT_PATH = "/ecus/rrc/pm/closingvalve/status";
        public const string PM_SHORT_TAPPING_STATUS_ENDPOINT_PATH = "/ecus/rrc/pm/shorttapping/status";
        public const string PM_SYSTEM_LEAKING_STATUS_ENDPOINT_PATH = "/ecus/rrc/pm/systemleaking/status";
        public const string RECORDINGS_GAS_USAGE_ENDPOINT_PATH = "/ecus/rrc/recordings/gasusage";
        public const string UISTATUS_ENDPOINT_PATH = "/ecus/rrc/uiStatus";
        public const string PERSONAL_DETAILS_ENDPOINT_PATH = "/ecus/rrc/personaldetails";
        public const string INSTALLER_DETAILS_ENDPOINT_PATH = "/ecus/rrc/installerdetails";
        public const string PIR_SENSITIVITY_ENDPOINT_PATH = "/ecus/rrc/pirSensitivity";
        public const string TEMPERATURE_STEP_ENDPOINT_PATH = "/ecus/rrc/temperaturestep";

        public const string DHWA_THERMAL_DESINFECT_STATE_ENDPOINT_PATH = "/dhwCircuits/dhwA/thermaldesinfect/state";
        public const string DHWA_THERMAL_DESINFECT_TIME_ENDPOINT_PATH = "/dhwCircuits/dhwA/thermaldesinfect/time";
        public const string DHWA_THERMAL_DESINFECT_WEEKDAY_ENDPOINT_PATH = "/dhwCircuits/dhwA/thermaldesinfect/weekday";
        public const string DHWA_CURRENT_SWITCHPOINT_ENDPOINT_PATH = "/dhwCircuits/dhwA/dhwCurrentSwitchpoint";
        public const string DHWA_NEXT_SWITCHPOINT_ENDPOINT_PATH = "/dhwCircuits/dhwA/dhwNextSwitchpoint";
        public const string DHWA_OPERATION_CLOCK_MODE_ENDPOINT_PATH = "/dhwCircuits/dhwA/dhwOperationClockMode";
        public const string DHWA_OPERATION_MANUAL_MODE_ENDPOINT_PATH = "/dhwCircuits/dhwA/dhwOperationManualMode";

        public const string SENSORS_TEMPERATURES_OUTDOOR_ENDPOINT_PATH = "/system/sensors/temperatures/outdoor_t1";
        public const string APPLIANCE_SYSTEM_PRESSURE_ENDPOINT_PATH = "/system/appliance/systemPressure";
        public const string APPLIANCE_DISPLAY_CODE_ENDPOINT_PATH = "/system/appliance/displaycode";
        public const string APPLIANCE_CAUSE_CODE_ENDPOINT_PATH = "/system/appliance/causecode";
        public const string LOCATION_LATITUDE_ENDPOINT_PATH = "/system/location/latitude";
        public const string LOCATION_LONGITUDE_ENDPOINT_PATH = "/system/location/longitude";
        public const string APPLIANCE_SERIAL_NUMBER_ENDPOINT_PATH = "/system/appliance/serialnumber";
        public const string APPLIANCE_VERSION_ENDPOINT_PATH = "/system/appliance/version";
        public const string EMS_BRANDBIT_ENDPOINT_PATH = "/system/interfaces/ems/brandbit";

        public const string REMOTE_SERVICESTATE_ENDPOINT_PATH = "/gateway/remote/servicestate";
        public const string SERIAL_NUMBER_ENDPOINT_PATH = "/gateway/serialnumber";
        public const string VERSION_FIRMWARE_ENDPOINT_PATH = "/gateway/versionFirmware";
        public const string VERSION_HARDWARE_ENDPOINT_PATH = "/gateway/versionHardware";
        public const string UUID_ENDPOINT_PATH = "/gateway/uuid";
        public const string UPDATE_STRATEGY_ENDPOINT_PATH = "/gateway/update/strategy";

        public const string HC1_ACTUAL_SUPPLY_TEMPERATURE_ENDPOINT_PATH = "/heatingCircuits/hc1/actualSupplyTemperature";
        public const string HC1_TEMPERATURE_ADJUSTMENT_ENDPOINT_PATH = "/heatingCircuits/hc1/temperatureAdjustment";
        public const string HC1_USERMODE_ENDPOINT_PATH = "/heatingCircuits/hc1/usermode";
        public const string HC1_TEMPERATURE_ROOM_MANUAL_ENDPOINT_PATH = "/heatingCircuits/hc1/temperatureRoomManual";
        public const string HC1_MANUAL_TEMPERATURE_OVERRIDE_STATUS_ENDPOINT_PATH = "/heatingCircuits/hc1/manualTempOverride/status";
        public const string HC1_MANUAL_TEMPERATURE_OVERRIDE = "/heatingCircuits/hc1/manualTempOverride/temperature";
    }
}