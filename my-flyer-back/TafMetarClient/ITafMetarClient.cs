using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_flyer_back.TafMetarClient
{
    public interface ITafMetarClient
    {
        Task<List<String>> GetMetars(String icao);
        Task<List<String>> GetTafs(String icao);
    }
}
