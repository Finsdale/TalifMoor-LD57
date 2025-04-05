using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseGameProject
{
  public sealed class TextureCollection
  {
    private static readonly TextureCollection collection = new TextureCollection();

    private TextureCollection() { }
    public static TextureCollection Instance
    {
      get
      {
        return collection;
      }
    }

    public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
    {
    }
  }
}