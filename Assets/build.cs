using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class build : MonoBehaviour
{
    public GameObject Player;
    public GameObject npcPuhe;
    public Text teksti1;
    public rakenne child;

    public int parts;

    public string viesti;

    PlayerTeko playerScript;

    AudioManager audioManager;

    public PlayerValues values;

    public void addPart()
    {
        parts++;
    }

    public void tekstiMuutos(string uusi_viesti)
    {
        teksti1.text = uusi_viesti;
    }

    public void puheActive(bool status)
    {
        npcPuhe.SetActive(status);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerScript = Player.GetComponent<PlayerTeko>();
        values = Player.GetComponent<PlayerValues>();
        audioManager = FindObjectOfType<AudioManager>();
        tekstiMuutos(viesti);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.buildBuild)
        {
            print("build viesti toimii");
        }
        if (parts == 3)
        {
            playerScript.tekstiMuutos("You repaired the structure!");
            tekstiMuutos("the lamp post is shining bright!");
            values.addKorjattu();
            playerScript.dialogActive();
            child.muutarakenne();
            playerScript.Wait();
            parts = 4;
            audioManager.AddLoop("AmbientDrums");

        }
    }
}
