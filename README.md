# unity-json
### Read from and write to external .json files using JsonUtilities or LitJson
With **JsonUtilities**, Unity 5.3 introduced a built-in possibility to interact with JSON-formatted strings. Before, it was common to use third-party libraries, sch as **LitJson**.
Both JsonUtilities and LitJson have their advantages and disadvantages. You can find a comparison [on this blog](http://jacksondunstan.com/articles/3294). This repo contains a Unity project with a couple of sample scripts that cover usual use cases with JSON data.
At this time (02.2016), there´s not so much documentation about the use of JsonUtilities and about the comparison JsonUtilities and LitJson, so I decided to make some super simple demos.

This project contains sample files (for both **JsonUtilities** and **LitJson**) which
- encode basic data objects into a JSON-formatted string and store it into a text file
- load a text file containing a JSON-formatted string and use the data
- put multiple nested data objects into an array and then encode them into a JSON-formatted string
- load a JSON-formatted string, make data changes, add more objects and encode the data into a JSON-formatted string again

#### Note that JsonUtilities is only available in Unity 5.3 and above.

## Using
You can simply pick the Unity Package ```JsonIO.unitypackage```in the root directory and unpack it in Unity3D via Assets/Import New Assets...
