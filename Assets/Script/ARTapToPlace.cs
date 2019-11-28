using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;

   // private ARSessionOrigin arOrigin;
  //  private ARRaycastManager raycastManager;
    private Pose placementPose;
    private float distance=1.5f;
    private Vector3 screenCenter;
    private bool placementPoseIsValid = true;





    void Start()
    {
        //   arOrigin = FindObjectOfType<ARSessionOrigin>();

        //     raycastManager = FindObjectOfType<ARRaycastManager>();
      
        PlaceObject(GPSEncoder.GPSToUCS(new Vector2(55.236206f, 61.301670f)));

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        /*  if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
          {
              Touch touch = Input.GetTouch(0);
              PlaceObject(Camera.current.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, distance)));
          }*/
        
        transform.position = GPSEncoder.GPSToUCS(new Vector2(GPS_.Instance.lattitude, GPS_.Instance.longitude));
    }

    private void PlaceObject(Vector3 pos)
    {
        
        Instantiate(objectToPlace, pos, placementPose.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(screenCenter, placementPose.rotation); 
        }else placementIndicator.SetActive(false);

    }

        private void UpdatePlacementPose()
    {
       screenCenter = Camera.current.ScreenToWorldPoint(new Vector3(0.5f, 0.5f));
        
       // var hits = new List<ARRaycastHit>();      
      //  raycastManager.Raycast(screenCenter, hits);
       // placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid) 
        { 
          //  placementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
        
    }
}
