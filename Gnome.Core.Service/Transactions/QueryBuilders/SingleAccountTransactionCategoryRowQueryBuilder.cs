﻿using Gnome.Core.Service.Categories.Resolvers;
using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Transactions.QueryBuilders
{
    public class SingleAccountTransactionCategoryRowQueryBuilder : ITransactionCategoryRowQueryBuilder
    {
        private readonly IResolverFactory resolverFactory;
        private readonly ITransactionRowQueryBuilder queryBuilder;

        public SingleAccountTransactionCategoryRowQueryBuilder(
            IResolverFactory resolverFactory,
            ITransactionRowQueryBuilder queryBuilder)
        {
            this.resolverFactory = resolverFactory;
            this.queryBuilder = queryBuilder;
        }

        public IEnumerable<TransactionCategoryRow> Query(Guid userId, SingleAccountTransactionSearchFilter filter)
        {
            var categoryResolver = resolverFactory.Create(userId, filter);
            return queryBuilder.Query(userId, filter)
                .Select(t => Create(t, categoryResolver.GetCategories(t.Id)));
        }

        private TransactionCategoryRow Create(TransactionRow row, List<Category> categories)
        {
            return new TransactionCategoryRow() { Row = row, Categories = categories };
        }
    }
}
