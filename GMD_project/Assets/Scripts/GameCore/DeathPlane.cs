using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    private GameObject m_Player;
    private static GameObject[] m_lostUIObjects;
    private Button m_restartButton;
    private Button m_menuButton;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_lostUIObjects = GameObject.FindGameObjectsWithTag("DeathUI");

        m_restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        m_menuButton = GameObject.Find("DeathMainMenuButton").GetComponent<Button>();

        m_restartButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        m_menuButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Menu1");
        });

        foreach (var item in m_lostUIObjects)
        {
            item.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_Player.GetComponent<Collider>().Equals(other))
        {
            GameObject.Destroy(m_Player);
            foreach (var item in m_lostUIObjects)
            {
                item.SetActive(true);
            }
        }
    }
}
