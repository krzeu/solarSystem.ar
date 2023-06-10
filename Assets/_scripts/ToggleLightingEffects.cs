using UnityEngine;

public class ToggleLightingEffects : MonoBehaviour
{
    public Light[] lights; // Array av ljuskomponenter för att aktivera/deaktivera

    private bool areEffectsEnabled = true; // Flagga för att indikera om belysningseffekterna är aktiverade

    public void ToggleEffects()
    {
        areEffectsEnabled = !areEffectsEnabled;

        foreach (Light light in lights)
        {
            light.enabled = areEffectsEnabled; // Aktivera eller inaktivera ljuskomponenten baserat på flaggans värde
        }
    }
}

