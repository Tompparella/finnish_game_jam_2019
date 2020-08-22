using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject Player;
    public GameObject npcPuhe;
    public Text teksti;

    public string viesti;
    PlayerTeko playerScript;

    public void tekstiMuutos(string uusi_viesti)
    {
        teksti.text = uusi_viesti;
    }



    public void puheActive(bool status)
    {
        npcPuhe.SetActive(status);
    }

    private void Start()
    {
        playerScript = Player.GetComponent<PlayerTeko>();
        tekstiMuutos(viesti);
    }
    private void Update()
    {
        if (playerScript.npcAction)
        {
            print("npc puhe toimii");   
        }
    }
}