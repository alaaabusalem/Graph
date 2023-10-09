using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_Graph
{
	public class GraphBusinessTrip
	{
		public static int? BusinessTrip(Graph<string> graph, string[] cities)
		{
			int cost = 0;
			for (int i = 0; i < cities.Length - 1; i++)
			{
				Vertex<string> city1 = graph.Vertices[cities[i]];

				Vertex<string> city2 = graph.Vertices[cities[i + 1]];

				if (!graph.Contains(city1) || !graph.Contains(city2))
				{
					return null;
				}
				List<Edge<string>> neighbors;
				neighbors = graph.GetNeighbors(city1);
				bool hasDirect = false;
				foreach (Edge<string> edge in neighbors)
				{
					if (edge.Vertex.Value == city2.Value)
					{
						hasDirect = true;
						break;
					}
				}
				if (!hasDirect)
					return null;

			}
			return cost;
		}

	}
}
