using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameApi.src.Application.Controllers
{
    public class StartGameRequest
    {
        public string[] PlayerId { get; set; } = [];
        public string[] CardId { get; set; } = [];
    }
}