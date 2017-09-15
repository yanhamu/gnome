﻿using Gnome.Core.Reports.AggregateReport;
using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Reports.Tests.AggregateReport
{
    public class AggregateGeneratorTests
    {
        private readonly AggregateGenerator generator;

        public AggregateGeneratorTests()
        {
            var groupedExpenses = new Dictionary<DateTime, decimal>() {
                { Day(1), 10 },
                { Day(2), 20 },
                { Day(4), 40 },
                { Day(5), 50 },
                { Day(6), 60 }
            };

            this.generator = new AggregateGenerator(groupedExpenses);
        }

        [Fact]
        public void Should_Create_Single_Aggregate()
        {
            var interval = new ClosedInterval(Day(2), Day(5));
            var aggregate = generator.Create(interval);

            Assert.Equal(Day(2), aggregate.Interval.From);
            Assert.Equal(Day(5), aggregate.Interval.To);
            Assert.Equal(110m, aggregate.Expences);
        }

        [Fact]
        public void Should_Generate_Aggregates()
        {
            var interval = new ClosedInterval(Day(2), Day(6));
            var aggregates = generator.Generate(interval, 1);

            AssertAggregate(aggregates, 0, ClosedInterval(Day(5), Day(6)), 110m);
            AssertAggregate(aggregates, 1, ClosedInterval(Day(4), Day(5)), 90m);
            AssertAggregate(aggregates, 2, ClosedInterval(Day(3), Day(4)), 40m);
            AssertAggregate(aggregates, 3, ClosedInterval(Day(2), Day(3)), 20m);
            AssertAggregate(aggregates, 4, ClosedInterval(Day(1), Day(2)), 30m);
        }

        public DateTime Day(int day) => new DateTime(2017, 1, day);

        public ClosedInterval ClosedInterval(DateTime from, DateTime to) => new ClosedInterval(from, to);

        public void AssertAggregate(List<Aggregate> aggregates, int index, ClosedInterval interval, decimal amount)
        {
            Assert.Equal(interval, aggregates[index].Interval);
            Assert.Equal(amount, aggregates[index].Expences);
        }
    }
}