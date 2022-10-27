# AIWatch---Unity3D

<h1>Instructions for starting the project</h1>
Curated by Renato Esposito <br>
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
