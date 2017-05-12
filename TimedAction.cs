using System;
using UnityEngine;

public class TimedAction : MonoBehaviour
{
    public float _duration = 0;

    private Action _action = null;

    private float _timeSinceStartCountdown = 0;

    private bool _started = false;

    public bool Initialized
    {
        get
        {
            return _action == null;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (_started)
        {
            _timeSinceStartCountdown += Time.deltaTime;

            if (_timeSinceStartCountdown > _duration)
            {
                _action();
                _started = false;
            }
        }
    }

    public void Initialize(Action action, float duration)
    {
        _action = action;
        _duration = duration;
    }

    public void StartCountdown()
    {
        _started = true;
        _timeSinceStartCountdown = 0;
    }

    // alias for StartCountdown() since this might make more sense semantically
    public void ResetCountdown()
    {
        StartCountdown();
    }

    public void StopCountdown()
    {
        _started = false;
        _timeSinceStartCountdown = 0;
    }
}
