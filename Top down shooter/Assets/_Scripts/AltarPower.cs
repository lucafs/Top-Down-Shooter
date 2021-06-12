using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarPower : MonoBehaviour
{
    public float targetTime = 0f;
    public float timeLastUsed = 0f;
    OtherManager om;

    // Start is called before the first frame update
    void Start()
    {
        timeLastUsed = Time.time;
        om = OtherManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            if(timeLastUsed- Time.time  <= targetTime){
                targetTime = -110f;
                timeLastUsed = Time.time;
                om.altarCount += 1;
            }

        }
    }
}
