using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BestBuyListingNotifier {

	public sealed class SearchResult {

		[JsonProperty(@"from")]
		public int From { get; set; }

		[JsonProperty(@"to")]
		public int To { get; set; }

		[JsonProperty(@"totalPages")]
		public int TotalPages { get; set; }

		[JsonProperty("products", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductCollection Products { get; set; } = new ProductCollection();

	}

}
