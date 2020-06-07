using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialog : MonoBehaviour
{

    public GameObject enterDialog;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {

       if (other.tag == "Player")
       {

           enterDialog.SetActive(true);

       }
       
       Debug.Log("trigger enter 2d");

    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.tag == "Player")
        {

            enterDialog.SetActive(false);

        }

        Debug.Log("trigger exit 2d");

    }

}
