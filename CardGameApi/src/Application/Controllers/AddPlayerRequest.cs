using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGameApi.src.Entities;

namespace CardGameApi.src.Application.Controllers
{
    public class AddPlayerRequest
    {
        public Player PlayerName { get; set; }
    }
}