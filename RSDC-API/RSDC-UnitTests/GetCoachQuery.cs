using RSDC_API;
using RSDC_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSDC_UnitTests
{
    public class GetCoachQuery
    {
        private readonly RSDCContext _context;

        public GetCoachQuery(RSDCContext context)
        {
            _context = context;
        }
        public IList<Coach> Execute()
        {
            return _context.Coaches
                .OrderBy(c => c.FirstName)
                .ToList();
        
        }
    }
}
