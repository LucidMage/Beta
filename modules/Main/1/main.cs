//  Code called when program starts
function Main::create( %this )
{
   %this.loadPreferences();
   
   // Load Main Scripts
   exec("./global.cs"); // Global Values
   exec("./console.cs");   // Console
   exec("./activity/loadList.cs");  // Load Activity Scripts
   exec("./gui/loadList.cs");   //  Load GUI
   exec("./behaviours/loadList.cs");   // Load Behaviours
   exec("./sprites/loadList.cs");   // Load Sprites

   //exec("./scenewindow.cs");
   exec("./profile.cs");
   exec("./inventory.cs");

   CreateSceneWindow();
	
	// Load and configure the console.	exec("./scripts/console.cs");  
	TamlRead("./gui/ConsoleDialog.gui.taml"); // Notice we are just reading in the Taml file, not adding it to the scene  
	GlobalActionMap.bind( keyboard, "tilde", toggleConsole );   // Press '`' to open console
    
    // Load and configure the toolbox.
    //Main.add( TamlRead("./gui/ToolboxDialog.gui.taml") );
	
	CreateProfile();
    ScanForYearGroups();
	/*%year = YearGroups.findObjectByInternalName("Year8");
	LoadYearGroup(%year);*/
	
	OpenProfileGUI();

	// Initialize the "cannot render" proxy.
	new RenderProxy(CannotRenderProxy)
	{
		Image = "Assets:CannotRender";
	};
	Main.add( CannotRenderProxy );
}

//  Code called when program ends
function Main::destroy( %this )
{
	UnloadYearGroup();
    destroySceneWindow();
}

function Main::loadPreferences( %this )
{
	// Load the default preferences.
	//exec( "./defaults.cs" );

	// Load the last session preferences if available.
	if ( isFile("preferences.cs") )
		exec( "preferences.cs" );
}

function OpenSelectActivityGUI()
{
	//	Disable all GUI buttons and player controls
	%scene = GameWindow.getScene();
	%scene.setScenePause(true);
	
	if (%scene.getName() $= ProfileScene || %scene.atEnd)
	   SelectActivityResumeButton.Visible = false;
   else
	   SelectActivityResumeButton.Visible = true;

	Canvas.pushDialog(SelectActivityGUI);
}

function CloseSelectActivityGUI()
{
	%scene = GameWindow.getScene();
	%scene.setScenePause(false);

	Canvas.popDialog(SelectActivityGUI);
}

function SelectActivity(%lesson)
{
	%scene = GameWindow.getScene();
	DestroyScene(%scene);
	
	Main.ActiveActivity = %lesson;
	Year8.reset();
	
	Canvas.popDialog(ProfileGUI);
	Canvas.popDialog(SelectActivityGUI);
}