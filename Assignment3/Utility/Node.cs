using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
    [DataContract]
    public class Node<T>
    {
        [DataMember]
        public T Data { get; set; }
        [DataMember]
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}