using System;
using System.Collections;

[Serializable]
public abstract class ActorCommand
{
    public float Duration;
    public short Priority;

    protected ActorCommand()
    {
        Duration = 0;
        Priority = 32;
    }

    protected ActorCommand(float duration, short priority)
    {
        Duration = duration;
        Priority = priority;
    }

    public abstract IEnumerator Execute(GameActor actor);
}
