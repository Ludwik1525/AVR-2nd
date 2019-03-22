using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;

public class MapPlacement : MonoBehaviour
{
    public GameObject display;
    private bool placed = false;
    public Canvas ui;
    public GameObject fPCamera;
	
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
                //GameObject map = Instantiate(display, hit.Pose.position, hit.Pose.rotation);

                display.transform.position = hit.Pose.position;
                display.SetActive(true);

                var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                display.transform.parent = anchor.transform;

                placed = true;

                /*QuizStarter q = fPCamera.GetComponent<QuizStarter>();
                q.display = map;
                q.citiesDisplay = map.transform.GetChild(3).gameObject;
                q.waterDisplay = map.transform.GetChild(2).gameObject;
                q.regioDisplay = map.transform.GetChild(1).gameObject;
                q.sevDisplay = map.transform.GetChild(4).gameObject;

                MapSelection ms = fPCamera.GetComponent<MapSelection>();
                ms.display = map;

                LayerSelection ls = fPCamera.GetComponent<LayerSelection>();
                ls.citiesDisplay = map.transform.GetChild(3).gameObject;
                ls.waterDisplay = map.transform.GetChild(2).gameObject;
                ls.regioDisplay = map.transform.GetChild(1).gameObject;
                ls.kommDisplay = map.transform.GetChild(0).gameObject;
                ls.sevDisplay = map.transform.GetChild(4).gameObject;*/


                ui.gameObject.SetActive(true);

            }
        }
    }
}
