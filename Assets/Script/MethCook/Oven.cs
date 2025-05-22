using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject methHasilOven; // Drag prefab box hitam ke sini lewat inspector
    public GameObject methHasilReshapeNampan;
    private GameObject methInput;
    public TextMeshPro text;

    private bool methInputDiDalam = false;
    private float timermethInput = 0f;
    public float waktuTunggu = 5f;
    private bool didalamOven = false;

    void Update()
    {
        if (methInputDiDalam && didalamOven)
        {
            timermethInput += Time.deltaTime;

            // Hitung waktu mundur
            float waktuSisa = Mathf.Ceil(waktuTunggu - timermethInput);
            waktuSisa = Mathf.Max(0, waktuSisa); // Biar gak negatif
            text.text = waktuSisa.ToString("0");

            if (timermethInput >= waktuTunggu)
            {
                Destroy(methInput);
                // Spawn box methInput di atas mangkok
                Vector3 spawnPos = transform.position + Vector3.up * 1f;
                Instantiate(methHasilOven, spawnPos, Quaternion.identity);

                // Reset supaya tidak terus ngespawn
                methInput = null;
                timermethInput = 0f;
                methInputDiDalam = false;
                text.text = ""; // Kosongkan tulisan setelah selesai
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Name Object:" + other.name + "Tag: "+ other.tag) ;
        if (other.CompareTag("Hitam"))
        {
            methInput = other.GameObject();
            Debug.Log("Reshape To Nampan");
            reshapeMethToNampan();
        }
        else if (other.CompareTag("Oven"))
        {
            Debug.Log("Oven terdeteksi");
            didalamOven = true;
        }
        else if (other.CompareTag("HitamReshape"))
        {
            Debug.Log("Meth Reshape in Area");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hitam"))
        {
            methInputDiDalam = false;
            timermethInput = 0f; // batalkan proses
            text.text = ""; // Kosongkan tulisan jika keluar
        }
        else if (other.CompareTag("Oven"))
        {
            Debug.Log("Oven terdeteksi");
            didalamOven = false;
        }
    }

    private void reshapeMethToNampan()
    {
         Destroy(methInput);
        // Spawn Bentuk Meth jadi yang seperti nampan
        Vector3 spawnPos = transform.position;
        Instantiate(methHasilReshapeNampan, spawnPos, Quaternion.identity);
    }
}
