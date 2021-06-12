using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherManager
{
    public bool recarregando;
    private static OtherManager _instance;
    public int altarCount = 0;




    public static OtherManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OtherManager();
        }

        return _instance;
    }
    private OtherManager()
    {
        altarCount = 0;
        recarregando = false;
    }
}



//TO DO 
// respawnar porta
// refazer posição player
//arrumar a porra do spawner

//ajustar 