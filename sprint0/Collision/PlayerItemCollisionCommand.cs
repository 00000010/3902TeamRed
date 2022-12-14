using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class PlayerItemCollisionCommand : ICommand
    {
        IObject player;
        IObject item;
        string intersectionLoc;
        GameObjectManager manager;
        public PlayerItemCollisionCommand(IObject player, IObject item, string intersectionLoc, GameObjectManager manager)
        {
            this.player = player;
            this.item = item;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            manager.RemoveObject(item);
            if (GameObjectManager.IsDesiredObject(item, "ZeldaBoomerang"))
            {
                manager.inventory.Boomerangs++;
                SoundFactory.Instance.zeldaBoomObtained.Play();
            }
            else if (GameObjectManager.IsDesiredObject(item, "ZeldaTriforce"))
            {
                MediaPlayer.Play(SoundFactory.Instance.zeldaVictory);
                manager.RemoveObject(item);
                manager.SetVictory();
            }
            else if (GameObjectManager.IsDesiredObject(item, "ZeldaHeart"))
            {
                //heart
                IPlayer managedPlayer = manager.player;
                managedPlayer.TakingDamage = false;
                managedPlayer.Health += 100;
                if (managedPlayer.Health > 100) managedPlayer.Health = 100;
                manager.inventory.FillHearts();
                manager.inventory.UpdateHealth(managedPlayer.Health);
                SoundFactory.Instance.zeldaItemObtained.Play();
            }
            else if (GameObjectManager.IsDesiredObject(item, "ZeldaRupy"))
            {
                manager.inventory.Coins++;
                SoundFactory.Instance.zeldaItemObtained.Play();
            }
        }
    }
}