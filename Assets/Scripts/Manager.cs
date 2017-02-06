using UnityEngine;
using System.Collections;
using System;

public class Manager : MonoBehaviour {

    public GameObject gridBox;
    public GameObject restart;
    public int gridWidth;
    public int gridHeight;
    public float gridSize;
    public GUIStyle lblStyle;

    public static string distanceType;
    public GameObject[,] blocks;

    private float[] margin = new float[] { 0, 0, 65, 45, 35, 25, 25, 5 };
    public int world, level;
    //This is what you need to show in the inspector.
    public static int distance = 2;
    public string startPoint = "1,1";
    ArrayList path = new ArrayList();
    string lastBlockname;

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
        gridWidth = GridMap.width[world, level];
        gridHeight = GridMap.height[world, level];


        createGrid();
        setBlocks();
    }


    void Start()
    {
        restart.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 50, Screen.height - 50));
        try
        {
            startPoint = GridMap.startPointsX[world, level, 0] + "," + GridMap.startPointsX[world, level, 1];
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            startPoint = "0,0";
        }
        lastBlockname = startPoint;
        DrawPath(startPoint); 
    }

    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{

        //    Ray2D ray = new Ray2D(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
        //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, -Vector2.up);
        //    if (hit.collider != null)
        //    {
        //        if (hit.transform.name != lastBlockname && valid(hit.transform.name))
        //        {
        //            DrawPath(hit.transform.name);
        //        }
        //    }
        //}

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {

                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create a particle if hit
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                    if (hit.transform.name != lastBlockname)
                        if (valid(hit.transform.name))
                            DrawPath(hit.transform.name);
            }
        }
    }

    void DrawPath(string name)
    {
        string[] splitter = name.Split(',');
        if (blocks[int.Parse(splitter[0]), int.Parse(splitter[1])].GetComponent<Renderer>().material.color == Color.white)
        {
            blocks[int.Parse(splitter[0]), int.Parse(splitter[1])].GetComponent<Renderer>().material.color = Color.blue;
            path.Add(name);
            lastBlockname = name;
        }
        else if (blocks[int.Parse(splitter[0]), int.Parse(splitter[1])].GetComponent<Renderer>().material.color == Color.blue)
        {
            int counter = 0;
            for (int i = path.IndexOf(name) + 1; i < path.Count; i++)
            {
                blocks[int.Parse(path[i].ToString().Split(',')[0]), int.Parse(path[i].ToString().Split(',')[1])].GetComponent<Renderer>().material.color = Color.white;
                counter++;
            }

            lastBlockname = name;
            path.RemoveRange(path.IndexOf(name) + 1, counter);

        }
    }



    bool valid(string name)
    {
        int newY = int.Parse(name.Split(',')[0]), newX = int.Parse(name.Split(',')[1]);
        int y = int.Parse(lastBlockname.Split(',')[0]), x = int.Parse(lastBlockname.Split(',')[1]);
        int[,] neighbours = new int[,]
        {
            {y+1,x},    //north
            //{y+1,x+1},//north-east
            {y,x+1},    //east
            //{y-1,x+1},//south-east
            {y-1,x},    //south
            //{y-1,x-1},//soth-west
            {y,x-1},    //west
            //{y+1,x-1}//north-west
        };

        for (int i = 0; i < 4; i++)
        {
            if (neighbours[i, 0] == newY && neighbours[i, 1] == newX)
            {
                return true;
            }
        }

        return false;
    }



    void calculateFitting()
    {
        gridSize = (Screen.width / gridWidth) * 2.5f;
        gridBox.transform.localScale = new Vector3(gridSize, gridSize, gridSize);

        gridBox.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(margin[gridWidth], 70));
    }

    void createGrid()
    {
        //Generate Gameobjects of GridBox to show on the Screen

        calculateFitting();
        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                GameObject nobj = (GameObject)GameObject.Instantiate(gridBox);
                nobj.transform.position = new Vector2(gridBox.transform.position.x + (gridSize * j), gridBox.transform.position.y + (gridSize * i));
                nobj.name = j + "," + i;

                nobj.gameObject.transform.parent = gridBox.transform.parent;
                nobj.SetActive(true);
                blocks[j, i] = nobj;
            }
        }
    }

    void setBlocks()
    {
        foreach (int[] coordinates in GridMap.blocks[world][level])
        {
            blocks[coordinates[0], coordinates[1]].GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
