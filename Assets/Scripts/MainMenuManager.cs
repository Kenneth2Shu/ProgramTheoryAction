using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //ENCAPSULATION
    public static MainMenuManager Instance { get; private set; }
    private int difficulty;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        difficulty = 1;
    }

    void Update()
    {

    }

    public void onLoadButtonPress(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name cannot be null or empty. Please provide a valid scene name.");
            return;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void quitApplication()
    {
        Debug.Log("Quitting application...");
        Application.Quit();

        //for editor play mode.
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void setDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
        Debug.Log("New difficulty is " + difficulty);
    }

    public int getDifficulty()
    {
        return this.difficulty;
    }
}
