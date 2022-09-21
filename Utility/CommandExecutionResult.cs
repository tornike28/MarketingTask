using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class CommandExecutionResult
    {
        public string? ResultId { get; set; }
        public bool Success { get; set; }
        public IEnumerable<Error>? Errors { get; set; } = new List<Error>();
        public string? ErrorMessage { get; set; }
        public long? ListCount { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public int Code = 200;
    }
}
