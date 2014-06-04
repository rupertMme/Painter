using UnityEngine;
using System.Collections;
using iViewX;

public class mainMenu2 : MonoBehaviourWithGazeComponent
{

    private float dwellTime = 0;
    private float dwellTimeMax = 1.5f;

    public Texture eyePaintlogo;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width * 0.25f, Screen.height * 0.25f), eyePaintlogo);
    }
    public override void OnGazeEnter(RaycastHit2D hit)
    {
        Debug.Log("OnGazeEnter" + name);
    }
	// Use this for initialization
    public override void OnGazeStay(RaycastHit2D hit) {
        if (gameObject.tag == "kalibrierung")
        {
            dwellTime = dwellTime + Time.deltaTime;
            GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
            if (dwellTime >= dwellTimeMax)
            {
                GazeControlComponent.Instance.StartCalibration();
            }
        }
        else if (gameObject.tag == "auto")
        {
            dwellTime = dwellTime + Time.deltaTime;
            GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
            if (dwellTime >= dwellTimeMax)
            {
                GameStateManager.Instance.startState("painterTest");
            }
        }
        else if (gameObject.tag == "fussball")
        {
            dwellTime = dwellTime + Time.deltaTime;
            GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
            if (dwellTime >= dwellTimeMax)
            {
                GameStateManager.Instance.startState("football");
            }
        }
        else if (gameObject.tag == "yoshi")
        {
            dwellTime = dwellTime + Time.deltaTime;
            GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
            if (dwellTime >= dwellTimeMax)
            {
                GameStateManager.Instance.startState("yoshy");
            }
        }
        else if (gameObject.tag == "zwerg")
        {
            dwellTime = dwellTime + Time.deltaTime;
            GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
            if (dwellTime >= dwellTimeMax)
            {
                GameStateManager.Instance.startState("zwerg");
            }
        }
        else if (gameObject.tag == "Spielbeenden") {
            dwellTime = dwellTime + Time.deltaTime;
            GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
            if (dwellTime >= dwellTimeMax)
            {

                Application.Quit();
            }
        }


    }
	void Start () {
        //GazeControlComponent.Instance.StartCalibration();
	}
   void OnLevelWasLoaded(int level) {
       if (level == 0)
       {
           GazeControlComponent.Instance.StartCalibration();
       }
}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnGazeExit()
    {
        Debug.Log("ongazeExit");
        dwellTime = 0;
        GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
    }
}
