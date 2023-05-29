using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem.EnhancedTouch;
using newInputTouch = UnityEngine.InputSystem.EnhancedTouch;





public class InteractionManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject objectToPlace;

    //private GameObject spawnedObject;

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
        
        if (raycastManager.Raycast(obj.screenPosition, hitResults, TrackableType.Planes))
        {
            Pose pose = hitResults[0].pose;
            
            /*if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToPlace, pose.position, pose.rotation);
                spawnedObject.SetActive(true);
            }*/
        }
    }
}