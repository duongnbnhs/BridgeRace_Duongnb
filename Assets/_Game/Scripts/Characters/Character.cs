using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Character : MonoBehaviour
{
    public ColorData characcterColorData;

    [SerializeField]
    Transform brickStackPos;
    public List<Brick> bricksList;
    [SerializeField]
    LayerMask stairLayer;
    protected float moveSpeed;
    protected bool moveOnBridge;
    private void Start()
    {
        OnInit();
    }
    protected virtual void OnInit()
    {
        moveSpeed = 2.5f;
    }
    public virtual void RemoveBrickOnStack()
    {
        Destroy(bricksList[bricksList.Count - 1].gameObject);
        bricksList.RemoveAt(bricksList.Count - 1);
    }
    public virtual bool CanMoveOnBridge(Vector3 direction)
    {
        bool canMove = false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 0.6f, stairLayer))
        {
            if (bricksList.Count > 0)
            {
                canMove = true;
            }
            else
            {
                if (hit.collider.transform.gameObject.GetComponent<Stair>() != null)
                {
                    if (hit.collider.transform.gameObject.GetComponent<Stair>().color.colorName == characcterColorData.colorName)
                    {
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
            }
        }
        else
        {
            canMove = true;
        }
        return canMove;
    }
    public bool IsOnBridge()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3f, stairLayer))
        {
            return true;
        }
        else return false;
    }
    public bool IsGoingDownOnBridge()
    {
        RaycastHit hit;
        if (IsOnBridge() && Physics.Raycast(transform.position, Vector3.back, out hit, 3f, stairLayer))
        {
            return true;
        }
        else return false;
    }
    public virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Brick"))
        {
            Brick brick = collision.gameObject.GetComponent<Brick>();
            if (brick.colorData.colorName == characcterColorData.colorName)
            {
                Destroy(collision.gameObject);

                brick = Instantiate(brick);
                brick.transform.SetParent(brickStackPos);
                bricksList.Add(brick);
                Vector3 pos = brickStackPos.position;
                pos.y += bricksList.Count * 0.32f;
                brick.transform.position = pos;
                brick.transform.localRotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }
}
