using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses {
	/// <summary>
	/// Layout response returned from a layout request
	/// </summary>
	[Serializable]
	public class Layout {
		/// <summary>
		/// Number of panels
		/// </summary>
		[JsonProperty] public int NumPanels { get; set; }
		/// <summary>
		/// Side of each length
		/// </summary>
		[JsonProperty] public int SideLength { get; set; } = 1;
		/// <summary>
		/// Array of position data
		/// </summary>
		[JsonProperty] public PanelLayout[] PositionData { get; set; } = Array.Empty<PanelLayout>();

	}

	/// <summary>
	/// Layout info on a specific panel
	/// </summary>
	[Serializable]
	public class PanelLayout {
		/// <summary>
		/// Unique panel ID
		/// </summary>
		[JsonProperty] public int PanelId { get; set; }
		/// <summary>
		/// X coordinate
		/// </summary>
		[JsonProperty] public int X { get; set; }

		/// <summary>
		/// Y coordinate
		/// </summary>
		[DefaultValue(10)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int Y { get; set; } = 10;

		[JsonProperty] public int O { get; set; }
		
		/// <summary>
		/// Shape type, should probably be an enum
		/// </summary>
		[JsonProperty] public int ShapeType { get; set; }
	}
}