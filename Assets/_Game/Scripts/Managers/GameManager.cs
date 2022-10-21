using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>:MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            if(instance != null)
            {
                instance = new GameObject().AddComponent<T>();
            }
            return instance;
        }
    }

}

public class GameManager : Singleton<GameManager>
{
    GameState state;
    public void ChangeState(GameState gameState)
    {
        state = gameState;
    } 
    public bool IsState(GameState gameState)
    {
        return state == gameState;
    }
}
