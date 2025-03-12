using UnityEngine;

public class CollectObject : MonoBehaviour
{
    //Player
    public Transform hand;
    private GameObject itemCollected = null;

    //Lantern
    public Light flashlight;
    private bool isOn = false;

    void Start()
    {
        flashlight.enabled = isOn;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2.0f))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    CollectItem(hit.collider.gameObject);
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && itemCollected != null)
        {
            DropItem();
        }

        CollectLantern();
    }

    private void CollectItem(GameObject item)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        BoxCollider collider = item.GetComponent<BoxCollider>();
        if (collider != null) collider.enabled = false;

        item.transform.position = hand.position;
        item.transform.rotation = hand.rotation;

        item.transform.SetParent(hand);

        itemCollected = item;
    }

    private void DropItem()
    {
        itemCollected.transform.SetParent(null);

        Rigidbody rb = itemCollected.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = false;

        BoxCollider collider = itemCollected.GetComponent<BoxCollider>();
        if (collider != null) collider.enabled = true;

        itemCollected = null;
    }

    private void CollectLantern()
    {
        if (Input.GetMouseButtonDown(0) && itemCollected != null)
        {
            isOn = !isOn;
            flashlight.enabled = isOn;   
        }
    }

}

