using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonsActivate : MonoBehaviour {

    public Text worldName;
    public MenuManager Manager;
	// Use this for initialization
	void Start () {
        Manager.Load();
        int world = 1;
        int.TryParse(worldName.text.Split('-')[1].Trim(), out world);
        foreach (GameObject panel in Manager.levels)
        {
            for(int i=0; i<panel.transform.childCount; i++)
            {
                bool unlocked = GlobalData.accessLevels.Exists(
                    x => x.Key == world && x.Value == int.Parse(panel.transform.GetChild(i).gameObject.name)
                );

                if (!unlocked) { 
                    panel.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                    panel.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color32(255, 135, 135, 255);
                }

            }
        }
	}
}
