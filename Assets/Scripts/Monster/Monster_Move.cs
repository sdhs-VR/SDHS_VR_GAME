using UnityEngine;
using System.Collections;

public class Monster_Move : objectBase
{
    NavMeshAgent Nav_Monster;
    public Transform m_vTarget;

    public float m_fRange;
    public Transform[] m_vPoint;

    float m_fRandomMoveTime = 200.0f;
    int m_iRandomNum;
    // Use this for initialization
    protected override void OnAwake()
    {
        Nav_Monster = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    protected override void OnUpdate()
    {
        if ( Vector3.Distance( transform.position, m_vTarget.position ) <= m_fRange )
        {
            Nav_Monster.SetDestination( m_vTarget.position );
        }
        else
        {
            m_fRandomMoveTime += Time.deltaTime;
            if ( m_fRandomMoveTime >= 35.0f )
            {
                m_iRandomNum = Random.Range( 0, m_vPoint.Length );
                m_fRandomMoveTime = 0.0f;
            }
            Nav_Monster.SetDestination( m_vPoint[ m_iRandomNum ].position );
        }
    }
}
