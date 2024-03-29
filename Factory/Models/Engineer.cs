
using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    public string Name { get; set; }
    public List<Machine> Machines { get; set; } //collection navigation property
    public List<EnMa> JoinEntities { get;} //collection navigation property
  }
}