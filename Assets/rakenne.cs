using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rakenne : MonoBehaviour
{
    public Sprite vanha_rakenne;
    public Sprite uusi_rakenne;

    private build parent;

    private SpriteRenderer spriteRenderer;

    public void muutarakenne()
    {
        spriteRenderer.sprite = uusi_rakenne;
        print("jee");
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = vanha_rakenne;
        }
        parent = GetComponent<build>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
