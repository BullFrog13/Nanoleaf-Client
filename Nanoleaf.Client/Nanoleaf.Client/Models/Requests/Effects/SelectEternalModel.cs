using System;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.Effects {
	[JsonObject(Title = "write")]
	public class SelectEternalModel {
		public SelectEternalModel(string controlVersion = "v2") {
			write = new Write {ControlVersion = controlVersion, Command = "display", AnimationType = "extControl"};
		}

		public Write write;

		[Serializable]
		public class Write {
			[JsonProperty("command")] 
			public string Command;
		
			[JsonProperty("animType")] 
			public string AnimationType;
		
			[JsonProperty("extControlVersion")] 
			public string ControlVersion { get; set; }
		}
	}
}