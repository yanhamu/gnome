﻿using Gnome.Core.Service.Categories;
using Gnome.Core.Service.Categories.Resolvers;
using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Transactions.QueryBuilders
{
    public class TransactionCategoryRowQueryBuilder : ITransactionCategoryRowQueryBuilder
    {
        private readonly ITransactionRowQueryBuilder queryBuilder;
        private readonly ICategoryTreeFactory categoryTreeFactory;

        public TransactionCategoryRowQueryBuilder(
            ITransactionRowQueryBuilder queryBuilder,
            ICategoryTreeFactory categoryTreeFactory)
        {
            this.queryBuilder = queryBuilder;
            this.categoryTreeFactory = categoryTreeFactory;
        }

        public async Task<IEnumerable<TransactionCategoryRow>> Query(Guid userId, TransactionSearchFilter filter)
        {
            var resolver = new Resolver(await categoryTreeFactory.Create(userId));
            return (await queryBuilder.Query(userId, filter))
                .Select(t => Create(t, resolver.GetCategories(t.Categories)));
        }

        private TransactionCategoryRow Create(TransactionRow row, List<Category> categories)
        {
            return new TransactionCategoryRow(row, categories);
        }
    }
}