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
    public string Engineer {get; set; } // not sure if I should have this property and the engineers list property?  But I think it's right.
    public List<Engineer> Engineers { get; set; } //? plural engineers? //just changed to list
    public List<EnMa> JoinEntities { get;} //collection navigation property
  }
}