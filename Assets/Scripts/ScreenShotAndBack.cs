using UnityEngine;
using System.Collections;

using iViewX;

public class ScreenShotAndBack : MonoBehaviourWithGazeComponent
{
    private float dwellTime;
    private float dwellTimeMax= 1.5f;
    private int screenshotCount = 0;

    public override void OnGazeEnter(RaycastHit2D hit)
    {
        
    }

    public override void OnGazeStay(RaycastHit2D hit)
    {
 
         dwellTime = dwellTime + Time.deltaTime;
            GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
            if (dwellTime >= dwellTimeMax)
            {
                
                    string screenshotFilename;
                    do
                    {
                        screenshotCount++;
                        screenshotFilename = "screenshot" + screenshotCount + ".png";
                        
                    } while (System.IO.File.Exists(screenshotFilename));

                    Application.CaptureScreenshot(screenshotFilename);
                    GameStateManager.Instance.startState("MainMenu");
            }
    }

    public override void OnGazeExit()
    {
        dwellTime = 0;
        GameObject.FindGameObjectWithTag("Dwellcursor").GetComponent<DwellTimeBar>().setDwelltime(dwellTime);
    }
}
