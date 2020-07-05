using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{   
    private AudioSource audio;
    private Transform playerPos;
    public float speed;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       playerPos = GameObject.FindGameObjectWithTag("Player").transform;
       audio = animator.GetComponent<AudioSource>();
       audio.Play();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
       Debug.Log("Player:"+playerPos.position);
       Debug.Log("Mob:"+animator.transform.position);
       animator.transform.position = Vector2.MoveTowards(animator.transform.position,new Vector2(playerPos.position.x-34,animator.transform.position.y),speed*Time.deltaTime);
       if(Input.GetKeyDown(KeyCode.Space)){
           animator.SetBool("isAttacking",true);
       }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
