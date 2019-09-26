using System.Collections.Generic;
using System.Threading.Tasks;
using Nanoleaf.Client.Colors;
using Nanoleaf.Client.Helpers;
using Nanoleaf.Client.Interfaces;
using Nanoleaf.Client.Models.Requests;
using Nanoleaf.Client.Models.Requests.Brightness;
using Nanoleaf.Client.Models.Requests.ColorTemperature;
using Nanoleaf.Client.Models.Requests.Effects;
using Nanoleaf.Client.Models.Requests.Hue;
using Nanoleaf.Client.Models.Requests.Saturation;
using Nanoleaf.Client.Models.Responses;
using Newtonsoft.Json;

namespace Nanoleaf.Client
{
    /// <inheritdoc/>
    public class NanoleafClient : INanoleafClient
    {
        private readonly NanoleafHttpClient _nanoleafHttpClient;

        public NanoleafClient(string host)
        {
            _nanoleafHttpClient = new NanoleafHttpClient(host);
        }

        public NanoleafClient(string host, string userToken)
        {
            _nanoleafHttpClient = new NanoleafHttpClient(host, userToken);
        }

        /// <inheritdoc/>
        public void Authorize(string token)
        {
            _nanoleafHttpClient.AuthorizeRequests(token);
        }

        /// <inheritdoc/>
        public async Task<Info> GetInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest();
            var info = JsonConvert.DeserializeObject<Info>(response);

            return info;
        }

        #region User

        public async Task<UserToken> CreateTokenAsync()
        {
            var response = await _nanoleafHttpClient.AddUserRequestAsync();
            var token = JsonConvert.DeserializeObject<UserToken>(response);

            return token;
        }

        /// <summary>Deletes the token asynchronous.</summary>
        /// <param name="userToken">The user token.</param>
        public async Task DeleteTokenAsync(string userToken)
        {
            await _nanoleafHttpClient.DeleteUserRequest(userToken + "/");
        }

        #endregion

        #region Power

        /// <inheritdoc/>
        public async Task<bool> GetPowerStatusAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/on");
            var powerStatus = JsonConvert.DeserializeObject<PowerStatus>(response);

