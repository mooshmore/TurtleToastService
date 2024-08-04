![Service logo](https://i.imgur.com/pIfQKJU.png)

[![NuGet Version](https://img.shields.io/nuget/v/TurtleToastService.Service)](https://www.nuget.org/packages/TurtleToastService.Service)
# TurtleToastService
A straightforward C#/WPF service for displaying toast messages!

```cs
TurtleToast.Information("Turtle toast!");
```
![Toast message example](https://i.imgur.com/M54Ki9O.png)

---
## Usage

1. Add the latest __package__ from [nuget](https://www.nuget.org/packages/TurtleToastService.Service) to your project
2. Add the reference to the service in your MainWindow.xaml:
```xaml
xmlns:TurtleToast="clr-namespace:TurtleToastService.Service.ToastHost;assembly=TurtleToastService.Service"
```
3. Place the toast control in your desired place:
```xaml
<TurtleToast:ToastHostView/>
```
4. That's all! The toast can be verified with your first message, from anywhere in your project:
```cs
TurtleToast.Information("I'm alive!");
```
---
## Key features
* Built-in queue system with a priority mechanism
* 4 themes with easy customizability

| Light | StoneGrey | Dark | TurtleGreen |
| ------------- | ------------- | ------------- | ------------- |
| ![Light theme](https://i.imgur.com/BiMAahw.png) | ![Stone grey theme](https://i.imgur.com/yUQoRLV.png) | ![Dark theme](https://i.imgur.com/BNjY7wN.png)  | ![Turtle green theme](https://i.imgur.com/2bojMFh.png)  |
* 3 different types of toast messages with a straight-forward expandability
  * ### Information toast
    ![Information toast](https://i.imgur.com/VPtbrrY.png) 
    
    ```cs
    TurtleToast.Information("Information toast");
    ```
    
    Hides after time calculated off the length of the text.
  * ### Confirmation toast
    ![Confirmation toast](https://i.imgur.com/0PuGMaw.png)
    
    ```cs
    TurtleToast.Confirmation("Confirmation toast");
    ```
    Hides after the button is clicked.
  * ### Loading toast
    ![Loading toast](https://i.imgur.com/hSIOoW3.png)
    
    ```cs
    TurtleToast.Loading("Loading toast", "This can take a while", 5, displayMode: ProgressDisplayMode.CountAndPercentage);
    ```
    Shows the progress with multiple display options. Can increment automatically when attached to an event.
