using UnityEngine;
using System.Collections;

public class Monster_Item : MonoBehaviour
{
    public Transform m_vTarget;
    public GameObject m_vMonster;

    public GameObject m_ObjArrow;

    public Player m_pPlayer;
    bool m_bMove = false;
    float m_fDeleteTime;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( m_bMove )
        {
            m_fDeleteTime += Time.deltaTime;
            if ( m_fDeleteTime >= 3.0f )
            {
                Destroy( m_vMonster );
                m_fDeleteTime = 0.0f;
                gameObject.SetActive( false );
                m_bMove = false;
                m_pPlayer.AddCount();
            }

            m_vMonster.transform.position = Vector3.MoveTowards( m_vMonster.transform.position, m_vTarget.position, 0.05f );
        }
    }


    void OnTriggerEnter( Collider col )
    {
        if ( col.tag == "Player" )
        {
            if ( gameObject.name == "MonsterCol3" )
            {
                GameObject.Find( "Arrow3Manager" ).SetActive( false );
                m_ObjArrow.SetActive( true );
            }
            if ( gameObject.name == "MonsterCol2" )
            {
                GameObject.Find( "Arrow2Manager" ).SetActive( false );
            }
            m_bMove = true;

        }
    }
}
