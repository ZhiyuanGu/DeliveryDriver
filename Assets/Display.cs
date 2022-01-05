using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] string beginPlay = "Game start! Pick up square packages and deliver to circle customers!";
    bool gameStart = false;
    // Start is called before the first frame update
    Delivery deliveryStatus;
    void Start()
    {
        textComponent.text = beginPlay;
        deliveryStatus = GameObject.FindObjectOfType<Delivery>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameStart)
        {
            textComponent.text = beginPlay;
            if (GameObject.FindGameObjectsWithTag("Customer").Length != GameObject.FindGameObjectsWithTag("Package").Length)
                gameStart = true;
        }
        else
        {
            string updateString = deliveryStatus.getCustomerLeft() + " customers left!";
            if (deliveryStatus.getCustomerLeft() == 0)
            {
                updateString += " You win! ";
            }
            textComponent.text = updateString;
        }
    }
}
