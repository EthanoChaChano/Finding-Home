using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BreadCrumbs : MonoBehaviour
{
    public GameObject breadCrumbs;
    public int breadAmount = 5;
    public Text breadCounter;
    public Collider lost;
    public PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        breadCounter.text = "Bread Left: " + breadAmount + " crumbs";

        if (breadAmount >= 999)
        {
            StartCoroutine(Win());
        }
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        if (breadAmount > 0)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && collisionInfo.tag == "BreadCrumbs")
            {
                collisionInfo.enabled = false;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                GameObject bread = Instantiate(breadCrumbs);
                bread.transform.position = hit.point;
                bread.transform.rotation = Quaternion.Euler(0, Random.Range(0, 359), 0);
                breadAmount--;
            }
        }

        if (breadAmount <= 0)
        {
            RenderSettings.fogDensity = 0.1f;
            lost.enabled = true;
            controller.enabled = false;
            StartCoroutine(Lost());
        }
    }

    IEnumerator Lost()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndScreen");
    }
}
