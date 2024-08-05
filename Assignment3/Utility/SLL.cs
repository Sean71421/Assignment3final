using System;
using System.Runtime.Serialization;
using System.IO;

namespace Assignment3.Utility
{
    [Serializable]
    public class SLL<T> : ILinkedListADT<User>, ISerializable where T : User
    {
        private class Node
        {
            public User Data { get; set; }
            public Node Next { get; set; }

            public Node(User data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private int count;

        public SLL()
        {
            head = null;
            count = 0;
        }

        public void AddFirst(User item)
        {
            Node newNode = new Node(item);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void AddLast(User item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        public void Add(User item, int index)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 0)
            {
                AddFirst(item);
            }
            else
            {
                Node newNode = new Node(item);
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            count--;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            if (head.Next == null)
            {
                head = null;
                count = 0;
                return;
            }

            Node current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
            count--;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        public User GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            return head.Data;
        }

        public User GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public bool Contains(User item)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int IndexOf(User item)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Count()
        {
            return count;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void Reverse()
        {
            if (head == null || head.Next == null)
                return;

            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }

        public void Sort()
        {
            if (head == null || head.Next == null)
                return;

            bool swapped;
            Node current;
            Node last = null;

            do
            {
                swapped = false;
                current = head;

                while (current.Next != last)
                {
                    if (string.Compare(current.Data.Name, current.Next.Data.Name) > 0)
                    {
                        User temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
                last = current;
            } while (swapped);
        }

        public User[] ToArray()
        {
            User[] array = new User[count];
            Node current = head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
            return array;
        }

        public void Join(ILinkedListADT<User> otherList)
        {
            for (int i = 0; i < otherList.Count(); i++)
            {
                this.AddLast(otherList.GetValue(i));
            }
        }

        public ILinkedListADT<User>[] Split(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            SLL<User> firstHalf = new SLL<User>();
            SLL<User> secondHalf = new SLL<User>();

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                firstHalf.AddLast(current.Data);
                current = current.Next;
            }

            while (current != null)
            {
                secondHalf.AddLast(current.Data);
                current = current.Next;
            }

            return new ILinkedListADT<User>[] { firstHalf, secondHalf };
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("count", count);
            User[] items = new User[count];
            Node current = head;
            for (int i = 0; i < count; i++)
            {
                items[i] = current.Data;
                current = current.Next;
            }
            info.AddValue("items", items);
        }

        protected SLL(SerializationInfo info, StreamingContext context)
        {
            count = info.GetInt32("count");
            User[] items = (User[])info.GetValue("items", typeof(User[]));

            Clear();

            foreach (User item in items)
            {
                AddLast(item);
            }
        }
    }
}