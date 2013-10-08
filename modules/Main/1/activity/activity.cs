Main.ActiveYear = "";
//Main.HelpMessage = 0;

//	Defaults for all activities
function PreSetupActivity(%activity)
{
	/*%scene = GameWindow.getScene();
	if (isObject(%scene))
	   %scene.clear();*/
   
	%activity.objective[0] = "Continue your journey on the road.";
	//	Default to objective 0
	%activity.currentObjective = 0;
	
	// Inventory
	if (isObject(Inventory))
		Inventory.delete();
	
	new ScriptObject(Inventory);
	Inventory.Setup();
}

//	Requires elements from the activity itself to work
function PostSetupActivity(%activity)
{
	//	Default Activity Settings
	CentreWindowOnSprite(Player);

	//  Debug
	%scene = GameWindow.getScene();
	//  Enable visualization for "collision", "position", and "aabb"
	%scene.setDebugOn("collision");//, "position", "aabb");

	//Canvas.pushDialog(ToolboxDialog);
	Canvas.pushDialog(InGameGUI);
	
	//Main.HelpMessage = 0;
	//%activity.schedule(100, UpdateHelpBar(%activity));
	UpdateHelpBar(%activity, 0);
}

function EndActivity(%activity)
{
	%activity.onEnd();
	
	%scene = GameWindow.getScene();
	%scene.setScenePause(true);
	OpenSelectActivityGUI();
}

function ToggleInGameMenu()
{
	inGameMenu.visible = !inGameMenu.visible;
}

//	Update the text in the In-game GUI Help Bar
function UpdateHelpBar(%activity, %text)
{
   echo(%text);
	if (%text $= 0)
	{
		warn("# =" SPC %activity.currentObjective);
		warn("Help Text =" SPC %activity.objective[%activity.currentObjective]);
		HelpText.Text = %activity.objective[%activity.currentObjective];
	}
	else
	{
		warn("Help Text =" SPC %text);
		HelpText.Text = %text;
		
		%activity.schedule($GUIHelpUpdateDelay, UpdateHelpBar(%activity, 0));
	}
}

function LoadYearGroup( %moduleDefinition )
{
	// Sanity!
	if ( !isObject( %moduleDefinition ) )
	{
		error( "Cannot load year group as the specified year group is not available." );
		return;
	}

	// Unload the current year group
	UnloadYearGroup();

	// Create a scene.
	//CreateScene();

	// Now is a good time to purge any idle assets.
	AssetDatabase.purgeAssets();

	// Set current year group
	Main.ActiveYear = %moduleDefinition;

	// Load year group
	if ( !ModuleDatabase.loadExplicit( %moduleDefinition.ModuleId, %moduleDefinition.VersionId ) )
	{
		error( "Failed to load year group '" @ %moduleDefinition.ModuleId @ "'." );
		return;
	}

	// Add the scene so it's unloaded when the activity is.
	%moduleDefinition.ScopeSet.add(GameWindow.getScene());

	// Add activity scope-set as a listener.
	GameWindow.addInputListener( %moduleDefinition.ScopeSet );
}

function UnloadYearGroup()
{
   // Finish if no year group is loaded
   if ( !isObject(Main.ActiveYear) )
      return;
   
   // Delete any custom controls added by the toy.
   //ToyCustomControls.deleteObjects();
   
   //resetCustomControls();
   
   // Unload the year group.
   if ( !ModuleDatabase.unloadExplicit( Main.ActiveYear.moduleId ) )
   {
      error( "Failed to unload year group '" @ Main.ActiveYear.ModuleId @ "'." );
   }
   
   // Reset active year.
   Main.ActiveYear = "";  
}

function ScanForYearGroups()
{
	%toLoad = 0;  // temp

	// Find modules
	%activityModules = ModuleDatabase.findModuleTypes( $ModuleTypeActivity, false );

	// Check for an existing set of yeargroups
	if ( !isObject(YearGroups) )
	{
		new SimSet(YearGroups);
	}

	YearGroups.clear();

	// Get module count
	%moduleCount = getWordCount( %activityModules );

	// Add modules
	for ( %i = 0; %i < %moduleCount; %i++ )
	{
		// Get module definition
		%moduleDefinition = getWord( %activityModules, %i );

		if (%toLoad == 0)
			%toLoad = %moduleDefinition;

		// Add to yeargroup set
		YearGroups.add( %moduleDefinition );
	}

	Main.YearGroup = %toLoad;
	//LoadYearGroup(%toLoad);
}