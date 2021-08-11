using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDecoration : MonoBehaviour
{
    public List<Sprite> SpriteList;

    void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        int selected = Random.Range(0, SpriteList.Count-1);
        spriteRenderer.sprite = SpriteList[selected];
        spriteRenderer.sortingLayerID = SortingLayer.NameToID(Random.value > 0.5 ? "Decorations A" : "Decorations B");
    }
}
