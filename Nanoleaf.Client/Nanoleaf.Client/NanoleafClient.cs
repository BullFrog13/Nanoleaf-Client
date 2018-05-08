using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        private NanoleafHttpClient _nanoleafHttpClient;
        private string userToken = "NAVEVjtwZhnU31xEr4VMj3ewJTiit5JG/";

        public NanoleafClient(string host)
        {
            BaseAddress = new Uri(host + "/api/v1/" + userToken);
        }

        public NanoleafClient(string host,  string userToken)
        {
            _nanoleafHttpClient = new NanoleafHttpClient(host, userToken);
        }

        public void AddUser()
        {

        }

        public async Task<Info> GetInfo()
        {
            return await _nanoleafHttpClient.SendGetRequest<Info>();
        }

        #region Power

        public async Task<bool> GetPowerStatus()
        {
            var powerStatus = await _nanoleafHttpClient.SendGetRequest<PowerStatus>("state/on");

            return powerStatus.Value;
        }

        public async Task TurnOn()
        {
            var request = new OnOffRequest(true);

            string json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task TurnOff()
        {
            var request = new OnOffRequest(false);

            string json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        #endregion

        #region Brightness

        public async Task<Brightness> GetBrightnessInfo()
        {
            using (var response = await GetAsync("state/brightness"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Brightness brightnessInfo = JsonConvert.DeserializeObject<Brightness>(responseString);

                return brightnessInfo;
            }
        }

        public async Task<int> GetBrightness()
        {
            using (var response = await GetAsync("state/brightness/value"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int brightnessInfo = JsonConvert.DeserializeObject<int>(responseString);

                return brightnessInfo;
            }
        }

        public async Task<int> GetBrightnessMaxValue()
        {
            using (var response = await GetAsync("state/brightness/max"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int brightnessMaxValue = JsonConvert.DeserializeObject<int>(responseString);

                return brightnessMaxValue;
            }
        }

        public async Task<int> GetBrightnessMinValue()
        {
            using (var response = await GetAsync("state/brightness/min"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int brightnessMinValue = JsonConvert.DeserializeObject<int>(responseString);

                return brightnessMinValue;
            }
        }

        public async Task SetBrightness(int targetBrightness, int time = 0)
        {
            var request = new SetBrightnessModel(targetBrightness, time);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task RaiseBrightness(int value)
        {
            var request = new IncrementBrightnessModel(value);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task LowerBrightness(int value)
        {
            var request = new IncrementBrightnessModel(-value);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        #endregion

        #region Hue

        public async Task<Hue> GetHueInfo()
        {
            using (var response = await GetAsync("state/hue"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Hue hueInfo = JsonConvert.DeserializeObject<Hue>(responseString);

                return hueInfo;
            }
        }

        public async Task<int> GetHue()
        {
            using (var response = await GetAsync("state/hue/value"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int hue = JsonConvert.DeserializeObject<int>(responseString);

                return hue;
            }
        }

        public async Task<int> GetHueMaxValue()
        {
            using (var response = await GetAsync("state/hue/max"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int hueMaxValue = JsonConvert.DeserializeObject<int>(responseString);

                return hueMaxValue;
            }
        }

        public async Task<int> GetHueMinValue()
        {
            using (var response = await GetAsync("state/hue/min"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int hueMinValue = JsonConvert.DeserializeObject<int>(responseString);

                return hueMinValue;
            }
        }

        public async Task SetHue(int targetHue)
        {
            var request = new SetHueModel(targetHue);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task RaiseHue(int value)
        {
            var request = new IncrementHueModel(value);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task LowerHue(int value)
        {
            var request = new IncrementHueModel(-value);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        #endregion

        #region Saturation

        public async Task<Saturation> GetSaturationInfo()
        {
            using (var response = await GetAsync("state/sat"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Saturation hueInfo = JsonConvert.DeserializeObject<Saturation>(responseString);

                return hueInfo;
            }
        }

        public async Task<int> GetSaturation()
        {
            using (var response = await GetAsync("state/sat/value"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int saturation = JsonConvert.DeserializeObject<int>(responseString);

                return saturation;
            }
        }

        public async Task<int> GetSaturationMaxValue()
        {
            using (var response = await GetAsync("state/sat/max"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int saturationMaxValue = JsonConvert.DeserializeObject<int>(responseString);

                return saturationMaxValue;
            }
        }

        public async Task<int> GetSaturationMinValue()
        {
            using (var response = await GetAsync("state/sat/min"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int saturationMinValue = JsonConvert.DeserializeObject<int>(responseString);

                return saturationMinValue;
            }
        }

        public async Task SetSaturation(int targetSat)
        {
            var request = new SetSaturationModel(targetSat);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task RaiseSaturation(int value)
        {
            var request = new IncrementSaturationModel(value);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task LowerSaturation(int value)
        {
            var request = new IncrementSaturationModel(-value);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        #endregion

        #region Color Temperature

        public async Task<ColorTemperature> GetTemperatureInfo()
        {
            using (var response = await GetAsync("state/ct"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                ColorTemperature colorTemperatureInfo = JsonConvert.DeserializeObject<ColorTemperature>(responseString);

                return colorTemperatureInfo;
            }
        }

        public async Task<int> GetColorTemperature()
        {
            using (var response = await GetAsync("state/ct/value"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int colorTemperature = JsonConvert.DeserializeObject<int>(responseString);

                return colorTemperature;
            }
        }

        public async Task<int> GetColorTemperatureMaxValue()
        {
            using (var response = await GetAsync("state/ct/max"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int colorTemperatureMaxValue = JsonConvert.DeserializeObject<int>(responseString);

                return colorTemperatureMaxValue;
            }
        }

        public async Task<int> GetColorTemperatureMinValue()
        {
            using (var response = await GetAsync("state/ct/min"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                int colorTemperatureMinValue = JsonConvert.DeserializeObject<int>(responseString);

                return colorTemperatureMinValue;
            }
        }

        public async Task SetColorTemperature(int targetCt)
        {
            var request = new SetColorTemperatureModel(targetCt);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task RaiseColorTemperature(int value)
        {
            var request = new IncrementColorTemperatureModel(value);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task LowerColorTemperature(int value)
        {
            var request = new IncrementColorTemperatureModel(-value);

            string json = Serializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        #endregion

        public async Task<string> GetColorMode()
        {
            using (var response = await GetAsync("state/colorMode"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                string colorMode = JsonConvert.DeserializeObject<string>(responseString);

                return colorMode;
            }
        }

        #region Effects

        public async Task<string> GetCurrentEffect()
        {
            using (var response = await GetAsync("effects/select"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                string effect = JsonConvert.DeserializeObject<string>(responseString);

                return effect;
            }
        }

        public async Task<List<string>> GetEffects()
        {
            using (var response = await GetAsync("effects/effectsList"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                List<string> effectsList = JsonConvert.DeserializeObject<List<string>>(responseString);

                return effectsList;
            }
        }

        public async Task SetEffect(string effectName)
        {
            var request = new SelectEffectModel(effectName);

            string json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("effects/", content))
            {
                // TODO handle status codes
            }
        }

        #endregion
    }
}