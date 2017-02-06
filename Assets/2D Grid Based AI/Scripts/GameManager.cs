using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
public class GameManager : MonoBehaviour {
	public GameObject gridBox, levelText;
    public GameObject Panel;
    public int gridWidth;
	public int gridHeight;
	public float gridSize;
	public GUIStyle lblStyle;


	public static string distanceType;
    public GameObject[,] blocks;

    private float[] margin = new float[] {0, 0, 65, 45, 35, 25, 25, 5};
    public int world, level;
	//This is what you need to show in the inspector.
	public static int distance = 2;

    void Awake()
    {
        blocks = new GameObject[50, 50];
        //instantiate grid gameobjects to display on the scene
        GridMap.populateblocks();

        if (GlobalData.World != 0 && GlobalData.Level != 0)
        {
            world = GlobalData.World;
            level = GlobalData.Level;
        }
        else
        {
            world = 1;
            level = 1;
        }

        levelText.GetComponent<Text>().text = world + "-" + level;

        gridWidth = GridMap.width[world, level];
        gridHeight = GridMap.height[world, level];
        

        createGrid();
        setBlocks();
    }


    void Start()
    {
        //restart.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - (Screen.width / 8), Screen.height - (Screen.height / 10), 10));
        //restart.transform.localScale = new Vector3(Screen.width, Screen.width, 1);
        
        //Back.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 8, Screen.height - (Screen.height / 10), 10));
        //Back.transform.localScale = new Vector3(Screen.width, Screen.width, 1);
	}


    void calculateFitting()
    {
        gridSize = (Screen.width / gridWidth);
        gridBox.transform.localScale = new Vector3(gridSize, gridSize, gridSize);

        gridBox.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(margin[gridWidth], 70));
    }

    void setGridCenter()
    {
        if(gridHeight < 6)
            Panel.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 1.42f, Screen.height/1.38f, Camera.main.nearClipPlane + 11));
        else if(gridHeight == 7 && gridWidth == 4)
            Panel.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 1.58f, Screen.height/1.95f, Camera.main.nearClipPlane + 11));
        else if (gridHeight == 7 && gridWidth == 5)
            Panel.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 1.8f, Screen.height / 1.95f, Camera.main.nearClipPlane + 11));
        else if (gridHeight == 8 && gridWidth == 5)
            Panel.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 1.8f, Screen.height / 2.1f, Camera.main.nearClipPlane + 11));
        else if (gridHeight == 7 && gridWidth == 6)
            Panel.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 1.965f, Screen.height / 1.95f, Camera.main.nearClipPlane + 11));
                    
    }
	void createGrid()
	{
        //Generate Gameobjects of GridBox to show on the Screen

        //calculateFitting();
        for (int i =0; i<gridHeight; i++) {
        	for (int j =0; j<gridWidth; j++) {
        		GameObject nobj = (GameObject)GameObject.Instantiate(gridBox);
                nobj.transform.position = new Vector2(
                    gridBox.transform.position.x + (gridBox.transform.localScale.x * j), 
                    gridBox.transform.position.y + (gridBox.transform.localScale.y * i)
                );
        		nobj.name = j+","+i;

        		nobj.gameObject.transform.parent = gridBox.transform.parent;
        		nobj.SetActive(true);
                blocks[j,i] = nobj;
                
            }
        }
        setGridCenter();
	}


    void setBlocks()
    {
        foreach (int[] coordinates in GridMap.blocks[world][level])
        {
            blocks[coordinates[0], coordinates[1]].GetComponent<Renderer>().material.color = new Color32(255, 135, 135, 255);
        }
    }

    
    public void OnRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnBack()
    {
        //Application.LoadLevel("LevelsMenu");
        Application.LoadLevel(0);
    }

}
