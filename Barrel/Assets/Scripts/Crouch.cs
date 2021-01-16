using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{

    public GameObject player;

    private CharacterController m_CharacterController;

    private bool m_Crouch = false;

    public KeyCode crouchKey = KeyCode.LeftControl;

    private float m_OriginalHeight;

    [SerializeField] private float m_CrouchHeight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = player.GetComponent<CharacterController>();
        m_OriginalHeight = m_CharacterController.height;
    }

    // Update is called once per frame
    void Update()
    {

        if(player.name == "FPSController")
        {

            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                m_Crouch = !m_Crouch;

                CheckCrouch();
            }

    
            if(Input.GetKeyUp(KeyCode.LeftControl))
            {
                m_Crouch = !m_Crouch;

                CheckCrouch();
            }
        }

        if(player.name == "FPSController (1)")
        {

            if(Input.GetKeyDown(KeyCode.RightControl))
            {
                m_Crouch = !m_Crouch;

                CheckCrouch();
            }

    
            if(Input.GetKeyUp(KeyCode.RightControl))
            {
                m_Crouch = !m_Crouch;

                CheckCrouch();
            }
        }
    }

    void CheckCrouch()
    {
        if(m_Crouch == true)
        {
            m_CharacterController.height = m_CrouchHeight;
        }
        else
        {
            m_CharacterController.height = m_OriginalHeight;
        }
    }


}
