using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    public Button startButton, infoButton;
    // Use this for initialization
    void Start()
    {
        Button start = startButton.GetComponent<Button>();
        Button info = infoButton.GetComponent<Button>();

        start.onClick.AddListener(StartGame);
        info.onClick.AddListener(Info);
    }

    void StartGame()
    {
        SceneManager.LoadScene("_The_Woods_Scene");
    }
    void Info()
    {
        SceneManager.LoadScene("_Info_Scene");
    }
}
