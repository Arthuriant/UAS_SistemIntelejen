using TMPro;
using UnityEngine;

public class Packaging : MonoBehaviour
{
    public GameObject boxmethUnitPackagedPrefab;

    private GameObject coklat;
    private bool coklatDiDalam = false;
    private bool methUnitPackagedSpawn = false;

    void Update()
    {
        if (coklatDiDalam && !methUnitPackagedSpawn)
        {
            Destroy(coklat);
            Vector3 spawnPos = transform.position;
            Instantiate(boxmethUnitPackagedPrefab, spawnPos, Quaternion.identity);
            methUnitPackagedSpawn = true;
            coklatDiDalam = false;
            coklat = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("methUnit"))
        {
            coklatDiDalam = true;
            coklat = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("methUnit"))
        {
            coklatDiDalam = false;
        }
        else if (other.CompareTag("methUnitPackaged"))
        {
            methUnitPackagedSpawn = false;
        }
    }
}
