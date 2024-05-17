using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform user;
    public Transform Enemy;

    private NavMeshAgent enemyAgent;
    private Animator enemyAnimator;

    public bool userDetected;
    public bool Froze = false;

    // Start is called before the first frame update
    void Start()
    {
       enemyAgent = GetComponent<NavMeshAgent>();
       enemyAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider colision)
    {
        if (!colision.CompareTag("Bullet"))
        {
            userDetected = true;
        }
    }
    private void OnTriggerExit(Collider colision)
    {
        if (!colision.CompareTag("Bullet"))
        {
            userDetected = false;
        }     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (!Froze)
            {
                SceneManager.LoadScene("DeadScene");
            }       
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Entra");
            Froze = true;
            enemyAgent.isStopped = true;
            userDetected = false;
            enemyAnimator.SetInteger("Morir", 1);
            StartCoroutine(FrezzeEnemy());
            enemyAgent.isStopped = false;
            Froze = false;
            //StartCoroutine(ActiveEnemy());
        }
    }
    IEnumerator FrezzeEnemy()
    {
        yield return new WaitForSeconds(2);
        enemyAnimator.SetInteger("Morir", 0);
        Enemy.gameObject.SetActive(false);
    }

    //IEnumerator ActiveEnemy()
    //{
    //    Debug.Log("Reactivara el enemigo en 5 segundos");
    //    yield return new WaitForSeconds(1);
    //    Enemy.gameObject.SetActive(true);
    //    Debug.Log("Enemigo Reaparecido");
    //}
    // Update is called once per frame
    void Update()
    {
        if (userDetected && !Froze)
        {
            enemyAgent.isStopped = false;
            enemyAgent.destination = user.position;
            enemyAnimator.SetInteger("Action", 1);
        }
        else
        {
            enemyAgent.isStopped = true;
            enemyAnimator.SetInteger("Action", 0);
        }
    }
}
