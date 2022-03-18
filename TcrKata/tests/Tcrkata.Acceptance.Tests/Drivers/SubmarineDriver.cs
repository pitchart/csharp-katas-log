using Tcrkata.Acceptance.Tests.Context;

namespace Tcrkata.Acceptance.Tests.Drivers;

public class SubmarineDriver
{
    private readonly SubmarineContext context;

    public SubmarineDriver(SubmarineContext context)
    {
        this.context = context;
    }

    public void InitializeSubmarine()
    {
    }

    public int GetSubmarineDepth() => this.context.Submarine.Depth;
    public int GetSubmarineAim() => this.context.Submarine.Aim;
    public int GetSubmarinePosition() => this.context.Submarine.Position;
    public int GetFinalValue() => this.context.Submarine.Position * this.context.Submarine.Depth;
    public void SendCommand(string command) => this.context.Submarine.ExecuteCommand(command);
}