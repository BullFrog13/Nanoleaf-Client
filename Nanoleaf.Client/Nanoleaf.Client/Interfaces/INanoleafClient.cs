using System.Threading.Tasks;
using Nanoleaf.Client.Models.Responses;

namespace Nanoleaf.Client.Interfaces
{
    public interface INanoleafClient
    {
        Task<Info> GetInfo();

        Task TurnOn();

        Task TurnOff();

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
    }
}