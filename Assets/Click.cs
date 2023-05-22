using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Sprite krest, nolik;
    private SpriteRenderer _renderer;
    public static bool iskrest = true;
    public int position;
    public PhotonView m_view;
    public static bool endgame = false;
    
    


    public bool isClicked;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        m_view = GetComponent<PhotonView>();
        iskrest = true;
        if (m_view.IsMine)
        {
            GameController.isStep = true;
        }

        if (!m_view.IsMine)
        {
            GameController.isStep = false;
        }
    }

    private void Update()
    {
        Debug.Log(GameController.isStep);
    }

    public void OnMouseDown()
    {
        if (endgame == false)
        {
            {
                if (GameController.isStep)
                {
                    if (iskrest && !isClicked)
                    {
                        m_view.RPC("krestclick", RpcTarget.OthersBuffered, null); //передача крестика другому клиенту
                        krestclick();
                        m_view.RPC("step", RpcTarget.OthersBuffered, null);
                        step();
                    }
                    else if (!iskrest && !isClicked)
                    {
                        m_view.RPC("nolikclick", RpcTarget.OthersBuffered, null); // Передача нолика другому клиенту
                        nolikclick();
                        m_view.RPC("step", RpcTarget.MasterClient, null);
                        step();
                    }

                    isClicked = true;
                }

                Debug.Log(GameController.isStep);
            }
        }
    }
    [PunRPC] public virtual void krestclick()
    {
        _renderer.sprite = krest;
        iskrest = false;
        tag = "krest";
        isClicked = true;
    }
    [PunRPC] public virtual void nolikclick()
    {
        _renderer.sprite = nolik;
        iskrest = true;
        tag = "nolik";
        isClicked = true;
    }

    [PunRPC]
    public virtual void step()
    {
        GameController.isStep = !GameController.isStep;
    }
}
