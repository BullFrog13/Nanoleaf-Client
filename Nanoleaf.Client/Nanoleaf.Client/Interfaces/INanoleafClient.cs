using System.Collections.Generic;
using System.Threading.Tasks;
using Nanoleaf.Client.Models.Responses;

namespace Nanoleaf.Client.Interfaces
{
    public interface INanoleafClient
    {
        Task<Info> GetInfoAsync();

        Task<UserToken> AddUserAsync();

        Task DeleteUserAsync(string userToken);

        #region Power

        Task<bool> GetPowerStatusAsync();

        Task TurnOnAsync();

        Task TurnOffAsync();

        #endregion

        #region Brightness

        Task<Brightness> GetBrightnessInfoAsync();

        Task<int> GetBrightnessAsync();

        Task<int> GetBrightnessMaxValueAsync();

        Task<int> GetBrightnessMinValueAsync();

        Task SetBrightnessAsync(int targetBrightness, int time = 0);

        Task RaiseBrightnessAsync(int value);

        Task LowerBrightnessAsync(int value);

        #endregion

        #region Hue

        Task<Hue> GetHueInfoAsync();

        Task<int> GetHueAsync();

        Task<int> GetHueMaxValueAsync();

        Task<int> GetHueMinValueAsync();

        Task SetHueAsync(int targetHue);

        Task RaiseHueAsync(int value);

        Task LowerHueAsync(int value);

        #endregion

        #region Saturation

        Task<Saturation> GetSaturationInfoAsync();

        Task<int> GetSaturationAsync();

        Task<int> GetSaturationMaxValueAsync();

        Task<int> GetSaturationMinValueAsync();

        Task SetSaturationAsync(int targetSat);

        Task RaiseSaturationAsync(int value);

        Task LowerSaturationAsync(int value);

        #endregion

        #region Color Temperature

        Task<ColorTemperature> GetTemperatureInfoAsync();

        Task<int> GetColorTemperatureAsync();

        Task<int> GetColorTemperatureMaxValueAsync();

        Task<int> GetColorTemperatureMinValueAsync();

        Task SetColorTemperatureAsync(int targetCt);

        Task RaiseColorTemperatureAsync(int value);

        Task LowerColorTemperatureAsync(int value);

        #endregion

        Task<string> GetColorModeAsync();

        #region Effects

        Task<string> GetCurrentEffectAsync();

        Task<List<string>> GetEffectsAsync();

        Task SetEffectAsync(string effectName);

        #endregion

        Task SetHsvAsync(int h, int s, int v);

        Task SetRgbAsync(int r, int g, int b);
    }
}