using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
    public class Character : MonoBehaviour, IDisposable
    {
        public bool StandingLeftSide => TargetTransform.position.x < otherPlayer.TargetTransform.position.x;
        
        [field: SerializeField] public PlayerType     Type  { get; protected set; }
        [field: SerializeField] public CharacterState State { get; protected set; } = CharacterState.IDLE;
         
        [field: SerializeField] public float Health      { get; private set; } = 100f;
        [field: SerializeField] public float AttackRange { get; private set; } = 2;
        [field: SerializeField] public float MoveSpeed   { get; private set; } = 1f;

        public float RightSide => TargetTransform.position.x + TargetCollider.bounds.extents.x;
        public float LeftSide  => TargetTransform.position.x - TargetCollider.bounds.extents.x;

        public Transform   TargetTransform;
        public Animator    TargetAnimator;
        public BoxCollider TargetCollider;
        
        public StageData StageData;
        
        protected Character otherPlayer;
        
        public static Character[] AllCharacters = new Character[2];

        public bool IsActionProcess => processActionCoroutine != null;
        protected Coroutine processActionCoroutine;

        [SerializeField] private Vector3 originStandPosition;
        
        public Character()
        {
            
        }
        
        public virtual void Initialized()
        {
            switch (Type)
            {
                case PlayerType.PLAYER_ONE:
                    AllCharacters[0] = this;
                    break;
                case PlayerType.PLAYER_TWO:
                    AllCharacters[1] = this;
                    break;
            }
            
            originStandPosition = TargetTransform.position;
        }

        public void GetOtherPlayer()
        {
            otherPlayer = Type == PlayerType.PLAYER_ONE ? AllCharacters[1] : AllCharacters[0];
        }

        public virtual void Update()
        {
        }

        public void ResetPosition()
        {
            TargetTransform.position = originStandPosition;
        }

        public void ReduceHealth(float _value)
        {
            Health -= _value;
        }
        
        public virtual void MoveLeft(float _moveAmount)
        {
        }
        
        public virtual void MoveRight(float _moveAmount)
        {
        }

        public virtual void MoveLeft(InputAction.CallbackContext? _context = null)
        {
        }

        public virtual void MoveRight(InputAction.CallbackContext? _context = null)
        {
        }

        public virtual void Attack(InputAction.CallbackContext? _context = null)
        {
        }

        public virtual void Block(InputAction.CallbackContext? _context = null)
        {
        }
        
        public virtual void UnBlock(InputAction.CallbackContext? _context = null)
        {
        }

        public virtual void Evade(InputAction.CallbackContext? _context = null)
        {
        }
        
        public virtual void Jump(InputAction.CallbackContext? _context = null)
        {
        }
        
        public void Dispose()
        {
            AllCharacters[0] = null;
            AllCharacters[1] = null;
        }
    }
}
