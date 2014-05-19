using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour
{

    private static GameStateManager instance;

    public static GameStateManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("gamestate").AddComponent<GameStateManager>();
            }

            return instance;
        }
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }

    public void startState(string level)
    {
        print("Creating a new GameState");

        //
        Application.LoadLevel(level);
    }

}