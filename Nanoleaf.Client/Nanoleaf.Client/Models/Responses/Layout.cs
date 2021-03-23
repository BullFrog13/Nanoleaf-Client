using System;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
	/// <summary>
	/// Layout response returned from a layout request
	/// </summary>
	[Serializable]
	public class Layout
	{
		/// <summary>
		/// Number of panels
		/// </summary>
		[JsonProperty]
		public int NumPanels { get; set; }
		/// <summary>
		/// Side of each length
		/// </summary>
		[JsonProperty]
		public int SideLength { get; set; } = 1;
		/// <summary>
		/// Array of position data
		/// </summary>
		[JsonProperty]
		public PanelLayout[] PositionData { get; set; } = Array.Empty<PanelLayout>();

	}
}