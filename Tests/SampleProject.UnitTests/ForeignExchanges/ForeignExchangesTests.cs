using NSubstitute;
using NUnit.Framework;
using SampleProject.Domain.ForeignExchange;
using SampleProject.Infrastructure.Caching;
using SampleProject.Infrastructure.Domain.ForeignExchanges;
using SampleProject.UnitTests.SeedWork;
using System.Collections.Generic;

namespace SampleProject.UnitTests.ForeignExchanges
{
    [TestFixture]
    public class ForeignExchangesTests : TestBase
    {
        [Test]
        public void GetConversionRates_WhenCacheNotAvailable_ShouldReturnTwoValues()
        {
            var subCacheStore = Substitute.For<ICacheStore>();
            var _ForeignExchange = new ForeignExchange(subCacheStore);

            var result = _ForeignExchange.GetConversionRates();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetConversionRates_WhenCacheAvailable_ShouldReturnDifferentValue()
        {

            var subCacheStore = Substitute.For<ICacheStore>();
            var _ForeignExchange = new ForeignExchange(subCacheStore);
            var cachedRates = new ConversionRatesCache(new List<ConversionRate>() {new ConversionRate("a","a",3),
                                                                                   new ConversionRate("b","b",4),
                                                                                   new ConversionRate("c","c",5), });

            subCacheStore.Get(new ConversionRatesCacheKey()).ReturnsForAnyArgs(cachedRates);

            var result = _ForeignExchange.GetConversionRates();

            Assert.AreNotEqual(result.Count, 2);
        }
    }
}