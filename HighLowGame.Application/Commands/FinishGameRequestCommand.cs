using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowGame.Application.Commands
{
    public class FinishGameRequestCommand : IRequest<bool>
    {
        public string GameId { get; set; }
    }
}
