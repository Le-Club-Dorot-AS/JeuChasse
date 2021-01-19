
using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject Detruire;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(Detruire);
        }
    }



}
