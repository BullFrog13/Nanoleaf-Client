using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Nanoleaf.Client {
	public class NanoleafStreamingClient : IDisposable {
		private readonly int _streamMode;
		private readonly IPEndPoint _ipEndPoint;
		private readonly UdpClient _sender;
		private bool _disposeSender;

		/// <summary>
		/// Create a new nanoleaf streaming client
		/// </summary>
		/// <param name="target">The IP Address or hostname of the nanoleaf device.</param>
		/// <param name="streamMode">(Optional) Streaming mode supported by the device. See the nanoleaf documentation for more info.</param>
		/// <param name="sender">(Optional) If specified, use a shared UdpClient. Be sure to disable blocking and
		/// set the socket options to ReuseAddress, or you will encounter issues.</param>
		public NanoleafStreamingClient(string target, int streamMode = 2, UdpClient sender = null) {
			_ipEndPoint = Parse(target, 60222);

			if (sender != null) {
				_sender = sender;
			} else {
				_disposeSender = true;
				_sender = new UdpClient();
				_sender.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
				_sender.Client.Blocking = false;
				_sender.DontFragment = true;
			}
			_streamMode = streamMode;
		}
		
		
		/// <summary>
		/// Send a UDP packet with updated color data
		/// </summary>
		/// <param name="colors">A dictionary of int, color; where int is the Panel ID,
		/// and color is a System.Drawing.Color to set. Use <see cref="M:NanoleafClient.GetLayoutAsync"/> to get layout info.</param>
		/// <param name="fadeTime"></param>
		public async Task SetColorAsync(Dictionary<int, Color> colors, int fadeTime = 0) {
			var byteString = new List<byte>();
			if (_streamMode == 2) {
				byteString.AddRange(PadInt(colors.Count));
			} else {
				byteString.Add(IntByte(colors.Count));
			}
			foreach (var pd in colors) {
				var id = pd.Key;
				if (_streamMode == 2) {
					byteString.AddRange(PadInt(id));
				} else {
					byteString.Add(IntByte(id));
				}

				var color = pd.Value;
				
				// Add rgb values
				byteString.Add(IntByte(color.R));
				byteString.Add(IntByte(color.G));
				byteString.Add(IntByte(color.B));
				// White value
				byteString.AddRange(PadInt(0, 1));
				// Pad duration time
				byteString.AddRange(_streamMode == 2 ? PadInt(fadeTime) : PadInt(fadeTime, 1));
			}

			await SendUdpUnicastAsync(byteString.ToArray());
		}
		
		private static byte[] PadInt(int toPad, int take = 2) {
			var intBytes = BitConverter.GetBytes(toPad);
			Array.Reverse(intBytes);
			intBytes = intBytes.Reverse().Take(take).Reverse().ToArray();
			return intBytes;
		}
		
		private static byte IntByte(int toByte, string format = "X2") {
			var b = Convert.ToByte(toByte.ToString(format, CultureInfo.InvariantCulture), 16);
			return b;
		}
		
		private async Task SendUdpUnicastAsync(byte[] data) {
			if (_ipEndPoint != null) {
				await _sender.SendAsync(data, data.Length, _ipEndPoint);
			} else {
				throw new Exception("Error, no endpoint");
			}
		}
		
		private static IPEndPoint Parse(string endpoint, int portIn) {
            if (string.IsNullOrEmpty(endpoint)
                || endpoint.Trim().Length == 0) {
                throw new ArgumentException("Endpoint descriptor may not be empty.");
            }

            if (portIn != -1 &&
                (portIn < IPEndPoint.MinPort
                 || portIn > IPEndPoint.MaxPort)) {
                throw new ArgumentException(string.Format("Invalid default port '{0}'", portIn));
            }

            string[] values = endpoint.Split(new[] {':'});
            IPAddress ipaddy;
            int port;

            //check if we have an IPv6 or ports
            if (values.Length <= 2) // ipv4 or hostname
            {
                if (values.Length == 1)
                    //no port is specified, default
                    port = portIn;
                else
                    port = GetPort(values[1]);

                //try to use the address as IPv4, otherwise get hostname
                if (!IPAddress.TryParse(values[0], out ipaddy))
                    ipaddy = GetIpFromHost(values[0]);
                if (ipaddy == null) return null;
            } else if (values.Length > 2) //ipv6
            {
                //could [a:b:c]:d
                if (values[0].StartsWith("[") && values[values.Length - 2].EndsWith("]")) {
                    string ipaddressstring = string.Join(":", values.Take(values.Length - 1).ToArray());
                    ipaddy = IPAddress.Parse(ipaddressstring);
                    port = GetPort(values[values.Length - 1]);
                } else //[a:b:c] or a:b:c
                {
                    ipaddy = IPAddress.Parse(endpoint);
                    port = portIn;
                }
            } else {
                throw new FormatException(string.Format("Invalid endpoint ipaddress '{0}'", endpoint));
            }

            if (port == -1)
                throw new ArgumentException(string.Format("No port specified: '{0}'", endpoint));

            return new IPEndPoint(ipaddy, port);
        }
		
		private static int GetPort(string p) {
			int port;

			if (!int.TryParse(p, out port)
			    || port < IPEndPoint.MinPort
			    || port > IPEndPoint.MaxPort) {
				throw new FormatException($@"Invalid end point port '{p}'");
			}

			return port;
		}

		private static IPAddress GetIpFromHost(string p) {
			if (string.IsNullOrEmpty(p)) return null;
			var hosts = Dns.GetHostAddresses(p);

			if (hosts == null || hosts.Length == 0)
				throw new ArgumentException(string.Format("Host not found: {0}", p));

			return hosts[0];
		}


		public void Dispose() {
			if (_disposeSender) _sender?.Dispose();
		}
	}
}