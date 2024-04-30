using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectingPlants : MonoBehaviour
{
    public int plants;
    public Text plantsCollectedText;
    public AudioSource SourceAudio;

    private int totalPlants = 5;
    private bool gameWon = false;

    void Start()
    {
        plants = 0;
        UpdatePlantsCollectedText();
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Plant") && !gameWon)
        {
            Debug.Log("Plant Collected");
            plants++;
            Destroy(Col.gameObject);
            UpdatePlantsCollectedText();

            if (plants == totalPlants)
            {
                Debug.Log("You Win!");
                gameWon = true;
                UpdatePlantsCollectedText("You Win!");
            }
        }
    }

    void UpdatePlantsCollectedText(string extraMessage = "")
    {
        plantsCollectedText.text = "Plants Collected: " + plants + "/" + totalPlants + "\n" + extraMessage;
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Prototype 4", LoadSceneMode.Single);
    }

    void OnCollisionEnter(Collision collision)
    {
        SourceAudio.Play();
    }
}
