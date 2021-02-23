using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject placementIdicator;
    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool PlacemnetPoseIsValid = false;
    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementPoseIndicator();
    }

    private void UpdatePlacementPoseIndicator()
    {
      if(PlacemnetPoseIsValid)
        {
            placementIdicator.SetActive(true);
            placementIdicator.transform.SetPositionAndRotation(placementPose.position,placementPose.rotation);
        }
      else
        {
            placementIdicator.SetActive(false);
        }
        
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter,hits,UnityEngine.XR.ARSubsystems.TrackableType.Planes);


        PlacemnetPoseIsValid = hits.Count > 0;
        if(PlacemnetPoseIsValid) //update center raycast
        {
            placementPose = hits[0].pose;
        }
    }
}
