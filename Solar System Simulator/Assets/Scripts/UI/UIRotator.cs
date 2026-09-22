using UnityEngine;

namespace Nova.SolarSystem
{
    public class UIRotator : MonoBehaviour
    {
        private RectTransform rectTransform;
        public float speed = 0.5f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rectTransform = this.GetComponent<RectTransform>();
        }

        // Update is called once per frame
        void Update()
        {
            //Rotate Icon on Z axis
            rectTransform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
    }
}
