using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInfo : MonoBehaviour
{
    public string itemName;
    public int itemValue;

    PlayerControl playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void OnMouseOver()
    {
        Debug.Log(itemName);
        playerScript.itemText.text = itemName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        playerScript.hasKey = true;
        Destroy(gameObject);
    }
}
