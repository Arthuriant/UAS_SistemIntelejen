using UnityEngine;

using System.Linq;

public class GantiAssetSaatPintuTertutup : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor;
    public Transform doorTransform;
    public GameObject replacementPrefab;
    public float angleThreshold = 2f;
    public float delay = 5f;
    public Vector3 replacementOffset = Vector3.zero;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable currentInteractable;
    private bool isReplacing = false;

    void Update()
    {
        if (socketInteractor.hasSelection && !isReplacing)
        {
            currentInteractable = socketInteractor.interactablesSelected.FirstOrDefault();

            float angleDiff = Mathf.Abs(Mathf.DeltaAngle(doorTransform.localEulerAngles.x, 270f)); // -90 == 270
            if (angleDiff <= angleThreshold)
            {
                StartCoroutine(ReplaceAfterDelay());
            }
        }
    }

    System.Collections.IEnumerator ReplaceAfterDelay()
    {
        isReplacing = true;

        yield return new WaitForSeconds(delay);

        // Cek kembali kondisi sebelum mengganti
        if (socketInteractor.hasSelection &&
            Mathf.Abs(Mathf.DeltaAngle(doorTransform.localEulerAngles.z, -0.052f)) <= angleThreshold)
        {
            GameObject toReplace = currentInteractable.transform.gameObject;
            Vector3 position = toReplace.transform.position + replacementOffset;
            Quaternion rotation = toReplace.transform.rotation;

            Destroy(toReplace);
            Instantiate(replacementPrefab, position, rotation);
        }

        isReplacing = false;
    }
}
