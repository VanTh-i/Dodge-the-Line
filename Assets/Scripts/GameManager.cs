using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private float initialGameSpeed = 2f;
    private float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;
    private float score;

    protected internal int healthPoint = 3;
    public bool isDead = false;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        NewGame();       
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.RoundToInt(score).ToString("");

        PlayerDead();
    }
    public void NewGame()
    {
        AudioManager.Instance.PlayMusic();

        isDead = false;
        gameSpeed = initialGameSpeed;
        healthPoint = 3;
        score = 0f;
        gameOverUI.gameObject.SetActive(false);

        Animator anim = GameObject.Find("Player").GetComponent<Animator>();
        anim.enabled = false;
    }
    void PlayerDead()
    {
        if (healthPoint == 0)
        {
            isDead = true;
            gameSpeed = 0;
            gameOverUI.gameObject.SetActive(true);

            Animator anim = GameObject.Find("Player").GetComponent<Animator>();
            anim.enabled = false;
        }
    }
}
