// See https://aka.ms/new-console-template for more information

using dotnet_nine.Debugging;
using dotnet_nine.Features;

Linq.CountBy();
Linq.AggregateInvestments();
Linq.IndexValues();
Linq.ParamOverload();
Linq.SearchValuesWithIndex();
Json.CamelCaseJson();
Threading.WhenEach();
Threading.PrioritizedThreads();
CollectionsVisualizer.VisualizeCollection();

// NEW INVESTMENTS
Hub.ReadInvestment(new Stock { Symbol = "AAPL", Price = 150, Quantity = 10, Company = "Apple Inc.", Dividend = 0.75m });
Hub.ReadInvestment(new Bond { Symbol = "GOVT", Price = 100, Quantity = 100, Coupon = 2.5m, Yield = 2.5m });
Hub.ReadInvestment(new Investment { Symbol = "BTC", Price = 50000, Quantity = 1 });

// PriorityQueue.RemoveFromQueue();
// Cryptography.OneShotHash();
// NewTimespan.CreateTimespanFromInt();