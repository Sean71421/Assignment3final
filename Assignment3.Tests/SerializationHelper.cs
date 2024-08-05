using System;
using System.IO;
using System.Runtime.Serialization;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT<User> users, string fileName)
        {

            DataContractSerializer serializer = new DataContractSerializer(
                typeof(ILinkedListADT<User>),
                new Type[] { typeof(SLL<User>), typeof(User), typeof(User[]) }
            );
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT<User> DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(
                typeof(ILinkedListADT<User>),
                new Type[] { typeof(SLL<User>), typeof(User), typeof(User[]) }
            );
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (ILinkedListADT<User>)serializer.ReadObject(stream);
            }
        }
    }
}