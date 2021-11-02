using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManagement : MonoBehaviour
{
    public ParticleSystem fireBallRed;
    public ParticleSystem fireBallPurple;
    public ParticleSystem blueParticle;
    public Animation textAnimation;
    public float smoothValue = 2000.0f;

   
    void Start()
    {
        fireBallRed.Stop();
        fireBallPurple.Stop();
        blueParticle.Stop();
    }


    void Update()
    {
        // I made a fast timer here.
        PlayerController.instance.scoreAmount += 2*Time.deltaTime;
  
        
        //PlayerController.instance.scoreAmount = (int)PlayerController.instance.scoreAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireBallRedCollider"))
        {
            blueParticle.Play();
            StartCoroutine(OpenParticleSystemForRed()); // Timer for fireball
            PlayerController.instance.scoreAmount += 10;
           // PlayerController.instance.scoreAmount = Mathf.Lerp(PlayerController.instance.scoreAmount, PlayerController.instance.newScoreAmount, smoothValue*Time.deltaTime);
            //Mathf.Round(PlayerController.instance.scoreAmount);
            PlayerController.instance.coinText.GetComponent<Animator>().Play("TextAnimation"); // Text animation for a nice and soft/smooth image.
            

        }
        if (other.gameObject.CompareTag("FireBallPurpleCollider"))
        {
            StartCoroutine(OpenParticleSystemForPurple());
            PlayerController.instance.scoreAmount += 10;
            //PlayerController.instance.scoreAmount = Mathf.Lerp(PlayerController.instance.scoreAmount, PlayerController.instance.newScoreAmount, smoothValue * Time.deltaTime);
            //Mathf.Round(PlayerController.instance.scoreAmount);
            PlayerController.instance.coinText.GetComponent<Animator>().Play("TextAnimation");
            blueParticle.Play();
        }
    }

    IEnumerator OpenParticleSystemForRed()
    {
        //Timer for red fireball to work.
        fireBallRed.Play();
        yield return new WaitForSeconds(3.5f);
        fireBallRed.Stop();
    }

    IEnumerator OpenParticleSystemForPurple()
    {
        //Timer for purple fireball to work.
        fireBallPurple.Play();
        yield return new WaitForSeconds(3.5f);
        fireBallPurple.Stop();
    }
}
