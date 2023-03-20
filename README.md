# starting over, moving original code to "original" branch


# Site Map
*footer should have a link back home, to engineers and to machines.
```mermaid
flowchart LR
SplashPage("/"<br>Engineers List<br>Machines List)--"[selected engineer]"-->EngineersIndex("/engineers"<br>list of Engineers)--Add an engineer-->EngineerCreate("/engineer/create") 
EngineersIndex-->EngineersDetails["/engineers/details/#"<br>Engineer: Machine1<br>        : Machine2]
SplashPage--"[selected machine]"-->MachineIndex("/machine"<br>list of Machines<br>)--add a machine-->MachineCreate("/machines/create"<br>)
MachineIndex-->MachineDetails["/machines/details#"<br>Machine: Engineer1<br>       : Engineer2]

```



# Dr. SillyStringz's Factory


# make sure to remove comment for your correct dotnet version in Factory.csproj