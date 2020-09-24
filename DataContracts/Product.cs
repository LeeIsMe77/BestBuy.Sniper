using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BestBuyListingNotifier {
	public sealed class Product {

		[JsonProperty(@"sku")]
		public string Sku { get; set; }

		[JsonProperty(@"name")]
		public string Name { get; set; }

		[JsonProperty(@"inStoreAvailability")]
		public bool InStoreAvailability { get; set; }

		[JsonProperty(@"inStoreAvailabilityText")]
		public string InStoreAvailabilityText { get; set; }

		[JsonProperty(@"inStoreAvailabilityUpdateDate")]
		public DateTime InStoreAvailabilityUpdateDate { get; set; }

		[JsonProperty(@"itemUpdateDate")]
		public DateTime ItemUpdateDate { get; set; }

		[JsonProperty(@"onlineAvailability")]
		public bool OnlineAvailability { get; set; }

		[JsonProperty(@"onlineAvailabilityText")]
		public string OnlineAvailabilityText { get; set; }

		[JsonProperty(@"onlineAvailabilityUpdateDate")]
		public DateTime OnlineAvailabilityUpdateDate { get; set; }

		[JsonProperty(@"addToCartUrl")]
		public string AddToCardUrl { get; set; }

	}

}
