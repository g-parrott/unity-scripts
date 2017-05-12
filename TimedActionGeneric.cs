using System;

public class TimedActionGeneric<T>
{
    public T Param { get; private set; }

    public float Duration { get; private set; }

    private Action<T> _action;

    private float _timeSinceStartCountdown = 0;

    private bool _started = false;

    public TimedActionGeneric(Action<T> action, T param, float duration)
    {
        _action = action;
        Param = param;
        Duration = duration;
    }

    public bool Update(float deltaTime)
    {
        if (_started)
        {
            _timeSinceStartCountdown += deltaTime;

            if (_timeSinceStartCountdown > Duration)
            {
                _action(Param);
                _started = false;
                return true;
            }
        }

        return false;
    }

    public void Start()
    {
        _started = true;
        _timeSinceStartCountdown = 0;
    }

    public void Stop()
    {
        _started = false;
        _timeSinceStartCountdown = 0;
    }

    public void Pause()
    {
        _started = false;
    }
}
