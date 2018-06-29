using System.IO;
using System.Linq;
using Nanoleaf.Client.Configuration;
using Nanoleaf.Client.Core;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Authentication
{
    public class AuthManager
    {
        public NanoleafUsers GetAllAuthInfo()
        {
            var testObject = JsonConvert.DeserializeObject<NanoleafUsers>(File.ReadAllText(Directory.GetCurrentDirectory() + Constants.AuthConfigPath));

            return testObject;
        }

        public void AddNanoleafIfNotExists(string id)
        {
            var info = GetAllAuthInfo();

            if (!info.Nanoleafs.Exists(x => x.Id.Equals(id)))
            {
                info.Nanoleafs.Add(new Configuration.Nanoleaf
                {
                    Id = id
                });

                Save(info);
            }
        }

        public void DeleteNanoleafDevice(string id)
        {
            var info = GetAllAuthInfo();
            info.Nanoleafs = info.Nanoleafs.Where(x => x.Id.Equals(id)).ToList();

            Save(info);
        }

        public void AddUser(string nanoleafId, string token)
        {
            var info = GetAllAuthInfo();
            var device = info.Nanoleafs.FirstOrDefault(x => x.Id.Equals(nanoleafId));
            device?.UserToken.Add(token);

            Save(info);
        }

        public void DeleteUser(string nanoleafId, string token)
        {
            var info = GetAllAuthInfo();
            var device = info.Nanoleafs.FirstOrDefault(x => x.Id.Equals(nanoleafId));
            device?.UserToken.RemoveAll(x => x.Equals(token));

            Save(info);
        }

        private void Save(NanoleafUsers configuration)
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + Constants.AuthConfigPath, JsonConvert.SerializeObject(configuration));
        }
    }
}