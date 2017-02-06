using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuManager : MonoBehaviour 
{
	[SerializeField]
	private string m_animationPropertyName;

	[SerializeField]
	private GameObject m_initialScreen;

	[SerializeField]
	private List<GameObject> m_navigationHistory;

	public void GoBack()
	{
		if (m_navigationHistory.Count > 1)
		{
			int index = m_navigationHistory.Count - 1;
			Animate(m_navigationHistory[index - 1], true);

			GameObject target = m_navigationHistory[index];
			m_navigationHistory.RemoveAt(index);
			Animate(target, false);
		}
	}

	public void GoToMenu(GameObject target)
	{
		if (target == null)
		{
			return;
		}

		if (m_navigationHistory.Count > 0)
		{
			Animate(m_navigationHistory[m_navigationHistory.Count - 1], false);
		}

		m_navigationHistory.Add(target);
		Animate(target, true);
	}

    public List<GameObject> levels;
    public GameObject previous, next;
    int currentMenu = 0;
    public void NextMenu(int level)
    {
        foreach (GameObject o in levels)
            o.SetActive(false);
        currentMenu += level;
        levels[currentMenu].SetActive(true);

        if (currentMenu == 0)
            previous.SetActive(false);
        if (currentMenu > 0)
            previous.SetActive(true);
        if (currentMenu == levels.Count - 1)
            next.SetActive(false);
        if (currentMenu < levels.Count - 1)
            next.SetActive(true);
    }

    public void Animate(GameObject target, bool direction)
	{
		if (target == null)
		{
			return;
		}

		target.SetActive(true);

		Canvas canvasComponent = target.GetComponent<Canvas>();
		if (canvasComponent != null)
		{
			canvasComponent.overrideSorting = true;
			canvasComponent.sortingOrder = m_navigationHistory.Count;
		}

		Animator animatorComponent = target.GetComponent<Animator>();
		if (animatorComponent != null)
		{
			animatorComponent.SetBool(m_animationPropertyName, direction);
		}
	}

	private void Awake()
	{
		m_navigationHistory = new List<GameObject>{m_initialScreen};
        if(GlobalData.accessLevels == null)
            GlobalData.Reinitialize();
        if (GlobalData.accessLevels.Count == 0)
            GlobalData.accessLevels.Add(new KeyValuePair<int, int>(1, 1));
	}
    
    public void LoadLevel(string world_level)
    {
        string[] splitter = world_level.Split('-');
        int world = 1, level = 1;
        int.TryParse(splitter[0], out world);
        int.TryParse(splitter[1], out level);


        GlobalData.World = world;
        GlobalData.Level = level;
        GlobalData.accessibleLevels[level] = true;
        Application.LoadLevel("Game2");
    }

    public void LevelsMenu()
    {
        Application.LoadLevelAsync(0);
    }

    public void LoadScene(string name)
    {
        Application.LoadLevel(name);
    }

    public void LoadScene(int i)
    {
        Application.LoadLevel(i);
    }

    public void NextLeve()
    {
        if (GlobalData.Level == 35) { 
            GlobalData.World++;
            GlobalData.Level = 0;
        }
        GlobalData.AddNextLevel();

        LoadLevel(GlobalData.World+"-"+(GlobalData.Level + 1));
    }

    void OnApplicationQuit()
    {
        Save();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.accessibleLevels = GlobalData.accessibleLevels;
        data.accessLevels = GlobalData.accessLevels;

        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();

            GlobalData.accessibleLevels = data.accessibleLevels;
            GlobalData.accessLevels = data.accessLevels;
        }
    }

    string subject = "BLOCK PATH: this game is AWESOME";
    string body = "I have passed level " + GlobalData.Level + " of this game. Guys, is there someone who can beat me?";

    public void callShareApp()
    {
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("shareText", subject, body);
    }

}

[Serializable]
class PlayerData
{
    public bool[] accessibleLevels = new bool[6 * 36];

    public List<KeyValuePair<int, int>> accessLevels { get; set; }
}