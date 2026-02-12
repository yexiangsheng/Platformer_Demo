using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] float radius = 0.1f;
    [SerializeField] LayerMask groundLayer;

    Collider[] colliders = new Collider[1];

    //该函数不会重新分配内存，故性能更好
    public bool IsGround => Physics.OverlapSphereNonAlloc(transform.position, radius, colliders, groundLayer) != 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
