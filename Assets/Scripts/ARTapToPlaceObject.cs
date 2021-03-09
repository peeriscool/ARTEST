using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject placementIdicator;
    private ARSessionOrigin arOrigin;
    private ARRaycastManager ArRaycastManager;
    private Pose placementPose;
    private bool PlacemnetPoseIsValid = false;
    private List<ARRaycastHit> currentrays;
    int count = 0;

    public PhoneDebuger log;
    void Start()
    {
        ArRaycastManager = FindObjectOfType<ARRaycastManager>();
        arOrigin = FindObjectOfType<ARSessionOrigin>();
      //  log = FindObjectOfType<PhoneDebuger>();
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
            log.Pushmessage("object placed");
        }
      else
        {
            placementIdicator.SetActive(false);
            log.Pushmessage(PlacemnetPoseIsValid.ToString());
        }
        
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        ArRaycastManager.Raycast(screenCenter,hits, UnityEngine.XR.ARSubsystems.TrackableType.FeaturePoint); //UnityEngine.XR.ARSubsystems.TrackableType.Planes

        currentrays = hits;
        PlacemnetPoseIsValid = hits.Count > count;
        if(PlacemnetPoseIsValid) //update center raycast
        {
            
            placementPose = hits[0].pose;
        }
    }
    public void Buttonpress()
    {
        log.Pushmessage("viable raycast hits are: ");
        log.Pushmessage(currentrays.Count.ToString());
        if(count < currentrays.Count)
        count++;
        log.Pushmessage("Current" + count.ToString());
    }
}
