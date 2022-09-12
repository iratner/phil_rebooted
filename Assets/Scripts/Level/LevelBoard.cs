using System.Collections.Generic;

namespace Level {
   public class LevelBoard {
      // private movableBlocks;
      // private groundBlocks;
      //
      // private connectedBlocks;
      // private unconnectedBlocks;

      private int _selectedLevel;
      private static LevelBoard _instance;
      
      public static LevelBoard Instance {
         get {
            if (_instance == null)
               _instance = new LevelBoard();
            return _instance;
         }
      }
      
      public int SelectedLevel {
         get => _selectedLevel;
         set => _selectedLevel = value;
      }
      
      public LevelBoard() {
         
      }
   }   
   
   static class Levels {
      private static Dictionary<int, string> levelMap;

      public static Dictionary<int, string> LevelMap {
         get => levelMap;
      }

      static Levels() {
         levelMap = new Dictionary<int, string>();
         levelMap.Add(1, "level_1");
         levelMap.Add(2, "level_2");
         levelMap.Add(3, "level_3");
      }
   }
}

