using System;
using System.Text.Json.Serialization;

namespace BestBuy.Sniper.Client.DataContracts {
	public sealed class Product {

		[JsonPropertyName(@"sku")]
		public long Sku { get; set; }

		[JsonPropertyName(@"name")]
		public string Name { get; set; }

		[JsonPropertyName(@"inStoreAvailability")]
		public bool InStoreAvailability { get; set; }

		[JsonPropertyName(@"inStoreAvailabilityText")]
		public string InStoreAvailabilityText { get; set; }

		[JsonPropertyName(@"inStoreAvailabilityUpdateDate")]
		public DateTime InStoreAvailabilityUpdateDate { get; set; }

		[JsonPropertyName(@"itemUpdateDate")]
		public DateTime ItemUpdateDate { get; set; }

		[JsonPropertyName(@"onlineAvailability")]
		public bool OnlineAvailability { get; set; }

		[JsonPropertyName(@"onlineAvailabilityText")]
		public string OnlineAvailabilityText { get; set; }

		[JsonPropertyName(@"onlineAvailabilityUpdateDate")]
		public DateTime OnlineAvailabilityUpdateDate { get; set; }

		[JsonPropertyName(@"addToCartUrl")]
		public string AddToCardUrl { get; set; }

		[JsonPropertyName(@"regularPrice")]
		public decimal RegularPrice { get; set; }

		[JsonPropertyName(@"salePrice")]
		public decimal SalePrice { get; set; }

	}

}
