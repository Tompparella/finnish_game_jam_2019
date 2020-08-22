using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Osa : MonoBehaviour
{
    public GameObject Player;
    public GameObject npcPuhe;
    public Text teksti1;

    public string viesti;

    public void poista()
    {
        Destroy(gameObject);
    }
    
    PlayerTeko playerScript;

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
        tekstiMuutos(viesti);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.osaAction)
        {
            print("kytkin viesti toimii");
        }
    }
}
