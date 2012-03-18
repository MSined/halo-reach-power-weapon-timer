using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System.IO;

namespace Halo_Timer
{
    public class PlaySoundFiles
    {
        #region Initialization
        SoundEffect sniperGrenadeWarning;
        SoundEffect sniperGrenadeSpawn;
        SoundEffect rocketWarning;
        SoundEffect rocketSpawn;
        SoundEffect sniperWarning;
        SoundEffect sniperSpawn;
        SoundEffect grenadeWarning;
        SoundEffect grenadeSpawn;
        SoundEffect swordWarning;
        SoundEffect swordSpawn;
        SoundEffect customWarning;
        SoundEffect customSpawn;
        SoundEffect allWarning;
        SoundEffect allSpawn;
        Stream stream;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PlaySoundFiles()
        {
            stream = TitleContainer.OpenStream("Sounds/03Sniper-Grenade-Warning.wav");
            sniperGrenadeWarning = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/01Sniper-Grenade-Spawn.wav");
            sniperGrenadeSpawn = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/04Rocket-Warning.wav");
            rocketWarning = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/02Rocket-Spawn.wav");
            rocketSpawn = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/09Sniper-Warning.wav");
            sniperWarning = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/10Sniper-Spawn.wav");
            sniperSpawn = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/08Grenade-Warning.wav");
            grenadeWarning = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/07Grenade-Spawn.wav");
            grenadeSpawn = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/05Sword-Warning.wav");
            swordWarning = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/06Sword-Spawn.wav");
            swordSpawn = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/03Custom-Powerup-Warning.wav");
            customWarning = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/04Custom-Powerup-Spawn.wav");
            customSpawn = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/01All-Warning.wav");
            allWarning = SoundEffect.FromStream(stream);

            stream = TitleContainer.OpenStream("Sounds/02All-Spawn.wav");
            allSpawn = SoundEffect.FromStream(stream);

            FrameworkDispatcher.Update();
        }

        #region PlayMethods
        public void playSniperGrenadeWarning()
        {
            sniperGrenadeWarning.Play();
        }

        public void playSniperGrenadeSpawn()
        {
            sniperGrenadeSpawn.Play();
        }

        public void playRocketWarning()
        {
            rocketWarning.Play();
        }
        public void playRocketSpawn()
        {
            rocketSpawn.Play();
        }

        public void playSniperWarning()
        {
            sniperWarning.Play();
        }
        public void playSniperSpawn()
        {
            sniperSpawn.Play();
        }
        public void playGrenadeWarning()
        {
            grenadeWarning.Play();
        }
        public void playGrenadeSpawn()
        {
            grenadeSpawn.Play();
        }
        public void playSwordWarning()
        {
            swordWarning.Play();
        }
        public void playSwordSpawn()
        {
            swordSpawn.Play();
        }
        public void playCustomWarning()
        {
            customWarning.Play();
        }
        public void playCustomSpawn()
        {
            customSpawn.Play();
        }
        public void playAllWarning()
        {
            allWarning.Play();
        }
        public void playAllSpawn()
        {
            allSpawn.Play();
        }
        #endregion
    }
}
