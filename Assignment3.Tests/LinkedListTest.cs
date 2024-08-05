using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public class LinkedListTest
    {
        private ILinkedListADT<User> list;

        [SetUp]
        public void Setup()
        {
            list = new SLL<User>();
        }

        [Test]
        public void TestEmptyList()
        {
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestAddFirst()
        {
            User user = new User(1, "Test User", "test@example.com", "password");
            list.AddFirst(user);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetFirst());
        }


        [Test]
        public void TestAddLast()
        {
            User user = new User(1, "Test User", "test@example.com", "password");
            list.AddLast(user);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetLast());
        }

        [Test]
        public void TestAdd()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");
            User user3 = new User(3, "User 3", "user3@example.com", "password3");

            list.AddLast(user1);
            list.AddLast(user3);
            list.Add(user2, 1);

            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(user2, list.GetValue(1));
        }

        [Test]
        public void TestRemove()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");
            User user3 = new User(3, "User 3", "user3@example.com", "password3");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            list.Remove(1);

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user1, list.GetFirst());
            Assert.AreEqual(user3, list.GetLast());
        }

        [Test]
        public void TestRemoveFirst()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);

            list.RemoveFirst();

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user2, list.GetFirst());
        }

        [Test]
        public void TestRemoveLast()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);

            list.RemoveLast();

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetLast());
        }

        [Test]
        public void TestReplace()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.Replace(user2, 0);

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user2, list.GetFirst());
        }

        [Test]
        public void TestGetValue()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);

            Assert.AreEqual(user1, list.GetValue(0));
            Assert.AreEqual(user2, list.GetValue(1));
        }

        [Test]
        public void TestIndexOf()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);

            Assert.AreEqual(0, list.IndexOf(user1));
            Assert.AreEqual(1, list.IndexOf(user2));
            Assert.AreEqual(-1, list.IndexOf(new User(3, "User 3", "user3@example.com", "password3")));
        }

        [Test]
        public void TestContains()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);

            Assert.IsTrue(list.Contains(user1));
            Assert.IsFalse(list.Contains(user2));
        }

        [Test]
        public void TestClear()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);

            list.Clear();

            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestReverse()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");
            User user3 = new User(3, "User 3", "user3@example.com", "password3");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            ((SLL<User>)list).Reverse();

            Assert.AreEqual(user3, list.GetFirst());
            Assert.AreEqual(user2, list.GetValue(1));
            Assert.AreEqual(user1, list.GetLast());
        }

        [Test]
        public void TestSort()
        {
            User user1 = new User(1, "Charlie", "charlie@example.com", "password1");
            User user2 = new User(2, "Alice", "alice@example.com", "password2");
            User user3 = new User(3, "Bob", "bob@example.com", "password3");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            ((SLL<User>)list).Sort();

            Assert.AreEqual("Alice", list.GetValue(0).Name);
            Assert.AreEqual("Bob", list.GetValue(1).Name);
            Assert.AreEqual("Charlie", list.GetValue(2).Name);
        }

        [Test]
        public void TestToArray()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);
            list.AddLast(user2);

            User[] array = ((SLL<User>)list).ToArray();

            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(user1, array[0]);
            Assert.AreEqual(user2, array[1]);
        }

        [Test]
        public void TestJoin()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");

            list.AddLast(user1);

            SLL<User> otherList = new SLL<User>();
            otherList.AddLast(user2);

            ((SLL<User>)list).Join(otherList);

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user1, list.GetFirst());
            Assert.AreEqual(user2, list.GetLast());
        }

        [Test]
        public void TestSplit()
        {
            User user1 = new User(1, "User 1", "user1@example.com", "password1");
            User user2 = new User(2, "User 2", "user2@example.com", "password2");
            User user3 = new User(3, "User 3", "user3@example.com", "password3");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            ILinkedListADT<User>[] splitLists = ((SLL<User>)list).Split(1);

            Assert.AreEqual(2, splitLists.Length);
            Assert.AreEqual(1, splitLists[0].Count());
            Assert.AreEqual(2, splitLists[1].Count());
            Assert.AreEqual(user1, splitLists[0].GetFirst());
            Assert.AreEqual(user2, splitLists[1].GetFirst());
            Assert.AreEqual(user3, splitLists[1].GetLast());
        }
    }
}



















