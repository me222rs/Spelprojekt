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
        public SoundEffect backgroundMusic;

        public Sound() {
            shoot = null;
            explosion = null;
            backgroundMusic = null;
        }


        //Monogame är helt värdelöst på att hantera ljud.... och det verkar vara vääääldigt många som har samma uppfattning på internet...
        //Går ej att spela ljud i vilket format som helst utan det måste vara xnb och inget annat.
        //Att spela bakgrundsmusiken med mediaplayer fungerar inte alls (fungerar om jag spelar upp den som soundeffect, men då går det inte pausa musiken)
        //Aldrig mer monogame förrens de har fixat problemen.
        public void LoadContent(ContentManager content) {
            //Fanns väldigt få ljud att ladda ner på internet som är i rätt format
            shoot = content.Load<SoundEffect>("pulse");
            explosion = content.Load<SoundEffect>("fire2");
            //backgroundMusic = content.Load<SoundEffect>("bgmusic");
            
        }
    }
}
