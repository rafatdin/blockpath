using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TurnToWall : MonoBehaviour {



	public GameManager Game;
    public MenuManager Manager;
    public GameObject nextLevel;
    public string startPoint = "1,1";
    ArrayList path = new ArrayList();
    string lastBlockname;
    bool success = false;

    Color32 blue = new Color32(38, 201, 255, 255);

	// Use this for initialization
	void Start () {
        startPoint = GridMap.startPointsX[Game.world, Game.level, 0] + "," + GridMap.startPointsX[Game.world, Game.level, 1];
        lastBlockname = startPoint;
        DrawPath(startPoint); 
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        //if (!success)
        //    if (Input.GetMouseButton(0) /*|| Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Moved*/)
        //    {
        //        //Ray2D ray = new Ray2D(Camera.main.ScreenPointToRay(Input.GetTouch(0).position).origin, Camera.main.ScreenPointToRay(Input.GetTouch(0).position).direction);
        //        Ray2D ray = new Ray2D(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
        //        //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

        //        RaycastHit2D hit = Physics2D.Raycast(ray.origin, -Vector2.up);
        //        if (hit.collider != null)
        //        {
        //            if (hit.transform.name != lastBlockname && hit.transform.name.Contains(","))
        //            {
        //                if (valid(hit.transform.name))
        //                    DrawPath(hit.transform.name);

        //            }
        //        }
        //    }

        if (!success)
        for (int i = 0; i < Input.touchCount; ++i)
        {
           Ray2D ray = new Ray2D(Camera.main.ScreenPointToRay(Input.GetTouch(i).position).origin, Camera.main.ScreenPointToRay(Input.GetTouch(i).position).direction);
           RaycastHit2D hit = Physics2D.Raycast(ray.origin, -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.transform.name != lastBlockname && hit.transform.name.Contains(","))
                {
                    if (valid(hit.transform.name))
                        DrawPath(hit.transform.name);
                }
            }
        }

        if (path.Count == (Game.gridHeight * Game.gridWidth) - GridMap.blocks[Game.world][Game.level].Count)
        {
            if (!success)
            {
                GlobalData.AddNextLevel();
                Application.LoadLevelAdditiveAsync("NextLevel");
                success = true;
            }
        }
    }

    void DrawPath(string name)
    {
        string[] splitter = name.Split(',');
        if (Game.blocks[int.Parse(splitter[0]), int.Parse(splitter[1])].GetComponent<SpriteRenderer>().material.color == Color.white)
        {
            Game.blocks[int.Parse(splitter[0]), int.Parse(splitter[1])].GetComponent<SpriteRenderer>().material.color = blue;
            path.Add(name);
            foreach (Transform child in Game.blocks[int.Parse(splitter[0]), int.Parse(splitter[1])].transform)
            {
                if (child.name == lastsSide)
                    child.gameObject.SetActive(true);
                if(child.name == "border_"+lastsSide)
                    child.gameObject.SetActive(true);
            }
            foreach (Transform child in Game.blocks[int.Parse(lastBlockname.Split(',')[0]), int.Parse(lastBlockname.Split(',')[1])].transform)
            {
                if (child.name == currentsSide)
                    child.gameObject.SetActive(true);
                if (child.name == "border_" + currentsSide)
                    child.gameObject.SetActive(true);
            }
            lastBlockname = name;
        }
        else if(Game.blocks[int.Parse(splitter[0]), int.Parse(splitter[1])].GetComponent<SpriteRenderer>().material.color == blue)
        {
            int counter = 0;
            for(int i = path.IndexOf(name)+1; i<path.Count; i++)
            {
                Game.blocks[int.Parse(path[i].ToString().Split(',')[0]), int.Parse(path[i].ToString().Split(',')[1])].GetComponent<SpriteRenderer>().material.color = Color.white;
                foreach (Transform child in Game.blocks[int.Parse(path[i].ToString().Split(',')[0]), int.Parse(path[i].ToString().Split(',')[1])].transform)
                {
                    child.gameObject.SetActive(false);
                }
                counter ++;
            }


            //------------------------------------------------
            foreach (Transform child in Game.blocks[int.Parse(name.Split(',')[0]), int.Parse(name.Split(',')[1])].transform)
            {
                child.gameObject.SetActive(false);
            }

            /*
             * When cutting the road the lastsSide variable is set to the one where we came from, 
             * thus we need to simulate the as if we are going from the given block to the cut one again 
             * That's what the next two lines are doing
             */
            lastBlockname = path[path.IndexOf(name) != 0 ? path.IndexOf(name) -1 : 0 ].ToString();
            valid(name);

            //if(!startPoint.Equals(lastBlockname))
            foreach (Transform child in Game.blocks[int.Parse(name.Split(',')[0]), int.Parse(name.Split(',')[1])].transform)
            {
                if (child.name == lastsSide)
                    child.gameObject.SetActive(true);

                if (child.name == "border_" + lastsSide)
                    child.gameObject.SetActive(true);
            }

            if(name.Equals(startPoint))
                foreach (Transform child in Game.blocks[int.Parse(name.Split(',')[0]), int.Parse(name.Split(',')[1])].transform)
                {
                    child.gameObject.SetActive(false);
                }

            //--------------------------------------------

            lastBlockname = name; 
            path.RemoveRange(path.IndexOf(name)+1, counter);
            
        }
    }

    string currentsSide = "", lastsSide = "";
	
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
                if (i == 0) { currentsSide = "right"; lastsSide = "left"; }
                else if (i == 1) { currentsSide = "up"; lastsSide = "down"; }
                else if (i == 2) { currentsSide = "left"; lastsSide = "right"; }
                else if (i == 3) { currentsSide = "down"; lastsSide = "up"; }
                return true;
            }
        }
        if (path.Contains(name))
            return true;

        return false;
    }

    void OnApplicationQuit()
    {
        GlobalData.Save();
    }

}
