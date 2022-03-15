using TcrKata.Domain;

namespace Tcrkata.Acceptance.Tests.Context;

public class SubmarineContext
{
    public SubmarineContext()
    {
        this.Submarine = new Submarine();
    }

    public Submarine Submarine { get; }
}