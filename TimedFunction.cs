using System;

public struct OptionalFunction<ParamT, ReturnT>
{
    private Func<ParamT, ReturnT> Fn { get; set; }

    public bool CanBeCalled { get; private set; }

    public OptionalFunction(Func<ParamT, ReturnT> fn, bool canBeCalled)
    {
        Fn = fn;
        CanBeCalled = canBeCalled;
    }

    public void Enable()
    {
        CanBeCalled = true;
    }

    public void Disable()
    {
        CanBeCalled = false;
    }

    public void Toggle()
    {
        CanBeCalled = !CanBeCalled;
    }

    public Nullable<ReturnT> Invoke(ParamT param)
    {
        return (CanBeCalled) ? new Nullable<ReturnT>(Fn(param)) : null;
    }
}

public class TimedFunction<ParamT, ResultT>
{
    public TimedFunction()
    {
    }
}
