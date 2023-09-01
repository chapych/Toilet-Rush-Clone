public interface IState
{
    
}

public interface IExitableState : IState
{
    void Exit();
}

public interface IEnteringState : IExitableState
{
    void Enter();
}

public interface IPayloadedEnteringState<TPayload> : IExitableState
{
    void Enter(TPayload activeState);
}

