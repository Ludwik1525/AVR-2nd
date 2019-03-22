using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;

public class MapPlacement : MonoBehaviour
{
    public GameObject display;
    private bool placed = false;
    public Canvas ui;
	
	// Update is called once per frame
	void Update ()
    {
        if (placed) return;

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
                Instantiate(display, hit.Pose.position, hit.Pose.rotation);

                var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                display.transform.parent = anchor.transform;

                placed = true;
                ui.gameObject.SetActive(true);
            }
        }
    }
}
