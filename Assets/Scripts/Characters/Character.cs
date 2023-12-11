using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
    public class Character : MonoBehaviour, IDisposable
    {
        public bool StandingLeftSide => TargetTransform.position.x < otherPlayer.TargetTransform.position.x;
        
        [field: SerializeField] public PlayerType Type  { get; protected set; }
         
        [field: Header("Character Attributes")]
        [field: SerializeField] public float Health      { get; private set; } = 100f;
        [field: SerializeField] public float AttackRange { get; private set; } = 2;
        [field: SerializeField] public float AttackPower { get; private set; } = 12f;
        [field: SerializeField] public float ChipDamage  { get; private set; } = 5f;
        [field: SerializeField] public float MoveSpeed   { get; private set; } = 1f;
        [field: SerializeField] public ParticleSystem HitEffect   { get; private set; }
        [field: SerializeField] public ParticleSystem BlockEffect { get; private set; }
        
        [Header("Evade Sprint Forward Parameter")]
        [SerializeField] protected Vector3 originPos;
        [SerializeField] protected Vector3 targetPos;
        [SerializeField] protected float sprintSpeed = 0.5f;
        [SerializeField] protected float sprintTValue;

        [field: SerializeField] public bool IsGuarding         { get; protected set; }
        [field: SerializeField] public bool IsSprintingForward { get; protected set; }

        public float RightSide => TargetTransform.position.x + TargetCollider.bounds.extents.x;
        public float LeftSide  => TargetTransform.position.x - TargetCollider.bounds.extents.x;

        public Transform   TargetTransform;
        public Animator    TargetAnimator;
        public BoxCollider TargetCollider;
        
        public StageData StageData;
        
        [Header("Game Character refs")]
        protected Character otherPlayer;
        public static Character[] AllCharacters = new Character[2];
        public static Character PlayerOne => AllCharacters[0];
        public static Character PlayerTwo => AllCharacters[1];

        [Header("Cached origin transform value")]
        [ReadOnly, SerializeField] private Vector3    originStandPosition;
        [ReadOnly, SerializeField] private Quaternion originRotation;

        public UnityEvent<float> OnGetHitEvent;

        protected ApplicationStarter application;
        
        protected static readonly int walkForwardProperty          = Animator.StringToHash("Walk Forward");
        protected static readonly int walkBackwardProperty         = Animator.StringToHash("Walk Backward");
        protected static readonly int punchTriggerProperty         = Animator.StringToHash("PunchTrigger");
        protected static readonly int guardProperty                = Animator.StringToHash("Guard");
        protected static readonly int jumpTriggerProperty          = Animator.StringToHash("JumpTrigger");
        protected static readonly int evadeTriggerProperty         = Animator.StringToHash("EvadeTrigger");
        protected static readonly int getPunchTriggerProperty      = Animator.StringToHash("GetPunchTrigger");
        protected static readonly int getKoTriggerProperty         = Animator.StringToHash("GetKOTrigger");
        protected static readonly int resetIdleTriggerProperty     = Animator.StringToHash("ResetIdle");
        protected static readonly int onBlockProperty              = Animator.StringToHash("OnBlock");
        protected static readonly int sprintForwardTriggerProperty = Animator.StringToHash("SprintForwardTrigger");

        public Character()
        {
            
        }
        
        public virtual void Initialized(ApplicationStarter _application)
        {
            application = _application;
            
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
            originRotation      = TargetTransform.rotation;
        }

        public void GetOtherPlayer()
        {
            otherPlayer = Type == PlayerType.PLAYER_ONE ? AllCharacters[1] : AllCharacters[0];
        }

        public virtual void Update()
        {
        }

        public void ResetHealth   () => Health = 100f;
        public void ResetAnimation() => TargetAnimator.Rebind();
        public void ResetPosition () => TargetTransform.position = originStandPosition;
        public void ResetRotation () => TargetTransform.rotation = originRotation;

        public void ReduceHealth(float _value)
        {
            Health -= _value;
            
            if (Health <= 0f)
            {
                Health = 0;
                TargetAnimator.SetTrigger(getKoTriggerProperty);
                application.StateMachineManager.ChangeState<GameOverState>();
            }
            
            OnGetHitEvent?.Invoke(Health / 100f);
        }
        
        public virtual void MoveLeft(float _moveAmount)
        {
        }
        
        public virtual void MoveRight(float _moveAmount)
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
        
        public virtual void EvadeSprintForward(InputAction.CallbackContext? _context = null)
        {
        }
        
        public virtual void Jump(InputAction.CallbackContext? _context = null)
        {
        }
        
        public void Dispose()
        {
            AllCharacters[0] = null;
            AllCharacters[1] = null;
            
            OnGetHitEvent.RemoveAllListeners();
        }
    }
}
