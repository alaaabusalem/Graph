using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_Graph
{
	public class Vertex<T>
	{
		public T Value { get; set; }

		public Vertex(T value)
		{
			Value = value;
		}
	}

	public class Edge<T>
	{
		public int Weight { get; set; }
		public Vertex<T> Vertex { get; set; }

	}
	public class Graph<T>
	{
		public Dictionary<Vertex<T>, List<Edge<T>>> AdjacenceyList { get; set; }
		public Dictionary<T, Vertex<T>> Vertices { get; set; }


		private int _size = 0;

		public Graph()
		{
			AdjacenceyList = new Dictionary<Vertex<T>, List<Edge<T>>>();
			Vertices = new Dictionary<T, Vertex<T>>();

		}

		public Vertex<T> AddVertex(T vertex)
		{
			Vertex<T> node = new Vertex<T>(vertex);

			AdjacenceyList.Add(node, new List<Edge<T>>());
			Vertices.Add(vertex, node);

			_size++;

			return node;

		}

		public void AddDirectEdge(Vertex<T> a, Vertex<T> b)
		{
			AdjacenceyList[a].Add(new Edge<T>
			{
				Weight = 0,
				Vertex = b,
			});

		}

		public void AddUnDirectEdge(Vertex<T> a, Vertex<T> b)
		{
			AddDirectEdge(a, b);
			AddDirectEdge(b, a);
		}

		public List<Edge<T>> GetNeighbors(Vertex<T> vertex)
		{
			return AdjacenceyList[vertex];
		}

		public void Print()
		{
			foreach (var item in AdjacenceyList)
			{
				Console.Write($"Vertex {item.Key.Value} =>");

				foreach (var edge in item.Value)
				{
					Console.Write($"{edge.Vertex.Value} =>");
				}

				Console.WriteLine();
			}
		}

		public List<T> Getvertixs()
		{
			if(_size==0) return null;
			List<T> Vertixs = new List<T>();
			foreach(var item in AdjacenceyList)
			{
				
				Vertixs.Add(item.Key.Value);
			}
			return Vertixs;
		}

		public int Size()
		{
			return _size;
		}
		public List<Vertex<T>> BreadthFirst(Vertex<T> node)
		{
			Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
			List<Vertex<T>> visited = new List<Vertex<T>>();
			queue.Enqueue(node);
			while (queue.Count > 0)
			{
				Vertex<T> nodeToAdd = queue.Peek();

				visited.Add(nodeToAdd);
				foreach (var item in AdjacenceyList[nodeToAdd])
				{
					if (!visited.Contains(item.Vertex))
					{
						queue.Enqueue(item.Vertex);
					}
				}
				queue.Dequeue();
			}
			return visited;
		}
		public bool Contains(Vertex<T> vertex)
		{
			return AdjacenceyList.ContainsKey(vertex);
		}
	}
}
