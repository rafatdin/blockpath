using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GridMap
{

    public static int[,] width = new int[7, 36]{
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {
            0, //1-0
            3, //1-1
            4, //1-2
            5, //1-3
            5, //1-4
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6//1-5 - 1-35 
        },
        {
            0, //2-0
            5, //2-1
            6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},    
        {6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},
        {6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},
        {6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},
        {6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6}
    };

    public static int[,] height = new int[7, 36] { 
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {
            0, //1-0
            3, //1-1
            7, //1-2
            7, //1-3
            8, //1-4
            7, //1-5
            8, //1-6
            8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8//1-7 - 1-35 
        },
        {
            8,//2-0
            8,//2-1
            6,//2-2
            7,//2-3
            8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8},    
        {8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8},
        {8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8},
        {8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8},
        {8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8}
    };


    public static int [,,] startPointsX = new int[3, 36, 2] { 
        {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},},
        {{0,0},//1-0
            {0,0},//1-1
            {0,2},//1-2
            {1,3},//1-3
            {4,1},//1-4
            {0,6},//1-5
            {1,7},//1-6
            {1,7},//1-7
            {5,2},//1-8
            {4,5},//1-9
            {4,7},//1-10
            {4,7},//1-11
            {1,7},//1-12
            {0,4},//1-13
            {4,7},//1-14
            {0,7},//1-15
            {2,7},//1-16
            {1,3},//1-17
            {4,4},//1-18
            {0,6},//1-19
            {1,7},//1-20
            {1,7},//1-21
            {2,7},//1-22
            {2,7},//1-23
            {1,2},//1-24
            {3,7},//1-25
            {4,7},//1-26
            {5,7},//1-27
            {1,7},//1-28
            {1,7},//1-29
            {0,7},//1-30
            {4,7},//1-31
            {4,2},//1-32
            {3,7},//1-33
            {3,7},//1-34
            {5,7},//1-35
        },
        {{0,0},//2-0
            {3,5},//2-1
            {0,4},//2-2
            {4,6},//2-3
            {3,7},//2-4
            {4,7},//2-5
            {4,7},//2-6
            {0,7},//2-7
            {5,0},//2-8
            {1,7},//2-9
            {2,7},//2-10
            {0,7},//2-11
            {3,7},//2-12
            {0,4},//2-13
            {0,2},//2-14
            {3,3},//2-15
            {5,2},//2-16
            {0,7},//2-17
            {1,1},//2-18
            {1,1},//2-19
            {1,1},//2-20
            {1,1},//2-21
            {1,1},//2-22
            {1,1},//2-23
            {1,1},//2-24
            {1,1},//2-25
            {1,1},//2-26
            {1,1},//2-27
            {1,1},//2-28
            {1,1},//2-29
            {1,1},//2-30
            {1,1},//2-31
            {1,1},//2-32
            {1,1},//2-33
            {1,1},//2-34
            {1,1},//2-35
        },
    };


    public static List<List<List<int[]>>> blocks = new List<List<List<int[]>>>();

    public static void populateblocks()
    {
        if (blocks.Count == 0)
        {
            blocks.Clear();
            blocks.Add(new List<List<int[]>>()); //world 0
            blocks.Add(new List<List<int[]>>()); //world 1
            blocks.Add(new List<List<int[]>>()); //world 2
            blocks.Add(new List<List<int[]>>()); //world 3
            blocks.Add(new List<List<int[]>>()); //world 4
            blocks.Add(new List<List<int[]>>()); //world 5
            blocks.Add(new List<List<int[]>>()); //world 6
            
            #region World-1 blocks

            blocks[0].Add(new List<int[]>()); // Level 0-0;
            blocks[1].Add(new List<int[]>()); // Level 1-0;
            blocks[1].Add(new List<int[]>()); // Level 1-1;
            blocks[1].Add(new List<int[]>()); // Level 1-2;
            blocks[1].Add(new List<int[]>()); // Level 1-3;
            blocks[1].Add(new List<int[]>()); // Level 1-4;
            blocks[1].Add(new List<int[]>()); // Level 1-5;
            blocks[1].Add(new List<int[]>()); // Level 1-6;
            blocks[1].Add(new List<int[]>()); // Level 1-7;
            blocks[1].Add(new List<int[]>()); // Level 1-8;
            blocks[1].Add(new List<int[]>()); // Level 1-9;
            blocks[1].Add(new List<int[]>()); // Level 1-10;
            blocks[1].Add(new List<int[]>()); // Level 1-11;
            blocks[1].Add(new List<int[]>()); // Level 1-12;
            blocks[1].Add(new List<int[]>()); // Level 1-13;
            blocks[1].Add(new List<int[]>()); // Level 1-14;
            blocks[1].Add(new List<int[]>()); // Level 1-15;
            blocks[1].Add(new List<int[]>()); // Level 1-16;
            blocks[1].Add(new List<int[]>()); // Level 1-17;
            blocks[1].Add(new List<int[]>()); // Level 1-18;
            blocks[1].Add(new List<int[]>()); // Level 1-19;
            blocks[1].Add(new List<int[]>()); // Level 1-20;
            blocks[1].Add(new List<int[]>()); // Level 1-21;
            blocks[1].Add(new List<int[]>()); // Level 1-22;
            blocks[1].Add(new List<int[]>()); // Level 1-23;
            blocks[1].Add(new List<int[]>()); // Level 1-24;
            blocks[1].Add(new List<int[]>()); // Level 1-25;
            blocks[1].Add(new List<int[]>()); // Level 1-26;
            blocks[1].Add(new List<int[]>()); // Level 1-27;
            blocks[1].Add(new List<int[]>()); // Level 1-28;
            blocks[1].Add(new List<int[]>()); // Level 1-29;
            blocks[1].Add(new List<int[]>()); // Level 1-30;
            blocks[1].Add(new List<int[]>()); // Level 1-31;
            blocks[1].Add(new List<int[]>()); // Level 1-32;
            blocks[1].Add(new List<int[]>()); // Level 1-33;
            blocks[1].Add(new List<int[]>()); // Level 1-34;
            blocks[1].Add(new List<int[]>()); // Level 1-35;

            blocks[1][1].Add(new int[] { 1, 1 }); //1-1 block 0 

            blocks[1][2].Add(new int[] { 3, 0 }); //1-2 block 0 
            blocks[1][2].Add(new int[] { 3, 1 }); //1-2 block 1
            blocks[1][2].Add(new int[] { 2, 1 }); //1-2 block 2 
            blocks[1][2].Add(new int[] { 2, 3 }); //1-2 block 3 
            blocks[1][2].Add(new int[] { 2, 4 }); //1-2 block 4

            blocks[1][3].Add(new int[] { 1, 0 }); //1-3 block 1
            blocks[1][3].Add(new int[] { 4, 2 }); //1-3 block 2 
            blocks[1][3].Add(new int[] { 0, 3 }); //1-3 block 3 
            blocks[1][3].Add(new int[] { 4, 3 }); //1-3 block 4 
            blocks[1][3].Add(new int[] { 2, 4 }); //1-3 block 5 
            blocks[1][3].Add(new int[] { 0, 6 }); //1-3 block 6

            blocks[1][4].Add(new int[] { 2, 0 }); //1-4 block 1 
            blocks[1][4].Add(new int[] { 0, 1 }); //1-4 block 2 
            blocks[1][4].Add(new int[] { 4, 2 }); //1-4 block 3 
            blocks[1][4].Add(new int[] { 2, 4 }); //1-4 block 4 
            blocks[1][4].Add(new int[] { 0, 5 }); //1-4 block 5 
            blocks[1][4].Add(new int[] { 3, 6 }); //1-4 block 6 

            blocks[1][5].Add(new int[] { 2, 0 }); //1-5 block 1 
            blocks[1][5].Add(new int[] { 4, 1 }); //1-5 block 2 
            blocks[1][5].Add(new int[] { 2, 2 }); //1-5 block 3 
            blocks[1][5].Add(new int[] { 5, 4 }); //1-5 block 5 
            blocks[1][5].Add(new int[] { 5, 5 }); //1-5 block 6 
            blocks[1][5].Add(new int[] { 3, 6 }); //1-5 block 7 

            blocks[1][6].Add(new int[] { 3, 0 }); //1-6 block 1
            blocks[1][6].Add(new int[] { 0, 1 }); //1-6 block 2
            blocks[1][6].Add(new int[] { 1, 1 }); //1-6 block 3
            blocks[1][6].Add(new int[] { 0, 2 }); //1-6 block 4
            blocks[1][6].Add(new int[] { 4, 3 }); //1-6 block 5
            blocks[1][6].Add(new int[] { 1, 4 }); //1-6 block 6
            blocks[1][6].Add(new int[] { 4, 6 }); //1-6 block 7

            blocks[1][7].Add(new int[] { 0, 0 }); //1-7 block 1
            blocks[1][7].Add(new int[] { 5, 0 }); //1-7 block 2
            blocks[1][7].Add(new int[] { 2, 2 }); //1-7 block 3
            blocks[1][7].Add(new int[] { 4, 4 }); //1-7 block 4
            blocks[1][7].Add(new int[] { 5, 4 }); //1-7 block 5
            blocks[1][7].Add(new int[] { 0, 5 }); //1-7 block 6
            blocks[1][7].Add(new int[] { 4, 7 }); //1-7 block 7

            blocks[1][8].Add(new int[] { 0, 0 }); //1-8 block 1
            blocks[1][8].Add(new int[] { 2, 0 }); //1-8 block 2
            blocks[1][8].Add(new int[] { 2, 1 }); //1-8 block 3
            blocks[1][8].Add(new int[] { 0, 3 }); //1-8 block 4
            blocks[1][8].Add(new int[] { 5, 3 }); //1-8 block 5
            blocks[1][8].Add(new int[] { 1, 6 }); //1-8 block 6
            blocks[1][8].Add(new int[] { 3, 7 }); //1-8 block 7

            blocks[1][9].Add(new int[] { 2, 1 }); //1-9 block 1
            blocks[1][9].Add(new int[] { 0, 2 }); //1-9 block 2
            blocks[1][9].Add(new int[] { 5, 2 }); //1-9 block 3
            blocks[1][9].Add(new int[] { 4, 4 }); //1-9 block 4
            blocks[1][9].Add(new int[] { 2, 5 }); //1-9 block 5
            blocks[1][9].Add(new int[] { 3, 5 }); //1-9 block 6
            blocks[1][9].Add(new int[] { 5, 5 }); //1-9 block 7

            blocks[1][10].Add(new int[] { 2, 0 }); //1-10 block 1
            blocks[1][10].Add(new int[] { 4, 0 }); //1-10 block 2
            blocks[1][10].Add(new int[] { 5, 0 }); //1-10 block 3
            blocks[1][10].Add(new int[] { 4, 1 }); //1-10 block 4
            blocks[1][10].Add(new int[] { 5, 1 }); //1-10 block 5
            blocks[1][10].Add(new int[] { 2, 2 }); //1-10 block 6
            blocks[1][10].Add(new int[] { 1, 6 }); //1-10 block 7

            blocks[1][11].Add(new int[] { 5, 1 }); //1-11 block 1
            blocks[1][11].Add(new int[] { 0, 2 }); //1-11 block 2
            blocks[1][11].Add(new int[] { 3, 2 }); //1-11 block 3
            blocks[1][11].Add(new int[] { 4, 4 }); //1-11 block 4
            blocks[1][11].Add(new int[] { 3, 6 }); //1-11 block 5
            blocks[1][11].Add(new int[] { 2, 7 }); //1-11 block 6
            blocks[1][11].Add(new int[] { 3, 7 }); //1-11 block 7

            blocks[1][12].Add(new int[] { 2, 1 }); //1-12 block 1
            blocks[1][12].Add(new int[] { 3, 1 }); //1-12 block 2
            blocks[1][12].Add(new int[] { 1, 3 }); //1-12 block 3
            blocks[1][12].Add(new int[] { 1, 4 }); //1-12 block 4
            blocks[1][12].Add(new int[] { 3, 4 }); //1-12 block 5
            blocks[1][12].Add(new int[] { 0, 5 }); //1-12 block 6
            blocks[1][12].Add(new int[] { 4, 6 }); //1-12 block 7

            blocks[1][13].Add(new int[] { 2, 0 }); //1-13 block 1
            blocks[1][13].Add(new int[] { 2, 1 }); //1-13 block 2
            blocks[1][13].Add(new int[] { 4, 1 }); //1-13 block 3
            blocks[1][13].Add(new int[] { 3, 2 }); //1-13 block 4
            blocks[1][13].Add(new int[] { 1, 5 }); //1-13 block 5
            blocks[1][13].Add(new int[] { 4, 5 }); //1-13 block 6
            blocks[1][13].Add(new int[] { 5, 5 }); //1-13 block 7

            blocks[1][14].Add(new int[] { 1, 1 }); //1-14 block 1
            blocks[1][14].Add(new int[] { 2, 2 }); //1-14 block 2
            blocks[1][14].Add(new int[] { 5, 2 }); //1-14 block 3
            blocks[1][14].Add(new int[] { 2, 5 }); //1-14 block 4
            blocks[1][14].Add(new int[] { 4, 6 }); //1-14 block 5
            blocks[1][14].Add(new int[] { 0, 7 }); //1-14 block 6
            blocks[1][14].Add(new int[] { 5, 7 }); //1-14 block 7

            blocks[1][15].Add(new int[] { 0, 0 }); //1-15 block 1
            blocks[1][15].Add(new int[] { 2, 0 }); //1-15 block 2
            blocks[1][15].Add(new int[] { 5, 0 }); //1-15 block 3
            blocks[1][15].Add(new int[] { 0, 3 }); //1-15 block 4
            blocks[1][15].Add(new int[] { 0, 4 }); //1-15 block 5
            blocks[1][15].Add(new int[] { 5, 4 }); //1-15 block 6
            blocks[1][15].Add(new int[] { 2, 6 }); //1-15 block 7

            blocks[1][16].Add(new int[] { 5, 1 }); //1-16 block 1
            blocks[1][16].Add(new int[] { 1, 2 }); //1-16 block 2
            blocks[1][16].Add(new int[] { 4, 3 }); //1-16 block 3
            blocks[1][16].Add(new int[] { 4, 4 }); //1-16 block 4
            blocks[1][16].Add(new int[] { 3, 5 }); //1-16 block 5
            blocks[1][16].Add(new int[] { 1, 5 }); //1-16 block 6
            blocks[1][16].Add(new int[] { 1, 6 }); //1-16 block 7

            blocks[1][17].Add(new int[] { 1, 0 }); //1-17 block 1
            blocks[1][17].Add(new int[] { 3, 2 }); //1-17 block 2
            blocks[1][17].Add(new int[] { 0, 4 }); //1-17 block 3
            blocks[1][17].Add(new int[] { 1, 4 }); //1-17 block 4
            blocks[1][17].Add(new int[] { 4, 4 }); //1-17 block 5
            blocks[1][17].Add(new int[] { 3, 5 }); //1-17 block 6
            blocks[1][17].Add(new int[] { 1, 6 }); //1-17 block 7

            blocks[1][18].Add(new int[] { 1, 0 }); //1-18 block 1
            blocks[1][18].Add(new int[] { 2, 2 }); //1-18 block 2
            blocks[1][18].Add(new int[] { 5, 2 }); //1-18 block 3
            blocks[1][18].Add(new int[] { 1, 3 }); //1-18 block 4
            blocks[1][18].Add(new int[] { 1, 4 }); //1-18 block 5
            blocks[1][18].Add(new int[] { 1, 5 }); //1-18 block 6
            blocks[1][18].Add(new int[] { 4, 5 }); //1-18 block 7

            blocks[1][19].Add(new int[] { 2, 0 }); //1-19 block 1
            blocks[1][19].Add(new int[] { 2, 2 }); //1-19 block 2
            blocks[1][19].Add(new int[] { 5, 2 }); //1-19 block 3
            blocks[1][19].Add(new int[] { 0, 5 }); //1-19 block 4
            blocks[1][19].Add(new int[] { 2, 5 }); //1-19 block 5
            blocks[1][19].Add(new int[] { 1, 6 }); //1-19 block 6
            blocks[1][19].Add(new int[] { 5, 7 }); //1-19 block 7

            blocks[1][20].Add(new int[] { 0, 1 }); //1-20 block 1
            blocks[1][20].Add(new int[] { 2, 2 }); //1-20 block 2
            blocks[1][20].Add(new int[] { 5, 2 }); //1-20 block 3
            blocks[1][20].Add(new int[] { 1, 3 }); //1-20 block 4
            blocks[1][20].Add(new int[] { 1, 4 }); //1-20 block 5
            blocks[1][20].Add(new int[] { 2, 5 }); //1-20 block 6
            blocks[1][20].Add(new int[] { 3, 5 }); //1-20 block 7

            blocks[1][21].Add(new int[] { 1, 2 }); //1-21 block 1
            blocks[1][21].Add(new int[] { 0, 3 }); //1-21 block 2
            blocks[1][21].Add(new int[] { 5, 3 }); //1-21 block 3
            blocks[1][21].Add(new int[] { 0, 4 }); //1-21 block 4
            blocks[1][21].Add(new int[] { 3, 4 }); //1-21 block 5
            blocks[1][21].Add(new int[] { 2, 7 }); //1-21 block 6
            blocks[1][21].Add(new int[] { 3, 7 }); //1-21 block 7

            blocks[1][22].Add(new int[] { 2, 0 }); //1-22 block 1
            blocks[1][22].Add(new int[] { 4, 1 }); //1-22 block 2
            blocks[1][22].Add(new int[] { 5, 1 }); //1-22 block 3
            blocks[1][22].Add(new int[] { 2, 2 }); //1-22 block 4
            blocks[1][22].Add(new int[] { 5, 4 }); //1-22 block 5
            blocks[1][22].Add(new int[] { 5, 5 }); //1-22 block 6
            blocks[1][22].Add(new int[] { 1, 6 }); //1-22 block 7
            
            blocks[1][23].Add(new int[] { 0, 0 }); //1-23 block 1
            blocks[1][23].Add(new int[] { 2, 0 }); //1-23 block 2
            blocks[1][23].Add(new int[] { 0, 3 }); //1-23 block 3
            blocks[1][23].Add(new int[] { 2, 3 }); //1-23 block 4
            blocks[1][23].Add(new int[] { 0, 6 }); //1-23 block 5
            blocks[1][23].Add(new int[] { 0, 7 }); //1-23 block 6
            blocks[1][23].Add(new int[] { 5, 7 }); //1-23 block 7

            blocks[1][24].Add(new int[] { 4, 0 }); //1-24 block 1
            blocks[1][24].Add(new int[] { 0, 2 }); //1-24 block 2
            blocks[1][24].Add(new int[] { 0, 3 }); //1-24 block 3
            blocks[1][24].Add(new int[] { 3, 3 }); //1-24 block 4
            blocks[1][24].Add(new int[] { 4, 5 }); //1-24 block 5
            blocks[1][24].Add(new int[] { 1, 6 }); //1-24 block 6
            blocks[1][24].Add(new int[] { 3, 7 }); //1-24 block 7

            blocks[1][25].Add(new int[] { 1, 0 }); //1-25 block 1
            blocks[1][25].Add(new int[] { 4, 2 }); //1-25 block 2
            blocks[1][25].Add(new int[] { 5, 2 }); //1-25 block 3
            blocks[1][25].Add(new int[] { 2, 3 }); //1-25 block 4
            blocks[1][25].Add(new int[] { 5, 3 }); //1-25 block 5
            blocks[1][25].Add(new int[] { 4, 5 }); //1-25 block 6
            blocks[1][25].Add(new int[] { 5, 7 }); //1-25 block 7

            blocks[1][26].Add(new int[] { 0, 2 }); //1-26 block 1
            blocks[1][26].Add(new int[] { 3, 2 }); //1-26 block 2
            blocks[1][26].Add(new int[] { 2, 3 }); //1-26 block 3
            blocks[1][26].Add(new int[] { 1, 5 }); //1-26 block 4
            blocks[1][26].Add(new int[] { 3, 5 }); //1-26 block 5
            blocks[1][26].Add(new int[] { 1, 6 }); //1-26 block 6
            blocks[1][26].Add(new int[] { 2, 6 }); //1-26 block 7

            blocks[1][27].Add(new int[] { 2, 0 }); //1-27 block 1
            blocks[1][27].Add(new int[] { 3, 0 }); //1-27 block 2
            blocks[1][27].Add(new int[] { 3, 2 }); //1-27 block 3
            blocks[1][27].Add(new int[] { 0, 3 }); //1-27 block 4
            blocks[1][27].Add(new int[] { 1, 3 }); //1-27 block 5
            blocks[1][27].Add(new int[] { 1, 4 }); //1-27 block 6
            blocks[1][27].Add(new int[] { 3, 7 }); //1-27 block 7

            blocks[1][28].Add(new int[] { 1, 0 }); //1-28 block 1
            blocks[1][28].Add(new int[] { 5, 0 }); //1-28 block 2
            blocks[1][28].Add(new int[] { 2, 2 }); //1-28 block 3
            blocks[1][28].Add(new int[] { 3, 3 }); //1-28 block 4
            blocks[1][28].Add(new int[] { 0, 5 }); //1-28 block 5
            blocks[1][28].Add(new int[] { 3, 5 }); //1-28 block 6
            blocks[1][28].Add(new int[] { 3, 6 }); //1-28 block 7

            blocks[1][29].Add(new int[] { 2, 0 }); //1-29 block 1
            blocks[1][29].Add(new int[] { 2, 2 }); //1-29 block 2
            blocks[1][29].Add(new int[] { 5, 2 }); //1-29 block 3
            blocks[1][29].Add(new int[] { 4, 3 }); //1-29 block 4
            blocks[1][29].Add(new int[] { 4, 4 }); //1-29 block 5
            blocks[1][29].Add(new int[] { 3, 6 }); //1-29 block 6
            blocks[1][29].Add(new int[] { 0, 7 }); //1-29 block 7

            blocks[1][30].Add(new int[] { 4, 0 }); //1-30 block 1
            blocks[1][30].Add(new int[] { 2, 2 }); //1-30 block 2
            blocks[1][30].Add(new int[] { 3, 2 }); //1-30 block 3
            blocks[1][30].Add(new int[] { 5, 2 }); //1-30 block 4
            blocks[1][30].Add(new int[] { 4, 4 }); //1-30 block 5
            blocks[1][30].Add(new int[] { 1, 5 }); //1-30 block 6
            blocks[1][30].Add(new int[] { 2, 7 }); //1-30 block 7

            blocks[1][31].Add(new int[] { 4, 1 }); //1-31 block 1
            blocks[1][31].Add(new int[] { 0, 3 }); //1-31 block 2
            blocks[1][31].Add(new int[] { 5, 3 }); //1-31 block 3
            blocks[1][31].Add(new int[] { 2, 4 }); //1-31 block 4
            blocks[1][31].Add(new int[] { 4, 4 }); //1-31 block 5
            blocks[1][31].Add(new int[] { 2, 7 }); //1-31 block 6
            blocks[1][31].Add(new int[] { 3, 7 }); //1-31 block 7

            blocks[1][32].Add(new int[] { 2, 0 }); //1-32 block 1
            blocks[1][32].Add(new int[] { 0, 1 }); //1-32 block 2
            blocks[1][32].Add(new int[] { 2, 1 }); //1-32 block 3
            blocks[1][32].Add(new int[] { 5, 2 }); //1-32 block 4
            blocks[1][32].Add(new int[] { 4, 3 }); //1-32 block 5
            blocks[1][32].Add(new int[] { 5, 3 }); //1-32 block 6
            blocks[1][32].Add(new int[] { 3, 7 }); //1-32 block 7

            blocks[1][33].Add(new int[] { 0, 0 }); //1-33 block 1
            blocks[1][33].Add(new int[] { 5, 0 }); //1-33 block 2
            blocks[1][33].Add(new int[] { 5, 4 }); //1-33 block 3
            blocks[1][33].Add(new int[] { 1, 5 }); //1-33 block 4
            blocks[1][33].Add(new int[] { 5, 5 }); //1-33 block 5
            blocks[1][33].Add(new int[] { 3, 6 }); //1-33 block 6
            blocks[1][33].Add(new int[] { 4, 7 }); //1-33 block 7

            blocks[1][34].Add(new int[] { 5, 0 }); //1-34 block 1
            blocks[1][34].Add(new int[] { 1, 1 }); //1-34 block 2
            blocks[1][34].Add(new int[] { 2, 1 }); //1-34 block 3
            blocks[1][34].Add(new int[] { 3, 1 }); //1-34 block 4
            blocks[1][34].Add(new int[] { 1, 2 }); //1-34 block 5
            blocks[1][34].Add(new int[] { 3, 2 }); //1-34 block 6
            blocks[1][34].Add(new int[] { 2, 6 }); //1-34 block 7

            blocks[1][35].Add(new int[] { 1, 1 }); //1-35 block 1
            blocks[1][35].Add(new int[] { 1, 2 }); //1-35 block 2
            blocks[1][35].Add(new int[] { 5, 3 }); //1-35 block 3
            blocks[1][35].Add(new int[] { 2, 5 }); //1-35 block 4
            blocks[1][35].Add(new int[] { 4, 5 }); //1-35 block 5
            blocks[1][35].Add(new int[] { 5, 6 }); //1-35 block 6
            blocks[1][35].Add(new int[] { 3, 7 }); //1-35 block 7
            #endregion
            #region World-2 blocks

            blocks[0].Add(new List<int[]>()); // Level 0-0;
            blocks[2].Add(new List<int[]>()); // Level 2-0;
            blocks[2].Add(new List<int[]>()); // Level 2-1;
            blocks[2].Add(new List<int[]>()); // Level 2-2;
            blocks[2].Add(new List<int[]>()); // Level 2-3;
            blocks[2].Add(new List<int[]>()); // Level 2-4;
            blocks[2].Add(new List<int[]>()); // Level 2-5;
            blocks[2].Add(new List<int[]>()); // Level 2-6;
            blocks[2].Add(new List<int[]>()); // Level 2-7;
            blocks[2].Add(new List<int[]>()); // Level 2-8;
            blocks[2].Add(new List<int[]>()); // Level 2-9;
            blocks[2].Add(new List<int[]>()); // Level 2-10;
            blocks[2].Add(new List<int[]>()); // Level 2-11;
            blocks[2].Add(new List<int[]>()); // Level 2-12;
            blocks[2].Add(new List<int[]>()); // Level 2-13;
            blocks[2].Add(new List<int[]>()); // Level 2-14;
            blocks[2].Add(new List<int[]>()); // Level 2-15;
            blocks[2].Add(new List<int[]>()); // Level 2-16;
            blocks[2].Add(new List<int[]>()); // Level 2-17;
            blocks[2].Add(new List<int[]>()); // Level 2-18;
            blocks[2].Add(new List<int[]>()); // Level 2-19;
            blocks[2].Add(new List<int[]>()); // Level 2-20;
            blocks[2].Add(new List<int[]>()); // Level 2-21;
            blocks[2].Add(new List<int[]>()); // Level 2-22;
            blocks[2].Add(new List<int[]>()); // Level 2-23;
            blocks[2].Add(new List<int[]>()); // Level 2-24;
            blocks[2].Add(new List<int[]>()); // Level 2-25;
            blocks[2].Add(new List<int[]>()); // Level 2-26;
            blocks[2].Add(new List<int[]>()); // Level 2-27;
            blocks[2].Add(new List<int[]>()); // Level 2-28;
            blocks[2].Add(new List<int[]>()); // Level 2-29;
            blocks[2].Add(new List<int[]>()); // Level 2-30;
            blocks[2].Add(new List<int[]>()); // Level 2-31;
            blocks[2].Add(new List<int[]>()); // Level 2-32;
            blocks[2].Add(new List<int[]>()); // Level 2-33;
            blocks[2].Add(new List<int[]>()); // Level 2-34;
            blocks[2].Add(new List<int[]>()); // Level 2-35;

            blocks[2][1].Add(new int[] { 0, 0 }); //2-1 block 1 
            blocks[2][1].Add(new int[] { 2, 0 }); //2-2 block 2 
            blocks[2][1].Add(new int[] { 4, 3 }); //2-3 block 3 
            blocks[2][1].Add(new int[] { 0, 4 }); //2-4 block 4 
            blocks[2][1].Add(new int[] { 2, 5 }); //2-5 block 5 
            blocks[2][1].Add(new int[] { 3, 6 }); //2-6 block 6 

            blocks[2][2].Add(new int[] { 0, 0 }); //2-2 block 0 
            blocks[2][2].Add(new int[] { 3, 0 }); //2-2 block 1
            blocks[2][2].Add(new int[] { 0, 3 }); //2-2 block 2 
            blocks[2][2].Add(new int[] { 5, 3 }); //2-2 block 3 
            blocks[2][2].Add(new int[] { 1, 4 }); //2-2 block 4
            blocks[2][2].Add(new int[] { 5, 5 }); //2-2 block 5

            blocks[2][3].Add(new int[] { 4, 0 }); //1-3 block 1
            blocks[2][3].Add(new int[] { 2, 1 }); //1-3 block 2 
            blocks[2][3].Add(new int[] { 0, 2 }); //1-3 block 3 
            blocks[2][3].Add(new int[] { 5, 3 }); //1-3 block 4 
            blocks[2][3].Add(new int[] { 4, 5 }); //1-3 block 5 
            blocks[2][3].Add(new int[] { 3, 6 }); //1-3 block 6

            blocks[2][4].Add(new int[] { 4, 0 }); //1-4 block 1 
            blocks[2][4].Add(new int[] { 5, 0 }); //1-4 block 2 
            blocks[2][4].Add(new int[] { 1, 1 }); //1-4 block 3 
            blocks[2][4].Add(new int[] { 1, 2 }); //1-4 block 4 
            blocks[2][4].Add(new int[] { 0, 3 }); //1-4 block 5 
            blocks[2][4].Add(new int[] { 4, 3 }); //1-4 block 6 
            blocks[2][4].Add(new int[] { 2, 6 }); //1-4 block 7 

            blocks[2][5].Add(new int[] { 0, 0 }); //1-5 block 1 
            blocks[2][5].Add(new int[] { 2, 0 }); //1-5 block 2 
            blocks[2][5].Add(new int[] { 2, 1 }); //1-5 block 3 
            blocks[2][5].Add(new int[] { 3, 2 }); //1-5 block 4 
            blocks[2][5].Add(new int[] { 2, 4 }); //1-5 block 5 
            blocks[2][5].Add(new int[] { 4, 4 }); //1-5 block 6 
            blocks[2][5].Add(new int[] { 0, 7 }); //1-5 block 7 

            blocks[2][6].Add(new int[] { 4, 0 }); //1-6 block 1
            blocks[2][6].Add(new int[] { 1, 1 }); //1-6 block 2
            blocks[2][6].Add(new int[] { 4, 1 }); //1-6 block 3
            blocks[2][6].Add(new int[] { 1, 5 }); //1-6 block 4
            blocks[2][6].Add(new int[] { 2, 5 }); //1-6 block 5
            blocks[2][6].Add(new int[] { 3, 6 }); //1-6 block 6
            blocks[2][6].Add(new int[] { 5, 7 }); //1-6 block 7

            blocks[2][7].Add(new int[] { 0, 0 }); //1-7 block 1
            blocks[2][7].Add(new int[] { 3, 2 }); //1-7 block 2
            blocks[2][7].Add(new int[] { 2, 3 }); //1-7 block 3
            blocks[2][7].Add(new int[] { 3, 3 }); //1-7 block 4
            blocks[2][7].Add(new int[] { 5, 4 }); //1-7 block 5
            blocks[2][7].Add(new int[] { 2, 6 }); //1-7 block 6
            blocks[2][7].Add(new int[] { 3, 7 }); //1-7 block 7

            blocks[2][8].Add(new int[] { 4, 0 }); //1-8 block 1
            blocks[2][8].Add(new int[] { 2, 1 }); //1-8 block 2
            blocks[2][8].Add(new int[] { 2, 2 }); //1-8 block 3
            blocks[2][8].Add(new int[] { 2, 3 }); //1-8 block 4
            blocks[2][8].Add(new int[] { 4, 3 }); //1-8 block 5
            blocks[2][8].Add(new int[] { 4, 6 }); //1-8 block 6
            blocks[2][8].Add(new int[] { 3, 7 }); //1-8 block 7

            blocks[2][9].Add(new int[] { 5, 0 }); //1-9 block 1
            blocks[2][9].Add(new int[] { 4, 2 }); //1-9 block 2
            blocks[2][9].Add(new int[] { 5, 2 }); //1-9 block 3
            blocks[2][9].Add(new int[] { 0, 3 }); //1-9 block 4
            blocks[2][9].Add(new int[] { 3, 5 }); //1-9 block 5
            blocks[2][9].Add(new int[] { 2, 7 }); //1-9 block 6
            blocks[2][9].Add(new int[] { 3, 7 }); //1-9 block 7

            blocks[2][10].Add(new int[] { 0, 0 }); //1-10 block 1
            blocks[2][10].Add(new int[] { 3, 0 }); //1-10 block 2
            blocks[2][10].Add(new int[] { 3, 1 }); //1-10 block 3
            blocks[2][10].Add(new int[] { 2, 3 }); //1-10 block 4
            blocks[2][10].Add(new int[] { 4, 4 }); //1-10 block 5
            blocks[2][10].Add(new int[] { 5, 5 }); //1-10 block 6
            blocks[2][10].Add(new int[] { 0, 7 }); //1-10 block 7

            blocks[2][11].Add(new int[] { 4, 0 }); //1-11 block 1
            blocks[2][11].Add(new int[] { 5, 0 }); //1-11 block 2
            blocks[2][11].Add(new int[] { 0, 3 }); //1-11 block 3
            blocks[2][11].Add(new int[] { 5, 3 }); //1-11 block 4
            blocks[2][11].Add(new int[] { 3, 4 }); //1-11 block 5
            blocks[2][11].Add(new int[] { 3, 7 }); //1-11 block 6
            blocks[2][11].Add(new int[] { 5, 7 }); //1-11 block 7

            blocks[2][12].Add(new int[] { 1, 1 }); //1-12 block 1
            blocks[2][12].Add(new int[] { 4, 1 }); //1-12 block 2
            blocks[2][12].Add(new int[] { 3, 2 }); //1-12 block 3
            blocks[2][12].Add(new int[] { 1, 5 }); //1-12 block 4
            blocks[2][12].Add(new int[] { 4, 5 }); //1-12 block 5
            blocks[2][12].Add(new int[] { 5, 5 }); //1-12 block 6
            blocks[2][12].Add(new int[] { 4, 7 }); //1-12 block 7

            blocks[2][13].Add(new int[] { 0, 0 }); //1-13 block 1
            blocks[2][13].Add(new int[] { 1, 0 }); //1-13 block 2
            blocks[2][13].Add(new int[] { 3, 0 }); //1-13 block 3
            blocks[2][13].Add(new int[] { 0, 3 }); //1-13 block 4
            blocks[2][13].Add(new int[] { 0, 5 }); //1-13 block 5
            blocks[2][13].Add(new int[] { 1, 5 }); //1-13 block 6
            blocks[2][13].Add(new int[] { 5, 7 }); //1-13 block 7

            blocks[2][14].Add(new int[] { 0, 1 }); //1-14 block 1
            blocks[2][14].Add(new int[] { 4, 2 }); //1-14 block 2
            blocks[2][14].Add(new int[] { 5, 2 }); //1-14 block 3
            blocks[2][14].Add(new int[] { 0, 3 }); //1-14 block 4
            blocks[2][14].Add(new int[] { 4, 4 }); //1-14 block 5
            blocks[2][14].Add(new int[] { 2, 5 }); //1-14 block 6
            blocks[2][14].Add(new int[] { 3, 5 }); //1-14 block 7

            blocks[2][15].Add(new int[] { 0, 1 }); //1-15 block 1
            blocks[2][15].Add(new int[] { 0, 2 }); //1-15 block 2
            blocks[2][15].Add(new int[] { 3, 2 }); //1-15 block 3
            blocks[2][15].Add(new int[] { 2, 3 }); //1-15 block 4
            blocks[2][15].Add(new int[] { 4, 4 }); //1-15 block 5
            blocks[2][15].Add(new int[] { 0, 7 }); //1-15 block 6
            blocks[2][15].Add(new int[] { 3, 7 }); //1-15 block 7

            blocks[2][16].Add(new int[] { 2, 0 }); //1-16 block 1
            blocks[2][16].Add(new int[] { 1, 1 }); //1-16 block 2
            blocks[2][16].Add(new int[] { 4, 3 }); //1-16 block 3
            blocks[2][16].Add(new int[] { 5, 3 }); //1-16 block 4
            blocks[2][16].Add(new int[] { 0, 5 }); //1-16 block 5
            blocks[2][16].Add(new int[] { 2, 5 }); //1-16 block 6
            blocks[2][16].Add(new int[] { 3, 5 }); //1-16 block 7

            blocks[2][17].Add(new int[] { 4, 0 }); //1-17 block 1
            blocks[2][17].Add(new int[] { 2, 1 }); //1-17 block 2
            blocks[2][17].Add(new int[] { 1, 3 }); //1-17 block 3
            blocks[2][17].Add(new int[] { 5, 3 }); //1-17 block 4
            blocks[2][17].Add(new int[] { 0, 5 }); //1-17 block 5
            blocks[2][17].Add(new int[] { 4, 5 }); //1-17 block 6
            blocks[2][17].Add(new int[] { 2, 6 }); //1-17 block 7

            //blocks[2][18].Add(new int[] { 1, 0 }); //1-18 block 1
            //blocks[2][18].Add(new int[] { 2, 2 }); //1-18 block 2
            //blocks[2][18].Add(new int[] { 5, 2 }); //1-18 block 3
            //blocks[2][18].Add(new int[] { 1, 3 }); //1-18 block 4
            //blocks[2][18].Add(new int[] { 1, 4 }); //1-18 block 5
            //blocks[2][18].Add(new int[] { 1, 5 }); //1-18 block 6
            //blocks[2][18].Add(new int[] { 4, 5 }); //1-18 block 7

            //blocks[2][19].Add(new int[] { 2, 0 }); //1-19 block 1
            //blocks[2][19].Add(new int[] { 2, 2 }); //1-19 block 2
            //blocks[2][19].Add(new int[] { 5, 2 }); //1-19 block 3
            //blocks[2][19].Add(new int[] { 0, 5 }); //1-19 block 4
            //blocks[2][19].Add(new int[] { 2, 5 }); //1-19 block 5
            //blocks[2][19].Add(new int[] { 1, 6 }); //1-19 block 6
            //blocks[2][19].Add(new int[] { 5, 7 }); //1-19 block 7

            //blocks[2][20].Add(new int[] { 0, 1 }); //1-20 block 1
            //blocks[2][20].Add(new int[] { 2, 2 }); //1-20 block 2
            //blocks[2][20].Add(new int[] { 5, 2 }); //1-20 block 3
            //blocks[2][20].Add(new int[] { 1, 3 }); //1-20 block 4
            //blocks[2][20].Add(new int[] { 1, 4 }); //1-20 block 5
            //blocks[2][20].Add(new int[] { 2, 5 }); //1-20 block 6
            //blocks[2][20].Add(new int[] { 3, 5 }); //1-20 block 7

            //blocks[2][21].Add(new int[] { 1, 2 }); //1-21 block 1
            //blocks[2][21].Add(new int[] { 0, 3 }); //1-21 block 2
            //blocks[2][21].Add(new int[] { 5, 3 }); //1-21 block 3
            //blocks[2][21].Add(new int[] { 0, 4 }); //1-21 block 4
            //blocks[2][21].Add(new int[] { 3, 4 }); //1-21 block 5
            //blocks[2][21].Add(new int[] { 2, 7 }); //1-21 block 6
            //blocks[2][21].Add(new int[] { 3, 7 }); //1-21 block 7

            //blocks[2][22].Add(new int[] { 2, 0 }); //1-22 block 1
            //blocks[2][22].Add(new int[] { 4, 1 }); //1-22 block 2
            //blocks[2][22].Add(new int[] { 5, 1 }); //1-22 block 3
            //blocks[2][22].Add(new int[] { 2, 2 }); //1-22 block 4
            //blocks[2][22].Add(new int[] { 5, 4 }); //1-22 block 5
            //blocks[2][22].Add(new int[] { 5, 5 }); //1-22 block 6
            //blocks[2][22].Add(new int[] { 1, 6 }); //1-22 block 7
            
            //blocks[2][23].Add(new int[] { 0, 0 }); //1-23 block 1
            //blocks[2][23].Add(new int[] { 2, 0 }); //1-23 block 2
            //blocks[2][23].Add(new int[] { 0, 3 }); //1-23 block 3
            //blocks[2][23].Add(new int[] { 2, 3 }); //1-23 block 4
            //blocks[2][23].Add(new int[] { 0, 6 }); //1-23 block 5
            //blocks[2][23].Add(new int[] { 0, 7 }); //1-23 block 6
            //blocks[2][23].Add(new int[] { 5, 7 }); //1-23 block 7

            //blocks[2][24].Add(new int[] { 4, 0 }); //1-24 block 1
            //blocks[2][24].Add(new int[] { 0, 2 }); //1-24 block 2
            //blocks[2][24].Add(new int[] { 0, 3 }); //1-24 block 3
            //blocks[2][24].Add(new int[] { 3, 3 }); //1-24 block 4
            //blocks[2][24].Add(new int[] { 4, 5 }); //1-24 block 5
            //blocks[2][24].Add(new int[] { 1, 6 }); //1-24 block 6
            //blocks[2][24].Add(new int[] { 3, 7 }); //1-24 block 7

            //blocks[2][25].Add(new int[] { 1, 0 }); //1-25 block 1
            //blocks[2][25].Add(new int[] { 4, 2 }); //1-25 block 2
            //blocks[2][25].Add(new int[] { 5, 2 }); //1-25 block 3
            //blocks[2][25].Add(new int[] { 2, 3 }); //1-25 block 4
            //blocks[2][25].Add(new int[] { 5, 3 }); //1-25 block 5
            //blocks[2][25].Add(new int[] { 4, 5 }); //1-25 block 6
            //blocks[2][25].Add(new int[] { 5, 7 }); //1-25 block 7

            //blocks[2][26].Add(new int[] { 0, 2 }); //1-26 block 1
            //blocks[2][26].Add(new int[] { 3, 2 }); //1-26 block 2
            //blocks[2][26].Add(new int[] { 2, 3 }); //1-26 block 3
            //blocks[2][26].Add(new int[] { 1, 5 }); //1-26 block 4
            //blocks[2][26].Add(new int[] { 3, 5 }); //1-26 block 5
            //blocks[2][26].Add(new int[] { 1, 6 }); //1-26 block 6
            //blocks[2][26].Add(new int[] { 2, 6 }); //1-26 block 7

            //blocks[2][27].Add(new int[] { 2, 0 }); //1-27 block 1
            //blocks[2][27].Add(new int[] { 3, 0 }); //1-27 block 2
            //blocks[2][27].Add(new int[] { 3, 2 }); //1-27 block 3
            //blocks[2][27].Add(new int[] { 0, 3 }); //1-27 block 4
            //blocks[2][27].Add(new int[] { 1, 3 }); //1-27 block 5
            //blocks[2][27].Add(new int[] { 1, 4 }); //1-27 block 6
            //blocks[2][27].Add(new int[] { 3, 7 }); //1-27 block 7

            //blocks[2][28].Add(new int[] { 1, 0 }); //1-28 block 1
            //blocks[2][28].Add(new int[] { 5, 0 }); //1-28 block 2
            //blocks[2][28].Add(new int[] { 2, 2 }); //1-28 block 3
            //blocks[2][28].Add(new int[] { 3, 3 }); //1-28 block 4
            //blocks[2][28].Add(new int[] { 0, 5 }); //1-28 block 5
            //blocks[2][28].Add(new int[] { 3, 5 }); //1-28 block 6
            //blocks[2][28].Add(new int[] { 3, 6 }); //1-28 block 7

            //blocks[2][29].Add(new int[] { 2, 0 }); //1-29 block 1
            //blocks[2][29].Add(new int[] { 2, 2 }); //1-29 block 2
            //blocks[2][29].Add(new int[] { 5, 2 }); //1-29 block 3
            //blocks[2][29].Add(new int[] { 4, 3 }); //1-29 block 4
            //blocks[2][29].Add(new int[] { 4, 4 }); //1-29 block 5
            //blocks[2][29].Add(new int[] { 3, 6 }); //1-29 block 6
            //blocks[2][29].Add(new int[] { 0, 7 }); //1-29 block 7

            //blocks[2][30].Add(new int[] { 4, 0 }); //1-30 block 1
            //blocks[2][30].Add(new int[] { 2, 2 }); //1-30 block 2
            //blocks[2][30].Add(new int[] { 3, 2 }); //1-30 block 3
            //blocks[2][30].Add(new int[] { 5, 2 }); //1-30 block 4
            //blocks[2][30].Add(new int[] { 4, 4 }); //1-30 block 5
            //blocks[2][30].Add(new int[] { 1, 5 }); //1-30 block 6
            //blocks[2][30].Add(new int[] { 2, 7 }); //1-30 block 7

            //blocks[2][31].Add(new int[] { 4, 1 }); //1-31 block 1
            //blocks[2][31].Add(new int[] { 0, 3 }); //1-31 block 2
            //blocks[2][31].Add(new int[] { 5, 3 }); //1-31 block 3
            //blocks[2][31].Add(new int[] { 2, 4 }); //1-31 block 4
            //blocks[2][31].Add(new int[] { 4, 4 }); //1-31 block 5
            //blocks[2][31].Add(new int[] { 2, 7 }); //1-31 block 6
            //blocks[2][31].Add(new int[] { 3, 7 }); //1-31 block 7

            //blocks[2][32].Add(new int[] { 2, 0 }); //1-32 block 1
            //blocks[2][32].Add(new int[] { 0, 1 }); //1-32 block 2
            //blocks[2][32].Add(new int[] { 2, 1 }); //1-32 block 3
            //blocks[2][32].Add(new int[] { 5, 2 }); //1-32 block 4
            //blocks[2][32].Add(new int[] { 4, 3 }); //1-32 block 5
            //blocks[2][32].Add(new int[] { 5, 3 }); //1-32 block 6
            //blocks[2][32].Add(new int[] { 3, 7 }); //1-32 block 7

            //blocks[2][33].Add(new int[] { 0, 0 }); //1-33 block 1
            //blocks[2][33].Add(new int[] { 5, 0 }); //1-33 block 2
            //blocks[2][33].Add(new int[] { 5, 4 }); //1-33 block 3
            //blocks[2][33].Add(new int[] { 1, 5 }); //1-33 block 4
            //blocks[2][33].Add(new int[] { 5, 5 }); //1-33 block 5
            //blocks[2][33].Add(new int[] { 3, 6 }); //1-33 block 6
            //blocks[2][33].Add(new int[] { 4, 7 }); //1-33 block 7

            //blocks[2][34].Add(new int[] { 5, 0 }); //1-34 block 1
            //blocks[2][34].Add(new int[] { 1, 1 }); //1-34 block 2
            //blocks[2][34].Add(new int[] { 2, 1 }); //1-34 block 3
            //blocks[2][34].Add(new int[] { 3, 1 }); //1-34 block 4
            //blocks[2][34].Add(new int[] { 1, 2 }); //1-34 block 5
            //blocks[2][34].Add(new int[] { 3, 2 }); //1-34 block 6
            //blocks[2][34].Add(new int[] { 2, 6 }); //1-34 block 7

            //blocks[2][35].Add(new int[] { 1, 1 }); //1-35 block 1
            //blocks[2][35].Add(new int[] { 1, 2 }); //1-35 block 2
            //blocks[2][35].Add(new int[] { 5, 3 }); //1-35 block 3
            //blocks[2][35].Add(new int[] { 2, 5 }); //1-35 block 4
            //blocks[2][35].Add(new int[] { 4, 5 }); //1-35 block 5
            //blocks[2][35].Add(new int[] { 5, 6 }); //1-35 block 6
            //blocks[2][35].Add(new int[] { 3, 7 }); //1-35 block 7
            #endregion
        }
    }
}