Cloud Goods Facebook 


Setup


1. Download the official Facebook Unity SDK from https://developers.facebook.com/docs/unity
2. Download the Cloud Goods Facebook Addon unity package at http://developer.socialplay.com/#sdk
3. Attach CloudGoodsFacebookLogin Component to any gameobject in the scene.
4. Press play in the editor and it should show a facebook pop up to log in, You can get your access token and successfully retrieve your facebook user info from unity editor
5. To display the user info in a unityUI text to confirm it worked, add a UnityUI Text into the scene.
6. Add the DisplayFacebookUserInfo component to any gameobject, and add the created text file in the Userlogin text input
7. Press play and when you successfully log in as a facebook user, it should change the display of the test to display facebook user info


Building to facebook


1. Go to https://developers.facebook.com/ and under MyApps select the app in which you want to have your unity game on
2. You will have to copy the AppID displayed for your app.
3. Return to the Unity Editor, Open the Facebook tab, then click edit settings
4. Type in your app name in the App Name input, and paste the AppID you had copied from the facebook developer page into the AppID input
5. Your project should now be ready to be hosted on facebook
6. Build Unity project on webplayer platform
7. You will need to find a place where you can host the file. Drop the contents of the build into the hosted file folder
8. Return to the facebook developer portal and go to the settings page of your app. In the Unity Binary URL input, add the directory path to your built unity webplayer file.
9. If you go to the app page, you should see that your facebook user info will be displayed in the unity app