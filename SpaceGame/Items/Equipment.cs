using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public struct Buff
    {
        public Buff(BuffType buffType, float modifier, Color color, Color backgroundColor)
        {
            this.buffType = buffType;
            this.modifier = modifier;
            _returnString = "";
            this.color = color;
            this.backgroundColor = backgroundColor;
        }
        public BuffType buffType;
        public float modifier;
        private string _returnString;
        private Color color;
        private Color backgroundColor;
        public Subtext subtext { get { return new Subtext(buffString, color, backgroundColor); } }
        private string buffString
        {
            get
            {
                switch (buffType)
                {
                    case BuffType.ShipAngularSpeed:
                        _returnString = "Increases angular speed by " + (modifier * 100).ToString("0.##") + "%";
                        break;
                    case BuffType.ShipLinearSpeed:
                        _returnString = "Increases linear speed by " + (modifier * 100).ToString("0.##") + "%";
                        break;
                }
                return _returnString;
            }
        }
    }

    public enum BuffType
    {
        ShipLinearSpeed,
        ShipAngularSpeed
    }

    public class Equipment : Item
    {
        public List<Buff> equipmentBuffs = new List<Buff>();
        public EquipmentType equipmentType;

        public Equipment(Texture2D texture, Vector2 position, string name, bool randomize)
            : base(texture, position, name, randomize)
        {
        }

        public Equipment(Texture2D texture, Vector2 position, Vector2 linearVelocity, float angularVelocity, string name)
            : base(texture, position, linearVelocity, angularVelocity, name)
        {
        }

        public virtual void AddEquipmentBuffs()
        {
            foreach (var equipmentBuff in equipmentBuffs)
                subtexts.Add(equipmentBuff.subtext);
        }
    }
}
