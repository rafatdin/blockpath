using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

[Serializable]
public static class GlobalData {

    public static void SetLevel(int world, int level)
    {
        World = world;
        Level = level;
    }
    public static int World { get; set; }
    public static int Level { get; set; }

    public static bool[] accessibleLevels = new bool[6*36];
    public static List<KeyValuePair<int, int>> accessLevels = new List<KeyValuePair<int, int>>(216);

    public static void Reinitialize()
    {
        if (accessLevels == null)
        {
            accessLevels = new List<KeyValuePair<int, int>>(216);
        }
        Load();
    }

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.accessibleLevels = GlobalData.accessibleLevels;
        data.accessLevels = GlobalData.accessLevels;
        formatter.Serialize(file, data);
        file.Close();
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();

            GlobalData.accessibleLevels = data.accessibleLevels;
            GlobalData.accessLevels = data.accessLevels;
        }
    }

    public static void AddNextLevel()
    {
        if (!GlobalData.accessLevels.Exists(x => x.Key == GlobalData.World && x.Value == GlobalData.Level + 1))
            GlobalData.accessLevels.Add(new KeyValuePair<int, int>(GlobalData.World, GlobalData.Level + 1));
        Save();
    }
}
