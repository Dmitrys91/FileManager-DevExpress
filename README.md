1. Open the file solution "FileManager.sln" in Visual Studio

2. Perform NuGet package restore if necessary
 
3. Clean and Build the solution without errors.
 
4. Select the project FileManager.WebUI, right-click, and select "publish." Next, follow the instructions to publish the web application to the selected folder.

5. Verify that the publication runs without errors

6. Next, you need to create a local web server using the built-in snap-in "Internet Information Services" To do this, open the snap-in, select the "sites" node in the tree and click "add web site", then specify the path to the folder into which we published our web application. You should also specify the site name and port if necessary.

 
7. The next step is to set the necessary permissions for the folder where our web application files are published. You need to select the folder with the right mouse button, select the "Security" tab, and add full access to the services of "IIS" and "IIS_IUSRS"


8. The last step is to select our site in the IIS sites tree, and click "Browse." If everything is done correctly, the site will open in a browser and the file manager interface will immediately appear
