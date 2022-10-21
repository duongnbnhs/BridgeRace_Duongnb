using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public ColorData colorData;
    public int brickNumber;
    Transform brickGenerator;
    private void Start()
    {
        brickGenerator = transform.parent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            brickGenerator.GetComponent<BrickGenerator>().CharacterTakeBrick(brickNumber);
        }
    }
}
