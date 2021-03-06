using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=k4hr7-7ysCY&ab_channel=TheGameGuy
public class Explosion : MonoBehaviour
{
    public float targetTime = 1f;
    public float fieldoImpact;
    public float force;
    public LayerMask LayerToHit;
    public AudioClip explosionSFX;

    GameObject objDestroyed;
    GameManager gm;
    Animator animator;
    public Rigidbody2D granadeRB;

    public GameObject heart;
    public GameObject granade;
    public GameObject boost;

        // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        animator = GetComponent<Animator>();

        targetTime -= Time.deltaTime;

        
    }

    // Update is called once per frame
    void Update(){
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f){
            AudioManager.PlaySFX(explosionSFX);
            explode();

        }
        
    }
    void explode(){
        granadeRB.isKinematic = true;
        granadeRB.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetTrigger("boom");
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,fieldoImpact,LayerToHit);
        Physics2D.OverlapCircleAll(transform.position,fieldoImpact,LayerToHit);
        foreach(Collider2D obj in objects){
            objDestroyed = obj.gameObject;
            if (objDestroyed.tag == "Enemy"){
                gm.pontos += 1;
                objDestroyed.GetComponent<Enemy>().Morrer();}
            else if(objDestroyed.tag == "Caixa"){
                int random = Random.Range(0,100);
                if(random < 33){
                    GameObject Heart = Instantiate(heart, objDestroyed.transform.position,Quaternion.identity);
                }
                else if(random < 66){
                    GameObject Boost = Instantiate(boost, objDestroyed.transform.position,Quaternion.identity);
                }
                else{
                    GameObject Granade = Instantiate(granade, objDestroyed.transform.position,Quaternion.identity);
                }
                Destroy(objDestroyed);
            }
            else if(objDestroyed.tag == "Boss")
            {
                gm.pontos += 6;
                Destroy(objDestroyed);
            }
        }
        while(!this.animator.GetCurrentAnimatorStateInfo(0).IsName("explosion")){
            Debug.Log("salve");
        }
        Destroy(gameObject);

    }
    void OnDrawGizmosSelected(){
        Gizmos.color =  Color.red;
        Gizmos.DrawWireSphere(transform.position,fieldoImpact);
    }

}
