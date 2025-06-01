using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class distributingMeth : MonoBehaviour
{

    public TextMeshProUGUI textTV;
    private GameObject methPackaged;
    private bool ismethPackaged;
    private int money = 0;
    public AudioSource moenySound;

    void Update()
    {
        if (ismethPackaged)
        {
            money += 2000;
            Destroy(methPackaged);
            textTV.text = "$" + money;
            ismethPackaged = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("methUnitPackaged"))
        {
            methPackaged = other.gameObject;
            ismethPackaged = true;
            moenySound.Play();
        }

    }
}






