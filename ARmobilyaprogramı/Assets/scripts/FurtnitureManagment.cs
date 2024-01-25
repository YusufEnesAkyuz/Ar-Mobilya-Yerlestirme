using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FurtnitureManagment : MonoBehaviour
{
    public GameObject spawnFurtniture;
    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastmanagaer;
    public ARPlaneManager planemanager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
          bool collision = raycastmanagaer.Raycast(Input.GetTouch(0).position, raycastHits, TrackableType.PlaneWithinPolygon);
            if (collision && isButtonPressed() == false)
            {
                GameObject _object = Instantiate(spawnFurtniture);
                _object.transform.position = raycastHits[0].pose.position;
                _object.transform.rotation = raycastHits[0].pose.rotation;
            }
            foreach (var planes in planemanager.trackables)
            {
                planes.gameObject.SetActive(false);
            }
            planemanager.enabled = false;
        }
    }

    public bool isButtonPressed()
    {
        if (EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void SwitchFurtniture(GameObject furtniture)
    {
        spawnFurtniture = furtniture;
    }
}
