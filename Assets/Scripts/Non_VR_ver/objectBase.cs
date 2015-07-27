using UnityEngine;
using System.Collections;

public class objectBase : MonoBehaviour
{
    void Awake() { OnAwake(); }
    void Start() { OnStart(); }
    void OnEnable() { _OnEnable(); }
    void OnDisable() { _OnDisable(); }
    void Update() { OnUpdate(); }
    void FixedUpdate() { OnFixedUpdate(); }

    void OnCollisionEnter( Collision pCollision ) { OnObjectCollisionEnter( pCollision ); }
    void OnCollisionExit( Collision pCollision ) { OnObjectCollisionExit( pCollision ); }
    void OnTriggerEnter( Collider pCollider ) { OnObjectTriggerEnter( pCollider ); }
    void OnTriggerExit( Collider pCollider ) { OnObjectTriggerExit( pCollider ); }

    void OnControllerColliderHit( ControllerColliderHit pHit ) { OnCharacterColliderHit( pHit ); }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void _OnEnable() { }
    protected virtual void _OnDisable() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnFixedUpdate() { }

    protected virtual void OnObjectCollisionEnter( Collision pCollision ) { }
    protected virtual void OnObjectCollisionExit( Collision pCollision ) { }

    protected virtual void OnObjectTriggerEnter( Collider pCollider ) { }
    protected virtual void OnObjectTriggerExit( Collider pCollider ) { }

    protected virtual void OnCharacterColliderHit( ControllerColliderHit pHit ) { }
}
