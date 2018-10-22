using LearnAlgorithms.Lists;
using System;

namespace LearnAlgorithms.Heaps
{
	class Heap<T> where T : IComparable
	{
		private Node<T> _node;
		private Queue<Node<T>> _queue;

		public Heap()
		{
			_queue = new Queue<Node<T>>();
		}

		public void Add(T value)
		{
			Node<T> node = new Node<T>(value);
			if (_node == null)
			{
				_node = node;
				return;
			}

			Node<T> currentNode;
			_queue.Enqueue(_node);

			while (node.ParentNode == null)
			{
				currentNode = _queue.Deqeue();

				if (currentNode.LeftNextNode == null)
				{
					currentNode.AttachLeft(node);
					continue;
				}
				_queue.Enqueue(currentNode.LeftNextNode);

				if (currentNode.RightNextNode == null)
				{
					currentNode.AttachRight(node);
					continue;
				}
				_queue.Enqueue(currentNode.RightNextNode);
			}

			if (node == _node)
			{
				return;
			}

			while (node.ParentNode != null && node.Value.CompareTo(node.ParentNode.Value) < 0)
			{
				SwitchNodes(node.ParentNode, node);
			}
		}

		private void SwitchNodes(Node<T> parentNode, Node<T> childNode)
		{
			SwitchRelatedNodes(parentNode, childNode);

			if (parentNode == _node)
			{
				_node = childNode;
				_node.DetachParent();
			}
		}

		public T Get()
		{
			T value = _node.Value;

			T leftValue,
				rightValue;

			if (_node.LeftNextNode != null) leftValue = _node.LeftNextNode.Value;
			if (_node.RightNextNode != null) rightValue = _node.RightNextNode.Value;

			UpdateRootNode();

			Node<T> currentNode = _node;

			while (currentNode != null)
			{
				Node<T> nextNode = GetNodeWithMinimalValue(currentNode);

				if (nextNode == null)
				{
					break;
				}

				SwitchNodes(currentNode, nextNode);

				#region MyRegion
				//if (currentNode.Value.CompareTo(leftValue) > 0 &&
				//	currentNode.Value.CompareTo(rightValue) > 0)
				//{
				//	if (leftValue.CompareTo(rightValue) < 0)
				//	{
				//		SwitchNodes(currentNode, currentNode.LeftNextNode);
				//	}

				//	if (leftValue.CompareTo(rightValue) > 0)
				//	{
				//		SwitchNodes(currentNode, currentNode.RightNextNode);
				//	}
				//}
				//else
				//{
				//	if (currentNode.Value.CompareTo(leftValue) > 0)
				//	{
				//		SwitchNodes(currentNode, currentNode.LeftNextNode);
				//		currentNode = currentNode.LeftNextNode;
				//	}
				//	else if (currentNode.Value.CompareTo(rightValue) > 0)
				//	{
				//		SwitchNodes(currentNode, currentNode.RightNextNode);
				//		currentNode = currentNode.RightNextNode;
				//	}
				//}
				#endregion
			}

			return value;
		}

		private Node<T> GetNodeWithMinimalValue(Node<T> node)
		{
			T value = node.Value;

			if (node.LeftNextNode == null && node.RightNextNode == null) return null;

			if (node.RightNextNode == null)
			{
				return value.CompareTo(node.LeftNextNode.Value) > 0
					? node.LeftNextNode
					: null;
			}

			if (node.LeftNextNode == null)
			{
				return value.CompareTo(node.RightNextNode.Value) > 0
					? node.RightNextNode
					: null;
			}

			if (value.CompareTo(node.RightNextNode.Value) > 0
			    && value.CompareTo(node.LeftNextNode.Value) > 0)
				return node.LeftNextNode.Value.CompareTo(node.RightNextNode.Value) > 0
					? node.RightNextNode
					: node.LeftNextNode;

			if (value.CompareTo(node.RightNextNode.Value) > 0)
				return node.RightNextNode;

			if (value.CompareTo(node.LeftNextNode.Value) > 0)
				return node.LeftNextNode;

			return null;
		}

		private void UpdateRootNode()
		{
			Node<T> currentNode;
			_queue.Enqueue(_node);

			do
			{
				currentNode = _queue.Deqeue();
				if (currentNode.LeftNextNode != null)
				{
					_queue.Enqueue(currentNode.LeftNextNode);
				}

				if (currentNode.RightNextNode != null)
				{
					_queue.Enqueue(currentNode.RightNextNode);
				}

			} while (_queue.Length > 0);

			currentNode.DetachParent();
			currentNode.AttachLeft(_node.LeftNextNode);
			currentNode.AttachRight(_node.RightNextNode);

			_node = currentNode;
		}

		private void SwitchRelatedNodes(Node<T> parentNode, Node<T> childNode)
		{
			if (childNode == null) return;

			Node<T> leftChildNode = childNode.LeftNextNode,
				rightChildNode = childNode.RightNextNode;

			SwitchRootNode(parentNode, childNode);

			SwitchParentNodes(parentNode, childNode);

			AttachParentToChildNode(parentNode, childNode);

			SwitchChildNodes(parentNode, leftChildNode, rightChildNode);
		}

		private void SwitchRootNode(Node<T> parentNode, Node<T> childNode)
		{
			Node<T> rootNode = parentNode.ParentNode;

			if (rootNode == null) return;

			if (rootNode.LeftNextNode == parentNode)
			{
				rootNode.AttachLeft(childNode);
			}

			if (rootNode.RightNextNode == parentNode)
			{
				rootNode.AttachRight(childNode);
			}
		}

		private void SwitchParentNodes(Node<T> parentNode, Node<T> childNode)
		{
			if (parentNode.RightNextNode == childNode)
			{
				childNode.AttachLeft(parentNode.LeftNextNode);
			}

			if (parentNode.LeftNextNode == childNode)
			{
				childNode.AttachRight(parentNode.RightNextNode);
			}
		}

		private void AttachParentToChildNode(Node<T> parentNode, Node<T> childNode)
		{
			if (parentNode.LeftNextNode == childNode)
				childNode.AttachLeft(parentNode);

			if (parentNode.RightNextNode == childNode)
				childNode.AttachRight(parentNode);
		}

		private void SwitchChildNodes(Node<T> parentNode, Node<T> leftChildNode, Node<T> rightChildNode)
		{
			parentNode.AttachLeft(leftChildNode);
			parentNode.AttachRight(rightChildNode);
		}
	}
}
