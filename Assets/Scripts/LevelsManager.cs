using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelsManager : MonoBehaviour
{
    public Text worldText, levelText;

    public void LoadLevel()
    {
        string[] splitter = worldText.text.Split('-');
        string worldT = splitter[1].Trim();

        int world = 1, level = 1;
        int.TryParse(worldT, out world);
        int.TryParse(levelText.text.Trim(), out level);


        GlobalData.World = world;
        GlobalData.Level = level;
        GlobalData.accessibleLevels[level] = true;
        Application.LoadLevel("Game2");
    }

  
}
