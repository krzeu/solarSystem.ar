using UnityEngine;
using UnityEngine.UI;

public class DarkenBackground : MonoBehaviour
{
    public Image overlayImage; // Referens till Image-komponenten som anv�nds f�r �verlagring
    public float darkeningOpacity = 0.5f; // Opaciteten f�r m�rkningseffekten

    void Start()
    {
        overlayImage.color = Color.black; // S�tt f�rgen p� �verlagringsbilden till svart
        overlayImage.enabled = false; // Inaktivera �verlagringsbilden vid start
    }

    public void ToggleDarkening()
    {
        overlayImage.enabled = !overlayImage.enabled; // Aktivera eller inaktivera �verlagringsbilden

        if (overlayImage.enabled)
        {
            Color overlayColor = overlayImage.color;
            overlayColor.a = darkeningOpacity;
            overlayImage.color = overlayColor;
        }
    }
}
