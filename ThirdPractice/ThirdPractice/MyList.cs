using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPractice
{
    class Node<T>
    {
        public Node(T data)
        {
            Value = data;
        }
        public T Value { get; set; }
        public Node<T> NextValue { get; set; }
        public Node<T> PrevValue { get; set;     }
    }
    class MyList<T> : IEnumerable<T>
    {
        private Node<T> _Head { get; set; }
        private Node<T> _Tail { get; set; }
        private int Count { get; set; }

        public MyList()
        {
            Count = 0;
        }

        public void Add(T Data)
        {
            Node<T> node = new Node<T>(Data);
            if(_Head == null)
            {
                _Head = node;
            }
            else
            {
                _Tail.NextValue = node;
                node.PrevValue = _Tail;
            }
            _Tail = node;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void AddFirst(T Data)
        {
            var node = new Node<T>(Data);
            var lastHeadNode = _Head;
            node.NextValue = lastHeadNode;
            _Head = node;
            if(Count == 0)
            {
                _Tail = _Head;
            }
            else
            {
                lastHeadNode.PrevValue = node;
            }
            Count++;
        }

        public void SwapFirstAndLast()
        {
            var last = _Tail;
            var first = _Head;
            _Tail.PrevValue.NextValue = first;
            _Head.NextValue.PrevValue = last;
            _Head = last;
            _Tail = first;
        }

        public override string ToString()
        {
            string Output = null;
            Node<T> node = null;
            node = _Head;
            for(int i = 0; i < Count; i++)
            {
                Output += Convert.ToString(node.Value);
                node = node.NextValue;
            }
            return Output;
        }

        public void AddList(List<T> data)
        {
            for(int i = 0; i < data.Count; i++)
            {
                Add(data[i]);
            }
        }
        public void Razbienie(T data)
        {
            var node = _Head;
            MyList<T> list = new MyList<T>();
            MyList<T> list1 = new MyList<T>();
            for (int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(data))
                {
                    list1.Add(node.Value);
                }
                else
                {
                    list.Add(node.Value);
                }
                node = node.NextValue;
            }
        }
        public void Swap(T dataA, T dataB)
        {
            var node = _Head;
            Node<T> nodeA = null;
            Node<T> nodeB = null;
            for (int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(dataA))
                {
                    nodeA = node;
                }
                if (node.Value.Equals(dataB))
                {
                    nodeB = node;
                }
                node = node.NextValue;
            }
            if(nodeA == null || nodeB == null)
            {
                throw new Exception("No element");
            }
            else
            {
                var nodea = new Node<T>(nodeA.Value);
                var nodeb = new Node<T>(nodeB.Value);
                nodea.NextValue = nodeB.NextValue;
                nodeb.NextValue = nodeA.NextValue;
                nodea.PrevValue = nodeB.PrevValue;
                nodeb.PrevValue = nodeA.PrevValue;
                nodeA.PrevValue.NextValue = nodeb;
                nodeA.NextValue.PrevValue = nodeb;
                nodeB.PrevValue.NextValue = nodea;
                nodeB.NextValue.PrevValue = nodea;
            }
        }
        public void Insert(T ElementE, T ElementF)
        {
            var node = _Head;
            var elementF = new Node<T>(ElementF);
            for(int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(ElementE))
                {
                    break;
                }
                node = node.NextValue;
            }
            elementF.NextValue = node;
            elementF.PrevValue = node.PrevValue;
            node.PrevValue.NextValue = elementF;
            /*elementF.NextValue = node;
            elementF.PrevValue = node.PrevValue;
            *//*elementF.PrevValue.NextValue = elementF;*/
            /*node.PrevValue = elementF;*//*
            node.PrevValue.NextValue = elementF;*/
        }
        public void RemovingSecondRefNode(T data)
        {
            var node = _Head;
            List<Node<T>> listNode = new List<Node<T>>();
            for(int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(data))
                {
                    listNode.Add(node);
                }
                node = node.NextValue;
            }
            var removedNode = listNode[1];
            removedNode.NextValue.PrevValue = removedNode.PrevValue;
            removedNode.PrevValue.NextValue = removedNode.NextValue;
            Count--;
        }
        public void RemoveRefNode(T data)
        {
            var node = _Head;
            List<Node<T>> listNode = new List<Node<T>>();
            Console.WriteLine(ToString());
            for (int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(data))
                {
                    listNode.Add(node);
                }
                node = node.NextValue;
            }
            for (int i = 0; i < listNode.Count; i++)
            {
                var removedNode = listNode[i];
                removedNode.NextValue.PrevValue = removedNode.PrevValue;
                removedNode.PrevValue.NextValue = removedNode.NextValue;
                Count--;
            }
        }
        public void Doubling()
        {
            var node = _Head;
            int x = Count;
            for(int i = 0; i < x; i++)
            {
                Add(node.Value);
                node = node.NextValue;
            }
        }
    }
}
