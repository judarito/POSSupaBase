namespace CommonBase.Models.ResumenVotos
{
    public class ResumenVotosModel
    {
        public int Votos { get; set; }
        public List<SumaryVotes>? LideresVotos { get; set; }
        public List<SumaryVotes>? PuestosVotos { get; set; }
    }
}
