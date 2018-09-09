using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour {

    public Canvas ExitCanvas;
    public Button Exit;
    public Button Restart;

    void Start ()
    {
        var btnExit = Exit.GetComponent<Button>();
        var btnRestart = Restart.GetComponent<Button>();
        ExitCanvas.GetComponent<Canvas>().enabled = false;

        btnExit.enabled = true;
        btnRestart.enabled = true;

        Cursor.visible = true;

    }
	
	void Update ()
    {

	}

    public void RestrartButton()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(0);
#pragma warning restore CS0618 // Type or member is obsolete

    }

    public void ExitButton()
    {
        FindObjectOfType<GameController>().EndText.enabled = false;

        ExitCanvas.enabled = true;

        Restart.enabled = false;
        Exit.enabled = false;

    }

    public void YesExit()
    {
        Application.Quit();
    }

    public void NoExit()
    {
        ExitCanvas.enabled = false;

        Restart.enabled = false;
        Exit.enabled = false;

    }
}
