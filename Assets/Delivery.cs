using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    int packageCount = 0;
    int packageCapacity = 2;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 emptyColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 onePackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 twoPackageColor = new Color32(255, 255, 255, 255);
    SpriteRenderer spriteRenderer;
    Driver driver;
    int customerLeftCount = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        driver = GetComponent<Driver>();
        updateColor();
        customerLeftCount = GameObject.FindGameObjectsWithTag("Customer").Length;
    }
    void updateColor()
    {
        if (packageCount == 1)
        {
            spriteRenderer.color = onePackageColor;
        }
        else if (packageCount == 2)
        {
            spriteRenderer.color = twoPackageColor;
        }
        else
        {
            spriteRenderer.color = emptyColor;
        }
    }

    public int getCustomerLeft()
    {
        return customerLeftCount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && packageCount < packageCapacity)
        {
            ++packageCount;
            Destroy(other.gameObject, destroyDelay);// object & comma
            Debug.Log("You picked up a package! Now you have " + packageCount + " package(s)!");
        }
        else if (other.tag == "Customer")
        {
            Customer customer = other.GetComponent<Customer>();
            if (!customer.getSatisfied() && packageCount > 0)
            {
                --packageCount;
                customer.setSatisfied();
                if (customerLeftCount > 0)
                    --customerLeftCount;
                Debug.Log("You delivered a package! Now you have " + packageCount + " package(s)!");
            }
        }
        updateColor();
    }
}
