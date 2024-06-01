using Application.Common.Execution;

namespace Application.Interfaces;

public interface IScript
{
    public void Perform(DesktopSession desktopSession);
}
