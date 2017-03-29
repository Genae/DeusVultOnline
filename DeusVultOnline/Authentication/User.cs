using System;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeusVultOnline.Authentication
{
    public class User : IUser<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailAddressConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public bool LockoutEnabled { get; set; }
        public DateTimeOffset BannedUntil { get; set; }
        public int AccessFailedCount { get; set; }
    }
}