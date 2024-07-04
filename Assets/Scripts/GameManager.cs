using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    [SerializeField] public PlayerInventory inventory;
    [SerializeField] public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.NumberOfCristals >=4)
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
}
