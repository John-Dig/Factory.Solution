namespace Factory.Models
{
  public class MachineTag
    {       
        public int MachineTagId { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}