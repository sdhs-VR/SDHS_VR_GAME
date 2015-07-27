using UnityEngine;
using System.Collections;

public class PlayerMove : objectBase // 모든 오브젝트들은 objectBase를 상속
{
    [SerializeField]
    private float m_fMoveSpeed;
    [SerializeField]
    private float m_fTurnSpeed;

    private GameObject m_goCamera = null;

	private Vector3 velocity;

    // 초기화에는 OnAwake, OnStart 사용
    protected override void OnAwake()
    {
        base.OnAwake();

        m_goCamera = Camera.main.gameObject;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        MoveProcess();
    }

    private void MoveProcess()
    {
        float fTransformZ = Input.GetAxis( "Vertical" ) * m_fMoveSpeed;
        float fTransformX = Input.GetAxis( "Horizontal" ) * m_fMoveSpeed;

        float fRotationX = Input.GetAxis( "Mouse X" ) * m_fTurnSpeed;
        float fRotationY = Input.GetAxis( "Mouse Y" ) * m_fTurnSpeed;

        fTransformZ *= Time.deltaTime;
        fTransformX *= Time.deltaTime;

        fRotationX *= Time.deltaTime;
        fRotationY *= Time.deltaTime;

        transform.Translate( fTransformX, 0, fTransformZ );
        
        transform.Rotate( 0, fRotationX, 0 );

        m_goCamera.transform.Rotate( -fRotationY, 0, 0 );
    }
}
