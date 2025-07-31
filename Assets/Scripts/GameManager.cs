using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private string scoreString = "Score: ";
    private int score;
    [SerializeField] private TMP_Text timerText;
    private string timerString = "Time: ";
    
    private float timeLimit;
    private float curTime;
    private bool isGameOver = false;
    [SerializeField] private TMP_Text gameText;

    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        score = 0;
        scoreText.text = scoreString + score.ToString();
        gameText.text = "";
        isGameOver = false;
        this.checkDifficulty();
        this.resetTimer();
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        if (curTime > 0)
        {
            // Lower the timer by the amount of time that has passed since the last frame.
            curTime -= Time.deltaTime;

            // Update the UI text to show the new time, formatted to show whole numbers.
            timerText.text = timerString + Mathf.CeilToInt(curTime).ToString();
        }
        else {
            isGameOver = true;
            timerText.text = timerString + "0";
            checkScore();
        }
    }

    void checkDifficulty()
    {
        if (MainMenuManager.Instance.getDifficulty() == 1)
        {
            timeLimit = 60f;
        }
        else if (MainMenuManager.Instance.getDifficulty() == 2)
        {
            timeLimit = 30f;
        }
    }

    void resetTimer()
    {
        this.curTime = timeLimit;
    }

    public void checkScore()
    {
        isGameOver = true;
        LightDisplayManager.Instance.RevealColors();

        if (LightDisplayManager.Instance.getColor1() == LightDisplayManager.Instance.getColorBut1())
        {
            score++;
        }
        if (LightDisplayManager.Instance.getColor2() == LightDisplayManager.Instance.getColorBut2()) {
            score++;
        }
        if (LightDisplayManager.Instance.getColor3() == LightDisplayManager.Instance.getColorBut3()) {
            score++;
        }
        scoreText.text = scoreString + score.ToString();
        
        if (score >= 3)
        {
            gameText.text = "Perfect score! Awesome job!";
        }
        else if (score >= 1)
        {
            gameText.text = "Not perfect, but not bad!";
        }
        else
        {
            gameText.text = "Ouch! You got them all wrong!";
        }
    }
}
