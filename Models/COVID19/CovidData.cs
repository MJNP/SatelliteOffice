using System.Collections.Generic;

namespace SatelliteOffice.Models.COVID19
{
    public class CovidData
    {
        public PaginationMeta PaginationMeta { get; set; }
        public List<CovidInformation> Rows { get; set; }
    }
}
