using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    Rigidbody rigidbody;
    [SerializeField]
    FixedJoystick joystick;
    /*[SerializeField]
    float moveSpeed;*/
    [SerializeField]
    Transform playerVisual;
    [SerializeField]
    LayerMask ropeLayer;
    Vector3 moveDir;

    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        Moving();
    }
    void Moving()
    {
        //rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed, 0, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            moveDir = new Vector3(joystick.Horizontal * moveSpeed, rigidbody.velocity.y, joystick.Vertical * moveSpeed);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 4f, ropeLayer))
            {

                if (CanMoveOnBridge(Vector3.forward * joystick.Vertical))
                {
                    Debug.DrawLine(transform.position, hit.point, Color.blue);
                    Vector3 hitPoint = hit.point;
                    if (IsOnBridge())
                    {
                        hitPoint.y += 2.1f;
                    }
                    else hitPoint.y += 1.1f;
                    Vector3 nextPoint = transform.position + moveDir * Time.deltaTime * moveSpeed;
                    transform.position = new Vector3(nextPoint.x, hitPoint.y, nextPoint.z);
                }
            }
            playerVisual.transform.rotation = Quaternion.LookRotation(moveDir);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
