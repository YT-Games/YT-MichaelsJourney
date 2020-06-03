# # Gamedev - Michael's Journey

Created by:

**Yotam dafna**

**Tomer hazan**

# Game description: 

This is a survival game, taking place on a deserted island in the heart of the ocean.

During the game, the player will have to deal with a number of challenges and tasks that will involve interacting with a variety of animals, and dealing with the challenges of nature.

<img width="886" alt="Island view from the start" src="https://user-images.githubusercontent.com/45067010/83530926-0e2d1600-a4f5-11ea-9faf-6c98227cee85.png">

# The world (island)

There are different types of components on the island, some that have an attraction with them, and some that do not interact and exist only for decor.

Components with no interaction:

* Sea

* Lakes

<img width="886" alt="Lake" src="https://user-images.githubusercontent.com/45067010/83531032-1f762280-a4f5-11ea-9583-a08257d08d80.png">

* Trees 

* Rocks

* Grass

* Mountains && Clouds.

<img width="886" alt="Mountains with Clouds" src="https://user-images.githubusercontent.com/45067010/83531072-2d2ba800-a4f5-11ea-8a36-be509f1154b0.png">

Components with which to interact:

* Animals (provide the resource food).

* Special rocks types (provide the resource stone).

* Special tree types (provide the resource wood).

# Boundaries

* Sea - the player will not be able to go deep into the sea.

* Rocks - Some of the boundaries will be huge rocks that the player will not be able to cross.

<img width="887" alt="Sea" src="https://user-images.githubusercontent.com/45067010/83531160-46ccef80-a4f5-11ea-99ba-8258a2352be2.png">

# The player

Capabilities - The player has the ability to jump, sprint, crouch, move right, move left, move straight and move back.

  In addition, the player can use one tool(Weapon) at the same time.

* Movement - to move with the player we will use the arrows on the keyboard.

* Sprint - to run fast with the player we will use the Shift on the keyboard.

* Crouch - to crouch with the player we will use the C on the keyboard.

* Jump - to jump with the player we will use space on the keyboard.

* tools(Weapons) - the player can swap tools(Weapons) by pressing the numbers on the keyboard.
  to attack with the player's tool, the player will have to press the left mouse button, and some weapons will have the option of zooming in
  
 * Look - with the mouse moving, the player can move his gaze in all directions.
 
 The player will have 3 metrics that he will have to maintain during the game:
 
 * HP
 
 * Hunger
 
 * Tiredness
 
 # Tools (Weapons)
 
 During the game, the player will be able to build and gain new tools.
 
 Every tool as its own dmg and range.
 
 Total weapons:
 
 * Axe
 
 <img width="940" alt="Weapons-Axe" src="https://user-images.githubusercontent.com/45067010/83531308-7aa81500-a4f5-11ea-9da0-4595dbd9e74e.png">
 
 * Revolver (pistol)
 
 <img width="940" alt="Weapons-Revolver" src="https://user-images.githubusercontent.com/45067010/83531591-dbcfe880-a4f5-11ea-8c0e-d3456a5f7420.png">
 
 <img width="941" alt="Weapons-Revolver-Aim" src="https://user-images.githubusercontent.com/45067010/83531598-e0949c80-a4f5-11ea-8650-b0a0fe3cd42b.png">
 
 * Wooden Bow
 
 <img width="942" alt="Weapons-Bow" src="https://user-images.githubusercontent.com/45067010/83531433-a7f4c300-a4f5-11ea-95b3-b0393c573811.png">
 
 <img width="943" alt="Weapons-Bow-Aim" src="https://user-images.githubusercontent.com/45067010/83531509-c064dd80-a4f5-11ea-86d4-6803d0580e37.png">
 
 * Wooden spear
 
 <img width="940" alt="Weapons-Spear" src="https://user-images.githubusercontent.com/45067010/83531742-05890f80-a4f6-11ea-889e-d8c24c9031db.png">
 
 <img width="941" alt="Weapons-Spear-Aim" src="https://user-images.githubusercontent.com/45067010/83531757-0752d300-a4f6-11ea-903a-b96ea1a43f8a.png">
 
 # Animals
 
There are different types of animals that some will interact with the player and some will not.

Each animal has a component called "Enemy Animator" that afterwards performs the animations according to the game situation:

* idle

* walk/fly

* run

* attack

