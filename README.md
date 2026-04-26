Project overview: We wanted to create a video game that was essentially a systems programming themed escape room, where the user would find clues and solve puzzles to move through a series of 4 challenge rooms.

4 themes:

Room 1 = Caching and memory

Room 2 = Software Locks

Room 3 = CPU Scheduling

ROOM 4 = Networking and sockets

Decisions and trade-offs: We originally intended on making our game 1st person 3d, but decided to use top-down 2d instead, as that was more achievable. Furthermore, while we had originally intended for our puzzles to have more interactive elements such as moving objects or inputting commands into terminals to modify the world around you, we ended up going with a more quiz-like approach as that was within our capabilities given the time we had. 

Challenges and lessons: Our main challenges involved difficulties learning and using the unity game engine. From this experience we are all more familiar with how to use the unity engine as this is our second time creating a project using unity. During the programming phase we ran into difficulties figuring out what the best approach would be for how a user would interact with a room, We wanted to originally have different ways to solve each room like two locks that the user would select shared or write lock on and when both were in the correct combo you would be able to move to the next room. For the next room we wanted to set up 3 questions where the user would have to get the right answer for each of the three scheduling types. Once we were able to set up multiple choices and fill in the blank we just wanted to focus on getting all of the rooms completed. The other challenge we ran into was the interactions with the terminals and hints as you had to spam the interaction key until it would register. After some tinkering we were able to set up a proper interaction system that will always work first try for interactions if the user is within the bounds for the interactable item.
