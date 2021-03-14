using System;
using BestBuy.Sniper.Client.DataContracts;

namespace BestBuy.Sniper.Client {

	public class SearchResultEventArgs : EventArgs {

		public SearchResult SearchResult { get; }

		public SearchResultEventArgs(SearchResult searchResult)
			: base() {
			this.SearchResult = searchResult;
		}

	}

}
