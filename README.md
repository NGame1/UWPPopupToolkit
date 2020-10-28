# UWPPopupToolkit
UWP Popup Toolkit is a simple UI Toolkit to make it easier to work with popups and Dialogs easier than ever in UWP.

# Get Started
It is easy to use UWPPopupToolkit. 

First of all, you need to add UWP Popup Toolkit to your solution and reference it to the main project. Or, You can use our NuGet package instead. 

Then add PopupPresenterHost to the Root of your Main Page. 

While using UWPPopupToolkit we highly recommend you not to navigate the Mainframe, Instead, add a Frame into your MainPage as a child of PopupPresenterHost and then navigate in that.

In this way, you will no longer need to add PopupPresenterHost to every page that you want to show a popup or dialog in it. 

However, It's not impossible to add PopupPresenterHost to every page and use it for showing popups. 

For showing a simple popup You have to call :

```PopupPresenterHost.ShowSlideupPopup(Type content, double ContentHeight = double.NaN, string Host_Id = null, params object[] args)``` 

The <b>content</b> parameter is the Type of the UserControl or the page that you want to show in the popup. 

<b>ContentHeight</b> defines what your popup height should be. this will cause showing a popup with the given height. The default value will show you a popup with a 100px margin from the top. 


<b>Host_Id</b> parameter can be used when you have several PopupPresenterHost controls (for example on every page or multiple controls in each other for some reason), this parameter will define which host will be the parent of the popup.

<b>args</b> parameter will be used when your content constructor (ctor) needs some parameters to be initialized. You can pass them using the args parameter and we will create instance of your control and dispose it after hiding the popup. 

# NuGet Packages
| Target | Branch | Recommended package version |
| ------ | ------ | ------ |
| Stable | SR/0.1.1.2 | [![NuGet](https://img.shields.io/nuget/vpre/UWPPopupToolkit)](https://www.nuget.org/packages/UWPPopupToolkit/0.0.0.5-rc) |

# Currently supported popup types
Currently, We support Slideup Popup type which is similar to Instagram's popups. 

![Capture](https://github.com/NGame1/UWPPopupToolkit/blob/main/UWPPopupToolkit/UWPPopupToolkit/Screenshots/Animate.gif?raw=true) ![Capture2](https://github.com/NGame1/UWPPopupToolkit/blob/main/UWPPopupToolkit/UWPPopupToolkit/Screenshots/Animate2.gif?raw=true)

# System Requirements
- Microsoft Visual Studio 2019 
- Universal Windows Platform SDK (Target: Win10 2004 / Build 19041)
- Minimum Target Required - Windows 10 November update / Build 10586
