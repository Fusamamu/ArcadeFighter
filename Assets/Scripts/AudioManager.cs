using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
	public enum SFXName
	{
		ATTACK,
		ONHIT,
		ONBLOCK,
		WALK, 
		JUMP,
		EVADE
	}

	[Serializable]
	public class SoundData
	{
		public SFXName Name;
		public AudioClip AudioClip;
	}
	
	[Serializable]
	public class AudioManager
	{
		[SerializeField] private AudioSource SFXSource;
		[SerializeField] private AudioSource BGMSource;

		public List<SoundData> AllSoundData = new List<SoundData>();

	    public ApplicationStarter ApplicationStarter { get; private set; }

	    private Dictionary<SFXName, AudioClip> soundDataTable = new ();

	    public void Initialized(ApplicationStarter _applicationStarter)
	    {
		    ApplicationStarter = _applicationStarter;

		    foreach (var _data in AllSoundData)
			    soundDataTable.Add(_data.Name, _data.AudioClip);
	    }

	    public void PlayBGM()
	    {
		    BGMSource.Play();
	    }

	    public void StopPlayBGM()
	    {
		    BGMSource.Stop();
	    }

	    public void PlaySFX(SFXName _name)
	    {
		    if (soundDataTable.TryGetValue(_name, out var _audioClip))
		    {
			    if(SFXSource.isPlaying)
				    SFXSource.Stop();
			    
			    SFXSource.PlayOneShot(_audioClip);
		    }
	    }
	}
}
