using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance = null;
    public AudioSource PlayerHit, PlayerDie, EnemyHit, EnemyDie, DoorOpen, DoorClose, Run;
    private Text coinText, healthText, timerText;
    private int coinScore;
    [HideInInspector] public bool isPlayerAlive;

    public float timerTime = 99f;

    public GameObject endPanel;

    void Awake()
    {
        MakeInstance();

        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();

        coinText.text = "Coins: " + coinScore;
    }
    void Start()
    {
        isPlayerAlive = true;
        endPanel.SetActive(false);
    }
    void Update()
    {
        CountdownTimer();
    }

    void MakeInstance()
    {
        instance = this;

    }
    public void CoinCollected()
    {
        coinScore++;
        coinText.text = "Coins: " + coinScore;
    }
    public void DisplayHealth(int health)
    {
        healthText.text = "Health: " + health;
    }
    void CountdownTimer()
    {
        timerTime -= Time.deltaTime;
        timerText.text = "Time: " + timerTime.ToString("F0");
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);
    }
}
