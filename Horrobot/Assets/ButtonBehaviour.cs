using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public void LoadLevelByIndex(int levelIndex)
    {
        Player.ResetStats();
        SceneManager.LoadScene(levelIndex);

    }


    public void LoadLevelByName(string levelName)
    {
        Player.ResetStats();
        SceneManager.LoadScene(levelName);
    }

}
