using UnityEngine;

public class Nampan : MonoBehaviour
{
    public GameObject methHasilReshapePrefab;
    private GameObject methInput;
    private GameObject methHasilReshapeNampan;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("methBubukTermasak"))
        {
            Debug.Log("Meth Input Masuk");
            methInput = other.gameObject;
            reshapeMethToNampan();
        }

    }
    
        private void reshapeMethToNampan()
    {
        if (methInput != null)
        {
            Destroy(methInput);
            Vector3 spawnPos = transform.position + new Vector3(0f, 0f, -0.030f);
            methHasilReshapeNampan = Instantiate(methHasilReshapePrefab, spawnPos, Quaternion.identity);
        }
    }
}
