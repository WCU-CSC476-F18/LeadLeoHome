using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoPage2 : MonoBehaviour {

    public Button retToTitleButton;

	// Use this for initialization
	void Start () {
        Button returnToTitle = retToTitleButton.GetComponent<Button>();

        returnToTitle.onClick.AddListener(retToTitle);
	}
	
	void retToTitle()
    {
        SceneManager.LoadScene("_Start_Scene");
    }
}
