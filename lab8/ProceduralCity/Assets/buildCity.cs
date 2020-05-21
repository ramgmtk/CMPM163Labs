using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject xstreets;
    public GameObject zstreets;
    public GameObject crossroad;
    public int mapWidth = 20;
    public int mapHeight =  20;
    int buildingFootprint = 3;
    int[,] mapgrid; 
   // Start is called before the first frame update
    void Start()
    {
	float seed = Random.Range(0, 100);
	mapgrid = new int[mapWidth,mapHeight];
        for (int h = 0; h < mapHeight; h++)
	{
	    for(int w = 0; w < mapWidth; w++)
	    {
		mapgrid[w,h] = (int) (Mathf.PerlinNoise(w/10.0f + seed, h/10.0f + seed) * 10);
	    }
	}

        int x = 0;
	for (int n = 0; n < 50; n++)
	{
	    for (int h = 0; h < mapHeight; h++)
	    {
		mapgrid[x,h] = -1;
	    }
	    x += Random.Range(2,10);
	    if (x >= mapWidth) break;
	}

	int z = 0;
	for(int n = 0; n < 10; n++)
	{
	    for (int w = 0; w < mapWidth; w++)
	    {
		if(mapgrid[w,z] == -1)
		    mapgrid[w,z] = -3;
		else
		    mapgrid[w,z] = -2;
	    }
	    z += Random.Range(2, 20);
	    if(z >= mapHeight) break;
	}

	for (int h = 0; h < mapHeight; h++) 
	{
	   for (int w = 0; w < mapHeight; w++)
	    {
		int result = mapgrid[w,h];
		Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);
		/*if (result < -2)
		   //Instantiate(crossroad, pos, crossroad.transform.rotation);
		else if (result < -1)
		   //Instantiate(xstreets, pos, xstreets.transform.rotation);
		else if (result < 0)
		   //Instantiate(zstreets, pos, zstreets.transform.rotation);*/
		if (result < 4)
		   Debug.Log(w);
		else if (result < 7)
		   Instantiate(buildings[2], pos, Quaternion.identity);
		else if (result < 10)
		   Instantiate(buildings[3], pos, Quaternion.identity);
	    }
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
