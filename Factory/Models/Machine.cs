using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string Name { get; set; }
    public List<Engineer> Engineers { get; set; } //collection navigation property
    public List<EnMa> JoinEntities { get;} //collection navigation property
  }
}