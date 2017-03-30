using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class MenuScript : MonoBehaviour {
    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public string firstLevelName;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {

        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;

    }
	
	public void StartLevel()
    {
        EditorSceneManager.LoadScene(firstLevelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
