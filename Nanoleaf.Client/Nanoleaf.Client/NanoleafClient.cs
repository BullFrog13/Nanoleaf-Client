using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceDiscovery;
using Nanoleaf.Client.Colors;
using Nanoleaf.Client.Helpers;
using Nanoleaf.Client.Interfaces;
using Nanoleaf.Client.Models;
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
    public class NanoleafClient : INanoleafClient
    {
        private readonly NanoleafHttpClient _nanoleafHttpClient;

        public NanoleafClient(string host)
        {

        }

        public NanoleafClient(string host, string userToken)
        {
            _nanoleafHttpClient = new NanoleafHttpClient(host, userToken);
        }

        public async Task<Info> GetInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest();
            Info info = JsonConvert.DeserializeObject<Info>(response);

            return info;
        }

        #region User

        public async Task<UserToken> AddUserAsync()
        {
            var response = await _nanoleafHttpClient.AddUserRequest("new/");
            UserToken token = JsonConvert.DeserializeObject<UserToken>(response);

            return token;
        }

        public async Task DeleteUserAsync(string userToken)
        {
            await _nanoleafHttpClient.DeleteUserRequest(userToken + "/");
        }

        #endregion

        #region Power

        public async Task<bool> GetPowerStatusAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/on");
            PowerStatus powerStatus = JsonConvert.DeserializeObject<PowerStatus>(response);

            return powerStatus.Value;
        }

        public async Task TurnOnAsync()
        {
            var request = new OnOffRequest(true);
            string json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task TurnOffAsync()
        {
            var request = new OnOffRequest(false);
            string json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Brightness

        public async Task<Brightness> GetBrightnessInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness");
            Brightness brightnessInfo = JsonConvert.DeserializeObject<Brightness>(response);

            return brightnessInfo;
        }

        public async Task<int> GetBrightnessAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/value");
            int brightnessInfo = JsonConvert.DeserializeObject<int>(response);

            return brightnessInfo;
        }

        public async Task<int> GetBrightnessMaxValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/max");
            int brightnessMaxValue = JsonConvert.DeserializeObject<int>(response);

            return brightnessMaxValue;
        }

        public async Task<int> GetBrightnessMinValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/min");
            int brightnessMinValue = JsonConvert.DeserializeObject<int>(response);

            return brightnessMinValue;
        }

        public async Task SetBrightnessAsync(int targetBrightness, int time = 0)
        {
            var request = new SetBrightnessModel(targetBrightness, time);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task RaiseBrightnessAsync(int value)
        {
            var request = new IncrementBrightnessModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task LowerBrightnessAsync(int value)
        {
            var request = new IncrementBrightnessModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Hue

        public async Task<Hue> GetHueInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue");
            Hue hueInfo = JsonConvert.DeserializeObject<Hue>(response);

            return hueInfo;
        }

        public async Task<int> GetHueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/value");
            int hue = JsonConvert.DeserializeObject<int>(response);

            return hue;
        }

        public async Task<int> GetHueMaxValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/max");
            int hueMaxValue = JsonConvert.DeserializeObject<int>(response);

            return hueMaxValue;
        }

        public async Task<int> GetHueMinValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/min");
            int hueMinValue = JsonConvert.DeserializeObject<int>(response);

            return hueMinValue;
        }

        public async Task SetHueAsync(int targetHue)
        {
            var request = new SetHueModel(targetHue);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task RaiseHueAsync(int value)
        {
            var request = new IncrementHueModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task LowerHueAsync(int value)
        {
            var request = new IncrementHueModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Saturation

        public async Task<Saturation> GetSaturationInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat");
            Saturation hueInfo = JsonConvert.DeserializeObject<Saturation>(response);

            return hueInfo;
        }

        public async Task<int> GetSaturationAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/value");
            int saturation = JsonConvert.DeserializeObject<int>(response);

            return saturation;
        }

        public async Task<int> GetSaturationMaxValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/max");
            int saturationMaxValue = JsonConvert.DeserializeObject<int>(response);

            return saturationMaxValue;
        }

        public async Task<int> GetSaturationMinValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/min");
            int saturationMinValue = JsonConvert.DeserializeObject<int>(response);

            return saturationMinValue;
        }

        public async Task SetSaturationAsync(int targetSat)
        {
            var request = new SetSaturationModel(targetSat);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task RaiseSaturationAsync(int value)
        {
            var request = new IncrementSaturationModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task LowerSaturationAsync(int value)
        {
            var request = new IncrementSaturationModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Color Temperature

        public async Task<ColorTemperature> GetTemperatureInfoAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct");
            ColorTemperature colorTemperatureInfo = JsonConvert.DeserializeObject<ColorTemperature>(response);

            return colorTemperatureInfo;
        }

        public async Task<int> GetColorTemperatureAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/value");
            int colorTemperature = JsonConvert.DeserializeObject<int>(response);

            return colorTemperature;
        }

        public async Task<int> GetColorTemperatureMaxValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/max");
            int colorTemperatureMaxValue = JsonConvert.DeserializeObject<int>(response);

            return colorTemperatureMaxValue;
        }

        public async Task<int> GetColorTemperatureMinValueAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/min");
            int colorTemperatureMinValue = JsonConvert.DeserializeObject<int>(response);

            return colorTemperatureMinValue;
        }

        public async Task SetColorTemperatureAsync(int targetCt)
        {
            var request = new SetColorTemperatureModel(targetCt);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task RaiseColorTemperatureAsync(int value)
        {
            var request = new IncrementColorTemperatureModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task LowerColorTemperatureAsync(int value)
        {
            var request = new IncrementColorTemperatureModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Effects

        public async Task<string> GetCurrentEffectAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("effects/select");
            string effect = JsonConvert.DeserializeObject<string>(response);

            return effect;
        }

        public async Task<List<string>> GetEffectsAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("effects/effectsList");
            List<string> effectsList = JsonConvert.DeserializeObject<List<string>>(response);

            return effectsList;
        }

        public async Task SetEffectAsync(string effectName)
        {
            var request = new SelectEffectModel(effectName);
            string json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "effects/");
        }

        #endregion

        public async Task<string> GetColorModeAsync()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/colorMode");
            string colorMode = JsonConvert.DeserializeObject<string>(response);

            return colorMode;
        }

        public async Task SetHsvAsync(int h, int s, int v)
        {
            var request = new HsvRequest(h, s, v);
            string json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task SetRgbAsync(int r, int g, int b)
        {
            var hsv = ColorConverter.RgbToHsv(r, g, b);
            var request = new HsvRequest(hsv.H, hsv.S, hsv.V);
            string json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }
    }
}