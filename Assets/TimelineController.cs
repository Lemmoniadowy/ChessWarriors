using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
 
 [SerializeField]
 PlayableDirector playableDirector;

 public void Play(float time)
 {
    playableDirector.time = time;
 }

}
