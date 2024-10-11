using System;
using System.Threading.Tasks;

public class Timer
{
    private int currentTime;
    
    public event Action TimeIsOver;
    public event Action<int> TimeIsChanged;

    private bool stopTimer;

    public void StopTimer()
    {
        stopTimer = true;
    }

    public void SetTimer(int timerTime)
    {
        currentTime = timerTime;
    }

    public void StartTimer()
    {
        stopTimer = false;
        ChangeCurrentTime();
    }

    private async Task ChangeCurrentTime()
    {
        while(currentTime > -1)
        {
            if (stopTimer) return;

            TimeIsChanged?.Invoke(currentTime);

            await Task.Delay(1000);

            currentTime -= 1;

            if (currentTime <= 0)
            {
                TimeIsOver?.Invoke();
                break;
            }
        }
    }
}
