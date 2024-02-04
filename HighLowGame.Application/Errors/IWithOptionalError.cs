using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowGame.Application.Errors
{
    public interface IWithOptionalError
    {
        public Error? Error { get; set; }
    }
}
