using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

/// NEW ///
/// F�r hantering av finger touch
using UnityEngine.InputSystem.EnhancedTouch;

/// Skapa en referens till s�kv�gen f�r EnhancedTouch
using newInputTouch = UnityEngine.InputSystem.EnhancedTouch;



public class InteractionManager : MonoBehaviour
{

    [SerializeField]
    private GameObject objectToPlace;

    private GameObject spawnedObject;

    [SerializeField]
    private ARRaycastManager raycastManager;

    private static List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnEnable()
    {
        newInputTouch.Touch.onFingerDown += Touch_onFingerDown;
    }

    private void OnDisable()
    {
        newInputTouch.Touch.onFingerDown -= Touch_onFingerDown;
    }

    private void Touch_onFingerDown(Finger obj)
    {
        //// g�r er interaktion h�r!
        // DebugManager.Instance.AddDebugMessage(obj.screenPosition.ToString());

        // Konvertera �ver sk�rmpositionen vi tryckte p� , p� mobilens sk�rm
        // till en Vector3 , genom att komplettera med near clip plane v�rdet.
        // near clip plane v�rdet syftar till det n�rmaste planet f�r kameran
        // som ligger n�rmast mobilens sk�rm. 
        Vector3 screenPos = new Vector3(obj.screenPosition.x, obj.screenPosition.y, Camera.main.nearClipPlane);

        // H�r utf�rs att vi skapar en raystr�le fr�n sk�rmens position
        // som vi riktas/pekar in i 3D v�rlden 
        Ray ray = Camera.main.ScreenPointToRay(screenPos);


        /// Kolla d� om denna raystr�le tr�ffar n�got objekt
        /// som har en kollisionobjekt kopplat till sig. 
        if (Physics.Raycast(ray, 100f))
        {
            // Om appen n�r �nda hit
            // s� har en interaktion skett med n�got 3D objekt i scenen
            
        }
    }

    bool TryGetTouchPosition(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            // L�ser av vart jag tryckt p� mobilsk�rmen
            // den returnerar tillbaks positionen vart jag tryckte
            // n�gonstans d�r och kopierar �ver v�rdet till touchPos
            touchPos = Input.GetTouch(0).position;

            return true;
        }

        touchPos = default; // L�gg m�rke till nyckelordet "default"

        return false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPos))
        {
            return;
        }

        if (raycastManager.Raycast(touchPos, hitResults, TrackableType.Planes))
        {
            Pose pose = hitResults[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToPlace, pose.position, pose.rotation);
                spawnedObject.SetActive(true);
            }
            else
            {
                // spawnedObject.transform.position = pose.position;
                // spawnedObject.transform.rotation = pose.rotation;
            }
        }
    }
}