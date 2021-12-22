using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    public float speed = 0.5f;
    private float offset;
    private Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        if (offset > 1)
        {
            offset -= 1;
        }
        _renderer.material.mainTextureOffset = new Vector2(0,offset);
    }
}
