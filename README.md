# !<img src="https://github.com/BullFrog13/Nanoleaf-Client/blob/master/nano1.png" width="35" height="35"> Nanoleaf.Core

[![NuGet](https://img.shields.io/nuget/v/Nanoleaf.Core)](https://nuget.org/packages/Nanoleaf.Core)


A .NET Core library library for accessing the [RESTful Nanoleaf OpenAPI][1] over HTTP.

## Usage

### Discover Nanoleaf Device

This is a convenient way to discover Nanoleaf in local network.

Before running the command make sure Nanoleaf is plugged-in and connected to WiFi.

```c#
var nanoleafDiscovery = new NanoleafDiscovery();
var request = new NanoleafDiscoveryRequest
{
	ST = SearchTarget.Nanoleaf
};
var discoveredNanoleafs = nanoleafDiscovery.DiscoverNanoleafs(request);
var nanoleaf = discoveredNanoleafs.FirstOrDefault();
```

### Get authorization token

A user is authorized to access the OpenAPI if they can demonstrate physical access of Panels.
This is achieved by: Holding the on-off button down for 5-7 seconds until the LED starts flashing in a pattern

Run the following code within 30 seconds of activating pairing. The response is a randomly generated auth token.
```c#
var token = await nanoleaf.CreateTokenAsync();
```

You can reuse this token in the following sessions, just make sure to authorize client with it.

### Token authorization

Use the token to authorize.

```c#
await nanoleaf?.AuthorizeAsync(token);
```

### Alternative way to access client

Provided that you know your local device IP and already have a user token.
```c#
var client = new NanoleafClient("<local_device_ip>", "<USER_TOKEN>");
```

Disposable
```c#
using(var client = new NanoleafClient("<local_device_ip>", "<USER_TOKEN>")
{
	// code
}
```

### Turn On/Off

```c#
await nanoleaf.TurnOnAsync();

Thread.Wait(5000);

await nanoleaf.TurnOffAsync();
```

### Get Power Status

```c#
powerStatus = await nanoleaf.GetPowerStatusAsync();
```

### Get General Information and State

Includes name, serial number, manufacturer, firmware version, model, state and effects

```c#
var info = await nanoleaf.GetInfoAsync();
```

### Get Brightness

```c#
var brightness = await nanoleaf.GetBrightnessAsync();
```

### Get Brightness with Max/Min Values

```c#
var brightness = await nanoleaf.GetBrightnessInfoAsync();
```

### Set Brightness

targetBrightness must be from 0 to 100
time is a brightness transfer duration

```c#
await nanoleaf.SetBrightnessAsync(targetBrightness: 100, time: 1000);
```

### Raise Brightness

```c#
await nanoleaf.RaiseBrightnessAsync(20);
```

### Lower Brghtness

```c#
await nanoleaf.LowerBrightnessAsync(5);
```

[1]: https://forum.nanoleaf.me/docs/openapi