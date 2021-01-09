using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{

    private CharacterController m_CharacterController;

    private bool m_Crouch = false;

    public KeyCode crouchKey = Keycode.C;

    private float m_OriginalHeight;

[SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_originalHeight = m_CharacterController.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                print("Crouch");
            }
    }

    void Crouch()
    {
        playerCol.height = reducedHeight;
    }

    void GoUp()
    {
        playerCol.height = originalHeight;
    }
}
