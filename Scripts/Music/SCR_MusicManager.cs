using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] musicClips;
    [SerializeField] private int currentTrack;
    private int maxTracks;
    private SCR_PlayerMovement movement;
    private SCR_CameraLook look;

    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject musicUI;
    [SerializeField] private GameObject pauseButton;

    [HideInInspector] public bool bSongChosen = false;

    void Start()
    {
        movement = player.GetComponent<SCR_PlayerMovement>();
        look = playerCam.GetComponent<SCR_CameraLook>();
        maxTracks = musicClips.Length - 1;
        currentTrack = musicClips.Length - 1;
    }

    void Update()
    {
        if(bSongChosen)
        {
            musicClips[currentTrack].Play();
            bSongChosen = false;
        }
    }

    public void NextSong()
    {
        if (currentTrack >= maxTracks)
        {
            ResetMusic();
            currentTrack = 0;
            bSongChosen = true;
        }
        else
        {
            ResetMusic();
            currentTrack++;
            bSongChosen = true;
        }
    }

    public void PreviousSong()
    {
        if (currentTrack <= 0)
        {
            ResetMusic();
            currentTrack = maxTracks;
            bSongChosen = true;
        }
        else
        {
            ResetMusic();
            currentTrack--;
            bSongChosen = true;
        }
    }

    public void RandomSong()
    {
        currentTrack = Random.Range(0, musicClips.Length);
        ResetMusic();
        musicClips[currentTrack].Play();
    }

    void ResetMusic()
    {
        for(int i = 0; i < musicClips.Length; i++)
        {
            musicClips[i].Stop();
        }
    }

    public void CloseMenu()
    {
        movement.enabled = true;
        look.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseButton.SetActive(true);
        musicUI.SetActive(false);
    }

    public void StopMusic()
    {
        ResetMusic();
    }
}
