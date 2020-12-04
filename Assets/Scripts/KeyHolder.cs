using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
   
    private List<Key.KeyType> keyList;

    public GameObject inventoryKey;

    public void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
        
        //Zeigt den aufgehobenen Key im Inventar an
        inventoryKey.SetActive(true);
    }
 
   public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);

        //Setzt den Key vom Inventar unsichtbar
        inventoryKey.SetActive(false);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    //Umgang mit der Kollidierung des Spielers und dem Key, sowie der dazugehoerigen Door
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        //Kollision zwischen Spieler und Key
        if (key != null)
        {
            //Fuegt den Key einer Liste hinzu
            AddKey(key.GetKeyType());

            //Entfernt den Key von der Map
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        //Kollision zwischen Spieler und Door
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                //hält den Key
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
        }
    }

}
