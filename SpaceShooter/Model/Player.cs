using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.View;

namespace SpaceShooter.Model
{
    /// <summary>
    /// Klassen är ett objekt som innehåller information om skeppet/spelaren
    /// </summary>
    class Player
    {
        //Sets the starting position for the ship
        public float xPos = 0.5f;
        public float yPos = 0.5f;
        public float speed = 0.01f;
        public float diameter = 1.0f;
    }
}
