# UWPPopupToolkit
UWP Popup Toolkit is a simple UI Toolkit to make it easier to work with popups and Dialogs easier than ever in UWP

# Get Started
It is Easy to use UWPPopupToolkit. First of all, you need to add UWP Popup Toolkit to your solution and reference it to the main project. 
Add PopupPresenterHost to the Root of your Main Page. While you are using UWPPopupToolkit we highly Recommend to not navigate the mainframe, Instead, add a Frame into your MainPage as a child of PopupPresenterHost and then navigate in that. In this way, you will no longer need to add PopupPresenterHost to every page you want to show a popup or dialog. However, It's not impossible to add PopupPresenterHost to every page and use it for showing popups. 

For showing a simple popup You have to call ```PopupPresenterHost.ShowPopup(Type content, double ContentHeight = double.NaN, string Host_Id = null, params object[] args)``` the content parameter is the Type of the UserControl or the page you want to show in the popup. 
ContentHeight defines what is your popup height should be. this will cause showing a popup with the given height the default value will show you a popup with a 100px margin from the top. 
Host_Id parameter can be used when you have several PopupPresenterHost controls (for example on every page or multiple controls in each other for some reason), this parameter will define which host will be the parent of the popup.
args parameter will be used when your content constructor (ctor) needs some parameters to be initialized. You can pass them using the args parameter and we will handle the Creating Instance of your control and disposing of it after hiding the popup. 

