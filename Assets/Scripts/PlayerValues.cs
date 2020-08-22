using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerValues : MonoBehaviour
{
    // Arvot

    public int osat = 0;
    public int hp = 3;
    public int korjattu = 0;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public PlayerMovement player;

    public Text dialog;
    public GameObject dialogBox;

    private int dialogTime = 5;

    private PlayerTeko teko;

    // Funktiot

    public void addKorjattu()
    {
        korjattu++;
    }
    public void addOsa()
    {
        osat++;
    }

    public void takeOsa()
    {
        osat--;
    }

    public void tekstiMuutos(string uusi_viesti)
    {
        dialog.text = uusi_viesti;
    }

    public IEnumerator Wait()
    {
        dialogBox.SetActive(true);
        yield return new WaitForSeconds(dialogTime);
        dialogBox.SetActive(false);
        print("loppuu");
    }

    public void dialogActive(bool status)
    {
        dialogBox.SetActive(status);
    }

    public void isku()
    {
        hp -= 1;
        tekstiMuutos("You took damage!");
        if (hp == 0)
        {
            teko.killPlayer();
        }
        StartCoroutine(Wait());
    }
    void Update()
    {
        if (hp > hearts.Length)
        {
            hp = hearts.Length;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < hp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        if (hp == 0)
        {
            print("kuolit");
            transform.parent = null;
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
            print("Juups");
        }
        if (korjattu == 3)
        {
            dialog.text = "You've repaired everything the invading baddies broke. Congratulations!";
            Wait();
            SceneManager.LoadScene("Victory");
            dialogBox.SetActive(true);
            player.enabled = false;

        }
    }

}
