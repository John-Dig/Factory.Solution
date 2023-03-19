using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "The machine's name can't be empty!")]
    public string Name { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must add your machine to a engineer. Have you created a engineer yet?")]
    public int EngineerId { get; set; }
    public Engineer Engineer { get; set; } //? plural engineers? 
    public List<EnMa> JoinEntities { get;} //collection navigation property
  }
}