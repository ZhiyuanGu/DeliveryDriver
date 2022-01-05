using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] Color32 satisfiedColor = new Color32(255, 255, 255, 255);
    bool isSatisfied = false;
    SpriteRenderer spriteRenderer;
    public void setSatisfied()
    {
        isSatisfied = true;
        spriteRenderer.color = satisfiedColor;
    }
    public bool getSatisfied()
    {
        return isSatisfied;
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
