using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;

public class MapPlacement : MonoBehaviour
{


    public GameObject display;
	
	// Update is called once per frame
	void Update ()
    {

        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                                          TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            if (hit.Trackable is DetectedPlane)
            {

                display.transform.position = hit.Pose.position;
                display.transform.rotation = hit.Pose.rotation;

                var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                display.transform.parent = anchor.transform;
            }
        }
    }
}
