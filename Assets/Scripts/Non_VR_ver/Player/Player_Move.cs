using UnityEngine;
using System.Collections;

public class Player_Move : objectBase
{
    public float forwardSpeed = 4.0f;
    public float backwardSpeed = 4.0f;

    //PlayerAnimation m_pPlayerAni;

    Vector3 velocity;

    private Door m_Door = null;
    public GameObject m_goFlash;

    private float m_fFlashLightCapacity = 40.0f;

    // Use this for initialization
    protected override void  OnStart()
    {
        //  Cursor.visible = false;
        // Physics.IgnoreLayerCollision(LayerMask.NameToLayer("PlayerNotCol"),
        //                                 LayerMask.NameToLayer("Player"), true);
        base.OnStart();
        //m_pPlayerAni = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        base.OnUpdate();
        float h = Input.GetAxis( "Horizontal" );
        float v = Input.GetAxis( "Vertical" );

        velocity = new Vector3( h, 0.0f, v );

        velocity = transform.TransformDirection( velocity );

        velocity *= forwardSpeed;

        if ( v == 0 && h == 0 )
        {
            //   GetComponent<Rigidbody>().isKinematic = true;
            //m_pPlayerAni.PlayAnimation( PlayerAnimation.PlayerState.IDLE );
        }
        else
        {
            //	GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = new Vector3( velocity.x, GetComponent<Rigidbody>().velocity.y, velocity.z );
            //m_pPlayerAni.PlayAnimation( PlayerAnimation.PlayerState.RUN );
        }

        Control();

        if ( m_goFlash.activeInHierarchy && m_fFlashLightCapacity >= 0 )
        {
            m_fFlashLightCapacity -= Time.deltaTime;
        }

    }

    private void Control()
    {
        if ( Input.GetKeyDown( KeyCode.E ) && m_Door != null )
        {
            m_Door.isOpen = !m_Door.isOpen;
        }

        if ( Input.GetKeyDown( KeyCode.F ) && m_fFlashLightCapacity > 0 )
        {
            m_goFlash.SetActive( !m_goFlash.activeInHierarchy );
        }
    }

    protected override void OnObjectCollisionEnter( Collision pCollision )
    {
        base.OnObjectCollisionEnter( pCollision );
    }

    protected override void OnObjectCollisionExit( Collision pCollision )
    {
        base.OnObjectCollisionExit( pCollision );
        
    }

    protected override void OnObjectTriggerEnter( Collider pCollider )
    {
        base.OnObjectTriggerEnter( pCollider );

        if ( pCollider.transform.parent.tag == "Opendoor" )
        {
            m_Door = pCollider.transform.parent.GetComponent<Door>();
        }
    }

    protected override void OnObjectTriggerExit( Collider pCollider )
    {
        base.OnObjectTriggerExit( pCollider );
        if ( pCollider.transform.parent.tag == "Opendoor" )
        {
            m_Door = null;
        }
    }
}
