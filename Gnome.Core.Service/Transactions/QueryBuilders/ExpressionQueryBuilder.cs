﻿using Gnome.Core.Service.RulesEngine;
using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Transactions.QueryBuilders
{
    public class ExpressionQueryBuilder : ITransactionCategoryRowQueryBuilder
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;
        private readonly ICachedEvaluatorFactory evaluatorFactory;

        public ExpressionQueryBuilder(
            ITransactionCategoryRowQueryBuilder queryBuilder,
            ICachedEvaluatorFactory evaluatorFactory)
        {
            this.queryBuilder = queryBuilder;
            this.evaluatorFactory = evaluatorFactory;
        }

        public async Task<IEnumerable<TransactionCategoryRow>> Query(Guid userId, TransactionSearchFilter filter)
        {
            var allExpressions = filter.ExcludeExpressions.Union(filter.IncludeExpressions).ToList();
            var evaluator = await evaluatorFactory.Create(allExpressions);

            var transactions = await queryBuilder.Query(userId, filter);

            if (filter.ExcludeExpressions.Any() && filter.IncludeExpressions.Any())
            {
                return transactions
                    .Where(t => filter.IncludeExpressions.Any(e => evaluator.Evaluate(e, t)))
                    .Where(t => !filter.ExcludeExpressions.Any(e => evaluator.Evaluate(e, t)));
            }
            else if (!filter.ExcludeExpressions.Any() && filter.IncludeExpressions.Any())
            {
                return transactions
                    .Where(t => filter.IncludeExpressions.Any(e => evaluator.Evaluate(e, t)));
            }
            else if (filter.ExcludeExpressions.Any() && !filter.IncludeExpressions.Any())
            {
                return transactions
                    .Where(t => !filter.ExcludeExpressions.Any(e => evaluator.Evaluate(e, t)));
            }
            else
            {
                return transactions;
            }
        }
    }
}