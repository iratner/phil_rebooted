using System;

namespace Level {
   
   /**
    * Allows us to map the members to json
    */
   [Serializable]
   public class LevelFromJson {
      public string[] movable;
      public string[] ground;
      public int width;
      public int height;
   }
}