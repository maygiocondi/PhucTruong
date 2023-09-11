public class Stopwatch
{
    DateTime starTime = DateTime.Now;
    DateTime endTime;

    public Stopwatch()
    {

    }

    public DateTime GetStartTime()
    {
        return starTime;
    }

    public DateTime GetEndTime()
    {
        return endTime;
    }

    public void Start()
    {
        starTime = DateTime.Now;
    }

    public void Stop()
    {
        endTime = DateTime.Now;
    }

    public TimeSpan GetElapsedTime()
    {
        TimeSpan timePassed = endTime - starTime;
        return timePassed;
    }
}