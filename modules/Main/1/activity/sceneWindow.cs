function CreateSceneWindow()
{
    //  Check GameWindow exists
    if ( !isObject(GameWindow) )
    {
        //  Create Scene Window
        new SceneWindow(GameWindow);

        //  Set Gui Profile
        GameWindow.Profile = GuiDefaultProfile;  //  GuiDefaultProfile is used by default

        //  Place the sWindow on the Canvas
        Canvas.setContent(GameWindow);   //  GameWindow fills entire canvas
    }

    //GameWindow.setCameraPosition(0, 0);
    GameWindow.setCameraSize(20, 15);
    //GameWindow.setCameraZoom(5);
    //GameWindow.setCameraAngle(0);
    //CentreWindowOnSprite(%sprite);
}

function DestroySceneWindow()
{
    //  Finish if no window available
    if ( !isObject(GameWindow) )
        return;

    //  Delete window
    GameWindow.delete();
}

function CentreWindowOnSprite(%sprite)
{
   GameWindow.setCameraPosition(%sprite.position);
   
   // Schedule to centre camera on player sprite
   GameWindow.PositionSchedule = schedule(1, 0, CentreWindowOnSprite, %sprite);
}