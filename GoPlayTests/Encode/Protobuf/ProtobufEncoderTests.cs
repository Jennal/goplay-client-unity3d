using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoPlay.Encode.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial;
using System.IO;
using Google.Protobuf;

namespace GoPlay.Encode.Protobuf.Tests
{
    [TestClass()]
    public class ProtobufEncoderTests
    {
        Person john = new Person
        {
            Id = 1234,
            Name = "John Doe",
            Email = "jdoe@example.com",
            Phones = { new Person.Types.PhoneNumber { Number = "555-4321", Type = Person.Types.PhoneType.Home } }
        };

        [TestMethod()]
        public void DecodeTest()
        {
            var ms = new MemoryStream();
            john.WriteTo(ms);

            var pbe = new ProtobufEncoder();
            var john2 = pbe.Decode<Person>(ms.ToArray());

            Assert.AreEqual(john, john2);
        }

        [TestMethod()]
        public void EncodeTest()
        {
            var ms = new MemoryStream();
            john.WriteTo(ms);

            var pbe = new ProtobufEncoder();
            var buffer = pbe.Encode(john);
            CollectionAssert.Equals(ms.ToArray(), buffer);
        }
    }
}