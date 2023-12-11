using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public class InputRecorder
    {
        public List<InputRecordData> AllRecordedInputs = new ();

        [SerializeField] private int currentRecordIndex;
        [SerializeField] private InputRecordData currentInputRecordData;

        private bool isUpdateReplay;
        
        public void RecordInput(CharacterInputAction _characterInputAction)
        {
            var _elapsedTime = ApplicationStarter.GameTime.ElapsedTime;
            var _recordInput = new InputRecordData(_elapsedTime, _characterInputAction);
            AllRecordedInputs.Add(_recordInput);
        }

        public void StartReplay()
        {
            isUpdateReplay = true;
            currentRecordIndex = 0;
            currentInputRecordData = AllRecordedInputs.First();
            ApplicationStarter.GameTime.ResetTime().StartUpdate();
        }
        
        public void StopReplay ()
        {
            isUpdateReplay = false;
            currentRecordIndex = 0;
            currentInputRecordData = null;
            ApplicationStarter.GameTime.ResetTime().StopUpdate();
        }

        private bool TryGetNextRecordData(int _currentIndex, out InputRecordData _data)
        {
            var _nextIndex = _currentIndex + 1;
            
            if (_nextIndex < AllRecordedInputs.Count)
            {
                _data = AllRecordedInputs[_nextIndex];
                return true;
            }

            _data = null;
            return false;
        }

        public void UpdateReplay()
        {
            if(!isUpdateReplay || currentInputRecordData == null)
                return;
            
            var _elapsedTime = ApplicationStarter.GameTime.ElapsedTime;
            if (_elapsedTime <= AllRecordedInputs.First().TimeStamp)
                return;

            if (!TryGetNextRecordData(currentRecordIndex, out var _nextRecordData))
            {
                if(currentInputRecordData.InputType == InputType.PRESSHOLD)
                    if (!currentInputRecordData.IsPressed)
                        currentInputRecordData.CharacterInputAction.RunReleasedActionCommand();
                
                if(currentInputRecordData.InputType == InputType.CLICK)
                    if (!currentInputRecordData.HasTriggered)
                        currentInputRecordData.CharacterInputAction.RunPressedActionCommand();
                
                StopReplay();
                return;
            }
            
            if (_elapsedTime < _nextRecordData.TimeStamp)
            {
                switch(currentInputRecordData.InputType)
                {
                    case InputType.PRESSHOLD:
                        if (currentInputRecordData.IsPressed)
                            currentInputRecordData.CharacterInputAction.RunPressedActionCommand();
                        else
                            currentInputRecordData.CharacterInputAction.RunReleasedActionCommand();
                        break;
                    case InputType.CLICK:
                        if (!currentInputRecordData.HasTriggered)
                        {
                            currentInputRecordData.CharacterInputAction.RunPressedActionCommand();
                            currentInputRecordData.HasTriggered = true;
                        }
                        break;
                }
            }
            else
            {
                currentInputRecordData.HasTriggered = false;
                currentInputRecordData = _nextRecordData;
                currentRecordIndex++;
            }
        }

        public void ClearInputRecord()
        {
            AllRecordedInputs.Clear();
        }
    }
}


