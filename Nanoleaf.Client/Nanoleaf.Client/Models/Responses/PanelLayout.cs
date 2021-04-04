using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
	/// <summary>
	/// Layout info on a specific panel
	/// </summary>
	[Serializable]
	public class PanelLayout
	{
		/// <summary>
		/// Unique panel ID
		/// </summary>
		[JsonProperty]
		public int PanelId { get; set; }
		/// <summary>
		/// X coordinate
		/// </summary>
		[JsonProperty]
		public int X { get; set; }

		/// <summary>
		/// Y coordinate
		/// </summary>
		[DefaultValue(10)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int Y { get; set; } = 10;

		/// <summary>
		/// Orientation
		/// </summary>
		[JsonProperty]
		public int O { get; set; }
		
		/// <summary>
		/// Shape type, should probably be an enum
		/// </summary>
		[JsonProperty]
		public int ShapeType { get; set; }
	}
}