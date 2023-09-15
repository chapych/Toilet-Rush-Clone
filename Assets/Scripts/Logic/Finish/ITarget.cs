using System;

namespace Logic.Finish
{
    public interface ITarget
    {
        event Action OnTargetReached;
    }
}