namespace Factory.Models
{
  public class EnMa
    {       
        public int EnMaId { get; set; }
        public int EngineerId { get; set; }
        public Engineer Engineer { get; set; } //reference navigation property, not saved in db
        public int MachineId { get; set; }
        public Machine Machine { get; set; } //reference navigation property, not saved in db
    }
}

