using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class Player : objectBase
{
    

    private Door m_Door;
    private float m_fFlashLightCapacity = 40.0f;
    
    
    
    public GameObject m_goFlash;


    public Door DoorProperty
    {
        set { m_Door = value; }
    }

    protected override void OnAwake()
    {
        base.OnAwake();

        m_Door = null;
        m_goFlash = null;

    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    public void Control()
    {
        if ( ( Input.GetKeyDown( KeyCode.E ) ||
            OVRGamepadController.GPC_GetButtonDown( OVRGamepadController.Button.B ) ) &&
            m_Door != null )
        {
            m_Door.isOpen = !m_Door.isOpen;
            //m_Door = null;
        }

        if ( ( Input.GetKeyDown( KeyCode.F ) ||
            OVRGamepadController.GPC_GetButtonDown( OVRGamepadController.Button.Y ) )
            && m_fFlashLightCapacity > 0 )
        {
            m_goFlash.SetActive( !m_goFlash.activeInHierarchy );
        }
    }

}
