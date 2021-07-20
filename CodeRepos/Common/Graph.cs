using Common.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Graph
/// </summary>
namespace Common.Graph
{
	public class Edge
	{
		public int Weight { get; set; }

		public Node From { get; set; }

		public Node To { get; set; }

		public Edge(int weight, Node from, Node to)
		{
			Weight = weight;
			From = from;
			To = to;
		}
	}

	public class Node
	{
		public int Value { get; set; }

		public int In { get; set; }

		public int Out { get; set; }

		public IList<Node> Nexts { get; set; }

		public IList<Edge> Edges { get; set; }

		public Node(int val)
		{
			Value = val;
			Nexts = new List<Node>();
			Edges = new List<Edge>();
		}
	}

	public class Graph
	{
		public IDictionary<int, Node> Nodes { get; set; }
		public HashSet<Edge> Edges { get; set; }

		public Graph()
		{
			Nodes = new Dictionary<int, Node>();
			Edges = new HashSet<Edge>();
		}

		// matrix 所有的边
		// N*3 的矩阵
		// [weight, from节点上面的值，to节点上面的值]
		// eg:
		//		[ 5 , 0 , 7]
		//		[ 3 , 0,  1]
		public static Graph CreateGraph(int[,] matrix)
		{
			Graph graph = new Graph();

			int len = matrix.GetLength(0);
			for (int i = 0; i < len; i++)
			{
				int weight = matrix[i, 0];
				int from = matrix[i, 1];
				int to = matrix[i, 2];

				if (!graph.Nodes.ContainsKey(from))
					graph.Nodes.Add(from, new Node(from));
				if (!graph.Nodes.ContainsKey(to))
					graph.Nodes.Add(to, new Node(to));

				Node fromNode = graph.Nodes[from];
				Node toNode = graph.Nodes[to];
				Edge newEdge = new Edge(weight, fromNode, toNode);
				fromNode.Nexts.Add(toNode);
				fromNode.Out++;
				toNode.In++;
				fromNode.Edges.Add(newEdge);
				graph.Edges.Add(newEdge);
			}
			return graph;
		}

		public IList<Node> TopologySort(Graph graph)
		{
			// key: 图中的节点; value:对应节点剩余的入度
			IDictionary<Node, int> inDict = new Dictionary<Node, int>();
			// 入度为0的节点
			Queue<Node> zeroInQueue = new Queue<Node>();

			foreach (Node node in graph.Nodes.Values)
			{
				inDict.Add(node, node.In);
				if (node.In == 0)
					zeroInQueue.Enqueue(node);
			}

			IList<Node> res = new List<Node>();
			while (zeroInQueue.Count > 0)
			{
				Node front = zeroInQueue.Dequeue();
				res.Add(front);

				foreach (Node next in front.Nexts)
				{
					inDict[next] -= 1;
					if (inDict[next] == 0)
						zeroInQueue.Enqueue(next);
				}
			}
			return res;
		}

		#region Kruskal - Minimum Spanning Tree

		public static HashSet<Edge> KruskalMST(Graph graph)
		{
			KruskalSet kSet = new KruskalSet(new List<Node>(graph.Nodes.Values));
			PriorityQueue<Edge> priorityQueue = new PriorityQueue<Edge>(graph.Edges.Count, new EdgeComparer());

			foreach (Edge edge in graph.Edges)
				priorityQueue.Enqueue(edge);

			HashSet<Edge> res = new HashSet<Edge>();
			while (!priorityQueue.IsEmpty)
			{
				Edge front = priorityQueue.Dequeue();
				if (!kSet.IsSameSet(front.From, front.To))
				{
					res.Add(front);
					kSet.Union(front.From, front.To);
				}
			}
			return res;
		}

		private class EdgeComparer : IComparer<Edge>
		{
			public int Compare(Edge x, Edge y)
			{
				return x.Weight - y.Weight;
			}
		}

		private class KruskalSet
		{
			public IDictionary<Node, IList<Node>> setMap;

