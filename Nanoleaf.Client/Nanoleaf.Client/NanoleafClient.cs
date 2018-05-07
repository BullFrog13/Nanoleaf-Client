using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Client.Helpers;
using Nanoleaf.Client.Interfaces;
using Nanoleaf.Client.Models;
using Nanoleaf.Client.Models.Requests.Brightness;
using Nanoleaf.Client.Models.Requests.Hue;
using Nanoleaf.Client.Models.Requests.Saturation;
using Nanoleaf.Client.Models.Responses;
using Newtonsoft.Json;

namespace Nanoleaf.Client
{
    public class NanoleafClient : HttpClient, INanoleafClient
    {
        private string NanoleafIp;
        private string userToken = "NAVEVjtwZhnU31xEr4VMj3ewJTiit5JG/";

        public NanoleafClient(string ip)
        {
            BaseAddress = new Uri(ip + "/api/v1/" + userToken);
        }

        public NanoleafClient(string ip, string userToken)
        {

        }

        public void AddUser()
        {

        }

        public async Task<Info> GetInfo()
        {
            using (var response = await GetAsync(""))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Info info = JsonConvert.DeserializeObject<Info>(responseString);

                return info;
            }
        }

        // Todo rework to SetPowerMode method
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

            string json = Serializer.SerializeWithParentClassName(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task RaiseBrightness(int value)
        {
            var request = new IncrementBrightnessModel(value);

            string json = Serializer.SerializeWithParentClassName(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task LowerBrightness(int value)
        {
            var request = new IncrementBrightnessModel(-value);

            string json = Serializer.SerializeWithParentClassName(request);
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

            string json = Serializer.SerializeWithParentClassName(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task RaiseHue(int value)
        {
            var request = new IncrementHueModel(value);

            string json = Serializer.SerializeWithParentClassName(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task LowerHue(int value)
        {
            var request = new IncrementHueModel(-value);

            string json = Serializer.SerializeWithParentClassName(request);
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

            string json = Serializer.SerializeWithParentClassName(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task RaiseSaturation(int value)
        {
            var request = new IncrementSaturationModel(value);

            string json = Serializer.SerializeWithParentClassName(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        public async Task LowerSaturation(int value)
        {
            var request = new IncrementSaturationModel(-value);

            string json = Serializer.SerializeWithParentClassName(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                // TODO handle status codes
            }
        }

        #endregion
    }
}