using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlanetRotationAR : MonoBehaviour
{
    public ARSessionOrigin arSessionOrigin; // AR-sessionens ursprung
    public Transform sun; // Referens till solen
    public float[] rotationSpeeds; // Hastighet för rotationen för varje planet
    private Transform[] planets; // Referens till varje planetobjekt

    void Start()
    {
        // Hämta referenser till alla planetobjekt i barnen till detta objekt
        planets = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            planets[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        // Rotera varje planet runt solen i AR-koordinater
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].RotateAround(sun.position, arSessionOrigin.transform.up, rotationSpeeds[i] * Time.deltaTime);
        }
    }
}
