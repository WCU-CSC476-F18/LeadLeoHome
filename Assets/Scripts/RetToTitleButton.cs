using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetToTitleButton : MonoBehaviour
{

    public Button startButton, returnButton;
    // Use this for initialization
    void Start()
    {
        Button start = startButton.GetComponent<Button>();
        Button returnToTitle = returnButton.GetComponent<Button>();

        start.onClick.AddListener(StartGame);
        returnToTitle.onClick.AddListener(Info);
    }

    void StartGame()
    {
        SceneManager.LoadScene("_Scene_1");
    }
    void Info()
    {
        SceneManager.LoadScene("_Start_Scene");
    }
}
