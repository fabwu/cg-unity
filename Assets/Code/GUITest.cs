using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour
{

    public static int grassblocks = 0;
    public static int stoneblocks = 0;
    public static int woodblocks = 0;


    //0 grass 1 stone 2 wood
    public static int currentSelection = 0;

    private float mouseWheelScrolled;

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 120, 90), "Items");

        setColor(0);
        GUI.Label(new Rect(25, 35, 100, 20), "GrassBlocks: " + grassblocks);

        setColor(1);
        GUI.Label(new Rect(25, 55, 100, 20), "StoneBlocks: " + stoneblocks);

        setColor(2);
        GUI.Label(new Rect(25, 75, 100, 20), "WoodBlocks: " + woodblocks);

        mouseWheelScrolled += Input.GetAxis("Mouse ScrollWheel");
        checkMouseWheelScrolledEnough();
    }

    private void setColor(int id)
    {
        GUI.contentColor = Color.white;
        if(currentSelection == id)
        {
            GUI.contentColor = Color.red;
        }
    }

    private void checkMouseWheelScrolledEnough()
    {
        if (mouseWheelScrolled > 0.1)
        {
            currentSelection--;
            mouseWheelScrolled = 0;
        }
        if (mouseWheelScrolled < -0.1)
        {
            currentSelection++;
            mouseWheelScrolled = 0;
        }
        if (currentSelection > 2)
        {
            currentSelection = 0;
        }
        if (currentSelection < 0)
        {
            currentSelection = 2;
        }
    }


}