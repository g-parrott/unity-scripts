using UnityEngine;

public class TimeSynchronizer
{
    private long _playbackPosition = 0;

    private long _pauseOffset = 0;

    private bool _paused = false;

    public TimeSynchronizer()
    {
    }

// sample - (sample - lastSample)

    public void Update(long deltaSamples)
    {
        _playbackPosition += deltaSamples;
    }

    public void Start()
    {
    }

    public void Stop()
    {
    }

    public void TogglePause()
    {
        _paused = !_paused;
    }

    public void Resync(AudioSource source)
    {
        source.timeSamples = _playbackPosition % source.clip.samples;
    }

    public float GetResync(float timeValue, TimeMeasure measure)
    {
        float rValue = 0;
        switch (measure)
        {
            case TimeMeasure.Micro:
                return timeValue + SamplesToMicroseconds(_playbackPosition);
            case TimeMeasure.Milli:
                return timeValue + SamplesToMilliseconds(_playbackPosition);
            case TimeMeasure.Second:
                return timeValue + SamplesToSeconds(_playbackPosition);
            case TimeMeasure.Minute:
                return timeValue + SamplesToMinute(_playbackPosition);
            default:
                return rValue;
        }
    }

    public static float SamplesToMicroseconds(long samples)
    {
        const float microFactor = 1000000;
        return ((float)samples) * (microFactor/AudioSettings.outputSampleRate);
    }

    public static float SamplesToMilliseconds(long samples)
    {
        const float milliFactor = 1000;
        return ((float)samples) * (milliFactor/AudioSettings.outputSampleRate);
    }

    public static float SamplesToSeconds(long samples)
    {
        const float secondsFactor = 1;
        return ((float)samples) * (secondsFactor/AudioSettings.outputSampleRate);
    }

    public static float SamplesToMinute(long samples)
    {
        const float minutesFactor = 1/60;
        return ((float)samples) * (minutesFactor/AudioSettings.outputSampleRate);
    }
}
