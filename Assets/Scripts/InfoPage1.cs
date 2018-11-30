using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoPage1 : MonoBehaviour
{

    public Button infoPage2Button, returnButton;
    // Use this for initialization
    void Start()
    {
        Button info = infoPage2Button.GetComponent<Button>();
        Button returnToTitle = returnButton.GetComponent<Button>();

        info.onClick.AddListener(InfoPage2);
        returnToTitle.onClick.AddListener(RetToTitle);
    }

    void InfoPage2()
    {
        SceneManager.LoadScene("_Info_Scene_Page2");
    }
    void RetToTitle()
    {
        SceneManager.LoadScene("_Start_Scene");
    }
}