            return powerStatus.Value;
        }

        /// <inheritdoc/>
        public async Task TurnOnAsync()
        {
            var request = new OnOffRequest(true);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task TurnOffAsync()
        {
            var request = new OnOffRequest(false);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Brightness

        /// <inheritdoc/>
        public async Task<Brightness> GetBrightnessInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness");
            var brightnessInfo = JsonConvert.DeserializeObject<Brightness>(response);

            return brightnessInfo;
        }

        /// <inheritdoc/>
        public async Task<int> GetBrightnessAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/value");
            var brightnessInfo = JsonConvert.DeserializeObject<int>(response);

            return brightnessInfo;
        }

        /// <inheritdoc/>
        public async Task<int> GetBrightnessMaxValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/max");
            var brightnessMaxValue = JsonConvert.DeserializeObject<int>(response);

            return brightnessMaxValue;
        }

        /// <inheritdoc/>
        public async Task<int> GetBrightnessMinValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/min");
            var brightnessMinValue = JsonConvert.DeserializeObject<int>(response);

            return brightnessMinValue;
        }

        /// <inheritdoc/>
        public async Task SetBrightnessAsync(int targetBrightness, int time = 0)
        {
            var request = new SetBrightnessModel(targetBrightness, time);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task RaiseBrightnessAsync(int value)
        {
            var request = new IncrementBrightnessModel(value);
            var json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task LowerBrightnessAsync(int value)
        {
            var request = new IncrementBrightnessModel(-value);
            var json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Hue

        /// <inheritdoc/>
        public async Task<Hue> GetHueInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue");
            Hue hueInfo = JsonConvert.DeserializeObject<Hue>(response);

            return hueInfo;
        }

        /// <inheritdoc/>
        public async Task<int> GetHueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/value");
            int hue = JsonConvert.DeserializeObject<int>(response);

            return hue;
        }

        /// <inheritdoc/>
        public async Task<int> GetHueMaxValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/max");
            int hueMaxValue = JsonConvert.DeserializeObject<int>(response);

            return hueMaxValue;
        }

        /// <inheritdoc/>
        public async Task<int> GetHueMinValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/min");
            int hueMinValue = JsonConvert.DeserializeObject<int>(response);

            return hueMinValue;
        }

        /// <inheritdoc/>
        public async Task SetHueAsync(int targetHue)
        {
            var request = new SetHueModel(targetHue);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task RaiseHueAsync(int value)
        {
            var request = new IncrementHueModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task LowerHueAsync(int value)
        {
            var request = new IncrementHueModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Saturation

        /// <inheritdoc/>
        public async Task<Saturation> GetSaturationInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat");
            var hueInfo = JsonConvert.DeserializeObject<Saturation>(response);

            return hueInfo;
        }

        /// <inheritdoc/>
        public async Task<int> GetSaturationAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/value");
            var saturation = JsonConvert.DeserializeObject<int>(response);

            return saturation;
        }

        /// <inheritdoc/>
        public async Task<int> GetSaturationMaxValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/max");
            var saturationMaxValue = JsonConvert.DeserializeObject<int>(response);

            return saturationMaxValue;
        }

        /// <inheritdoc/>
        public async Task<int> GetSaturationMinValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/min");
            var saturationMinValue = JsonConvert.DeserializeObject<int>(response);

            return saturationMinValue;
        }

        /// <inheritdoc/>
        public async Task SetSaturationAsync(int targetSat)
        {
            var request = new SetSaturationModel(targetSat);
            var json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task RaiseSaturationAsync(int value)
        {
            var request = new IncrementSaturationModel(value);
            var json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task LowerSaturationAsync(int value)
        {
            var request = new IncrementSaturationModel(-value);
            var json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Color Temperature

        /// <inheritdoc/>
        public async Task<ColorTemperature> GetTemperatureInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct");
            var colorTemperatureInfo = JsonConvert.DeserializeObject<ColorTemperature>(response);

            return colorTemperatureInfo;
        }

        /// <inheritdoc/>
        public async Task<int> GetColorTemperatureAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/value");
            var colorTemperature = JsonConvert.DeserializeObject<int>(response);

            return colorTemperature;
        }

        /// <inheritdoc/>
        public async Task<int> GetColorTemperatureMaxValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/max");
            var colorTemperatureMaxValue = JsonConvert.DeserializeObject<int>(response);

            return colorTemperatureMaxValue;
        }

        /// <inheritdoc/>
        public async Task<int> GetColorTemperatureMinValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/min");
            var colorTemperatureMinValue = JsonConvert.DeserializeObject<int>(response);

            return colorTemperatureMinValue;
        }

        /// <inheritdoc/>
        public async Task SetColorTemperatureAsync(int targetCt)
        {
            var request = new SetColorTemperatureModel(targetCt);
            var json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task RaiseColorTemperatureAsync(int value)
        {
            var request = new IncrementColorTemperatureModel(value);
            var json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task LowerColorTemperatureAsync(int value)
        {
            var request = new IncrementColorTemperatureModel(-value);
            var json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Effects

        /// <inheritdoc/>
        public async Task<string> GetCurrentEffectAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("effects/select");
            var effect = JsonConvert.DeserializeObject<string>(response);

            return effect;
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetEffectsAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("effects/effectsList");
            var effectsList = JsonConvert.DeserializeObject<List<string>>(response);

            return effectsList;
        }

        /// <inheritdoc/>
        public async Task SetEffectAsync(string effectName)
        {
            var request = new SelectEffectModel(effectName);
            var json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "effects/");
        }

        #endregion

        /// <inheritdoc/>
        public async Task<string> GetColorModeAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/colorMode");
            var colorMode = JsonConvert.DeserializeObject<string>(response);

            return colorMode;
        }

        /// <inheritdoc/>
        public async Task SetHsvAsync(int h, int s, int v)
        {
            var request = new HsvRequest(h, s, v);
            var json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        /// <inheritdoc/>
        public async Task SetRgbAsync(int r, int g, int b)
        {
            var hsv = ColorConverter.RgbToHsv(r, g, b);
            var request = new HsvRequest(hsv.H, hsv.S, hsv.V);
            var json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }
    }
}