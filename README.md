![Service logo](https://i.imgur.com/pIfQKJU.png)

# TurtleToastService
A straightforward C#/WPF service for displaying toast messages!
<br>

```cs
TurtleToast.Information("Turtle toast!");
```
![Toast message example](https://i.imgur.com/M54Ki9O.png)

---
### Key features
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
    TurtleToast.Loading("Loading toast", "This can take a while", maxLoadingCount, progressEvent: ref LoadingEvent, displayMode: ProgressDisplayMode.CountAndPercentage);
    ```
    Shows the progress with multiple display options. Can increment automatically when attached to an event.
