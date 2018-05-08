using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Nanoleaf.Client.Helpers;
using Nanoleaf.Client.Interfaces;
using Nanoleaf.Client.Models;
using Nanoleaf.Client.Models.Requests.Brightness;
using Nanoleaf.Client.Models.Requests.ColorTemperature;
using Nanoleaf.Client.Models.Requests.Effects;
using Nanoleaf.Client.Models.Requests.Hue;
using Nanoleaf.Client.Models.Requests.Saturation;
using Nanoleaf.Client.Models.Responses;
using Newtonsoft.Json;

namespace Nanoleaf.Client
{
    public class NanoleafClient : HttpClient, INanoleafClient
    {
        private readonly NanoleafHttpClient _nanoleafHttpClient;
        private readonly string _host;
        private string _userToken;

        public NanoleafClient(string host, string userToken)
        {
            _host = host;
            _userToken = userToken;
            _nanoleafHttpClient = new NanoleafHttpClient(host, userToken);
        }

        public void AddUser()
        {

        }

        public async Task<Info> GetInfo()
        {
            var response = await _nanoleafHttpClient.SendGetRequest();
            Info info = JsonConvert.DeserializeObject<Info>(response);

            return info;
        }

        #region Power

        public async Task<bool> GetPowerStatus()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/on");
            PowerStatus powerStatus = JsonConvert.DeserializeObject<PowerStatus>(response);

            return powerStatus.Value;
        }

        public async Task TurnOn()
        {
            var request = new OnOffRequest(true);
            string json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task TurnOff()
        {
            var request = new OnOffRequest(false);
            string json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Brightness

        public async Task<Brightness> GetBrightnessInfo()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness");
            Brightness brightnessInfo = JsonConvert.DeserializeObject<Brightness>(response);

            return brightnessInfo;
        }

        public async Task<int> GetBrightness()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/value");
            int brightnessInfo = JsonConvert.DeserializeObject<int>(response);

            return brightnessInfo;
        }

        public async Task<int> GetBrightnessMaxValue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/max");
            int brightnessMaxValue = JsonConvert.DeserializeObject<int>(response);

            return brightnessMaxValue;
        }

        public async Task<int> GetBrightnessMinValue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/brightness/min");
            int brightnessMinValue = JsonConvert.DeserializeObject<int>(response);

            return brightnessMinValue;
        }

        public async Task SetBrightness(int targetBrightness, int time = 0)
        {
            var request = new SetBrightnessModel(targetBrightness, time);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task RaiseBrightness(int value)
        {
            var request = new IncrementBrightnessModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task LowerBrightness(int value)
        {
            var request = new IncrementBrightnessModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Hue

        public async Task<Hue> GetHueInfo()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue");
            Hue hueInfo = JsonConvert.DeserializeObject<Hue>(response);

            return hueInfo;
        }

        public async Task<int> GetHue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/value");
            int hue = JsonConvert.DeserializeObject<int>(response);

            return hue;
        }

        public async Task<int> GetHueMaxValue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/max");
            int hueMaxValue = JsonConvert.DeserializeObject<int>(response);

            return hueMaxValue;
        }

        public async Task<int> GetHueMinValue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/hue/min");
            int hueMinValue = JsonConvert.DeserializeObject<int>(response);

            return hueMinValue;
        }

        public async Task SetHue(int targetHue)
        {
            var request = new SetHueModel(targetHue);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task RaiseHue(int value)
        {
            var request = new IncrementHueModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task LowerHue(int value)
        {
            var request = new IncrementHueModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Saturation

        public async Task<Saturation> GetSaturationInfo()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat");
            Saturation hueInfo = JsonConvert.DeserializeObject<Saturation>(response);

            return hueInfo;
        }

        public async Task<int> GetSaturation()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/value");
            int saturation = JsonConvert.DeserializeObject<int>(response);

            return saturation;
        }

        public async Task<int> GetSaturationMaxValue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/max");
            int saturationMaxValue = JsonConvert.DeserializeObject<int>(response);

            return saturationMaxValue;
        }

        public async Task<int> GetSaturationMinValue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/sat/min");
            int saturationMinValue = JsonConvert.DeserializeObject<int>(response);

            return saturationMinValue;
        }

        public async Task SetSaturation(int targetSat)
        {
            var request = new SetSaturationModel(targetSat);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task RaiseSaturation(int value)
        {
            var request = new IncrementSaturationModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task LowerSaturation(int value)
        {
            var request = new IncrementSaturationModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        #region Color Temperature

        public async Task<ColorTemperature> GetTemperatureInfo()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct");
            ColorTemperature colorTemperatureInfo = JsonConvert.DeserializeObject<ColorTemperature>(response);

            return colorTemperatureInfo;
        }

        public async Task<int> GetColorTemperature()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/value");
            int colorTemperature = JsonConvert.DeserializeObject<int>(response);

            return colorTemperature;
        }

        public async Task<int> GetColorTemperatureMaxValue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/max");
            int colorTemperatureMaxValue = JsonConvert.DeserializeObject<int>(response);

            return colorTemperatureMaxValue;
        }

        public async Task<int> GetColorTemperatureMinValue()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/ct/min");
            int colorTemperatureMinValue = JsonConvert.DeserializeObject<int>(response);

            return colorTemperatureMinValue;
        }

        public async Task SetColorTemperature(int targetCt)
        {
            var request = new SetColorTemperatureModel(targetCt);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task RaiseColorTemperature(int value)
        {
            var request = new IncrementColorTemperatureModel(value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        public async Task LowerColorTemperature(int value)
        {
            var request = new IncrementColorTemperatureModel(-value);
            string json = Serializer.Serialize(request);

            await _nanoleafHttpClient.SendPutRequest(json, "state/");
        }

        #endregion

        public async Task<string> GetColorMode()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("state/colorMode");
            string colorMode = JsonConvert.DeserializeObject<string>(response);

            return colorMode;
        }

        #region Effects

        public async Task<string> GetCurrentEffect()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("effects/select");
            string effect = JsonConvert.DeserializeObject<string>(response);

            return effect;
        }

        public async Task<List<string>> GetEffects()
        {
            var response = await _nanoleafHttpClient.SendGetRequest("effects/effectsList");
            List<string> effectsList = JsonConvert.DeserializeObject<List<string>>(response);

            return effectsList;
        }

        public async Task SetEffect(string effectName)
        {
            var request = new SelectEffectModel(effectName);
            string json = JsonConvert.SerializeObject(request);

            await _nanoleafHttpClient.SendPutRequest(json, "effects/");
        }

        #endregion
    }
}