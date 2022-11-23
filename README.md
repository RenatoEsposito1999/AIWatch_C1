# About AIWatch
***
AIWatch is a university research project with is intended to create a real-world video surveillance system that is capable of creating a digital twin for each human detected by the system and detect and report any abnormal behavior on them. Specifically, it wants to create a system in which from cameras placed in the real world, information about the humans in the scene is obtained, including:
- Position and orientation.
- Actions.
This information following processing, through which digital twins are created, is transmitted to the virtual environment within which it is then reproduced.

# About the C1 Module
***
AIWatch is a modular project for which three modules are currently planned: A1, B1 and C1.
The goal of module C1 is to the development of a virtual environment replicating the Computer Vision and Pattern Recognition laboratory of the Department of Science and Technology and the north wing fourth floor corridor leading to the laboratory itself.  Subsequently, the module focused on the analysis and development of a system that is capable of receiving, processing and integrating information from the real world into the virtual environment.  


## Demo AI WATCH 💻
***
- [Example video of running the application. The avatar turns red when the B1 form model reports abnormal behavior.] 


## System Structure 🏛
***
![architettura_di_comunicazione](https://user-images.githubusercontent.com/53092291/203617948-1c0f1736-ca8b-4d35-9bc2-3db1e3901fb4.png)

## Instructions 🚀
***
<ul><strong>Requirements</strong> </ul> 
  <li>Unity 2020.3.36f1 (https://unity3d.com/get-unity/download/archive)</li>
  <li>Visual Studio or any other editor (https://visualstudio.microsoft.com/it/downloads/)</li>
  <li>Confluent Kafka Library (read below)</li>
  <li>(Optional) GitHub Desktop https://desktop.github.com/</li>
<br><br>

<ul><strong>Procedure</strong> </ul>
  <li>Confluent Kafka: in order to install the library it is necessary to create a new project (separate from Unity) and download "Confluent.Kafka" from the NuGet package manager (project link: https://github.com/confluentinc/confluent-kafka -dotnet /). Some files (.dll) are now visible in the project folder (usually the Packages folder, but may change depending on the version of the IDE) <br>
  copy these files and return to the project repository, go to
  “Assets”, create the “Plugins” folder and paste the files.<br>
  N.B: resuming the project as it was left, it is not necessary to create additional folders, but it is essential to create a new project (separate from Unity) and to recover the files downloaded from the NuGet Manager</li>
  <li>Operation: start the Unity environment and the session ("play" button), at this point it is necessary to wait for the system to receive the coordinates from a "producer" (ie from whoever takes care of the Digital Twin).</li>
  However, the avatar has the ability to move through the W A S D buttons, and by reading the console it is possible to view the key combinations that allow you to:
  store the data for any simulations (explanation in the next point), open each window, change the camera, jump and return to the plane (after the jump).
  <li>Simulation: if the chambers are not yet present, it is possible to create tests simply by walking around the environment (using the W A S D keys) and at the end of the operation press the "8" key, it will be created in the folder “Assets” a “data.json” file that must be sent (via e-mail or USB) to those involved in digital twin / anomaly detection. </li>
N.B: when it is no longer necessary to carry out simulations, it is recommended to comment / delete the DataMemorization function.
## Tools 🛠
***
- [Eclipse Ditto](https://www.eclipse.org/ditto/)
- [Kafka](https://kafka.apache.org/)
- [C# Confluent Kafka library]([https://github.com/confluentinc/confluent-kafka-python](https://github.com/confluentinc/confluent-kafka-dotnet))
- [Confluent](https://www.confluent.io/)
- [Unity](https://unity.com/)
- [C#](https://learn.microsoft.com/it-it/dotnet/csharp/)


## License ☢️
AI Watch C1 is licensed under the Apache License, Version 2.0. Copyright 2022. Please, see the [license](https://github.com/Luruu/AI_Watch_B1/blob/main/LICENSE).

## Contacts 🪪
- [mail] renato [ dot ] esposito001 [ at ] studenti [ dot ] uniparthenope [ dot ] it (you can write to me in english or italian).


## Citation 📖
```
    @report{AIWatch_C1,
        author = {Luca Rubino},
        title = {Reproducing a virtual environment in Unity and creating a system that integrates real information within the VR environment.},
        institution = {University of Naples, Parthenope},
        year = {2022}
    }
```

## Supervisor
- [Prof. Francesco Camastra](https://www.researchgate.net/profile/Francesco-Camastra), Associate Professor of Computer Science, at Science and Technology Dept.,  [University of Naples Parthenope](https://www.uniparthenope.it/).


## Other modules
- [A1 - Tracker](https://github.com/dennewbie/AI_Watch_A1)
- [B1 - Anomaly Detection + Digital Twin](https://github.com/Luruu/AI_Watch_B1)

a.a. 2021/2022
