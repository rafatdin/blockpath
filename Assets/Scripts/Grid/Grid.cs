using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public string gridName { get; set; }
    public float width { get; set; }
    public float height { get; set; }
    //public GameObject boxPrefab;
    //public GameObject borderTopPrefab;
    //public GameObject borderRightPrefab;
    //public GameObject upDashPrefab;
    //public GameObject rightDashPrefab;
    //public GameObject downDashPrefab;
    //public GameObject leftDashPrefab;

    public GameObject box, borderTop, borderRight, upDash, rightDash, downDash, leftDash;
    public void GridCreate(float x, float y, string name, float width, float height)
    {
        //box = (GameObject)GameObject.Instantiate(boxPrefab);
        //borderTop = GameObject.Instantiate(borderTopPrefab);
        //borderRight = GameObject.Instantiate(borderRightPrefab);
        //upDash = GameObject.Instantiate(upDashPrefab);
        //rightDash = GameObject.Instantiate(rightDashPrefab);
        //downDash = GameObject.Instantiate(downDashPrefab);
        //leftDash = GameObject.Instantiate(leftDashPrefab);

        gridName = name;
        this.width = width;
        this.height = height;

        setBox(x, y);
    }

    void setBox(float x, float y)
    {
        box.SetActive(true);
        box.transform.position = new Vector2(x, y);

        setTopBorder(x + box.transform.localScale.x, y);
        setRightBorder(x, y + box.transform.localScale.y);
    }

    void setTopBorder(float x, float y)
    {
        borderTop.transform.localScale.Set(width, 5, 0);
        borderTop.transform.position = new Vector2(x, y);
        borderTop.SetActive(true);
    }

    void setRightBorder(float x, float y)
    {
        borderRight.transform.localScale.Set(5, height, 0);
        borderRight.transform.position = new Vector2(x, y);
        borderRight.SetActive(true);

    }

}
