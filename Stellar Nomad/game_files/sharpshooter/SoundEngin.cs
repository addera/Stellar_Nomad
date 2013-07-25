using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;
using Microsoft.DirectX.DirectSound;
using System.Drawing;


namespace sharpshooter
{
    public class SoundEngin
    {

        public Device dSound;
        public BufferDescription bufferDescription;
        public Audio bgm;
        public bool bgmPlaying = false;
        public List<SecondaryBuffer> soundList = new List<SecondaryBuffer>();

        public SoundEngin(MainForm mainForm)
        {
            dSound = new Device();
            dSound.SetCooperativeLevel(mainForm.Handle, CooperativeLevel.Priority);
            bufferDescription = new BufferDescription();
            bufferDescription.ControlVolume = true;

        }

        public void playSound(String filename, PointF location)
        {
            for (int i = 0; i < soundList.Count; i++)
            {
                if (soundList[i].Status.Playing == false)
                {
                    soundList[i].Dispose();
                    soundList.RemoveAt(i);
                }
            }

            SecondaryBuffer sound = new SecondaryBuffer(filename, bufferDescription, dSound);
            soundList.Add(sound);

            sound.Volume -= (int)(Math.Abs(MainForm.Player1.location.X - location.X) + Math.Abs(MainForm.Player1.location.Y - location.Y)) * 2;
        }

        public void playBGM(String filename)
        {
            if (bgmPlaying == true)
            {
                return;
            }

            bgm = new Audio(filename);
            bgm.Play();
            bgm.Ending += new EventHandler(bgm_Ending);
            bgmPlaying = true;
        }

        void bgm_Ending(object Sender, EventArgs e)
        {
            bgm.SeekCurrentPosition(0.0, SeekPositionFlags.AbsolutePositioning);
        }

        public void stopBGM()
        {
            bgmPlaying = false;
            bgm.Stop();
        }
    }
}
