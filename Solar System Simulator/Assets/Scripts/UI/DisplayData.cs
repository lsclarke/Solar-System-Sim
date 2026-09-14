using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using Codice.CM.Client.Differences;
using UnityEngine.Video;
using UnityEngine.UI;

namespace Nova.SolarSystem
{
    public class DisplayData : MonoBehaviour
    {
        [SerializeField]
        private RequestAPI requestAPI;

        //Label Text UI Display
        private Label dataLabel;

        //Video/Image UI Display
        public VideoPlayer videoPlayer; 

        public RawImage image;

        private void Start()
        {
            StartCoroutine(playVideo());
        }

        public IEnumerator playVideo()
        {
            //Disable Play on Awake
            videoPlayer.playOnAwake = false;

            //Play video from the video clip not the url
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = "https://youtu.be/T0s-043iDEk"; /*requestAPI.API_URL();*/

            videoPlayer.Prepare();

            //Create a new wait time and check while the video is not prepared then wait for video to prepare
            WaitForSeconds waitTime = new WaitForSeconds(5f);
            while (!videoPlayer.isPrepared)
            {
                Debug.Log("Preparing Video");
                yield return waitTime;
                break;
            }

            //Assign the video image to the raw image texture
            image.texture = videoPlayer.texture;

            //Play Video
            videoPlayer.Play();

            while (videoPlayer.isPlaying)
            {
                Debug.Log("Video Time:" + Mathf.FloorToInt((float)videoPlayer.time));
                yield return waitTime;
                break;
            }
        }

        IEnumerator UpdateUI()
        {
            yield return new WaitForSeconds(2f);
            var root = GetComponent<UIDocument>().rootVisualElement;

            dataLabel = root.Q<Label>("DataLabel");

            dataLabel.text = requestAPI.ShowText();
        }
    }
}
