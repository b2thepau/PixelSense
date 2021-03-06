﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Surface;
using Microsoft.Surface.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonJoliPortavion;


public abstract class Sprite
{

    //Association au pgm

    protected AircraftCarrierApp programm;

    /// <summary>
    /// Récupère ou définit l'image du sprite
    /// </summary>
    public Texture2D Texture
    {
        get { return _texture; }
        set { _texture = value; }
    }
    private Texture2D _texture;

    /// <summary>
    /// Récupère ou définit la position du Sprite
    /// </summary>
    public Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }
    private Vector2 _position;

    /// <summary>
    /// Récupère ou définit la direction du sprite. Lorsque la direction est modifiée, elle est automatiquement normalisée.
    /// </summary>
    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = Vector2.Normalize(value); }
    }
    private Vector2 _direction;

    /// <summary>
    /// Récupère ou définit la vitesse de déplacement du sprite.
    /// </summary>
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    private float _speed;
    /// <summary>
    /// Initialise les variables du Sprite
    /// </summary>
    public virtual void Initialize()
    {
        _position = Vector2.Zero;
        _direction = Vector2.Zero;
        _speed = 0;
    }

    /// <summary>
    /// Charge l'image voulue grâce au ContentManager donné
    /// </summary>
    /// <param name="content">Le ContentManager qui chargera l'image</param>
    /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
    public virtual void LoadContent(ContentManager content, string assetName)
    {
        _texture = content.Load<Texture2D>(assetName);
    }

    /// <summary>
    /// Met à jour les variables du sprite
    /// </summary>
    /// <param name="gameTime">Le GameTime associé à la frame</param>
    public virtual void Update(GameTime gameTime)
    {
        _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
    }

    /// <summary>
    /// Permet de gérer les entrées du joueur
    /// </summary>
    /// <param name="keyboardState">L'état du clavier à tester</param>
    /// <param name="mouseState">L'état de la souris à tester</param>
    /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
    public void HandleInput(TouchTarget touchTarget)
    {
        touchTarget.TouchDown += new EventHandler<TouchEventArgs>(this.Touched);
        touchTarget.TouchMove += new EventHandler<TouchEventArgs>(this.TouchedMove);
    }

    public virtual void Touched(object sender, EventArgs e){}
    public virtual void TouchedMove(object sender, EventArgs e) { }


    /// <summary>
    /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
    /// </summary>
    /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
    /// <param name="gameTime">Le GameTime de la frame</param>
    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }
}