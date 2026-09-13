using System.Collections;
using UnityEngine;

namespace Nova.SolarSystem
{
    public class APOD_API : MonoBehaviour
    {

        //NASA APOD API Data
        string date;
        string title;
        string url;
        string hdurl;
        string media_type;
        string explanation;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        IEnumerator DeserialiseJToken()
        {
            yield return null;
        }
    }
}
