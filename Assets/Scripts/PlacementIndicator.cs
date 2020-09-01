using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager rayManager;

    [SerializeField]
    private GameObject visual;

    private void Start()
    {
        // Hide the placement visual
        visual.SetActive(false);
    }

    private void Update()
    {
        // Shoot a raycast from center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // if hit AR plane, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }
    }
}
