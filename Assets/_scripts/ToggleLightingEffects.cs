using UnityEngine;

public class ToggleLightingEffects : MonoBehaviour
{
    public Light[] lights; // Array av ljuskomponenter f�r att aktivera/deaktivera

    private bool areEffectsEnabled = true; // Flagga f�r att indikera om belysningseffekterna �r aktiverade

    public void ToggleEffects()
    {
        areEffectsEnabled = !areEffectsEnabled;

        foreach (Light light in lights)
        {
            light.enabled = areEffectsEnabled; // Aktivera eller inaktivera ljuskomponenten baserat p� flaggans v�rde
        }
    }
}