There is no  interaction (Part of the decor of the game):
 
 * Eagle
 
 There is interaction:
 
 * Tiger - data - life points (HP) , attack dmg points (dmg)
 
 <img width="485" alt="Tiger" src="https://user-images.githubusercontent.com/45067010/83531239-619f6400-a4f5-11ea-8b6c-db0617d35b4f.png">

 * Boar - data - life points (HP) , attack dmg points (dmg)
 
 <img width="483" alt="Boar" src="https://user-images.githubusercontent.com/45067010/83530786-e342c200-a4f4-11ea-95d7-fb0aa25170a5.png">
 
 # Resources
 
 With the resources, the player can build tools or other things to help him during the game.
 
 There will be 3 resources in the game:
 
 * food
 
 * stone
 
 * wood
 
 # Audio
 
 The game has background music, and sounds that will be played during a particular action:
 
 * Sea - when the player is at a certain distance from the sea he will hear wave sounds.
 
 * Footsteps - when the player walk he will hear footsteps sounds.
 
 # Link to ITCH.IO
 
 [Michael's Journey - Game](https://yotamd.itch.io/michaels-journey)
 
 # Codes
 
 * Player movement script:
 
  ```
  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_Controller;
    private Vector3 move_Direction;

    public float speed = 5f;
    private float gravity = 20f;

    public float jump_Force = 10f;
    private float vertical_velocity;

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveThePlayer();
    }
    void MoveThePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        ApplyGravity();

        character_Controller.Move(move_Direction);
    }

    void ApplyGravity()
    {
        vertical_velocity -= gravity * Time.deltaTime;

        PlayerJump();

        move_Direction.y = vertical_velocity * Time.deltaTime;
    }


    void PlayerJump()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_velocity = jump_Force;
        }
    }
}
 ```
 
 * Player sprint & crouch script:
 
 ```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public float sprint_Speed = 10f;
    public float move_Speed = 5f;
    public float crouch_Speed = 2f;

    private Transform look_root;
    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;

    private bool is_Crouching;

    private PlayerFootsteps player_Footsteps;

    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_Min = 0.2f, walk_Volume_Max = 0.6f;

    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        look_root = transform.GetChild(0);
        player_Footsteps = GetComponentInChildren<PlayerFootsteps>();
    }

    void Start()
    {
        player_Footsteps.volume_Min = walk_Volume_Min;
        player_Footsteps.volume_Min = walk_Volume_Max;
        player_Footsteps.step_Distance = walk_Step_Distance;
    }

    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovement.speed = sprint_Speed;

            player_Footsteps.step_Distance = sprint_Step_Distance;
            player_Footsteps.volume_Min = sprint_Volume;
            player_Footsteps.volume_Max = sprint_Volume;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovement.speed = move_Speed;

            player_Footsteps.step_Distance = walk_Step_Distance;
            player_Footsteps.volume_Min = walk_Volume_Min;
            player_Footsteps.volume_Min = walk_Volume_Max;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (is_Crouching)
            {
                look_root.localPosition = new Vector3(0f, stand_Height, 0f);
                playerMovement.speed = move_Speed;

                player_Footsteps.step_Distance = walk_Step_Distance;
                player_Footsteps.volume_Min = walk_Volume_Min;
                player_Footsteps.volume_Min = walk_Volume_Max;


                is_Crouching = false;
            }
            else
            {
                look_root.localPosition = new Vector3(0f, crouch_Height, 0f);
                playerMovement.speed = crouch_Speed;

                player_Footsteps.step_Distance = crouch_Step_Distance;
                player_Footsteps.volume_Min = crouch_Volume;
                player_Footsteps.volume_Min = crouch_Volume;

                is_Crouching = true;
            }
        }
    }
}

 ```
 
 * Mouse Look script:
 
 ```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool can_Unlock = true;

    [SerializeField]
    private float sensitivity = 5f;

    [SerializeField]
    private int smooth_Steps = 10;

    [SerializeField]
    private float smooth_Weight = 0.4f;

    [SerializeField]
    private float roll_Angle = 10f;

    [SerializeField]
    private float roll_Speed = 3f;

    [SerializeField]
    private Vector2 default_Look_Limits = new Vector2(-70f, 80f);

    private Vector2 look_Angles;

    private Vector2 current_Mouse_Look;
    private Vector2 smooth_Move;

    private float current_Roll_Angle;

    private int last_Look_Frame;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LockAndUnlockCursor();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }

    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void LookAround()
    {
        current_Mouse_Look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_Angles.x += current_Mouse_Look.x * sensitivity * (invert ? 1f : -1f);
        look_Angles.y += current_Mouse_Look.y * sensitivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x, default_Look_Limits.x, default_Look_Limits.y);

        current_Roll_Angle = Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X)
            * roll_Angle, Time.deltaTime * roll_Speed);

        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, 0f, current_Roll_Angle);
        playerRoot.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);
    }
}
 ```
 
 * Enemy Controller script - Responsible for enemy control (AI):
 ```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private EnemyAnimator enemyAnim;
    private NavMeshAgent navAgent;

    private EnemyState enemyState;

    public float walkSpeed = 0.5f;
    public float runSpeed = 4f;

    public float chase_Distance = 7f;
    private float current_Chase_Distance;
    public float attack_Distance = 1.8f;
    public float chase_After_Attack_Distance = 2f;

    public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
    public float patrol_For_This_Time = 15f;
    private float patrol_Timer;

    public float wait_Before_Attack = 2f;
    private float attack_Timer;

    private Transform target;

    private void Awake()
    {
        enemyAnim = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    void Start()
    {
        enemyState = EnemyState.PATROL;

        patrol_Timer = patrol_For_This_Time;

        attack_Timer = wait_Before_Attack; // when the enemy first gets to the player, attack right away

        current_Chase_Distance = chase_Distance; // memorize the value of chase distance so we can put it back
    }

    void Update()
    {
        if (enemyState == EnemyState.PATROL)
        {
            Patrol();
        }
        if (enemyState == EnemyState.CHASE)
        {
            Chase();
        }
        if (enemyState == EnemyState.ATTACK)
        {
            Attack();
        }
    }

    void Patrol()
    {
        navAgent.isStopped = false; // tell nav agent that he can move
        navAgent.speed = walkSpeed;

        patrol_Timer += Time.deltaTime;

        if (patrol_Timer > patrol_For_This_Time)
        {
            SetNewRandomDestination();

            patrol_Timer = 0f;
        }

        if (navAgent.velocity.sqrMagnitude > 0)
        {
            enemyAnim.Walk(true);
        }
        else
        {
            enemyAnim.Walk(false);
        }
        // tests the distance between the player and the enemy
        if (Vector3.Distance(transform.position, target.position) <= chase_Distance)
        {
            enemyAnim.Walk(false);

            enemyState = EnemyState.CHASE;

            // play spotted audio

        }
    }

    void Chase()
    {
        navAgent.isStopped = false; // enable the agent to move again
        navAgent.speed = runSpeed;

        navAgent.SetDestination(target.position); // set the player's position as the destination

        if (navAgent.velocity.sqrMagnitude > 0)
        {
            enemyAnim.Run(true);
        }
        else
        {
            enemyAnim.Run(false);
        }
        // if the distance between the enemy and the player is less than the attack distance
        if (Vector3.Distance(transform.position, target.position) <= attack_Distance)
        {
            enemyAnim.Run(false);
            enemyAnim.Walk(false);
            enemyState = EnemyState.ATTACK;

            if (chase_Distance != current_Chase_Distance)
            {
                chase_Distance = current_Chase_Distance;
            }
        }
        else if (Vector3.Distance(transform.position, target.position) > chase_Distance)
        { //player run from the enemy
            enemyAnim.Run(false);
            enemyState = EnemyState.PATROL;

            patrol_Timer = patrol_For_This_Time;

            if (chase_Distance != current_Chase_Distance)
            {
                chase_Distance = current_Chase_Distance;
            }

        }
        {

        }
    }

    void Attack()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        attack_Timer += Time.deltaTime;

        if (attack_Timer > wait_Before_Attack)
        {
            enemyAnim.Attack();

            attack_Timer = 0f;

            // play attack sound
        }

        if (Vector3.Distance(transform.position, target.position) > attack_Distance + chase_After_Attack_Distance)
        {
            enemyState = EnemyState.CHASE;
        }
    }

    void SetNewRandomDestination()
    {
        float random_Radius = Random.Range(patrol_Radius_Min, patrol_Radius_Max);

        Vector3 randDir = Random.insideUnitSphere * random_Radius;
        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, random_Radius, -1);

        navAgent.SetDestination(navHit.position);
    }

}
 ```
