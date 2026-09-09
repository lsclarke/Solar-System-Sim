using UnityEngine;

namespace Nova.SolarSystem
{
    public class SaturnsRing : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed;

        //Rotate the ring every frame at the value of the rotationSpeed variable
        void Update()
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
