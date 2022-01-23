namespace Frwk.AppService.DTO
{
    public class NumerosDTO
    {
        public NumerosDTO()
        {
            NumerosDivisores = new List<int>(); 
            NumerosPrimos = new List<int>();
        }
        public List<int> NumerosDivisores { get; set; }
        public List<int> NumerosPrimos { get; set; } 
    }
}
