# Here will be the name of your project

## Running a lambda function locally

Debugging executable assembly functions is a little different. This requires you to run `Amazon.Lambda.TestTool` first.

1. Run the below command to install the Mock Lambda Test Tool.
```bash
dotnet tool update -g Amazon.Lambda.TestTool-8.0
```

2. After that, navigate to `C:\Users\<username>\.dotnet\tools` location, you will see all the installed tools.
![image](https://github.com/ArdenHide/AWS-Lambda-Function/assets/66203238/16658e94-2891-4fa8-9314-a1bf36c35c88)


3. Run this tool via the command line, which starts the Test Tool in the browser at http://localhost:5050/ URL.
![image](https://github.com/ArdenHide/AWS-Lambda-Function/assets/66203238/d9b5446a-39f9-484b-87bc-01674390da73)

4. Now, switch back to Visual Studio, and set the `AWS_LAMBDA_RUNTIME_API` environment variable to `localhost:5050`.
    1. Right-click, and select Properties.
    2. Navigate to Debug > General tab, and select Open debug launch profiles UI
    3. Set the required environment variable, and close the window.
    ![image](https://github.com/ArdenHide/AWS-Lambda-Function/assets/66203238/0cd2d046-cb70-426c-bb96-fd978b67802a)
    4. This creates a `launchSettings.json` file like this.
    ```json
    {
      "profiles": {
        "AWSLambda.NET8.Demo": {
          "commandName": "Project",
          "environmentVariables": {
            "AWS_LAMBDA_RUNTIME_API": "localhost:5050"
          }
        }
      }
    }
    ```

5. Now, run the application by pressing F5. This starts the app and executes the `main()` method.

6. Code in the `main()` method to start the Lambda Runtime looks for the `AWS_LAMBDA_RUNTIME_API` environment variable. That’s why the Mock Lambda Test tool needs to be started first.

7. Now, go back to the lambda test tool, enter the event in the text box, and press the `Queue Event` button.

8. The moment you press the Queue Event button, the debugger is hit in Visual Studio.
![image](https://github.com/ArdenHide/AWS-Lambda-Function/assets/66203238/5d98ff4e-1871-44cb-8f95-8e5a9a98b2b2)

9. So this is how you can debug and test your Lambda function.

