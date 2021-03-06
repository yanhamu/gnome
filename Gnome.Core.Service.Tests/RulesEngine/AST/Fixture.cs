﻿using Gnome.Core.Service.Transactions;
using System;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public static class Fixture
    {
        public static TransactionRow TransactionRow
        {
            get
            {
                var transaction = new TransactionRow(
                    new Guid("6333f550-f904-42f0-9206-981acc5629f7"),
                    new Guid("1d000171-4e13-445f-bd70-5fa5c4e42fc1"),
                    new DateTime(2015, 1, 1),
                    300,
                    "fio",
                    null);
                transaction.Fields.Add("address", "1600 Pennsylvania Avenue");
                transaction.Fields.Add("order", "100");
                return transaction;
            }
        }
    }
}