// using System;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
//
// namespace ArcadeFighter
// {
//     [Serializable]
//     public class InputRecorder
//     {
//         //public List<InputRecordData> AllRecordedInputs = new ();
//
//         
//         
//             //[SerializeField] private int currentRecordIndex;
//         //[SerializeField] private InputRecordData currentInputRecordData;
//
//         
//         
//
//         
//         [SerializeField] private int playerOneRecordIndex;
//         [SerializeField] private InputRecordData currentPlayerOneInputRecordData;
//         
//         [SerializeField] private int playerTwoRecordIndex;
//         [SerializeField] private InputRecordData currentPlayerTwoInputRecordData;
//         
//         private bool isUpdateReplay;
//         
//         private Dictionary<PlayerType, List<InputRecordData>> inputRecordDataTable = new ();
//         
//         public void RecordInput(CharacterInputAction _characterInputAction)
//         {
//             var _elapsedTime = ApplicationStarter.GameTime.ElapsedTime;
//             var _recordInput = new InputRecordData(_elapsedTime, _characterInputAction);
//
//             var _type = _characterInputAction.TargetCharacter.Type;
//             
//             if (inputRecordDataTable.ContainsKey(_type))
//                 inputRecordDataTable[_type].Add(_recordInput);
//             else
//                 inputRecordDataTable.Add(_type, new List<InputRecordData> { _recordInput });
//         }
//
//         public void StartReplay()
//         {
//             isUpdateReplay = true;
//
//             playerOneRecordIndex = 0;
//             playerTwoRecordIndex = 0;
//
//             currentPlayerOneInputRecordData = inputRecordDataTable[PlayerType.PLAYER_ONE].First();
//             currentPlayerTwoInputRecordData = inputRecordDataTable[PlayerType.PLAYER_TWO].First();
//             
//             ApplicationStarter.GameTime.ResetTime().StartUpdate();
//         }
//         
//         public void StopReplay ()
//         {
//             isUpdateReplay = false;
//             
//             playerOneRecordIndex = 0;
//             playerTwoRecordIndex = 0;
//
//             currentPlayerOneInputRecordData = null;
//             currentPlayerTwoInputRecordData = null;
//             
//             ApplicationStarter.GameTime.ResetTime().StopUpdate();
//         }
//
//         // private bool TryGetNextRecordData(int _currentIndex, out InputRecordData _data)
//         // {
//         //     var _nextIndex = _currentIndex + 1;
//         //     
//         //     if (_nextIndex < AllRecordedInputs.Count)
//         //     {
//         //         _data = AllRecordedInputs[_nextIndex];
//         //         return true;
//         //     }
//         //
//         //     _data = null;
//         //     return false;
//         // }
//         
//         private bool TryGetNextRecordData(PlayerType _playerType, int _currentIndex, out InputRecordData _data)
//         {
//             var _nextIndex = _currentIndex + 1;
//
//             if (inputRecordDataTable.TryGetValue(_playerType, out var _recordInputs))
//             {
//                 if (_nextIndex < _recordInputs.Count)
//                 {
//                     _data = _recordInputs[_nextIndex];
//                     return true;
//                 }
//             }
//
//             _data = null;
//             return false;
//         }
//
//         public void UpdateReplay()
//         {
//             if(!isUpdateReplay)
//                 return;
//             
//             RunInputRecordData(PlayerType.PLAYER_ONE, ref playerOneRecordIndex, ref currentPlayerOneInputRecordData);
//         }
//
//         public void RunInputRecordData(PlayerType _playerType, ref int _recordIndex, ref InputRecordData _inputRecordData)
//         {
//             if(_inputRecordData == null)
//                 return;
//             
//             var _elapsedTime = ApplicationStarter.GameTime.ElapsedTime;
//             if (_elapsedTime <= inputRecordDataTable[_playerType].First().TimeStamp)
//                 return;
//             
//             if (!TryGetNextRecordData(_playerType, _recordIndex, out var _nextRecordData))
//             {
//                 if(_inputRecordData.InputType == InputType.PRESSHOLD)
//                     if (!_inputRecordData.IsPressed)
//                         _inputRecordData.CharacterInputAction.RunReleasedActionCommand();
//                 
//                 if(_inputRecordData.InputType == InputType.CLICK)
//                     if (!_inputRecordData.HasTriggered)
//                         _inputRecordData.CharacterInputAction.RunPressedActionCommand();
//                 
//                 StopReplay();
//                 return;
//             }
//             
//             if (_elapsedTime < _nextRecordData.TimeStamp)
//             {
//                 switch(_inputRecordData.InputType)
//                 {
//                     case InputType.PRESSHOLD:
//                         if (_inputRecordData.IsPressed)
//                             _inputRecordData.CharacterInputAction.RunPressedActionCommand();
//                         else
//                             _inputRecordData.CharacterInputAction.RunReleasedActionCommand();
//                         break;
//                     case InputType.CLICK:
//                         if (!_inputRecordData.HasTriggered)
//                         {
//                             _inputRecordData.CharacterInputAction.RunPressedActionCommand();
//                             _inputRecordData.HasTriggered = true;
//                         }
//                         break;
//                 }
//             }
//             else
//             {
//                 _inputRecordData.HasTriggered = false;
//                 _inputRecordData = _nextRecordData;
//                 _recordIndex++;
//             }
//         }
//
//         public void ClearInputRecord()
//         {
//             //AllRecordedInputs.Clear();
//             inputRecordDataTable.Clear();
//         }
//     }
// }
