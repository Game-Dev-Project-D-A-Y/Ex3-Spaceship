# Ex3 - Game Development PREFABS & TRIGGERS 
# :space_invader: :video_game: :space_invader: :video_game: :space_invader: :video_game:  :space_invader: :video_game:  :space_invader: :video_game:  :space_invader: :video_game: 

## A - Changing & Improving the lesson's game 
### (Choose from 1-5 and add an original)
[View On Itch.io](https://game-dev-project-d-a-y.itch.io/spaceship-parta)  
 _**Note** - Play all the following games on **full screen mode**_

### 3 - The spaceship has N lives and only when it crashes N times it will be destroyed.
We added to the spaceship an object named "HealthPoint".  
This object has a [HealthPointManager](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Assets/Scripts/5-scripts/HealthPointManager.cs) script.  
This script handles operations on the player's hp which can be modified through the Inspector.  
In addition, we had to add a script to the ship which will handle the collisions and hp therefore we created the [DestroyOnTriggerWithHP](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Assets/Scripts/3-collisions/DestroyOnTriggerWithHP.cs).  
  
  <img src=https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Images%20for%20github/hpspaceship.jpg width="250"/>

    

### 4 - Delay between every shot.  
Instead of using the KeyboardSpawner script we've implemented our own [KeyboardSpawnerWithDelay](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Assets/Scripts/2-spawners/KeyboardSpawnerWithDelay.cs) script.  
This script allows us to adjust a delay which its duration may be changed in the Inspector.  
The LaserShooter inherits the KeyboardSpawnerWithDelay.  
  
   
  

### Extra Feature - Special Bomb eliminates all enemies around :bomb:  
We added a script - **[SpawnByScore](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Assets/Scripts/2-spawners/SpawnByScore.cs)** which will reveal a special bomb every N amount of enemy kills (N may be changed by Inspector).  
We added the prefab **"Bomb"** which will be cloned every time it will be called by it's spawner.  
To eliminate all the enemies around the screen, we've created the [DestroyAllObjectsOnTrigger](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Assets/Scripts/3-collisions/DestroyAllObjectsOnTrigger.cs) which basically destroyes all the enemies around.  
To do so we used [FindGameObjectsWithTag](https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
) which gave us an array of all the enemies and then we were able to count how many we have destroyed in order to update the score bored.  
  
 <img src=https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Images%20for%20github/bonbEvery20.jpg width="250"/>


## B - Boundries

<img src=https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Images%20for%20github/partb1.jpg width="800"/>


### 1 - A flat world with visible boundaries
[View On Itch.io](https://game-dev-project-d-a-y.itch.io/spaceshippartb1)

We've created a prefab "border" and we used 4 border objects - each one represents a border of the game (top, bottom, left and right)  
Each border has these components: 
* Rigid Body - Control of an object's position through physics simulation.
* Box Colider -The Box Collider is a basic cube-shaped collision primitive.
* Cube (Mesh Filter) - We created a cube with this component. 
* Mesh Renderer - The Mesh Renderer takes the geometry from the Mesh Filter and renders it at the position defined by the object's Transform component.



![alt text](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Images%20for%20github/Borders.jpeg?raw=true)


Our main player the SpaceShip also has the coliderr component and the Unity engine according to the Dynamic physics will identify the colistion and maintains the position of the spaceship inside our boundries..  
In the KeyboardMover component of the spaceship we've added a RigidBody object which makes the Object go smoothly and not "jump" againts the wall.



### 2 - A flat world with invisible boundaries
[View On Itch.io](https://game-dev-project-d-a-y.itch.io/spaceship-part-b2)

To do this we just had to do one simple change from the previous scene (1-A):  
We've maid the mesh Renderer invisbile (by ticking the box right near the component's name)  
now you can't see the shape of the border but it functionality works.

### 3 - A round world. When the player reaches one side of the world he appears on the other side.
[View On Itch.io](https://game-dev-project-d-a-y.itch.io/spaceshippartb3)

First thing we've clicked on the border to avoid them on this task.  
We added a script named [CircleWorldCamera](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Assets/Scripts/5-scripts/CircleWorldCamera.cs).  
In this script we got the position of every border using the [orthographicSize](https://docs.unity3d.com/ScriptReference/Camera-orthographicSize.html
) combined with the [camera.aspect](https://docs.unity3d.com/ScriptReference/Camera-aspect.html
) function..  
By using the Input.GetAxis function we know in which direction the spaceship is flying from.  
With a few simple "if" statements we covered all of the options (4 options one for each direction).


## C - Implement Core Game Loop
[Play RGB-Hero Game](https://game-dev-project-d-a-y.itch.io/rgb-hero)  
  
![alt text](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Images%20for%20github/RGBHero.jpeg?raw=true)

We created a game based on the logic of Guitar Hero.
We created three spawners which a "Capsule" in a color Red Green or Blue will drop from each spawner. We positioned the spawners on the top left of the screen with a small space between each one.
Each color has its own ColorPositsion (target - RedPosition etc).
The target of the game is to press the correct key on the keyboard for each Capsule as sonn as it reaches it's position. 
Each color has its own key (shown on the screen)..  
The prefab capsules and the color positions both have the colider component.   
The targets each have a script named [GetColorOnTrigger](https://github.com/Game-Dev-Project-D-A-Y/Ex3-Spaceship/blob/master/Assets/Scripts/3-collisions/GetColorOnTrigger.cs).    
GetColorOnTrigger - This script Goal is to open a time space which allow you to destroy once activated while collision.  
Using the OnTriggerEnter we actviated the option to destroy (with a boolian flag which becoms true on enter). If the correct Key has been pressed and the active is true (we are in a collistion) we will destroy the objcet (the capsule) and add a point to the score board.   
 ## Features added
 * ScoreBoard - Every time you press the correct button you get an extra point and every time you press incorrectly you loose a point!
 * Sound - We added music to acompnay the player which can be muted by a clicking the sound button.
 * Time - We added a timer - Each player has 60 seconds to reach the best score.
 * Restart - You may resatrt the game pressing the restart button on the bottom right of the screen. This may occure while playing in addition to the end of the game.

  
    
  #### Authors - 
  * Alon Perlmuter
  * Yishay Garame
  * Dovie Chitiz
  
  Enjoy !
