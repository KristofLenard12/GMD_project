using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private Button m_startButton;
    private Button m_difficultyButton;
    private Button m_exitButton;
    private Text m_difficultyText; //Diff numbering: 0: normal, 1: hard

    // Start is called before the first frame update
    void Start()
    {
        m_startButton = GameObject.Find("StartGameButton").GetComponent<Button>();
        m_difficultyButton = GameObject.Find("DifficultyButton").GetComponent<Button>();
        m_exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        m_difficultyText = GameObject.Find("DifficultyText").GetComponent<Text>();
        PlayerPrefs.SetInt("Difficulty", 0);

        m_startButton.onClick.AddListener(() => {
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainGame");
        });
        m_difficultyButton.onClick.AddListener(() => {
            if (m_difficultyText.text.Equals("Difficulty: Normal"))
            {
                m_difficultyText.text = "Difficulty: Hard";
                PlayerPrefs.SetInt("Difficulty", 1);
            }
            else
            {
                m_difficultyText.text = "Difficulty: Normal";
                PlayerPrefs.SetInt("Difficulty", 0);
            }
        });
        m_exitButton.onClick.AddListener(() => { 
            Application.Quit();
        });
    }
}
