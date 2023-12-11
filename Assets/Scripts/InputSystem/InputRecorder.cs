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

        public bool IsUpdateReplay;
        public bool IsFinishUpdate;
        
        public void RecordInput(CharacterInputAction _characterInputAction)
        {
            var _elapsedTime = ApplicationStarter.GameTime.ElapsedTime;
            var _recordInput = new InputRecordData(_elapsedTime, _characterInputAction);
            AllRecordedInputs.Add(_recordInput);
        }

        public void StartReplay()
        {
            IsUpdateReplay = true;
            IsFinishUpdate = false;
            currentRecordIndex = 0;
            currentInputRecordData = AllRecordedInputs.First();
            ApplicationStarter.GameTime.ResetTime().StartUpdate();
        }
        
        public void StopReplay ()
        {
            IsUpdateReplay = false;
            IsFinishUpdate = true;
            currentRecordIndex = 0;
            currentInputRecordData = null;
            //ApplicationStarter.GameTime.ResetTime().StopUpdate();
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
            if(!IsUpdateReplay || currentInputRecordData == null)
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
