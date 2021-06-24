using System;
using Xunit;
using Web.Controllers;
using Web.Data;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;

namespace Web.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void CVEController_ReadCVE_2021_0109()
        {
            var _db = new VulnDbContext();
            var cveController = new CVEsController(null, _db);
            var cve = await cveController.ReadCVE("0109", 2021);
            Assert.Equal(2021, cve.Year);
            Assert.Equal("0109", cve.Id.Trim());
            Assert.Equal(27, cve.CNA);
        }

        [Fact]
        public async void CWEController_CountCWEs()
        {
            var _db = new VulnDbContext();
            var cweController = new CWEsController(null, _db);
            var cweCount = await cweController.CountCWEs();
            Assert.Equal(941, cweCount);
        }

        [Fact]
        public async void CPEController_CountCPEs()
        {
            var _db = new VulnDbContext();
            var cpeController = new CPEsController(null, _db);
            var cweCount = await cpeController.CountCPEs();
            Assert.Equal(290221, cweCount);
        }


        [Fact]
        public async void CNAController_CountCNAs()
        {
            var _db = new VulnDbContext();
            var cnaController = new CNAsController(null, _db);
            var cnaCount = await cnaController.CountCNAs();
            Assert.Equal(143, cnaCount);
        }

    }
}
