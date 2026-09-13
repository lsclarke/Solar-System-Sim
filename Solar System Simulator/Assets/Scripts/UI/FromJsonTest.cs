using UnityEngine;

namespace Nova.SolarSystem
{
    public class FromJsonTest : MonoBehaviour
    {
        public static string completeJson = "{\"name\":\"Dr Charles\",\"lives\":3,\"health\":0.8}";
        // Partial JSON, missing lives and health. In this example, these fields will get their values from the initializer and constructor respectively.
        public static string partialJson = "{\"name\":\"Dr Charles\"}";

        void Start()
        {
            PlayerInfo player1 = PlayerInfo.CreateFromJSON(completeJson);
            Debug.Log("Player1 Name: " + player1.name); // Dr Charles
            Debug.Log("Player1 Lives: " + player1.lives); // 3
            Debug.Log("Player1 Health: " + player1.health); // 0.8
            PlayerInfo player2 = PlayerInfo.CreateFromJSON(partialJson);
            Debug.Log("Player2 Name: " + player2.name); // Dr Charles (from JSON)
            Debug.Log("Player2 Lives: " + player2.lives); // 2 (from initializer)
            Debug.Log("Player2 Health: " + player2.health); // 1 (from constructor)
        }

    }

    [System.Serializable]
    public class PlayerInfo
    {
        public string name = "Unknown";
        public int lives = 2;
        public float health;

        public PlayerInfo()
        {
            health = 1.0f;
        }

        public static PlayerInfo CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PlayerInfo>(jsonString);
        }

    }
}
