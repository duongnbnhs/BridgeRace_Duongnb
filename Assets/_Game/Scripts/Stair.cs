using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stair : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public bool isTaken;
    public ColorData color; 
    [SerializeField]
    BrickGenerator brickGenerator;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isTaken)
            {
                Player player = other.transform.GetComponent<Player>();
                if (player.bricksList.Count > 0)
                {
                    player.RemoveBrickOnStack();
                    color.colorName = player.characcterColorData.colorName;
                    Color colorValue = new Color();
                    foreach (var cl in brickGenerator.colorArray)
                    {
                        if (cl.colorName == color.colorName)
                        {
                            colorValue = cl.color;
                            break;
                        }
                    }
                    meshRenderer.gameObject.SetActive(true);
                    meshRenderer.material.SetColor("_Color", colorValue);
                    isTaken = true;
                }
                
            }
            

        }
    }
}
