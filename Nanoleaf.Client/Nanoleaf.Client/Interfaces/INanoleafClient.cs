using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nanoleaf.Client.Models.Responses;

namespace Nanoleaf.Client.Interfaces
{
    /// <summary>
    /// Nanoleaf API interface
    /// </summary>
    public interface INanoleafClient : IDisposable
    {
        /// <summary>
        /// Gets nanoleaf information.
        /// </summary>
        /// <returns>Nanoleaf device information.</returns>
        Task<Info> GetInfoAsync();

        /// <summary>  Adds the user asynchronous.</summary>
        /// <returns>The task object representing the asynchronous operation.
        /// The task result contains a User Token.</returns>
        Task<UserToken> CreateTokenAsync();

        /// <summary>
        /// Authorize all following request for this device.
        /// </summary>
        /// <param name="token">User token</param>
        void Authorize(string token);

        /// <summary>Deletes the user asynchronous.</summary>
        /// <param name="userToken">The user token.</param>
        Task DeleteTokenAsync(string userToken);

        #region Power

        /// <summary>
        /// Get power status.
        /// </summary>
        /// <returns>True/False - On/Off</returns>
        Task<bool> GetPowerStatusAsync();

        /// <summary>
        /// Turn on device
        /// </summary>
        /// <returns>Task that represents the asynchronous operation.</returns>
        Task TurnOnAsync();

        /// <summary>
        /// Turn off device
        /// </summary>
        /// <returns>Task that represents the asynchronous operation.</returns>
        Task TurnOffAsync();

        #endregion

        #region Brightness

        /// <summary>
        /// Get brightness information.
        /// </summary>
        /// <returns>Brightness information.</returns>
        Task<Brightness> GetBrightnessInfoAsync();

        /// <summary>
        /// Get current brightness value
        /// </summary>
        /// <returns>Brightness value from 0 to 100.</returns>
        Task<int> GetBrightnessAsync();

        /// <summary>
        /// Get maximum brightness value.
        /// </summary>
        /// <returns>Maximum brightness value.</returns>
        Task<int> GetBrightnessMaxValueAsync();

        /// <summary>
        /// Get minimum brightness value.
        /// </summary>
        /// <returns>Minimum brightness value.</returns>
        Task<int> GetBrightnessMinValueAsync();

        /// <summary>
        /// Set brightness.
        /// </summary>
        /// <param name="targetBrightness">brightness value</param>
        /// <param name="time">transition time in seconds</param>
        Task SetBrightnessAsync(int targetBrightness, int time = 0);

        /// <summary>
        /// Raise brightness.
        /// </summary>
        /// <param name="value">Brightness increment.</param>
        Task RaiseBrightnessAsync(int value);

        /// <summary>
        /// Lower brightness
        /// </summary>
        /// <param name="value">Brightness decrement.</param>
        Task LowerBrightnessAsync(int value);

        #endregion

        #region Hue

        /// <summary>
        /// Get hue information
        /// </summary>
        /// <returns>Hue information</returns>
        Task<Hue> GetHueInfoAsync();

        /// <summary>
        /// Get current hue value.
        /// </summary>
        /// <returns>Hue value from 0 to 360.</returns>
        Task<int> GetHueAsync();

        /// <summary>
        /// Get max hue value.
        /// </summary>
        /// <returns>Max hue value.</returns>
        Task<int> GetHueMaxValueAsync();

        /// <summary>
        /// Get min hue value.
        /// </summary>
        /// <returns>Min hue value.</returns>
        Task<int> GetHueMinValueAsync();

        /// <summary>
        /// Set hue.
        /// </summary>
        /// <param name="targetHue">Target hue value.</param>
        Task SetHueAsync(int targetHue);

        /// <summary>
        /// Raise hue value.
        /// </summary>
        /// <param name="value">Hue increment value</param>
        Task RaiseHueAsync(int value);

        /// <summary>
        /// Lower hue value.
        /// </summary>
        /// <param name="value">Hue decrement value.</param>
        Task LowerHueAsync(int value);

        #endregion

        #region Saturation

        /// <summary>
        /// Get saturation information.
        /// </summary>
        /// <returns>Saturation information.</returns>
        Task<Saturation> GetSaturationInfoAsync();

        /// <summary>
        /// Get current saturation value.
        /// </summary>
        /// <returns>Saturation value from 0 to 100.</returns>
        Task<int> GetSaturationAsync();

        /// <summary>
        /// Get maximum saturation value.
        /// </summary>
        /// <returns>Max saturation value.</returns>
        Task<int> GetSaturationMaxValueAsync();

        /// <summary>
        /// Get minimum saturation value.
        /// </summary>
        /// <returns>Min saturation value.</returns>
        Task<int> GetSaturationMinValueAsync();

        /// <summary>
        /// Set saturation
        /// </summary>
        /// <param name="targetSat">Target saturation value.</param>
        Task SetSaturationAsync(int targetSat);

        /// <summary>
        /// Raise saturation by number.
        /// </summary>
        /// <param name="value">Saturation increment value.</param>
        Task RaiseSaturationAsync(int value);

        /// <summary>
        /// Lower saturation by number.
        /// </summary>
        /// <param name="value">Saturation decrement value.</param>
        Task LowerSaturationAsync(int value);

        #endregion

        #region Color Temperature

        /// <summary>
        /// Get color temperature information.
        /// </summary>
        /// <returns>Color temperature information.</returns>
        Task<ColorTemperature> GetTemperatureInfoAsync();

        /// <summary>
        /// Get current color temperature value.
        /// </summary>
        /// <returns>Current color temperature value.</returns>
        Task<int> GetColorTemperatureAsync();

        /// <summary>
        /// Get maximum color temperature.
        /// </summary>
        /// <returns>Max color temperature.</returns>
        Task<int> GetColorTemperatureMaxValueAsync();

        /// <summary>
        /// Get minimum color temperature.
        /// </summary>
        /// <returns>Min color temperature.</returns>
        Task<int> GetColorTemperatureMinValueAsync();

        /// <summary>
        /// Set color temperature.
        /// </summary>
        /// <param name="targetCt">Target color temperature.</param>
        Task SetColorTemperatureAsync(int targetCt);

        /// <summary>
        /// Raise color temperature by value.
        /// </summary>
        /// <param name="value">Color temperature increment value.</param>
        Task RaiseColorTemperatureAsync(int value);

        /// <summary>
        /// Lower color temperature by value.
        /// </summary>
        /// <param name="value">Color temperature decrement value.</param>
        Task LowerColorTemperatureAsync(int value);

        #endregion

        /// <summary>
        /// Get color mode
        /// </summary>
        /// <returns></returns>
        Task<string> GetColorModeAsync();

        #region Effects

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<string> GetCurrentEffectAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetEffectsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effectName"></param>
        /// <returns></returns>
        Task SetEffectAsync(string effectName);

        #endregion

        /// <summary>
        /// Set color using Hsv
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        Task SetHsvAsync(int h, int s, int v);

        /// <summary>
        /// Set color using Rgb
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        Task SetRgbAsync(int r, int g, int b);
    }
}