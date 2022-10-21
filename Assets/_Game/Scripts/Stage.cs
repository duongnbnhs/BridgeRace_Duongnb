using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public List<ColorData> colorArray;
    public BrickGenerator brickGenerator;
    public bool openStage;
    public bool createBrick;
    private void Start()
    {
        //openStage = false;
        createBrick = false;
    }
    private void Update()
    {
        if (openStage)
        {
            brickGenerator.gameObject.SetActive(true);
            brickGenerator.colorArray = colorArray;
            //brickGenerator.CreateBricks();
        }
    }
}
