using UnityEngine;
using System.Collections;

public class ClickOnFaceScript : MonoBehaviour
{

    public Vector3 delta;

    private Transform voxelObject;
    private Transform player;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    // This function is triggered when the mouse cursor is over the GameObject on which this script runs
    void OnMouseOver()
    {
        // If the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //Distanz zum Objekt
            player = GameObject.FindGameObjectWithTag("Player").transform;
            voxelObject = this.transform;
            float distance = Vector3.Distance(voxelObject.position, player.position);

            if (distance < 5)
            {
                Destroy(this.transform.parent.gameObject);
                increaseCounter(this.transform.parent.gameObject.name);
            }
            else
            {
                Debug.Log("Objekt zu weit weg");
            }
        }

        // If the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            GameObject objectToPlace = null;
            int currenctSelected = GUITest.currentSelection;
            switch (currenctSelected)
            {
                case 0:
                    if(GUITest.grassblocks>0)
                        objectToPlace = GameObject.FindGameObjectsWithTag("Voxel_Grass")[0];
                    break;
                case 1:
                    if (GUITest.stoneblocks > 0)
                        objectToPlace = GameObject.FindGameObjectsWithTag("Voxel_Stone")[0];
                    break;
                case 2:
                    if (GUITest.woodblocks > 0)
                        objectToPlace = GameObject.FindGameObjectsWithTag("Voxel_Wood")[0];
                    break;
            }

            if (objectToPlace != null) { 
                // Call method from WorldGenerator class
                WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, // N = C + delta
                                             objectToPlace); // The parent GameObject
                increaseCounter(objectToPlace.name, -1);
            }
        }
    }

    private void increaseCounter(string gameObjectName)
    {
        increaseCounter(gameObjectName, 1);
    }

    private void increaseCounter(string gameObjectName, int increaseBy)
    {
        if(WordIsInText("Wood", gameObjectName))
        {
            GUITest.woodblocks += increaseBy;
        }
        if (WordIsInText("Stone", gameObjectName))
        {
            GUITest.stoneblocks += increaseBy;
        }
        if (WordIsInText("Grass", gameObjectName))
        {
            GUITest.grassblocks += increaseBy;
        }
    }

    private bool WordIsInText(string word, string text)
    {
        return text.IndexOf(word) > 0;
    }
}