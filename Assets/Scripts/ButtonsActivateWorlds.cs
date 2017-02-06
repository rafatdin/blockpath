using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonsActivateWorlds : MonoBehaviour {

    public List<Button> worlds;
	// Use this for initialization
	void Start () {
        foreach(Button worldButton in worlds)
        {
            int worldNumber = int.Parse(worldButton.GetComponentInChildren<Text>().text);
            GlobalData.Reinitialize();
            if (!GlobalData.accessLevels.Exists(x=>x.Key == worldNumber)){
                worldButton.interactable = false;
                worldButton.GetComponentInParent<Image>().color = new Color32(255, 135, 135, 255);
            }
            else
            {
                worldButton.interactable = true;
                worldButton.GetComponentInParent<Image>().color = new Color32(38, 201, 255, 255);
            }
        }
	}
}
