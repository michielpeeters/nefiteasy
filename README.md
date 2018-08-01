# Nefit Easy™ .NET Standard Library
.NET Standard client library for the [Nefit Easy](http://www.nefit.nl/consument/service/easy/easy) smart thermostat.

## PLEASE READ BEFORE USE!
Use this library in moderation: don't flood the backend with new connections made every X seconds. Instead, if you want to poll the backend for data, create a connection once and reuse it for each command. In the end, it's your own responsibility to not get blocked because of excessive (ab)use.

## Disclaimer
The implementation of this library is based on an other github user [larscom](https://github.com/larscom). He put really great work in it. The only thing I did is creating a dotnet standard package from it so it can be used in dotnet core projects.

#### Official Disclaimer from larscom:
The implementation of this library is based on reverse-engineering the communications between the apps and the backend, plus various other bits and pieces of information. It is *not* based on any official information given out by Nefit/Bosch, and therefore there are no guarantees whatsoever regarding the safety of your devices and/or their settings, or the accuracy of the information provided.

## Examples
### Create Client & Connect

Create a client and get the owner info.

```
INefitEasyClient client = new NefitEasyClient(new NefitEasyCredentials {
  SerialNumber = "",
  AccessKey = "",
  Password = ""
});
    
await client.ConnectAsync().ConfigureAwait(false);
    
if (client.Status == NefitConnectionStatus.Connected)
{
  IEnumerable<string> owner = await client.GetOwnerInfoAsync().ConfigureAwait(false);
}    
```

#### 

### Subscribe to Connection Events

```
INefitEasyClient client = new NefitEasyClient(new NefitEasyCredentials {
  SerialNumber = "",
  AccessKey = "",
  Password = ""
});

client.OnStatusChanged += (sender, status) =>
{
    switch (status)
    {
       case NefitConnectionStatus.Connecting:
           break;
       case NefitConnectionStatus.Connected:
           break;
       case NefitConnectionStatus.AuthenticationTest:
           break;
       case NefitConnectionStatus.InvalidCredentials:
           break;
       case NefitConnectionStatus.Disconnecting:
           break;
       case NefitConnectionStatus.Disconnected:
           break;
    }
 };

await client.ConnectAsync().ConfigureAwait(false);
```

#### 

### UI Status

Get the current UI status (room temperature and more)

```
INefitEasyClient client = new NefitEasyClient(new NefitEasyCredentials {
  SerialNumber = "",
  AccessKey = "",
  Password = ""
});
    
await client.ConnectAsync().ConfigureAwait(false);
    
if (client.ConnectionStatus == NefitConnectionStatus.Connected)
{
   UiStatus status = await client.GetUiStatusAsync().ConfigureAwait(false);
   double temperature = status.InHouseTemperature;
}
```

#### 

### Set Room Temperature

Set a room temperature between 5 and 30 degrees Celsius

```
INefitEasyClient client = new NefitEasyClient(new NefitEasyCredentials {
  SerialNumber = "",
  AccessKey = "",
  Password = ""
});
    
await client.ConnectAsync();
    
if (client.ConnectionStatus == NefitConnectionStatus.Connected)
{
  bool succeeded = await client.SetTemperatureAsync(24d).ConfigureAwait(false);
}
```

####

### Using in dotnet core project

In StartUp.cs
```
services.AddNefitEasy(options => {
  IsSingletonClient = true|false,
  AutoConnect = true|false
  Credentials = new NefitEasyCredentials {
    SerialNumber = "",
    AccessKey = "",
    Password = ""
  }  
});
```

Usage in a controller
```
public HomeController(INefitEasyClient client)
{
   UiStatus status = await client.GetUiStatusAsync().ConfigureAwait(false);
   double temperature = status.InHouseTemperature
}
```

####
