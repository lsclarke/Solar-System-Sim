using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nova.SolarSystem;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;


namespace Nova.SolarSystem
{
    public class RequestAPI : MonoBehaviour
    {
        //API URL
        public string API_SOURCE;

        //UI TextMesh String
        private string displayText;

        //NASA APOD API Data
        string date;
        string title;
        string url;
        string hdurl;
        string media_type;
        public string thumbnail_url;
        string explanation;

        //When simulator begins start the Request API process
        void Start()
        {
         //   StartCoroutine(RequestAPIData());
        }

        #region API Request Func
        /// <summary>
        /// Request Access to the APOD NASA API and the wait for the request. If the request is not successful print an error.
        /// If the request is a success then the displayText variable will be set to the downloadHander text. 
        /// This is the text format of the API data that will help to give insight into what is specifcally is being retrieved.
        /// The results is the byte data of the downloadHander
        /// </summary>
        IEnumerator RequestAPIData()
        {
            //Create a Unity Web Request and wait for request to be returned
            UnityWebRequest request = UnityWebRequest.Get(API_SOURCE);
            yield return request.SendWebRequest();

            //Check if request is successful or not
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else // Do everything in this code block if request is successful
            {
                // Show results as text
                displayText = request.downloadHandler.text;

                Debug.Log(request.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = request.downloadHandler.data;

                //--------------------------------------------------------------

                //Deserialise using json.net into a generic json token object
                JToken response = JsonConvert.DeserializeObject<JToken>(request.downloadHandler.text);

                if (response is JArray responseArray && responseArray.Count != 0)
                {
                    //Response was an array! Get the first element and then get the data from that field.
                    //Exp: Data = [0]["date"], first element = 0, data = "date".

                    date = (string)responseArray[0]["date"];
                    title = (string)responseArray[0]["title"];
                    url = (string)responseArray[0]["url"];
                    hdurl = (string)responseArray[0]["hdurl"];
                    thumbnail_url = (string)responseArray[0]["thumbnail_url"];
                    media_type = (string)responseArray[0]["media_type"];
                    explanation = (string)responseArray[0]["explanation"];


                    //Do stuff
                    Debug.Log("date: " + date +
                            "\ntitle: " + title +
                            "\nurl: " + url +
                            "\nhdurl: " + hdurl +
                            "\nmedia_type: " + media_type +
                            "\nexplaination: " + explanation);

                    //Create a data variable to access the video player
                    DisplayData data = FindObjectOfType<DisplayData>();

                    //Start new coroutine to play video
                    StartCoroutine(data.playVideo());
                }
                else
                {
                    throw new Exception("Response json was not an array or was empty!");
                }

            }
        }

        #endregion

        #region
        [System.Serializable]
        public class API_Data {

            //NASA APOD API Data
            public string date;
            public string title;
            public string url;
            public string hdurl;
            public string media_type;
            public string thumbnail_url;
            public string explanation;

        }

        #endregion

        #region public variable funcs

        //Display text
        public string ShowText()
        {
            return displayText;
        }

        //Display date
        public string API_Date()
        {
            return date;
        }

        //Display title
        public string API_Title()
        {
            return title;
        }

        //Display url
        public string API_URL()
        {
            return url;
        }

        //Display hdurl
        public string API_HDURL()
        {
            return hdurl;
        }

        //Display Media Type
        public string API_Media_Type()
        {
            return media_type;
        }

        //Display Explanation
        public string API_Explanation()
        {
            return explanation;
        }
        #endregion
    }
}

