namespace BestBuy.Sniper.Client.Extensions {
	public static class StringExtension {

		public static string NullIfNullOrWhiteSpace(this string thisString) {
			return string.IsNullOrWhiteSpace(thisString) ? null : thisString;
		}

	}

}
