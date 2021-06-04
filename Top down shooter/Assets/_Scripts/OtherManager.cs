using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherManager
{
    public bool recarregando;
    private static OtherManager _instance;




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
        recarregando = false;
    }
}



//TO DO 
// respawnar porta
// refazer posição player
//arrumar a porra do spawner