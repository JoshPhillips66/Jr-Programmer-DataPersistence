using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMenuHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TextMeshProUGUI highScoreInfo;

    public string highScoreText;


    private string playerName;
    private string highScoreName;
    private int highScore;

    void Start()
    {
        playerName = DataManager.Instance.GetPlayerName();
        highScoreName = DataManager.Instance.GetHighScoreName();
        highScore = DataManager.Instance.GetHighScore();

        
        SetText();
    }

    private void SetText()
    {
        nameField.SetTextWithoutNotify(playerName);
        highScoreInfo.text = highScoreName + " " + highScore;
    }

    public void StartButtonPressed()
    {
        playerName = nameField.text;
        DataManager.Instance.SetPlayerName(playerName);
        DataManager.Instance.SaveAll();

        //To do:  Load the main game
        SceneManager.LoadScene(1);
        
    }

    public void QuitButtonPressed()
    {
        DataManager.Instance.SaveAll();
        Application.Quit();
    }

}
