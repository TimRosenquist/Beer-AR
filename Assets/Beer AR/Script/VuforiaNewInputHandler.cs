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
        // Lyssnar på om man tryckt ned en finger
        LeanTouch.OnFingerTap += LeanTouch_OnFingerDown;

        // Lyssnar och fångar upp händelsen InteractiveHitTest
        // vilket sker när man träffat ett plan
        planeFinderBehaviour.OnInteractiveHitTest.AddListener((hitTestResult) =>
        {
            // Gör då objektet synligt i appen
            refToObject.SetActive(true);

            // sätt positionen på denna plats vi tryckte på
            refToObject.transform.position = planeFinderBehaviour.PlaneIndicator.transform.position;
            refToObject.transform.rotation = planeFinderBehaviour.PlaneIndicator.transform.rotation;


        });
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= LeanTouch_OnFingerDown;

        // Slutar lyssna på händelsen InteractiveHitTest
        planeFinderBehaviour.OnInteractiveHitTest.RemoveListener((x) => { });
    }

    private void LeanTouch_OnFingerDown(LeanFinger obj)
    {
        Vector3 screenPos = new Vector3(obj.ScreenPosition.x, obj.ScreenPosition.y, Camera.main.nearClipPlane);

        // utför ett s.k. "hit test" operation
        // utifrån den position på mobilskärmen man tryckte på
        // och ser om man träffade planet (med andra ord kastar en raycast)
        planeFinderBehaviour.PerformHitTest(screenPos);
    }
}