using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class Player : objectBase
{
    

    private Door m_Door;
    private float m_fFlashLightCapacity = 40.0f;
    private OVRPlayerController m_vrController;
    
    
    public GameObject m_goFlash;

    public int ItemCount = 0;
    public bool canOpenDoor = false;

    private AudioClip OpenSound;
    private AudioClip CloseSound;

    private AudioSource m_AudioSource;

    public Door DoorProperty
    {
        set { m_Door = value; }
    }

    public void AddCount()
    {
        ItemCount++;
    }

    protected override void OnAwake()
    {
        base.OnAwake();

        m_Door = null;
        m_goFlash = null;

        m_vrController = GameObject.FindObjectOfType<OVRPlayerController>();

        OpenSound = ( AudioClip )Resources.Load( "Audio/z_OpenDoor", typeof( AudioClip ) );
        CloseSound = ( AudioClip )Resources.Load( "Audio/z_CloseDoor", typeof( AudioClip ) );

        this.gameObject.AddComponent<AudioSource>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    public void Control()
    {
        if ( ( Input.GetKeyDown( KeyCode.E ) ||
            OVRGamepadController.GPC_GetButtonDown( OVRGamepadController.Button.B ) ) &&
            m_Door != null && canOpenDoor )
        {
            m_Door.isOpen = !m_Door.isOpen;
            if ( m_Door.isOpen )
            {
                m_AudioSource.PlayOneShot( OpenSound );
            }
            else
            {
                m_AudioSource.PlayOneShot( CloseSound );
            }
            m_vrController.LockDoor = false;
            //m_Door = null;
        }
        else if ( canOpenDoor == false && Input.GetKeyDown( KeyCode.E ) )
        {
            m_vrController.LockDoor = true;
        }

        if ( ( Input.GetKeyDown( KeyCode.F ) ||
            OVRGamepadController.GPC_GetButtonDown( OVRGamepadController.Button.Y ) )
            && m_fFlashLightCapacity > 0 )
        {
            m_goFlash.SetActive( !m_goFlash.activeInHierarchy );
        }
    }

}
