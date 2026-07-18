# OOP Project

---

- Are you in a Group?
    - I am not in a group
- If so, who else is in your group?
    - N/A
- Do you have your GitHub account set up?
    - Yes
- Do you have a public repository for your Project?
    - Yes
- What is the link to your GitHub repository?
    - https://github.com/VGoyal999/oop_project.git
- If you are in a group, does everyone have write access to the github repo?
    - N/A
- Do you have a “Hello World” program that compiles and runs?
        Yes
- Where is the entry point to your project? (src/main/Main.java for example)
    - `cd` into the `SoundCloud.Term.AppHost` project and enter `dotnet run`. This will open the Aspire dashboard where you can run the project

---

## Project Description

This is a terminal based music player that takes inspiration from Neovim and plugins like telescope and fzf.
The goal for this project is for me to be able to seemlessly navigate through playlists and change music while coding.

## Design Patterns

### Builder Pattern

The implementation of Builder Pattern that I'm using is a different from what is laid out in the Gang of Four text.
Instead there is the `UiBuilder` class which contains several methods that returns the object itself. In implementation you are supposed to chain together these different methods until you finally call the `Build` method.
My goal with this class is to build the console output for the main UI that the user will eventually see. Right now it is filled with placeholder text but after I introduce more classes and design patterns the data displayed here will become dynamic.

### Factory Method

My implementation of factory method can be a little confusing at first glance. I actually have to different factory method classes being `HelpLayerRenderFactoy` and `SearchLayerRenderFactory`; however, these two are linked together using a static factory being `RenderLayerFactory`.
Now this static factory implementation was used just to make Dependency Injection a little easier for myself and can be ignored. `HelpLayerRenderFactory` and `SearchLayerRenderFactory` implement the traditional factory method gone over in the Gang of Four text. 
Right now they also display static hardcoded data but these will eventually be updated to include dynamic UI as the project progresses.


