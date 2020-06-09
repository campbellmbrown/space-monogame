﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.ShipStateManagers
{
    public class ShipMenuManager 
    {
        public enum ShipMenuType
        {
            Items,
            Crew,
            Engines,
            Shields,
            Weapons
        }

        protected ShipMenuType menuType;
        public ItemMenu itemMenu;
        protected Vector2 menuSize;

        public ShipMenuManager()
        {
            menuType = ShipMenuType.Items;
            itemMenu = new ItemMenu(Vector2.Zero, LimitsEdgeGame.textures["selection_bar"], true);
            menuSize = new Vector2(330, 142);
            LimitsEdgeGame.shipCamera.Position = (-LimitsEdgeGame.screenSize + menuSize) / 2f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (menuType)
            {
                case ShipMenuType.Items:
                    itemMenu.Draw(spriteBatch);
                    break;
            }
        }

        public void Click(Vector2 mousePosition)
        {
            switch (menuType)
            {
                case ShipMenuType.Items:
                    itemMenu.Click(mousePosition);
                    break;
            }
        }
    }
}
