using UnityEngine;
using System.Collections;

public class KeepMouse : MonoBehaviour {

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnGUI()
    {
        GUILayout.BeginVertical();
        // Release cursor on escape keypress
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }


        

        GUILayout.EndVertical();

    }
}