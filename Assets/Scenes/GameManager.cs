using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager gameManager;
    public Text coinText;
    public static GameManager instance;
    public int coinsCollected = 0;

    public Text winText;
    public int coinsToWin = 6;
    private bool gameWon = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int value)
    {
        coinsCollected += value;
        coinText.text = "Coins: " + coinsCollected.ToString();

        if (coinsCollected >= coinsToWin && !gameWon)
        {
            Victory();
        }
    }

    public void Victory()
    {
        winText.gameObject.SetActive(true);
        gameWon = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}