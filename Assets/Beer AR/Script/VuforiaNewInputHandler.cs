using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vuforia;
using Lean.Touch;

public class VuforiaNewInputHandler : MonoBehaviour
{
    //private Touchscreen touchscreen;

    [SerializeField]
    private PlaneFinderBehaviour planeFinderBehaviour;

    [SerializeField]
    private GameObject refToObject;

    

    private void OnEnable()
    {
        // Lyssnar p� om man tryckt ned en finger
        LeanTouch.OnFingerTap += LeanTouch_OnFingerDown;

        // Lyssnar och f�ngar upp h�ndelsen InteractiveHitTest
        // vilket sker n�r man tr�ffat ett plan
        planeFinderBehaviour.OnInteractiveHitTest.AddListener((hitTestResult) =>
        {
            // G�r d� objektet synligt i appen
            refToObject.SetActive(true);

            // s�tt positionen p� denna plats vi tryckte p�
            refToObject.transform.position = planeFinderBehaviour.PlaneIndicator.transform.position;
            refToObject.transform.rotation = planeFinderBehaviour.PlaneIndicator.transform.rotation;


        });
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= LeanTouch_OnFingerDown;

        // Slutar lyssna p� h�ndelsen InteractiveHitTest
        planeFinderBehaviour.OnInteractiveHitTest.RemoveListener((x) => { });
    }

    private void LeanTouch_OnFingerDown(LeanFinger obj)
    {
        Vector3 screenPos = new Vector3(obj.ScreenPosition.x, obj.ScreenPosition.y, Camera.main.nearClipPlane);

        // utf�r ett s.k. "hit test" operation
        // utifr�n den position p� mobilsk�rmen man tryckte p�
        // och ser om man tr�ffade planet (med andra ord kastar en raycast)
        planeFinderBehaviour.PerformHitTest(screenPos);
    }
}