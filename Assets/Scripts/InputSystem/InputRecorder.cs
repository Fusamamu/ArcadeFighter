using System;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public class InputRecorder
    {
        public List<InputRecordData> AllRecordedInputs = new List<InputRecordData>();

        public void RecordInput(CharacterInputAction _characterInputAction)
        {
            var _recordInput = new InputRecordData(Time.time, _characterInputAction);
            AllRecordedInputs.Add(_recordInput);
        }

        public void ReplayRecord()
        {
            
        }

        public void ClearInputRecord()
        {
            AllRecordedInputs.Clear();
        }
    }
}
