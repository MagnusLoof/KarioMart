# KarioMart
 KarioMart school project.


# Setup, gameplay and keybinds
My project is supposed to be open with Unity 2022.3.8f1.
The starting scene should be irrelevant as my InitScript should automatically set the starting scene to StartScene.
But in case that doesn't work, then StartScene should be set as the starting scene.

All of the UI should be interactable with your mouse and in general are pretty straightforward.
After clicking the play button, you can select which car to pick for each player by clicking the arrow buttons.
After pressing continue you are then prompted to pick which map you want to play.
After the scene loads a 3 second timer counts down after which the cars are now controlable.
To control the direction and rotation of player 1 and 2, you use the WASD keys and arrow keys respectively.
For one of the players to win you need to go around the map and pass the goal 3 times.
The green orbs are speed boosts that can be collided with, and over time they respawn.
If you crash into another player or a wall you'll bounce back a bit towards the direction you came from.
Afterwards the winners lap times will be shown and you can then go back to start, restart the current map or quit.

# Plan
I first started working with what I deemed to be the most important part of the project, the car itself...

Then once the car was working I just made a simple map where I could add speedboosts, checkpoints and a goal...

Then I added the UI so that you could select the map, etc.

Eventually i added car selection, prefab wise I just had to make small changes to the speedboosts and car prefabs.
Most difficult part was figuring out the math for the lists and the lists of lists. 

Added a race manager which took take care of laptimes, checkpoints,

Also struggled with the buttons losing references since the reference was being transfered between scenes but not the UI.
I struggled for quite a bit so ended up just carrying over my UI between each scene.

Countdown & fps limit


# Stuff I had to look up or get help with
When you get to select which car model you wanted, I struggled to change the image to the correct one.
I've done similar things previously but forgot how to do it. When I looked up this problem I found this page.

https://stackoverflow.com/questions/56676894/how-convert-type-unityengine-texture2d-to-unityengine-sprite

It talks about how to use Sprite.Create, I implemented the solution that I found.
Shortly thereafter I realised the issue, I was using List<Texture2D> instead of just List<Sprite>.


For my countdown I was setting a text to a float counting down from 0. I wanted to show decimal points, but only 2.

https://forum.unity.com/threads/how-do-i-make-my-code-only-display-1-or-2-numbers-after-the-decimal.370059/

Using the information I found here I learned a bit about how to use String.Format in the way I wanted it to work.


Originally when I was keeping track of the laptimes I was using a timer on each instance of a car prefab.
Only 2 cars using the update loop to update the timer with Time.deltaTime might not affect performance that much.
But one of my classmates pointed out that if you had let's say a thousand cars it definetly would be more costly.

The solution I came up with is that I let the racemanager just have one timer for the whole race.
The first laps time would be correct, but the second lap would have the time for lap one and two combined, and so on.
So when the race is won, I reverse the saved laptimes and put them in a for loop where i -= i+1, Until you're at the last i.
Lastly I just reversed the valeus again so I can display them in the proper order.
This information is also available in the RaceManager.cs as a comment.

I've also discussed a lot of ideas with my classmates on how to do certain things, in addition to looking at my previous projects.

Magnus Lööf