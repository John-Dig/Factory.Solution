# Site Map
*footer should have a link back home, to engineers and to machines.
```mermaid
flowchart LR
SplashPage["/"<br>Engineers List<br>Machines List]--"[selected engineer]"-->EngineersIndex("/engineers"<br>list of Engineers)--Add an engineer-->EngineerCreate("/engineer/create") 
EngineersIndex-->EngineersDetails{"/engineers/details"}
SplashPage--"[selected machine]"-->MachineIndex("/machine/Index/#"<br>list of Machines<br>)--add a machine-->MachineCreate("/machines/create"<br>)
MachineIndex-->MachineDetails{"/machines/details"}

```



# Dr. SillyStringz's Factory


# make sure to remove comment for your correct dotnet version in Factory.csproj