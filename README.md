<img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/f5544227-dc19-4e2a-a562-24fab120a525" width=100>

# TurtleToastService
A straightforward C#/WPF service for displaying toast messages!
<br>

```
TurtleToast.Information("Turtle toast!");
```
<img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/a040dfb8-b446-4cd0-914f-d187f2b94fe6" width=185>

---
### Key features
* Built-in queue system with a priority mechanism
* 4 themes with easy customizability

| Light | Stone grey | Dark | Turtle green |
| ------------- | ------------- | ------------- | ------------- |
| <img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/8a7fc994-3755-44fd-b117-33618e29a8ca" width=185> | <img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/a040dfb8-b446-4cd0-914f-d187f2b94fe6" width=185> | <img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/af45ef66-4a3e-4340-bb59-7498dab3a431" width=185>  | <img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/4f7c6794-854d-4201-9b9b-be78a8a18718" width=185>  |
* 3 different types of toast messages with a straight-forward expandability
  * ### Information toast
    <img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/fb3083d9-fa20-4a2e-9a0a-53995c8f73d4" width=185> 
    
    ```
    TurtleToast.Information("Information toast");
    ```
    
    Hides after time calculated off the length of the text.
  * ### Confirmation toast
    <img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/93993717-4c76-4ca8-9c51-9e0180948ace" width=214>
    
    ```
    TurtleToast.Confirmation("Confirmation toast");
    ```
    Hides after the button is clicked.
  * ### Loading toast
    <img src="https://github.com/mooshmore/TurtleToastService/assets/89631705/e240b7b5-2f49-44b3-a1e0-207b928a0077" width=245>
    
    ```
    TurtleToast.Loading("Loading toast", "This can take a while", maxLoadingCount, progressEvent: ref LoadingEvent, displayMode: ProgressDisplayMode.CountAndPercentage);
    ```
    Shows the progress with multiple display options. Can increment automatically when attached to an event.

  
