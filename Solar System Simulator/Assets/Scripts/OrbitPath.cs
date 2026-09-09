using UnityEngine;
using UnityEngine.Splines;

namespace Nova.SolarSystem
{
    public class OrbitPath : MonoBehaviour
    {
        public GameObject planet;
        private SplineContainer splineOrbitPath;

        [Range(0, 1)]
        public float t = 0;
        public float speed;

        //Initialize the spline component.
        private void Start()
        {
            splineOrbitPath = GetComponent<SplineContainer>();
        }


        //Every frame the orbit path will check if the progress of the object is greater than 1. If so it will reset it back to 0 making the object run through the spline again.
        void Update()
        {

            if (t >= 1)
            {
                t = 0;
            }
            //If speed is positive (+) move along spline forward.
            if (speed > 0.0f)
                t += Time.deltaTime * speed;

            //If speed is negative (-) move along spline backwards.
            if (speed < 0.0f)
                t -= Time.deltaTime * -speed;
            
            //evalute the position of the spline path which the object will snap its position to.
            var newPostion = splineOrbitPath.EvaluatePosition(t);

            //Set object to the position of the spline's progress.
            planet.transform.position = newPostion;
        }
    }
}
