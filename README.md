# Nanoleaf-Client

Open source library for communication with your Nanoleaf Aurora.
This library is available via NuGet package and supports only .NET Core projects. Library covers all basic Nanoleaf API calls. You can get the info of your device. This library is a part of a bigger infrastructure of other Home devices. Yeelight striplight support will arrive by the end of May 2018.

# Nuget reference

You can find Nuget here https://www.nuget.org/packages/Nanoleaf.Core/

# How to use?

```
var client = new NanoleafClient("http://<your_device_ip>:16021", "<USER_TOKEN>");
```

# Disclaimer

Library is still in WIP state. You might experience bugs.
I can see some people are looking for the Nanoleaf implementation.
I hope you enjoy my work and I would appreciate any comments regarding my work.
Email: 13heavyweather@gmail.com

# Work TODO

1. Implement Error HttpCode handling
2. Add Nanoleaf Discovery
3. Add support for new users
