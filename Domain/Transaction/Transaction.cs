﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Transactions;

namespace Domain
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string SenderWalletId { get; set; } = string.Empty;
        public string ReceiverWalletId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public EnumTransactionStatus Status { get; set; } = EnumTransactionStatus.Pending;
    }

    public enum EnumTransactionStatus
    {
        Pending,
        Authorized,
        Rejected,
        Completed
    }
}
