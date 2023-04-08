using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color offsetColor, baseColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Init(bool isOffset)
    {
        _spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }
}
