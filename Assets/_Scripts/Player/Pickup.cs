using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Transform itemHolder;
    [SerializeField] int range;

    bool equipped = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && !equipped) {
            // equipped = true;

            if (Physics.Raycast(head.position, head.forward, out RaycastHit hit, range, LayerMask.GetMask("Interaction"))) {
                hit.transform.SetParent(itemHolder);
                hit.transform.GetComponent<Flashlight>().enabled = true;
                hit.transform.localPosition = Vector3.zero;
                hit.transform.localRotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }
}
