# <img src="https://github.com/BullFrog13/Nanoleaf-Client/blob/master/nano1.png" width="60" height="60">

[![NuGet](https://img.shields.io/nuget/v/Nanoleaf.Core)](https://nuget.org/packages/Nanoleaf.Core)


A .NET Core library for accessing the [RESTful Nanoleaf OpenAPI][1] over HTTP.

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

Optionally, you can pass an existing HttpClient to NanoLeafClient if you wish to re-use it.
```c#
var httpClient = new HttpClient();
var client = new NanoleafClient("<local_device_ip>", "<USER_TOKEN>", httpClient);
```

You can also retrieve the hostname from the Nanoleaf Client.
```c#
var client = new NanoleafClient("<local_device_ip>");
var hostname = client.HostName;
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
time is a brightness transition time

```c#
await nanoleaf.SetBrightnessAsync(targetBrightness: 100, time: 1000);
```

### Raise Brightness

```c#
await nanoleaf.RaiseBrightnessAsync(20);
```

### Lower Brightness

```c#
await nanoleaf.LowerBrightnessAsync(5);
```

### Get Layout

```c#
await nanoleaf.GetLayoutAsync();
```

### Start Streaming

```c#
await nanoleaf.StartExternalAsync();
```

## Create a Streaming Client

Before sending data to your nanoleaf, you must first have authorized to your device.
Once authorized, you should call "nanoleaf.StartExternalAsync()";

```c#
var client = new NanoleafClient("<local_device_ip>", "<USER_TOKEN>");
await client.StartExternalAsync();

var nanoStream = new NanoleafStreamingClient("<local_device_ip_or_hostname>");
```

The structure of the data sent to the device depends on the API version. Most devices 
should use the V2 structure, which is the default setting. If you wish to use V1, specify it in the 
streaming client's constructor.

```c#
var nanoStream = new NanoleafStreamingClient("<local_device_ip_or_hostname>", 1); // Specify version 1
```

Additionally, if you wish to use an existing UDP client, you can do so in the constructor.

```c#
var UdpClient = new UdpClient {Ttl = 5};
UdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
UdpClient.Client.Blocking = false;
UdpClient.DontFragment = true;
var nanoStream = new NanoleafStreamingClient("<local_device_ip_or_hostname>", 2, UdpClient);
```

### Sending Color Data

To send color data after initializing a Streaming Client, you first need to know the id's of
the panels to address. 

Once you have the IDs, create a Dictionary<int, System.Drawing.Color>. Assign the panel ID to the
dictionary's key, and the desired color to the corresponding value.

Pass this dictionary to the nanostreaming client with an optional fade time, and repeat as necessary.

```c#
// Create client
var client = new NanoleafClient("<local_device_ip>", "<USER_TOKEN>");

// Retrieve our layout
var layout = client.GetLayoutAsync();
// Create a dictionary to pass to the stream
var allRed = new Dictionary<int,Color>();
var allBlack = new Dictionary<int,Color>();
// Create colors
var redColor = Color.FromArgb(255,0,0);
var blackColor = Color.FromArgb(0,0,0);

// Create stream
var nanoStream = new NanoleafStreamingClient("<local_device_ip_or_hostname>", 1); // Specify version 1

// Fill red dict 
foreach (var position in layout.PositionData) {
    allRed[position.PanelId] = redColor;
}

// Fill black dict
foreach (var position in layout.PositionData) {
    allBlack[position.PanelId] = blackColor;
}

// Start streaming
await client.StartExternalAsync();

// Set all panels to red with no delay
await nanoStream.SetColorAsync(allRed);
await Task.Delay(1000);

// Set all panels to black with 500ms fade time
await nanoStream.SetColorAsync(allBlack, 500);



```

https://forum.nanoleaf.me/docs/openapi
