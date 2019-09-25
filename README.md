# Nanoleaf-Client

A .NET Core library library for accessing the [RESTful Nanoleaf OpenAPI][1] over HTTP.

[Nuget][2]

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

### Token authorization

Use the token to authorize.

```c#
await nanoleaf?.AuthorizeAsync(token);
```

### Alternative way to access client

Provided that you know your local device IP and already have a user token.
```c#
var client = new NanoleafClient("http://<your_device_ip>:16021", "<USER_TOKEN>");
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
[2]: https://nuget.org/packages/Nanoleaf.Core