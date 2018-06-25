using System.IO;
using Nanoleaf.Client.Configuration;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Authentication
{
    public class AuthManager
    {
        private NanoleafUsers CachedInfo { get; set; }

        private void UpdateCache()
        {
            CachedInfo = JsonConvert.DeserializeObject<NanoleafUsers>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\app.json"));
        }


        public NanoleafUsers GetAllInfo()
        {
            var testObject = JsonConvert.DeserializeObject<NanoleafUsers>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\app.json"));

            CachedInfo = testObject;

            return testObject;
        }

        public void AddNanoleafDevice(string id)
        {
            if (CachedInfo == null)
            {
                CachedInfo = JsonConvert.DeserializeObject<NanoleafUsers>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\app.json"));
            }

            CachedInfo.Nanoleafs.Add(new Configuration.Nanoleaf
            {
                Id = id
            });

            File.WriteAllText(Directory.GetCurrentDirectory() + "\\app.json", JsonConvert.SerializeObject(CachedInfo));
        }

        public void DeleteNanoleafDevice(string id)
        {

        }

        public void AddUser(string nanoleafId, string token)
        {

        }

        public void DeleteUser(string nanoleafId, string token)
        {

        }
    }
}
