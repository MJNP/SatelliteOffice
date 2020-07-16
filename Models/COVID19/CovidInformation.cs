using Newtonsoft.Json;

namespace SatelliteOffice.Models.COVID19
{
    public class CovidInformation
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_abbreviation")]
        public string CountryAbbreviation { get; set; }

        [JsonProperty("total_cases")]
        public string TotalCases { get; set; }

        [JsonProperty("new_cases")]
        public string NewCases { get; set; }

        [JsonProperty("total_deaths")]
        public string TotalDeaths { get; set; }

        [JsonProperty("new_deaths")]
        public string NewDeaths { get; set; }

        [JsonProperty("total_recovered")]
        public string TotalRecovered { get; set; }

        [JsonProperty("active_cases")]
        public string ActiveCases { get; set; }

        [JsonProperty("serious_critical")]
        public string SeriousCritical { get; set; }

        [JsonProperty("cases_per_mill_pop")]
        public decimal CasesPerMillPop { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
}
