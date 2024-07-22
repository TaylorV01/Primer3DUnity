using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    [SerializeField] public PlayerInventory inventory;
    [SerializeField] public GameObject GameOver;

    private Launcher launcher; // Reference to the Launcher script

    void Start()
    {
        // Find the Launcher script in the scene
        launcher = FindObjectOfType<Launcher>();

        // Register the sceneLoaded callback
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (inventory.NumberOfCristals >= 4)
        {
            isGameOver = true;
            GameOver.SetActive(true);
        }
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            ResetGame();
            inventory.NumberOfCristals = 0;
        }
    }

    void ResetGame()
    {
        // Reset isGameOver to false
        isGameOver = false;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Spawn the player after the scene is loaded
        if (launcher != null)
        {
            launcher.SpawnPlayer();
        }
    }

    void OnDestroy()
    {
        // Unregister the sceneLoaded callback
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
