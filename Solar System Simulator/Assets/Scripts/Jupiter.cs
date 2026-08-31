using UnityEngine;

namespace Nova.SolarSystem
{
    public class Jupiter : CelestialBody
    {
        [SerializeField]
        private Earth earth;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GetComponent<Rigidbody>().mass = mass;

            //transform.localScale = new Vector3(mass, mass, mass);
            
        }
        private void FixedUpdate()
        {
            GetComponent<Rigidbody>().mass = mass;
        }
    }
}
