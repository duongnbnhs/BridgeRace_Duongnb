using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform BrickPrefab;
    [SerializeField]
    Stage currentState;
    private Vector3 startPoint;
    private Vector3 position;

    //so luong gach toi da
    
    private int length = 25;
    private int line = 5;
    private int xOrder = 0;

    private float zPosition;
    private float xPosition;
    public List<ColorData> colorArray;
    
    public SpawnedBricks[] spawnedBricks;

    void Start()
    {
        startPoint = transform.position;
        zPosition = transform.position.z;
        xPosition = transform.position.x;

        spawnedBricks = new SpawnedBricks[length];
        if (currentState.openStage)
        {
            colorArray = currentState.colorArray;
            CreateBricks();
        }

    }
    private void Update()
    {
        if (currentState.openStage)
        {
            colorArray = currentState.colorArray;
        }
    }
    //instantiate gach
    public void CreateBricks()
    {
        for (int i = 0; i < length; i++)
        {
            xOrder++;
            if (i % line == 0)
            {
                zPosition += 1;
                xOrder = 0;
                position = new Vector3(xPosition, startPoint.y, zPosition);
            }
            else
            {
                position = new Vector3(xPosition + xOrder, startPoint.y, zPosition);
            }

            Transform createdBrick = Instantiate(BrickPrefab, position, BrickPrefab.transform.rotation, transform);
            Debug.Log(createdBrick == null);
            FillColor(createdBrick, i);
        }
    }
    //phu mau cho vien gach vua tao o tren
    private void FillColor(Transform createdBrick, int num)
    {
        Debug.Log(colorArray.Count);
        int randomColor = Random.Range(0, colorArray.Count);
        createdBrick.GetComponent<Renderer>().material.SetColor("_Color", colorArray[randomColor].color);
        createdBrick.GetComponent<Brick>().colorData.colorName = colorArray[randomColor].colorName;
        createdBrick.GetComponent<Brick>().colorData.color = colorArray[randomColor].color;
        createdBrick.GetComponent<Brick>().brickNumber = num;

        InsertIntoArray(colorArray[randomColor], createdBrick, num);
    }
    //luu tru vien gach vua tao vao trong 1 list
    private void InsertIntoArray(ColorData colorData, Transform createdBrick, int i)
    {
        SpawnedBricks spawned = new SpawnedBricks();

        spawned.position = createdBrick.position;
        spawned.colorData = colorData;
        spawned.removed = false;
        spawnedBricks[i] = spawned;
    }
    //vien gach da duoc nhan vat nhat len => remove = true
    public void CharacterTakeBrick(int brickNumber)
    {
        spawnedBricks[brickNumber].removed = true;
    }
    //tao them cac vien gach vao vi tri vien gach da duoc nhat
    public void RefillBrick()
    {
        for (int i = 0; i < length; i++)
        {
            if (spawnedBricks[i].removed == true)
            {
                Transform createdBrick = Instantiate(BrickPrefab, spawnedBricks[i].position, BrickPrefab.transform.rotation, transform);

                createdBrick.GetComponent<Renderer>().material.SetColor("_Color", spawnedBricks[i].colorData.color);
                createdBrick.GetComponent<Brick>().colorData.colorName = spawnedBricks[i].colorData.colorName;
                createdBrick.GetComponent<Brick>().brickNumber = i;

                spawnedBricks[i].removed = false;
                return;
            }
        }
    }
}
