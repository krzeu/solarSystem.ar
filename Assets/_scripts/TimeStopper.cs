using UnityEngine;

public class TimeStopper : MonoBehaviour
{
    public void StopTime()
    {
        if (Time.timeScale == 0f)
        {
            // Återställ tidens skala om den redan är noll
            Time.timeScale = 1f;
        }
        else
        {
            // Stoppa tiden genom att sätta tidens skala till noll
            Time.timeScale = 0f;
        }
    }
}
