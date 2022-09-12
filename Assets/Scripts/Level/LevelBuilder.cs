using System;
using System.IO;
using Level;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {
   private const string LEVEL_DIRECTORY = "Levels";

   private LevelBoard _levelBoard;
   
   private double _defaultBlockScale = 0.2647366;
   private int _width = 241;
   private int _height = 429;
   
   
   [Header("Cannot be 0 or an error will result.  Used as a default level during testing")]
   public int loadedLevel;

   void Awake() {
      _levelBoard = LevelBoard.Instance;
   }

   // Start is called before the first frame update
   void Start() {
      string level;
      
      if (_levelBoard.SelectedLevel == 0) {
         level = Levels.LevelMap[loadedLevel];
      } else {
         level = Levels.LevelMap[_levelBoard.SelectedLevel];
      }
      
      buildLevel(level);
   }

   // Update is called once per frame
   void Update() { }

   void buildLevel(string levelName) {
      Debug.Log($"The world width is {ScreenSize.GetScreenToWorldWidth}");
      Debug.Log($"The world height is {ScreenSize.GetScreenToWorldHeight}");
      Debug.Log($"The screen width is {Screen.width}");
      Debug.Log($"The screen height is {Screen.height}");
      calculateBlockScale();
      
      try {
         TextAsset asset = Resources.Load<TextAsset>(LEVEL_DIRECTORY + "/" + levelName);
         LevelFromJson levelFromJson = JsonUtility.FromJson<LevelFromJson>(asset.text);
         Debug.Log("The level has loaded");
      }
      catch (Exception e) {
         Debug.Log($"There was an error {e}");
      }
   }

   double calculateBlockScale() {
      Debug.Log(Screen.currentResolution);
      
      return 0.0;
   }
}

public class ScreenSize {
   public static float GetScreenToWorldHeight {
      get {
         Vector2 topRightCorner = new Vector2(1, 1);
         Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
         var height = edgeVector.y * 2;
         return height;
      }
   }
   public static float GetScreenToWorldWidth {
      get {
         Vector2 topRightCorner = new Vector2(1, 1);
         Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
         var width = edgeVector.x * 2;
         return width;
      }
   }
}