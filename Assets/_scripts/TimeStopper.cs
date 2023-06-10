using UnityEngine;

public class TimeStopper : MonoBehaviour
{
    public void StopTime()
    {
        if (Time.timeScale == 0f)
        {
            // �terst�ll tidens skala om den redan �r noll
            Time.timeScale = 1f;
        }
        else
        {
            // Stoppa tiden genom att s�tta tidens skala till noll
            Time.timeScale = 0f;
        }
    }
}
