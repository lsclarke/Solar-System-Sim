using UnityEngine;
using UnityEngine.Splines;

namespace Nova.SolarSystem
{
    public class OrbitPath : MonoBehaviour
    {
        public CelestialBody planet;
        private SplineContainer splineOrbitPath;

        [Range(0, 1)]
        public float t = 0;
        public float speed;

        private void Start()
        {
            splineOrbitPath = GetComponent<SplineContainer>();
        }

        void Update()
        {

            if (t >= 1)
            {
                t = 0;
            }

            if (speed > 0.0f)
                t += Time.deltaTime * speed;

            if (speed < 0.0f)
                t -= Time.deltaTime * -speed;
            
            var newPostion = splineOrbitPath.EvaluatePosition(t);

            planet.gameObject.transform.position = newPostion;





        }
    }
}
