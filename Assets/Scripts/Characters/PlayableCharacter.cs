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
        private static readonly int walkForwardProperty  = Animator.StringToHash("Walk Forward");
        private static readonly int walkBackwardProperty = Animator.StringToHash("Walk Backward");
        private static readonly int punchProperty        = Animator.StringToHash("PunchTrigger");
        private static readonly int guardProperty        = Animator.StringToHash("Guard");

        public override void MoveLeft(float _moveAmount)
        {
            if (_moveAmount < 0.02f)
            {
                TargetAnimator.SetBool(walkForwardProperty, false);
                return;
            }
                
            TargetAnimator.SetBool(walkForwardProperty, true);
            TargetTransform.Translate(_moveAmount * Vector3.back * MoveSpeed * Time.deltaTime);
        }
        
        public override void MoveRight(float _moveAmount)
        {
            if (_moveAmount < 0.02f)
            {
                TargetAnimator.SetBool(walkBackwardProperty, false);
                return;
            }
            TargetAnimator.SetBool(walkBackwardProperty, true);
            TargetTransform.Translate(_moveAmount * Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        
        public override void MoveLeft(InputAction.CallbackContext? _context = null)
        {
        }

        public override void MoveRight(InputAction.CallbackContext? _context = null)
        {
        }

        public override void Attack(InputAction.CallbackContext? _context = null)
        {
            TargetAnimator.ResetTrigger(punchProperty);
            TargetAnimator.SetTrigger(punchProperty);
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
        }
    }
}
