using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetInformation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject informationPanel; // Referens till informationspanelen
    public Text planetNameText; // Referens till textkomponenten för planetens namn
    public Text planetDataText; // Referens till textkomponenten för planetens fakta och data

    private bool isPointerDown = false; // Flagga för att indikera om användaren håller nere pekfingret på en planet

    void Update()
    {
        if (isPointerDown)
        {
            // Visa informationspanelen vid pekfingrets position
            Vector2 pointerPosition = Input.mousePosition;
            informationPanel.transform.position = pointerPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        ShowPlanetInformation();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        HidePlanetInformation();
    }

    void ShowPlanetInformation()
    {
        informationPanel.SetActive(true);

        // Uppdatera textkomponenterna med planetens fakta och data
        planetNameText.text = "Planetens namn";
        planetDataText.text = "Fakta och data om planeten";
    }

    void HidePlanetInformation()
    {
        informationPanel.SetActive(false);
    }
}
