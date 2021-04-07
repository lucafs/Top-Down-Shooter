using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenu : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        
    }
    public void Comecar()
    {
       gm.ChangeState(GameManager.GameState.GAME); 
    }
}
