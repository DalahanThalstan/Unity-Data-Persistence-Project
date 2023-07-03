using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.SetText("Best Score: " + DataSignleton.Instance.highScoreName + ": " + DataSignleton.Instance.highScore);
    }

    public void StartGame()
    {
        DataSignleton.Instance.playerName = inputField.text;
        SceneManager.LoadScene(1); // Load the "main" scene
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
