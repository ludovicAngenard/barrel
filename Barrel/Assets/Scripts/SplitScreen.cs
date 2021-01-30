using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public Camera cam1, cam2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         SetSplitScreen();
    }

    public void SetSplitScreen()
    {
        
            cam1.rect = new Rect(0f, .5f, 1f, .5f);
            cam2.rect = new Rect(0f, 0f, 1f, .5f);
   }
}
