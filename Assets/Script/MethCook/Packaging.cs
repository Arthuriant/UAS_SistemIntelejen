using TMPro;
using UnityEngine;

public class Packaging : MonoBehaviour
{
public GameObject boxPutihPrefab; // Drag prefab box coklat ke sini lewat inspector

    private GameObject coklat;
    private bool coklatDiDalam = false;
    private bool putihSpawn = false;


    void Update()
    {
        if (coklatDiDalam && !putihSpawn)
        {
            Destroy(coklat);
            Vector3 spawnPos = transform.position;
            Instantiate(boxPutihPrefab, spawnPos, Quaternion.identity);
            putihSpawn = true;
            coklatDiDalam = false;

            // Reset supaya tidak terus ngespawn
            coklat = null;
            
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoklatMini"))
        {
            coklatDiDalam = true;
            coklat = other.gameObject;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CoklatMini"))
        {
            coklatDiDalam = false;  
        }else if(other.CompareTag("Putih")){
            putihSpawn = false;
        }
    }
}
