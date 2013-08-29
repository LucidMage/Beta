function CreateScene(%sceneName)
{
   //  Destroy the scene if it already exists
   if (isObject(%sceneName))
      destroyScene();
      
   //  Create Scene
   new Scene(%sceneName);
   %sceneName.setup();  // Run setup
   
   // Sanity!
   if ( !isObject(GameWindow) )
   {
      error( "Created scene but no window available." );
      return;
   }
   
   SetSceneToWindow(%sceneName);
}

function DestroyScene(%scene)
{
    //  Finish if no scene available
    if ( !isObject(%scene) )
        return;

    //  Delete Scene
    %scene.delete();
}

// Load scene from file
function LoadScene(%scene)
{
   // File Path: Data/ProfileName.Lesson#.SceneName.taml
   %path = $DataSavePath @ Player.displayName @ "." @ Main.ActiveActivity @ "." @ %scene.getName() @ $DataSaveExtension;
   echo(%path);
   //%savedScene = TamlRead(%path);
   
   // Check saved scene isn't null
   if (%savedScene $= "")
      CreateScene(%scene);
   else
      SetScene(%savedScene);
}

// Save scene to file, persistent scene
function SaveScene(%scene)
{
   // File Path: Data/ProfileName.Lesson#.SceneName.taml
   %path = $DataSavePath @ Player.displayName @ "." @ Main.ActiveActivity @ "." @ %scene.getName() @ $DataSaveExtension;
   TamlWrite(%scene, %path, $DataSaveFormat);
}

function SetSceneToWindow(%scene)
{
   // Sanity!
   if ( !isObject(%scene) )
   {
      error( "Cannot set Scene to Window as the Scene is invalid." );
      return;
   }
   
   // Set scene to window.
   GameWindow.setScene(%scene);
}

function SetScene(%scene)
{
	echo("Setting Scene");

    // Sanity!
    if (!isObject(%scene))
    {
        error("Cannot set to use an invalid Scene.");
        return;
    }
   
    // Destroy the existing scene.
    %toDelete = GameWindow.getScene();
    DestroyScene(%toDelete);
    
    // Set the scene to the window.
    SetSceneToWindow(%scene);
}