using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRemove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);
    }
}
