using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateWeapon : MonoBehaviour
{
    public GameObject messageText;
    GameManager gm;
    private int is_trigger;
    public GameObject animationGun;
    private int indexGunSelect;
    private int is_active = 0;

    public GameObject gunsActive;
    private int countFilhos;
    private Transform[] sortGuns;
    private int sortedGun;
    private GameObject animDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        countFilhos = gunsActive.transform.childCount;

        sortGuns = new Transform[countFilhos];

        for (int i = 0; i < countFilhos; i++)
        {
            sortGuns[i] = gunsActive.transform.GetChild(i);
        }

        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && is_active == 1)
        {
            is_trigger = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            is_active = 1;
            Instantiate(messageText, transform.position, Quaternion.identity);

            if (gm.coins >= 500 && is_trigger == 1)
            {

                Instantiate(animationGun, transform.position + new Vector3(1,3,0), Quaternion.identity);

                is_trigger = 0;
                indexGunSelect = Random.Range(4,8);

                sortedGun = Random.Range(0, 5);

                StartCoroutine(waiter(indexGunSelect));

                //StartCoroutine(waiter(4));

                //Destroy(sortGuns[sortedGun]);
            }
        }
    }

    IEnumerator waiter(int timeWaiter)
    {
        yield return new WaitForSeconds(timeWaiter);

        Destroy(GameObject.FindGameObjectWithTag("animator"));

        Instantiate(sortGuns[sortedGun], transform.position + new Vector3(1, 3, 0), Quaternion.identity);

        yield return new WaitForSeconds(4);

        Destroy(GameObject.FindGameObjectWithTag("gunSorted"));
    }

}
