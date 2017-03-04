using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP
{
    public enum SSAPSeverityLevel
    {
        EMERGENCY,      // 0 system is unusable
        ALERT,          // 1 action must be taken immediately
        CRITICAL,       // 2 critical conditions
        ERROR,          // 3 error conditions
        WARNING,        // 4 warning conditions
        NOTICE,         // 5 normal but significant condition
        INFORMATIONAL,  // 6 informational messages
        DEBUG
    }
}
