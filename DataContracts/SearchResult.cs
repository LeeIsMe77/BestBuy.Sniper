using System.Text.Json.Serialization;

namespace BestBuy.Sniper.Client.DataContracts {

	public sealed class SearchResult {

		[JsonPropertyName(@"from")]
		public int From { get; set; }

		[JsonPropertyName(@"to")]
		public int To { get; set; }

		[JsonPropertyName(@"totalPages")]
		public int TotalPages { get; set; }

		[JsonPropertyName("products")]
		public ProductCollection Products { get; set; } = new ProductCollection();

	}

}
