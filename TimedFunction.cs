using System;

public class TimedFunction<ParamT, ResultT>
{
    public float Duration { get; private set; }

    public ParamT Param { get; private set; }

    private NullableFunction<ParamT, ResultT> _fn;

    private float _timeSinceStartCountdown = 0f;

    private bool _started = false;

    public TimedFunction(Func<ParamT, ResultT> fn, ParamT param, float duration)
    {
        _fn = new NullableFunction<ParamT, ResultT>(fn, false);
    }

    public void Start()
    {
        _timeSinceStartCountdown = 0;
        _started = true;
    }

    public void Stop()
    {
        _started = false;
        _timeSinceStartCountdown = 0;
    }

    public void TogglePause()
    {
        _started = !started;
    }

    public Nullable<ResultT> Update(float deltaTime)
    {
        if (_started)
        {
            _timeSinceStartCountdown += deltaTime;

            if (_timeSinceStartCountdown > Duration)
            {
                _fn.Enable();
            }
        }

        return _fn.Invoke(Param);
    }
}
