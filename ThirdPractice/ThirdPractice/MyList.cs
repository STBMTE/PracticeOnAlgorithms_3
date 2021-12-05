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
    }
}
