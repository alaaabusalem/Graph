using CC_Graph;

namespace GraphTest
{
	public class UnitTest1
	{
		[Fact]
		public void Getvertixs()
		{
			Graph<string> graph = new Graph<string>();

			Vertex<string> a = graph.AddVertex("Amman");
			Vertex<string> b = graph.AddVertex("Irbid");
			Vertex<string> c = graph.AddVertex("Salt");
			var vertixList = graph.Getvertixs();
			Assert.Equal("Amman", vertixList[0]);
			Assert.Equal("Irbid", vertixList[1]);
			Assert.Equal("Salt", vertixList[2]);

		}

	

		[Fact]
		public void TestBusinessTrip_ImpossibleTripWithThreeCities_ReturnsNull()
		{
			Graph<string> graph = new Graph<string>();
			Vertex<string> city1 = graph.AddVertex("City1");
			Vertex<string> city2 = graph.AddVertex("City2");
			Vertex<string> city3 = graph.AddVertex("City3");
			graph.AddDirectEdge(city1, city2);
			graph.AddDirectEdge(city2, city3);



			int? cost = GraphBusinessTrip.BusinessTrip(graph, new string[] { "City1", "City3" });

			Assert.Null(cost);
		}

		[Fact]
		public void TestBusinessTrip_EmptyItinerary_ReturnsZero()
		{
			Graph<string> graph = new Graph<string>();

			int? cost = GraphBusinessTrip.BusinessTrip(graph, new string[] { });

			Assert.Equal(0, cost);
		}

		[Fact]
		public void TestDepthFirst_SingleNodeGraph()
		{
			var graph = new Graph<int>();
			var node = graph.AddVertex(1);
			var result = graph.DepthFirst(node);
			Assert.Single(result);
			Assert.Equal(node, result.First());
		}

		[Fact]
		public void TestDepthFirst_LinearGraph()
		{
			var graph = new Graph<int>();
			var node1 = graph.AddVertex(1);
			var node2 = graph.AddVertex(2);
			var node3 = graph.AddVertex(3);
			graph.AddDirectEdge(node1, node2);
			graph.AddDirectEdge(node2, node3);

			var result = graph.DepthFirst(node1);
			Assert.Equal(3, result.Count);
			Assert.Equal(node1, result[0]);
			Assert.Equal(node2, result[1]);
			Assert.Equal(node3, result[2]);
		}

		[Fact]
		public void TestDepthFirst_BranchingGraph()
		{
			var graph = new Graph<int>();
			var node1 = graph.AddVertex(1);
			var node2 = graph.AddVertex(2);
			var node3 = graph.AddVertex(3);
			var node4 = graph.AddVertex(4);
			graph.AddDirectEdge(node1, node2);
			graph.AddDirectEdge(node1, node3);
			graph.AddDirectEdge(node2, node4);

			var result = graph.DepthFirst(node1);
			Assert.Equal(4, result.Count);
			Assert.Equal(node1, result[0]);
		}
	}
}