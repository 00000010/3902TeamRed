using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class SoundFactory
    {
        public Song themeSound, zeldaVictory;
        public SoundEffect zeldaSword, zeldaArrowBoomerang;
        public SoundEffect zeldaEnemyHit, zeldaEnemyDie, zeldaLinkHurt, zeldaLinkDie;
        public SoundEffect zeldaItemObtained, zeldaBoomObtained;

        private static SoundFactory instance = new SoundFactory();
        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundFactory() { }

        public void LoadSounds(ContentManager content)
        {
            themeSound = content.Load<Song>("Zelda_theme_sound");
            zeldaSword = content.Load<SoundEffect>("Zelda_sword");
            zeldaArrowBoomerang = content.Load<SoundEffect>("Zelda_arrow_boomerang");
            zeldaEnemyHit = content.Load<SoundEffect>("Zelda_enemy_hit");
            zeldaLinkHurt = content.Load<SoundEffect>("Zelda_link_hurt");
            zeldaLinkDie = content.Load<SoundEffect>("Zelda_link_die");
            zeldaEnemyDie = content.Load<SoundEffect>("Zelda_enemy_die");
            zeldaItemObtained = content.Load<SoundEffect>("Zelda_item_obtained");
            zeldaBoomObtained = content.Load<SoundEffect>("Zelda_boom_obtained");
            zeldaVictory = content.Load<Song>("Zelda_victory");
        }
    }
}