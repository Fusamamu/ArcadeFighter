using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public class InputRecorder
    {
        private List<InputRecordData> AllRecordedInputs = new ();

        [SerializeField] private int currentRecordIndex;
        [SerializeField] private InputRecordData currentInputRecordData;

        private bool isUpdateReplay;

        private bool hasAlreadyTriggerred;
        
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
            if(!isUpdateReplay)
                return;
            
            var _elapsedTime = ApplicationStarter.GameTime.ElapsedTime;
            
            if (_elapsedTime <= AllRecordedInputs.First().TimeStamp)
                return;
            
            if (currentInputRecordData == null)
                return;

            if (!TryGetNextRecordData(currentRecordIndex, out var _nextRecordData))
            {
                if(!currentInputRecordData.IsPressed)
                    currentInputRecordData.CharacterInputAction.RunReleasedActionCommand();
                StopReplay();
                return;
            }

            if (_elapsedTime < _nextRecordData.TimeStamp)
            {
                if (!currentInputRecordData.IsTriggerred)
                {
                    if (currentInputRecordData.IsPressed)
                        currentInputRecordData.CharacterInputAction.RunPressedActionCommand();
                    else
                        currentInputRecordData.CharacterInputAction.RunReleasedActionCommand();
                }
                else
                {
                    hasAlreadyTriggerred = true;
                    if(hasAlreadyTriggerred)
                        return;
                    
                    currentInputRecordData.CharacterInputAction.RunPressedActionCommand();
                }
            }
            else
            {
                hasAlreadyTriggerred = false;
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
