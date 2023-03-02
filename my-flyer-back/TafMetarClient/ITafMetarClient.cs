using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_flyer_back.TafMetarClient
{
    public interface ITafMetarClient
    {
        Task<String> GetMetars(String icao);
    }
}