			public KruskalSet(IList<Node> nodes)
			{
				setMap = new Dictionary<Node, IList<Node>>();
				foreach (Node cur in nodes)
				{
					IList<Node> set = new List<Node>() { cur };
					setMap.Add(cur, set);
				}
			}

			public bool IsSameSet(Node from, Node to)
			{
				return setMap[from] == setMap[to];
			}

			public void Union(Node from, Node to)
			{
				if (IsSameSet(from, to))
					return;

				IList<Node> fromSet = setMap[from];
				IList<Node> toSet = setMap[to];

				foreach (Node node in toSet)
				{
					fromSet.Add(node);
					setMap[node] = fromSet;
				}
			}
		}

		#endregion Kruskal - Minimum Spanning Tree

		#region Prim - Minimum Spanning Tree

		public static HashSet<Edge> PrimMST(Graph graph)
		{
			PriorityQueue<Edge> priorityQueue = new PriorityQueue<Edge>(graph.Edges.Count, new EdgeComparer());
			HashSet<Node> visited = new HashSet<Node>();
			HashSet<Edge> res = new HashSet<Edge>();

			foreach (Node node in graph.Nodes.Values)
			{
				if (!visited.Contains(node))
				{
					visited.Add(node);
					foreach (Edge edge in node.Edges)
						priorityQueue.Enqueue(edge);

					while (!priorityQueue.IsEmpty)
					{
						Edge front = priorityQueue.Dequeue();
						Node toNode = front.To;

						if (!visited.Contains(toNode))
						{
							visited.Add(toNode);
							res.Add(front);
							foreach (Edge edge in toNode.Edges)
								priorityQueue.Enqueue(edge);
						}
					}
				}
			}
			return res;
		}

		#endregion Prim - Minimum Spanning Tree

		#region Dijkstra - Shortest Path

		public static IDictionary<Node, int> Dijkstra(Node head)
		{
			// 从head出发到所有节点的最小距离
			// key: 从head出发到达的每一个节点； value: 当前从head出发到达每个节点的最短距离
			// 如果Dict中没有某节点，说明从head出发到达该节点的距离为正无穷
			IDictionary<Node, int> distanceDict = new Dictionary<Node, int>();
			distanceDict.Add(head, 0);
			// 已经访问过的节点
			HashSet<Node> selected = new HashSet<Node>();
			Node minNode = GetUnselectedMinimumDistanceNode(distanceDict, selected);

			while (minNode != null)
			{
				int distance = distanceDict[minNode];
				foreach (Edge edge in minNode.Edges)
				{
					if (!distanceDict.ContainsKey(edge.To))
						distanceDict.Add(edge.To, distance + edge.Weight);
					else
						distanceDict[edge.To] = Math.Min(distanceDict[edge.To], distance + edge.Weight);
				}
				selected.Add(minNode);
				minNode = GetUnselectedMinimumDistanceNode(distanceDict, selected);
			}
			return distanceDict;
		}

		private static Node GetUnselectedMinimumDistanceNode(IDictionary<Node, int> distanceDict, ISet<Node> touched)
		{
			Node minNode = null;
			int minDistance = int.MaxValue;
			foreach (KeyValuePair<Node, int> kv in distanceDict)
			{
				if (!touched.Contains(kv.Key) && kv.Value < minDistance)
				{
					minNode = kv.Key;
					minDistance = kv.Value;
				}
			}

			return minNode;
		}

		#endregion Dijkstra - Shortest Path

		//public static void Main()
		//{
		//	int[,] matrix = new int[,]
		//	{
		//		{ 1, 0, 1 },
		//		{ 3, 1, 2 },
		//		{ 2, 2, 3 },
		//		{ 4, 0, 3 }
		//	};

		//	Graph graph = Graph.CreateGraph(matrix);

		//	var res = KruskalMST(graph);
		//	var res2 = PrimMST(graph);
		//}
	}
}
