using System;
using UnityEngine;

public class Timer
{
    private const int FRAMERATE = 60;
    private double seconds;
    private double frameRate;
    public double secondsPerFrame;

    public Timer()
    {
        this.seconds = 0;
        this.frameRate = FRAMERATE;
        this.secondsPerFrame = 1 / this.frameRate;
    }
    
    public int Update(double seconds)
    {
        this.seconds += seconds;
        int frames = Convert.ToInt32(Math.Floor(this.seconds / secondsPerFrame));
        this.seconds %= this.secondsPerFrame;
        return frames;
    }
}