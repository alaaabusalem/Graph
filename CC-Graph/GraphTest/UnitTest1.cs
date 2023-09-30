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
	}
}