using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum ColorName
{
    Default,
    Pink,
    Green,
    White,
    Yellow,
    Blue,
}

[System.Serializable]
public class ColorData
{
    public Color color;
    public ColorName colorName;
}

