using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadCounter : MonoBehaviour
{
   OtherManager om;
   public Image recarregando;
   float reloadTime = 1.3f;
    float lastTime;
   void Start()
   {
       om = OtherManager.GetInstance();
   }
   

   void FixedUpdate()
   {
       if(om.recarregando){
            recarregando.gameObject.SetActive(true);
            om.recarregando = false;
            lastTime = Time.time;
       }
        else if(Time.time - lastTime > reloadTime && !om.recarregando){
                recarregando.gameObject.SetActive(false);
            
        }
   }
}
