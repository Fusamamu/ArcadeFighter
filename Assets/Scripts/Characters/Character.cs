using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
    public class Character : MonoBehaviour, IDisposable
    {
        [field: SerializeField] public PlayerType Type;
         
        [field: SerializeField] public float Health    { get; private set; } = 100f;
        [field: SerializeField] public float MoveSpeed { get; private set; } = 1f;

        [SerializeField] protected Transform TargetTransform;
        [SerializeField] protected Animator  TargetAnimator;

        public CharacterInputControl CharacterInputControl;

        public static List<Character> AllCharacters = new ();

        [SerializeField] private Vector3 originStandPosition;
        
        public Character()
        {
            
        }
        
        public virtual void Initialized()
        {
            if(!AllCharacters.Contains(this))
                AllCharacters.Add(this);
            
            originStandPosition = TargetTransform.position;
        }

        public virtual void Update()
        {
        }

        public void ResetPosition()
        {
            TargetTransform.position = originStandPosition;
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

        public virtual void Evade(InputAction.CallbackContext? _context = null)
        {
        }
        
        public void Dispose()
        {
            AllCharacters.Clear();
        }
    }
}
