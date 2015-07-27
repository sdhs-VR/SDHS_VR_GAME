using UnityEngine;
using System.Collections;

public class MouseCamera : MonoBehaviour
{
    public Transform target;      // 카메라 타겟 오브젝트
    public float distance = 10.0f; // 오브젝트와 카메라 거리

    public float xSpeed = 250.0f;   // x 마우스 스피드
    public float ySpeed = 120.0f;   // y 마우스 스피드

    public float yMinLimit = -20.0f;  // y 밑에 제한
    public float yMaxLimit = 80;      // y 위에 제한

    double x = 0.0f;
    double y = 0.0f;

    float Wheel = 0.0f;

    Quaternion rotation;

    bool LeftMouseClick = false;   // 왼쪽 마우스 눌렀을때

    bool MouseColl = false;         // 벽과 부딛혔을때
    bool CountMouseColl = false;    // 벽과 부딛혔을때
    float MouseTime = 0.0f;         // 벽 시간
    Vector3 Targetposition;               // 타겟 포지션 
    Quaternion targetrotation;      // 타겟 로테이션

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if ( GetComponent<Rigidbody>() )
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame


    void Update()
    {
        if ( target )
        {
            x += Input.GetAxis( "Mouse X" ) * xSpeed * 0.02;
            y -= Input.GetAxis( "Mouse Y" ) * ySpeed * 0.02;

            if ( LeftMouseClick == false )
            {
                y = ClampAngle( ( float )y, yMinLimit, yMaxLimit );
                targetrotation = Quaternion.Euler( 0.0f, ( float )x, 0.0f );
            }
            else
            {
                y = ClampAngle( ( float )y, 10.0f, yMaxLimit );
            }

            rotation = Quaternion.Euler( ( float )y, ( float )x, 0.0f );

            if ( MouseColl == false )
            {
                MouseTime += Time.deltaTime;
                if ( MouseTime >= 0.6f )
                {
                    MouseTime = 0.0f;
                    CountMouseColl = false;
                }
            }

            if ( CountMouseColl == false )
            {
                Targetposition = rotation * new Vector3( 0.0f, 1.0f, -distance ) + target.position;
            }
            else
            {
                Targetposition = rotation * new Vector3( 0.0f, 1.0f, -2.0f ) + target.position;
            }

            if ( LeftMouseClick == false )
                target.rotation = targetrotation;

            transform.rotation = rotation;
            transform.position = new Vector3( Targetposition.x, Targetposition.y, Targetposition.z );
            //transform.position = Targetposition;
        }
    }

    static float ClampAngle( float angle, float min, float max )
    {
        if ( angle < -360 )
            angle += 360;
        if ( angle > 360 )
            angle -= 360;
        return Mathf.Clamp( angle, min, max );
    }
}
