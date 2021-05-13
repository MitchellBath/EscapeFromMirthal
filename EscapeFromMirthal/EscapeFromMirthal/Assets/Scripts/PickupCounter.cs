using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupCounter : MonoBehaviour
{

    public Text pickupText;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Pickup display
        //GameObject playerobj = GameObject.Find("Player");
        //PlayerControl pscript = playerobj.GetComponent<PlayerControl>();
        //pickups = pscript.pickups;
        count = GameObject.Find("Player").GetComponent<PlayerControl>().pickups;
        pickupText.text = "Power-Ups: " + count;
    }
}
