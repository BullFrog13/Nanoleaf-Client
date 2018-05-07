using System.Threading.Tasks;

namespace Nanoleaf.Client.Interfaces
{
    public interface INanoleafClient
    {
        Task TurnOn();

        Task TurnOff();
    }
}