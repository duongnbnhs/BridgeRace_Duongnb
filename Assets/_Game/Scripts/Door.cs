using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Stage nextStage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Player player = other.GetComponent<Player>();
            nextStage.openStage = true;
            ColorData colorData = new ColorData();
            foreach (var color in LevelManager.instance.colorArray)
            {
                if (color.colorName == player.characcterColorData.colorName)
                {
                    colorData = color;
                    break;
                }
            }
            nextStage.colorArray.Add(colorData);


        }
    }

}
