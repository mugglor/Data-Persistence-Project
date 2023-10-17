using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameField;
    public TMP_Text scoreText;

    void Start()
    {
        if (MainMenu.Instance.bestPlayerName.Length > 0)
        {
            scoreText.text = "Best Score: " + MainMenu.Instance.bestPlayerScore;
        }
    }
    public void StartGame()
    {
        MainMenu.Instance.StartGame(playerNameField.text);
    }

    public void Exit()
    {
        MainMenu.Instance.Exit();
    }
}
