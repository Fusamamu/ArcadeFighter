using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
    public class PlayableCharacter : Character
    {
        private static readonly int walkForwardProperty     = Animator.StringToHash("Walk Forward");
        private static readonly int walkBackwardProperty    = Animator.StringToHash("Walk Backward");
        private static readonly int punchTriggerProperty    = Animator.StringToHash("PunchTrigger");
        private static readonly int guardProperty           = Animator.StringToHash("Guard");
        private static readonly int jumpTriggerProperty     = Animator.StringToHash("JumpTrigger");
        private static readonly int evadeTriggerProperty    = Animator.StringToHash("EvadeTrigger");
        private static readonly int getPunchTriggerProperty = Animator.StringToHash("GetPunchTrigger");

        public override void MoveLeft(float _moveAmount)
        {
            if (_moveAmount < 0.02f)
            {
                TargetAnimator.SetBool(walkForwardProperty, false);
                return;
            }
           
            if(!StandingLeftSide)
                if (LeftSide < otherPlayer.RightSide)
                    return;
            
            if (TargetTransform.position.x < StageData.LeftWall.position.x)
                return;

            int _direction = StandingLeftSide ? 1 : -1;
                
            TargetAnimator.SetBool(walkForwardProperty, true);
            TargetTransform.Translate(_direction *_moveAmount * Vector3.back * MoveSpeed * Time.deltaTime);
        }
        
        public override void MoveRight(float _moveAmount)
        {
            if (_moveAmount < 0.02f)
            {
                TargetAnimator.SetBool(walkBackwardProperty, false);
                return;
            }

            if (StandingLeftSide)
                if (RightSide > otherPlayer.LeftSide)
                    return;
            
            if (TargetTransform.position.x > StageData.RightWall.position.x)
                return;
            
            int _direction = StandingLeftSide ? 1 : -1;
            
            TargetAnimator.SetBool(walkBackwardProperty, true);
            TargetTransform.Translate(_direction * _moveAmount * Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        
        public override void MoveLeft(InputAction.CallbackContext? _context = null)
        {
        }

        public override void MoveRight(InputAction.CallbackContext? _context = null)
        {
        }

        public override void Attack(InputAction.CallbackContext? _context = null)
        {
            processActionCoroutine = StartCoroutine(AttackCoroutine());
        }

        public override void Block(InputAction.CallbackContext? _context = null)
        {
            if(!TargetAnimator.GetBool(guardProperty))
                TargetAnimator.SetBool(guardProperty, true);
        }
        
        public override void UnBlock(InputAction.CallbackContext? _context = null)
        {
            if(TargetAnimator.GetBool(guardProperty))
                TargetAnimator.SetBool(guardProperty, false);
        }

        public override void Evade(InputAction.CallbackContext? _context = null)
        {
            TargetAnimator.ResetTrigger(evadeTriggerProperty);
            TargetAnimator.SetTrigger(evadeTriggerProperty);
        }
        
        public override void Jump(InputAction.CallbackContext? _context = null)
        {
            processActionCoroutine = StartCoroutine(TriggerCoroutine(jumpTriggerProperty));
        }

        private IEnumerator TriggerCoroutine(int _propertyID, Action _onTriggerCompleted = null)
        {
            TargetAnimator.SetTrigger(_propertyID);
            yield return new WaitUntil(() => TargetAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
            yield return new WaitUntil(() => TargetAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
            _onTriggerCompleted?.Invoke();
            processActionCoroutine = null;
        }
        
        private IEnumerator AttackCoroutine()
        {
            TargetAnimator.SetTrigger(punchTriggerProperty);

            yield return new WaitUntil(() => TargetAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
                
            if (Vector3.Distance(TargetTransform.position, otherPlayer.TargetTransform.position) < AttackRange)
            {
                otherPlayer.TargetAnimator.SetTrigger(getPunchTriggerProperty);
                otherPlayer.ReduceHealth(10f);
            }

            processActionCoroutine = null;
        }
    }
}
