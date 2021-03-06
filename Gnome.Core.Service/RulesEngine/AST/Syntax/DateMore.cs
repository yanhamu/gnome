﻿using Gnome.Core.Service.Transactions;
using System;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class DateMore : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<DateTime> date;
        private readonly ISyntaxNode<DateTime> than;

        public DateMore(ISyntaxNode<DateTime> date, ISyntaxNode<DateTime> than)
        {
            this.date = date;
            this.than = than;
        }

        public bool Evaluate(TransactionRow row)
        {
            return date.Evaluate(row) > than.Evaluate(row);
        }
    }
}
