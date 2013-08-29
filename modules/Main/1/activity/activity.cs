Main.ActiveYear = "";

//	Defaults for all activities
function PreSetupActivity(%activity)
{
	%activity.objective[0] = "Find the exit.";
	%activity.currentObjective = 0;
}

//	Requires elements from the activity itself to work
function PostSetupActivity(%activity)
{
	Canvas.pushDialog(InGameGUI);
	
	//	Default to objective 0
	UpdateHelpBar(%activity, "");
}

//	Update the text in the In-game GUI Help Bar
function UpdateHelpBar(%activity, %text)
{
	if (%text $= "")
		HelpText.Text = %activity.objective[%activity.currentObjective];
	else
		HelpText.Text = %text;
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
   
   // Add the scene so it's unloaded when the activty is.
   %moduleDefinition.ScopeSet.add(GameWindow.getScene());
   
   // Add activity scope-set as a listener.
   GameWindow.addInputListener( %moduleDefinition.ScopeSet );
   
	//	Default Activity Settings
	CentreWindowOnSprite(Player);
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
   
   LoadYearGroup(%toLoad);
}