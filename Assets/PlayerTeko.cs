using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeko : MonoBehaviour
{
    private GameObject encounteredNpc;
    private GameObject encounteredOsa;
    private GameObject encounteredBuild;
    private GameObject encounteredVihu;

    public Knockback knockback;

    private NPC puhe;
    private Osa viesti;
    private build msg;

    public float dialogTime = 5;

    public Text dialog;

    public GameObject dialogBox;

    public bool npcAction;
    public bool osaAction;
    public bool buildAction;

    public bool osaPickup;
    public bool buildBuild;

    bool npcKytkin;
    bool osaKytkin;
    bool buildKytkin;

    public PlayerValues Values;

    private void knockActivate(GameObject vihu)
    {
        knockback.knockback(vihu);
    }

    public void killPlayer()
    {
        Destroy(gameObject);
    }

        public IEnumerator Wait()
    {
        dialogBox.SetActive(true);
        yield return new WaitForSeconds(dialogTime);
        dialogBox.SetActive(false);
        print("loppuu");
    }


    public void dialogActive()
    {
        print("alkaa");
        StartCoroutine(Wait());

    }

    public void tekstiMuutos(string uusi_viesti)
    {
        dialog.text = uusi_viesti;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            encounteredNpc = collision.gameObject;
            puhe = encounteredNpc.GetComponent<NPC>();
            Debug.Log("npc");
            npcKytkin = true;
        }
        if (collision.gameObject.tag == "Osa")
        {
            encounteredOsa = collision.gameObject;
            viesti = encounteredOsa.GetComponent<Osa>();
            Debug.Log("Osa");
            osaKytkin = true;
        }
        if (collision.gameObject.tag == "build")
        {
            encounteredBuild = collision.gameObject;
            msg = encounteredBuild.GetComponent<build>();
            Debug.Log("build");
            buildKytkin = true;
        }
        if (collision.gameObject.tag == "vihu")
        {
            encounteredVihu = collision.gameObject;
            tekstiMuutos("you took damage!");
            Values.isku();
            dialogActive();
            knockActivate(encounteredVihu);
            Debug.Log("vihu");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("Heihei npc!");
            npcKytkin = false;
            puhe.puheActive(false);
            encounteredNpc = null;
        }
        if (collision.gameObject.tag == "Osa")
        {
            Debug.Log("Heihei Osa!");
            osaKytkin = false;
            viesti.puheActive(false);
            encounteredOsa = null;
        }
        if (collision.gameObject.tag == "build")
        {
            Debug.Log("Heihei build!");
            buildKytkin = false;
            msg.puheActive(false);
            encounteredBuild = null;
        }
        if (collision.gameObject.tag == "vihu")
        {
            Debug.Log("Heihei vihu!");
            encounteredVihu = null;
        }
    }
    void Update()
    {
     
        osaAction = false;
        osaPickup = false;

        buildBuild = false;

        npcAction = false;

        buildAction = false;

        if (npcKytkin)
        {
            if (Input.GetButtonDown("Teko")) {
                npcAction = true;
                puhe.puheActive(true);


            }
        }
        if (osaKytkin)
        {
            if (Input.GetButtonDown("Teko"))
            {
                osaAction = true;
                viesti.puheActive(true);
            }
            if (Input.GetButtonDown("Isku"))
            {
                osaPickup = true;

                tekstiMuutos("you picked up the scrap");
                dialogActive();
                Values.addOsa();
                var audioManager = FindObjectOfType<AudioManager>();
                audioManager.PlaySound("PianoChime");
                viesti.poista();

            }
        }
            if (buildKytkin)
            {
                if (Input.GetButtonDown("Teko"))
                {
                    buildAction = true;
                    msg.puheActive(true);
                
                }

                if (Input.GetButtonDown("Isku"))
                {
                    buildBuild = true;

                    if (Values.osat > 0)
                    {
                    tekstiMuutos("You used the scrap to add repairs to the wreck");

                    dialogActive();
                    
                    msg.addPart();
                    var audioManager = FindObjectOfType<AudioManager>();
                    audioManager.PlaySound("PianoChime");
                    Values.takeOsa();
                    audioManager.IterateMusic();
                }
            }

            }
    }
}
