using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Animator animationHandler;

    public float speed;

    private Transform target;

    private bool facingX;

    private bool facingY;

    private bool playerInRange;

    private SpriteRenderer mySpriteRenderer;

    private bool attackState;

    public GameObject player;
    public PlayerMovement script;

    private int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 150;

        animationHandler = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //Sets script = to our PlayerMovement.cs script that is attached to our Player.
        //This way we can access variables and even modify them if we need to.
        script = player.GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the enemy and player are < 1.5 blocks apart, and the player is not attacking, move towards the player.
        

        if (Vector2.Distance(transform.position, target.position) <= 2)
        {

            attackState = true;

            if (script.attackState == true)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                enemyHealth--;
                Debug.Log("Enemy taking damage from player");

                if (enemyHealth == 0)
                {
                    Destroy(this.gameObject);
                }


            }

            else if (script.attackState == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            }


        }

        //if the distance between the character and the enemy is less
        //than one square, set enmemy attack animation to true
        //and keep following the player. ^^
        
        //------------------------------------------------------------------

        if ((Vector2.Distance(transform.position, target.position) > 2) && (Vector2.Distance(transform.position, target.position) < 7))
        {

            if ((transform.position.x > target.position.x))
            {

                facingX = true;

                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                playerInRange = true;

                mySpriteRenderer.flipX = true;

            }
            else
            {

                facingX = true;

                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                playerInRange = true;
                mySpriteRenderer.flipX = false;

            }
            

            if ((transform.position.y < target.position.y) && (Vector2.Distance(transform.position, target.position) < 7))
            {

                facingY = true;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                playerInRange = true;


            }
            else
            {
                facingY = false;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                playerInRange = true;


            }




        }
        else
        {
            playerInRange = false;
        }




        animationHandler.SetBool("FacingX", facingX);
        animationHandler.SetBool("FacingY", facingY);
        animationHandler.SetBool("IsPlayerNear", playerInRange);
        animationHandler.SetBool("AttackState", attackState);

    }

    public bool getAttackState()
    {
   
        return attackState;

    }

}
