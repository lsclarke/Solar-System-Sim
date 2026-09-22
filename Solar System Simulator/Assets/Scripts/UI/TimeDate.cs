using TMPro;
using UnityEngine;

namespace Nova.SolarSystem
{
    public class TimeDate : MonoBehaviour
    {
        public TextMeshProUGUI TimeTextMesh;
        public TextMeshProUGUI DateTextMesh;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            var time = System.DateTime.Now;
            var date = System.DateTime.Now;

            TimeTextMesh.text = time.ToString("hh:mm tt");
            DateTextMesh.text = time.ToString("d");
        }
    }
}
