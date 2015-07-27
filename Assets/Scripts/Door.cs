using UnityEngine;
using System.Collections;

public class Door : objectBase
{

    public bool m_isOpen = false;
    private bool FLAG = true;

    public bool isOpen
    {
        get { return m_isOpen; }
        set { m_isOpen = value; }
    }

    private Transform tfTarget;

    private float m_fRotateSpeed = 5f;

    protected override void OnAwake()
    {
        base.OnAwake();

        tfTarget = transform.FindChild( "DoorPivot" );

        if ( this.transform.rotation.y == 0 )
        {
            isOpen = true;
        }
        else if ( this.transform.rotation.y == 90 )
        {
            isOpen = false;
        }
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        DoorProcess();
        //Debug.Log( tfTarget.rotation.eulerAngles.y );
    }
    private void DoorProcess()
    {
        if ( m_isOpen )
        {
            tfTarget.forward = Vector3.Slerp( tfTarget.forward, Vector3.forward, m_fRotateSpeed * Time.deltaTime );
            
            //if ( tfTarget.localRotation.eulerAngles.y <= 270f && tfTarget.localRotation.eulerAngles.y > 0f )
            //{
            //    FLAG = false;
            //}
            //tfTarget.Rotate( Vector3.up * -m_fRotateSpeed * Time.deltaTime );
        }
        else if ( false == m_isOpen )
        {
            tfTarget.forward = Vector3.Slerp( tfTarget.forward, Vector3.right, m_fRotateSpeed * Time.deltaTime );
            //if ( tfTarget.localRotation.eulerAngles.y == 0 )
            //{
            //    FLAG = true;
            //}
            //tfTarget.Rotate( Vector3.up * m_fRotateSpeed * Time.deltaTime );
        }
    }
}
