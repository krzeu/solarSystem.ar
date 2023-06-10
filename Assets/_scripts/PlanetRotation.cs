using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform centerObject; // Referens till centrumobjektet
    public float rotationSpeed = 10f; // Hastighet f�r rotationen

    void Update()
    {
        // Rotera planeten runt centrumobjektet
        transform.RotateAround(centerObject.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
