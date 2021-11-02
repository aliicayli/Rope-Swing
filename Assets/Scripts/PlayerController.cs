using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public static PlayerController instance;

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] public LineRenderer lineRenderer;
    [SerializeField] private float swinningSpeed;
    public GameObject finishPanel;

    public LayerMask grappleLayer;
    private Vector3 ropePoint;
    private bool isStarted;
    private bool isSwinning;

    public Text coinText;
    public float scoreAmount;
    public int newScoreAmount;

  



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
     
        rigidBody.useGravity = false;
        lineRenderer.enabled = true;
        isStarted = false;

        // I set the point for the movement.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit))
        {
            ropePoint = hit.point;
        }

        // Starting movement
        StartCoroutine(InitialSwing());

       
       


    }



    private void Update()
    {

        

            if (Input.GetMouseButtonDown(0))
            {
                StartSwinning();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopSwinning();
            }

            // If the oscillation continues
            else if (isSwinning || !isStarted)
            {
                // It was drown a new rope.
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, ropePoint);

                // ??
                rigidBody.velocity = Vector3.Cross(-transform.right, (transform.position - ropePoint).normalized) * swinningSpeed;
            }

        coinText.text = scoreAmount.ToString("0");
        
    }
    private void StopSwinning()
    {
        //When exiting the swinning , I enabled the gravity.
        isSwinning = false;
        rigidBody.useGravity = true;
        lineRenderer.enabled = false;
    }

    private void StartSwinning()
    {
        //When in state of the swinning, I removed the gravity.
        isSwinning = true;
        lineRenderer.enabled = true;
        rigidBody.useGravity = false; 


        if (!isStarted)
        {
            isStarted = true;
        }
        else
        {
            // Cast a ray to forward/up
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward + transform.up, out hit, grappleLayer))
            {
                // Build line to next move
                ropePoint = hit.point;
            }
        }
    }


  
    // I used Mathf.PingPong fuction for oscillation movement.
    private IEnumerator InitialSwing()
    {
        // We discard the original speed value.
        float initialSpeed = swinningSpeed;
        float timeSpent = 0;

        while (!isStarted)
        {
            // Adjusting the swing rate
            swinningSpeed = Mathf.PingPong(timeSpent * initialSpeed, initialSpeed * 2) ;
            timeSpent += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        //Because the swinning is over, I returned the initial speed value.
        swinningSpeed = initialSpeed;
    }
 




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.CompareTag("finish"))
        {
           // finishPanel.GetComponent<Animator>().Play("FinishAnimation");
            finishPanel.SetActive(true);
        }

        //if (other.gameObject.CompareTag("ColorChanger"))
        //{
        //    ColorCycler.instance.shouldChange = true;
        //}
    }

    



}

