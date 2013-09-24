// Should run after profile login
function Year8::create( %this )
{
   exec("./lesson1/main.cs");
   exec("./lesson2/main.cs");
   exec("./lesson3A/main.cs");
   
   // Default to lesson 1
   Main.ActiveActivity = Lesson2;//3A;//Lesson1;
   
   %this.reset();
}

function Year8::destroy( %this )
{
}

// Load Lesson
function Year8::reset( %this )
{
   // Inventory
   new ScriptObject(Inventory);
   
   new ScriptObject(Main.ActiveActivity);
   
   SaveScene(GameWindow.getScene());
}