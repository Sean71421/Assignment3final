using System;
using Assignment3.Utility;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linked List ADT Demonstration");
            Console.WriteLine("=============================");
            SLL<User> userList = new SLL<User>();

            Console.WriteLine("\nAdding users to the list:");
            userList.AddLast(new User(1, "John Doe", "john@example.com", "password123"));
            userList.AddLast(new User(2, "Jane Smith", "jane@example.com", "password456"));
            userList.AddLast(new User(3, "Bob Johnson", "bob@example.com", "password789"));
            PrintUsers(userList);

            Console.WriteLine("\nAdding a user to the beginning of the list:");
            userList.AddFirst(new User(4, "Alice Brown", "alice@example.com", "passwordabc"));
            PrintUsers(userList);

            Console.WriteLine($"\nFirst user: {userList.GetFirst().Name}");
            Console.WriteLine($"Last user: {userList.GetLast().Name}");

            User searchUser = new User(2, "Jane Smith", "jane@example.com", "password456");
            Console.WriteLine($"\nDoes the list contain Jane Smith? {userList.Contains(searchUser)}");

            Console.WriteLine($"Index of Jane Smith: {userList.IndexOf(searchUser)}");

            Console.WriteLine("\nRemoving Jane Smith from the list:");
            userList.Remove(userList.IndexOf(searchUser));
            PrintUsers(userList);

            Console.WriteLine("\nReplacing Bob Johnson with Eve Wilson:");
            User newUser = new User(5, "Eve Wilson", "eve@example.com", "passwordxyz");
            userList.Replace(newUser, 2);
            PrintUsers(userList);

            Console.WriteLine("\nReversing the list:");
            userList.Reverse();
            PrintUsers(userList);

            Console.WriteLine("\nSorting the list by name:");
            userList.Sort();
            PrintUsers(userList);

            Console.WriteLine("\nConverting list to array:");
            User[] userArray = userList.ToArray();
            foreach (User user in userArray)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
            }

            // join
            Console.WriteLine("\nJoining another list:");
            SLL<User> otherList = new SLL<User>();
            otherList.AddLast(new User(6, "Frank White", "frank@example.com", "password321"));
            otherList.AddLast(new User(7, "Grace Lee", "grace@example.com", "password654"));
            userList.Join(otherList);
            PrintUsers(userList);

            // Split
            Console.WriteLine("\nSplitting the list at index 3:");
            ILinkedListADT<User>[] splitLists = userList.Split(3);
            Console.WriteLine("First half:");
            PrintUsers(splitLists[0]);
            Console.WriteLine("Second half:");
            PrintUsers(splitLists[1]);

            //Clear
            Console.WriteLine("\nClearing the list:");
            userList.Clear();
            Console.WriteLine($"Is the list empty? {userList.IsEmpty()}");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void PrintUsers(ILinkedListADT<User> userList)
        {
            Console.WriteLine($"Number of users: {userList.Count()}");
            for (int i = 0; i < userList.Count(); i++)
            {
                User user = userList.GetValue(i);
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
            }
        }
    }
}