using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class Example : MonoBehaviour
{
    public GameObject playground = null;

    bool isInited = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlaneDetected(DetectedPlane plane)
    {
        if (isInited) return;

        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon
            | TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(Screen.width * 0.5f, Screen.height * 0.5f, raycastFilter, out hit)) 
        {
            Pose pose = hit.Pose;
            var go = Instantiate(playground, pose.position, pose.rotation);
            
            isInited = true;
        }
    }
}
