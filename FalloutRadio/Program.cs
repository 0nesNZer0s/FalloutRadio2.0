using RimWorld;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Verse;
using Verse.Sound;

public class MrNewVegasAudio
{
    private static bool shouldPlayMrNewVegasClip = false;
    private static List<string> mrNewVegasClips = new List<string>();

    public static void PlaySong(SongDef song)
    {
        if (song == null) return;

        MusicManagerPlay musicManager = Find.MusicManagerPlay;

        if (shouldPlayMrNewVegasClip)
        {
            // Select a random Mr. New Vegas audio clip
            AudioClip clip = GetRandomMrNewVegasClip();
            SoundInfo info = SoundInfo.OnCamera(MaintenanceType.None);
            LongEventHandler.ExecuteWhenFinished(delegate
            {
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            });
        }
        else
        {
            // Play the song
            musicManager.ForceStartSong(song, true);
        }

        // Toggle the flag for next time
        shouldPlayMrNewVegasClip = !shouldPlayMrNewVegasClip;
    }

    private static AudioClip GetRandomMrNewVegasClip()
    {
        string randomClipPath = mrNewVegasClips.RandomElement();
        return ContentFinder<AudioClip>.Get(randomClipPath);
    }
}
