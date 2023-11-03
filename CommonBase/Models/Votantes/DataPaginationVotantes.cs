namespace CommonBase.Models.Votantes
{
    public class DataPaginationVotantes
    {
        public int TotalCount { get; set; }
        public IEnumerable<Votante> Votantes { get; set; }
    }
}
