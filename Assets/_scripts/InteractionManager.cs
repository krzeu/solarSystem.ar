using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

/// NEW ///
/// För hantering av finger touch
using UnityEngine.InputSystem.EnhancedTouch;

/// Skapa en referens till sökvägen för EnhancedTouch
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
        //// gör er interaktion här!
        // DebugManager.Instance.AddDebugMessage(obj.screenPosition.ToString());

        // Konvertera över skärmpositionen vi tryckte på , på mobilens skärm
        // till en Vector3 , genom att komplettera med near clip plane värdet.
        // near clip plane värdet syftar till det närmaste planet för kameran
        // som ligger närmast mobilens skärm. 
        Vector3 screenPos = new Vector3(obj.screenPosition.x, obj.screenPosition.y, Camera.main.nearClipPlane);

        // Här utförs att vi skapar en raystråle från skärmens position
        // som vi riktas/pekar in i 3D världen 
        Ray ray = Camera.main.ScreenPointToRay(screenPos);


        /// Kolla då om denna raystråle träffar något objekt
        /// som har en kollisionobjekt kopplat till sig. 
        if (Physics.Raycast(ray, 100f))
        {
            // Om appen når ända hit
            // så har en interaktion skett med något 3D objekt i scenen
            
        }
    }

    bool TryGetTouchPosition(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            // Läser av vart jag tryckt på mobilskärmen
            // den returnerar tillbaks positionen vart jag tryckte
            // någonstans där och kopierar över värdet till touchPos
            touchPos = Input.GetTouch(0).position;

            return true;
        }

        touchPos = default; // Lägg märke till nyckelordet "default"

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