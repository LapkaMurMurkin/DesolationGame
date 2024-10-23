using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreePath : MonoBehaviour
{
    [SerializeField] List<Image> images;
    public void SetPathColor(Color color)
    {
        foreach(Image image in images)
        {
            image.color = color;
        }
    }
}
