using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
   GameManager gm;
   public Image[] vidas;
   int vidas_atuais;
   bool changed = false;

   void Start()
   {
       gm = GameManager.GetInstance();
       vidas_atuais = gm.vidas;

   }
   
   void FixedUpdate()
   {
       if(vidas_atuais!=gm.vidas){
        changed = true;        
       }
       if(changed){
           for(int i =0;i<4;i++){
           vidas[i].gameObject.SetActive(false);}
           for(int i =0;i<gm.vidas;i++){
               vidas[i].gameObject.SetActive(true);
           }
       }
       vidas_atuais = gm.vidas;

   }
}
