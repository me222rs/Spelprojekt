using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace SpaceShooter.View
{
    public class Sound
    {
        public SoundEffect shoot;
        public SoundEffect explosion;
        public Song backgroundMusic;

        public Sound() {
            shoot = null;
            explosion = null;
            backgroundMusic = null;
        }


        //Monogame är helt värdelöst på att hantera ljud....
        public void LoadContent(ContentManager content) {
            //shoot = content.Load<SoundEffect>("playershoot");
            //explosion = content.Load<SoundEffect>("explode");
            //backgroundMusic = content.Load<Song>("theme");
        }
    }
}
