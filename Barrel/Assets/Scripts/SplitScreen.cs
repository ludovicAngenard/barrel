using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NamespaceSplitScreen{
    public class SplitScreen : MonoBehaviour
    {
        [SerializeField] Camera cam1, cam2;
        public int camCounter = 0;

        // Start is called before the first frame update
        void Start()
        {
            SetSplitScreen();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetSplitScreen()
        {

                cam1.rect = new Rect(0f, .5f, 1f, .5f);
                cam2.rect = new Rect(0f, 0f, 1f, .5f);
        }
    }
}