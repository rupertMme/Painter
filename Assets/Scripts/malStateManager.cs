using UnityEngine;
using System.Collections;

public class malStateManager : MonoBehaviour {
    private bool malState = false;

    public bool getMalState()
    {
        return malState;
    }

   public  bool setMalState(bool newMalState)
    {
        malState = newMalState;
        return malState;
    }
}
