using UnityEngine;
using UnityEngine.UI;

public class DarkenBackground : MonoBehaviour
{
    public Image overlayImage; // Referens till Image-komponenten som används för överlagring
    public float darkeningOpacity = 0.5f; // Opaciteten för mörkningseffekten

    void Start()
    {
        overlayImage.color = Color.black; // Sätt färgen på överlagringsbilden till svart
        overlayImage.enabled = false; // Inaktivera överlagringsbilden vid start
    }

    public void ToggleDarkening()
    {
        overlayImage.enabled = !overlayImage.enabled; // Aktivera eller inaktivera överlagringsbilden

        if (overlayImage.enabled)
        {
            Color overlayColor = overlayImage.color;
            overlayColor.a = darkeningOpacity;
            overlayImage.color = overlayColor;
        }
    }
}
