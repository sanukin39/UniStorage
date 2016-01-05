using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniStorageSample : MonoBehaviour {

    [SerializeField] Text text;

    void Start(){
        text.text = string.Format ("Avarable Storage: {0}MB", UniStorage.StorageAvailableMb());
    }
}
