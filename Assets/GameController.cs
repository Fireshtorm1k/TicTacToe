using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] tab;
    public static bool isStep;

    public TMP_Text finish;
    // Start is called before the first frame update
    void Start()
    {
        Click.iskrest = true;
    }

    public void Exit()
    {
        Click.endgame = false;
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Main");
        
    }

   public void WinKrest()
    {
        finish.text = "Крестики победили";
        Click.endgame = true;
    }

   public void WinNolik()
   {
       finish.text = "Нолики победили";
       Click.endgame = true;
   }
    // Update is called once per frame
    public void Update()
    {
        if (tab[0].tag == "krest" && tab[1].tag == "krest" && tab[2].tag == "krest")
        {
            WinKrest();
        }
        if (tab[3].tag == "krest" && tab[4].tag == "krest" && tab[5].tag == "krest")
        {
            WinKrest();
        }
        if (tab[6].tag == "krest" && tab[7].tag == "krest" && tab[8].tag == "krest")
        {
            WinKrest();
        }
        if (tab[0].tag == "krest" && tab[3].tag == "krest" && tab[6].tag == "krest")
        {
            WinKrest();
        }
        if (tab[1].tag == "krest" && tab[4].tag == "krest" && tab[7].tag == "krest")
        {
            WinKrest();
        }
        if (tab[2].tag == "krest" && tab[5].tag == "krest" && tab[8].tag == "krest")
        {
            WinKrest();
        }
        if (tab[2].tag == "krest" && tab[4].tag == "krest" && tab[6].tag == "krest")
        {
            WinKrest();
        }
        if (tab[0].tag == "krest" && tab[4].tag == "krest" && tab[8].tag == "krest")
        {
            WinKrest();
        }
        
        
        
        
        if (tab[0].tag == "nolik" && tab[1].tag == "nolik" && tab[2].tag == "nolik")
        {
            WinNolik();
        }
        
        if (tab[3].tag == "nolik" && tab[4].tag == "nolik" && tab[5].tag == "nolik")
        {
            WinNolik();
        }
        if (tab[6].tag == "nolik" && tab[7].tag == "nolik" && tab[8].tag == "nolik")
        {
            WinNolik();
        }
        if (tab[0].tag == "nolik" && tab[3].tag == "nolik" && tab[6].tag == "nolik")
        {
            WinNolik();
        }
        if (tab[1].tag == "nolik" && tab[4].tag == "nolik" && tab[7].tag == "nolik")
        {
            WinNolik();
        }
        if (tab[2].tag == "nolik" && tab[5].tag == "nolik" && tab[8].tag == "nolik")
        {
            WinNolik();
        }
        if (tab[2].tag == "nolik" && tab[4].tag == "nolik" && tab[6].tag == "nolik")
        {
            WinNolik();
        }
        if (tab[0].tag == "nolik" && tab[4].tag == "nolik" && tab[8].tag == "nolik")
        {
            WinNolik();
        }
    }
}
