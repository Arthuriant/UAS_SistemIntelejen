using TMPro;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject methHasilOven; // Prefab hasil oven (box methBubukTermasak)
    public GameObject methHasilReshapePrefab; // Prefab hasil reshape (nampan)
    private GameObject methInput;
    private GameObject methHasilReshapeNampan;

    public TextMeshPro text;

    private bool methInputDiDalam = false;
    private bool methReshapeDiDalam = false;
    private bool didalamOven = false;

    private float timermethInput = 0f;
    public float waktuTunggu = 5f;

    void Update()
    {
        if (methReshapeDiDalam && didalamOven)
        {
            timermethInput += Time.deltaTime;

            float waktuSisa = Mathf.Ceil(waktuTunggu - timermethInput);
            waktuSisa = Mathf.Max(0, waktuSisa);
            text.text = waktuSisa.ToString("0");

            if (timermethInput >= waktuTunggu)
            {
                // Hapus objek hasil reshape
                if (methHasilReshapeNampan != null)
                    Destroy(methHasilReshapeNampan);

                // Spawn hasil oven
                Vector3 spawnPos = transform.position;
                Instantiate(methHasilOven, spawnPos, Quaternion.identity);

                // Reset
                methHasilReshapeNampan = null;
                timermethInput = 0f;
                methReshapeDiDalam = false;
                text.text = "";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("methBubukTermasak"))
        {
            Debug.Log("Meth Input Masuk");
            methInput = other.gameObject;
            reshapeMethToNampan();
        }
        else if (other.CompareTag("methBlock"))
        {
            Debug.Log("Hasil Reshape Masuk");
            methHasilReshapeNampan = other.gameObject;
            methReshapeDiDalam = true;
        }
        else if (other.CompareTag("Oven"))
        {
            Debug.Log("Nampan Masuk Oven");
            didalamOven = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("methBubukTermasak"))
        {
            methInput = null;
        }
        else if (other.CompareTag("methBlock"))
        {
            methHasilReshapeNampan = null;
            methReshapeDiDalam = false;
        }
        else if (other.CompareTag("Oven"))
        {
            didalamOven = false;
        }
    }

    void OnTriggerStay(Collider other)
{
    if (other.CompareTag("methBlock") && !methReshapeDiDalam)
    {
        Debug.Log("Hasil Reshape tetap di dalam (OnTriggerStay)");
        methHasilReshapeNampan = other.gameObject;
        methReshapeDiDalam = true;
    }

    if (other.CompareTag("Oven") && !didalamOven)
    {
        Debug.Log("Masih di dalam oven (OnTriggerStay)");
        didalamOven = true;
    }
}


    private void reshapeMethToNampan()
    {
        if (methInput != null)
        {
            Destroy(methInput);
            Vector3 spawnPos = transform.position;
            methHasilReshapeNampan = Instantiate(methHasilReshapePrefab, spawnPos, Quaternion.identity);
            methReshapeDiDalam = true;
        }
    }
}