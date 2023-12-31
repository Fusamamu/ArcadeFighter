using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
    public class PlayableCharacter : Character
    {
        public override void Update()
        {
            if (IsSprintingForward)
            {
                sprintTValue += sprintSpeed * Time.deltaTime;

                sprintTValue = Mathf.Clamp01(sprintTValue);

                TargetTransform.position = Vector3.Lerp(originPos, targetPos, sprintTValue);

                if (Math.Abs(sprintTValue - 1.0f) < 0.02f)
                {
                    sprintTValue = 0.0f;
                    
                    originPos = Vector3.zero;
                    targetPos = Vector3.zero;

                    if (StandingLeftSide)
                    {
                        TargetTransform.rotation = Quaternion.Euler(0, 90, 0);
                        otherPlayer.TargetTransform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else
                    {
                        TargetTransform.rotation = Quaternion.Euler(0, -90, 0);
                        otherPlayer.TargetTransform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    
                    IsSprintingForward = false;
                }
            }
        }
        
        public override void MoveLeft(float _moveAmount)
        {
            if(IsSprintingForward)
                return;
            
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
            TargetTransform.Translate(_direction * _moveAmount * Vector3.back * MoveSpeed * Time.deltaTime);
        }
        
        public override void MoveRight(float _moveAmount)
        {
            if(IsSprintingForward)
                return;
            
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

        public override void Attack(InputAction.CallbackContext? _context = null)
        {
            TargetAnimator.SetTrigger(punchTriggerProperty);
                
            if (Vector3.Distance(TargetTransform.position, otherPlayer.TargetTransform.position) < AttackRange)
            {
                if(otherPlayer.IsSprintingForward)
                    return;
                
                if (otherPlayer.IsGuarding)
                {
                    otherPlayer.TargetAnimator.SetTrigger(onBlockProperty);
                    otherPlayer.ReduceHealth(ChipDamage);
                    
                    if(otherPlayer.BlockEffect.isPlaying)
                        otherPlayer.BlockEffect.Stop();
                    otherPlayer.BlockEffect.Play();
                    
                    application.AudioManager.PlaySFX(SFXName.ONBLOCK);
                    return;
                }
                
                otherPlayer.TargetAnimator.SetTrigger(getPunchTriggerProperty);
                otherPlayer.ReduceHealth(AttackPower);
                
                if(otherPlayer.HitEffect.isPlaying)
                    otherPlayer.HitEffect.Stop();
                otherPlayer.HitEffect.Play();
                
                application.AudioManager.PlaySFX(SFXName.ONHIT);
                return;
            }
            
            application.AudioManager.PlaySFX(SFXName.ATTACK);
        }

        public override void Block(InputAction.CallbackContext? _context = null)
        {
            IsGuarding = true;
            if(!TargetAnimator.GetBool(guardProperty))
                TargetAnimator.SetBool(guardProperty, true);
        }
        
        public override void UnBlock(InputAction.CallbackContext? _context = null)
        {
            IsGuarding = false;
            if(TargetAnimator.GetBool(guardProperty))
                TargetAnimator.SetBool(guardProperty, false);
        }

        public override void Evade(InputAction.CallbackContext? _context = null)
        {
            TargetAnimator.ResetTrigger(evadeTriggerProperty);
            TargetAnimator.SetTrigger(evadeTriggerProperty);
            
            application.AudioManager.PlaySFX(SFXName.EVADE);
        }
        
        public override void EvadeSprintForward(InputAction.CallbackContext? _context = null)
        {
            if(IsSprintingForward)
                return;
            
            IsSprintingForward = true;

            originPos = TargetTransform.transform.position;
            
            if (StandingLeftSide)
                targetPos = originPos + new Vector3(3, 0, 0);
            else
                targetPos = originPos - new Vector3(3, 0, 0);
            
            TargetAnimator.ResetTrigger(sprintForwardTriggerProperty);
            TargetAnimator.SetTrigger(sprintForwardTriggerProperty);
            
            application.AudioManager.PlaySFX(SFXName.EVADE);
        }
        
        public override void Jump(InputAction.CallbackContext? _context = null)
        {
            TargetAnimator.SetTrigger(jumpTriggerProperty);
            
            application.AudioManager.PlaySFX(SFXName.JUMP);
        }
    }
}
