﻿using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour
{
    // Public fields are visible and their values can be changed dirrectly in the editor

    // Drag and drop here the Voxel from the Scene
    // Used to create new instances
    public GameObject Voxel_Grass;
    public GameObject Voxel_Stone;
    public GameObject Voxel_Tree;

    //Specify the dimensions of the world
    public float SizeX;
    public float SizeZ;
    public float SizeY;

    // Use this for initialization
    void Start()
    {
        // Start the world generation coroutine
        // StartCoroutine function always returns immediately, however you can yield the result. 
        StartCoroutine(SimpleGenerator());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject)
    {
        // Clone
        GameObject clone = (GameObject)Instantiate(originalGameobject, newPosition, Quaternion.identity);
        // Place
        clone.transform.position = newPosition;
        // Rename
        //clone.name = "Cube@" + clone.transform.position;
    }

    /* from docs.unity.com
		 * The execution of a coroutine can be paused at any point using the yield statement. 
		 * The yield return value specifies when the coroutine is resumed. 
		 * Coroutines are excellent when modelling behaviour over several frames. 
		 * Coroutines have virtually no performance overhead. 
		 * StartCoroutine function always returns immediately, however you can yield the result. 
		 * This will wait until the coroutine has finished execution.
		*/
    IEnumerator SimpleGenerator()
    {
        // In this Coroutine we will instantiate 50 voxels per frame
        uint numberOfInstances = 0;
        uint instancesPerFrame = 50;

        for (int x = 1; x <= SizeX; x++)
        {
            for (int z = 1; z <= SizeZ; z++)
            {
                // Compute a random height
                //Höhere Nummern leicht priorisieren damit weniger löcher
                float height1 = Random.Range(0, SizeY);
                float height2 = Random.Range(0, SizeY);
                float height = (height1 > height2) ? height1 : height2;
                for (int y = 0; y <= height; y++)
                {
                    // Compute the position for every voxel
                    Vector3 newPosition = new Vector3(x, y, z);
                    // Call the method giving the new position and a Voxel instance as parameters
                    float random = Random.Range(0.0f, 2.0f);
                    if (random <= 1.5f)
                    {
                        CloneAndPlace(newPosition, Voxel_Grass);
                    }
                    else if(random > 1.5f && random <=1.99)
                    {
                        CloneAndPlace(newPosition, Voxel_Stone);
                    }
                    else
                    {
                        CloneAndPlace(newPosition, Voxel_Tree);
                    }
                    
                    // Increment numberOfInstances
                    numberOfInstances++;

                    // If the number of instances per frame was met
                    if (numberOfInstances == instancesPerFrame)
                    {
                        // Reset numberOfInstances
                        numberOfInstances = 0;
                        // Wait for next frame
                        yield return new WaitForEndOfFrame();
                    }
                }

            }

        }
    }
}