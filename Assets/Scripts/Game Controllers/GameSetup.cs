using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public static GameSetup gameSetup;
    public Transform[] spawnPoints;

    private void OnEnable()
    {
        if(GameSetup.gameSetup == null)
        {
            GameSetup.gameSetup = this;
        }
    }
}
