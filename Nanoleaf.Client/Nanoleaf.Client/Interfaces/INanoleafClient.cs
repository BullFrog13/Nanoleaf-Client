using System.Collections.Generic;
using System.Threading.Tasks;
using Nanoleaf.Client.Models.Responses;

namespace Nanoleaf.Client.Interfaces
{
    public interface INanoleafClient
    {
        Task<Info> GetInfo();

        #region Power

        Task<bool> GetPowerStatus();

        Task TurnOn();

        Task TurnOff();

        #endregion

        #region Brightness

        Task<Brightness> GetBrightnessInfo();

        Task<int> GetBrightness();

        Task<int> GetBrightnessMaxValue();

        Task<int> GetBrightnessMinValue();

        Task SetBrightness(int targetBrightness, int time = 0);

        Task RaiseBrightness(int value);

        Task LowerBrightness(int value);

        #endregion

        #region Hue

        Task<Hue> GetHueInfo();

        Task<int> GetHue();

        Task<int> GetHueMaxValue();

        Task<int> GetHueMinValue();

        Task SetHue(int targetHue);

        Task RaiseHue(int value);

        Task LowerHue(int value);

        #endregion

        #region Saturation

        Task<Saturation> GetSaturationInfo();

        Task<int> GetSaturation();

        Task<int> GetSaturationMaxValue();

        Task<int> GetSaturationMinValue();

        Task SetSaturation(int targetSat);

        Task RaiseSaturation(int value);

        Task LowerSaturation(int value);

        #endregion

        #region Color Temperature

        Task<ColorTemperature> GetTemperatureInfo();

        Task<int> GetColorTemperature();

        Task<int> GetColorTemperatureMaxValue();

        Task<int> GetColorTemperatureMinValue();

        Task SetColorTemperature(int targetCt);

        Task RaiseColorTemperature(int value);

        Task LowerColorTemperature(int value);

        #endregion

        Task<string> GetColorMode();

        #region Effects

        Task<string> GetCurrentEffect();

        Task<List<string>> GetEffects();

        Task SetEffect(string effectName);

        #endregion
    }
}