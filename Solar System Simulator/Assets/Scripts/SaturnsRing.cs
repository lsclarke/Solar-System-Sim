using UnityEngine;

namespace Nova.SolarSystem
{
    public class SaturnsRing : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
