using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "SampleScene")
            {
                Debug.Log("Loading Floor 2");
                SceneManager.LoadScene("Floor2");
            }
            else if (sceneName == "Floor2")
            {
                Debug.Log("Loading Floor 3");
                SceneManager.LoadScene("Floor3");
            }
            else if (sceneName == "Floor3")
            {
                Debug.Log("Loading Floor 4");
                SceneManager.LoadScene("Floor4");
            }
            else if (sceneName == "Floor4")
            {
                Debug.Log("Loading Floor 5");
                SceneManager.LoadScene("Floor5");
            }
            else if (sceneName == "Floor5")
            {
                Debug.Log("Victory Screen");
                SceneManager.LoadScene("VictoryScene");
            }
        }
    }
}
