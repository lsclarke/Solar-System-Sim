using System;
using UnityEngine;

namespace Nova.SolarSystem
{
    public class CameraController : MonoBehaviour
    {
       [SerializeField] private CelestialBody planetObject;

        private float originalZoom;

        [SerializeField]
        private float newZoomIn;

        private Camera cam;

        private void Start()
        {
            cam = GetComponent<Camera>();
            originalZoom = cam.fieldOfView;
        }

        //Every frame focus on the LookAt target.
        void Update()
        {
            transform.LookAt(planetObject.transform);


            if(planetObject.name != "Sun")
            {
                cam.fieldOfView = newZoomIn;
            }
            else
            {
                cam.fieldOfView = originalZoom;
            }
        }
    }
}
