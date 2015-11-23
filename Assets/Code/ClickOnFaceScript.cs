using UnityEngine;
using System.Collections;

public class ClickOnFaceScript : MonoBehaviour
{

    public Vector3 delta;

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
            // Display a message in the Console tab
            Debug.Log("Left click!");
            // Destroy the parent of the face we clicked
            Destroy(this.transform.parent.gameObject);
        }

        // If the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Display a message in the Console tab
            Debug.Log("Right click!");

            // Call method from WorldGenerator class
            WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, // N = C + delta
                                         this.transform.parent.gameObject); // The parent GameObject 
        }
    }
}