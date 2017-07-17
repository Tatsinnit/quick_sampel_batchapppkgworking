# quick_sample_batchapppkgworking
Sample barebone app to show batch application working end to end for a quick SO post.

Readme: barebone quick app:

Please note thta this app is nothing but a quick sample made based on the existing sample for DotNetTutorial.

Following code is generated just as a sample code for end to end app package working feature.

•	https://docs.microsoft.com/en-us/azure/batch/

•	https://docs.microsoft.com/en-us/azure/batch/batch-technical-overview

App Pacakges:

•	https://docs.microsoft.com/en-us/azure/batch/batch-application-packages

•	https://azure.microsoft.com/en-us/blog/application-packages-and-task-dependencies-now-available-on-azure-batch/

The overview as how it works is fairly simple, when user uploads to adds an application package the package becomes available within node’s working directory (wd). The env var gets created to handle multiple updated versions of the app: (the timestamp is automatically part of the App pkg populated env var you dont need to do anything to handle this.)

```
set AZ_BATCH_APP_PACKAGE_TEST1#1.0=C:\user\tasks\applications\wd\test1\1.0\2017-07-14T21.45.45.765Z
```

Hence if user has correct package version all set and node has app pkg they can invoke that from whatever the need is for application package: (something like this)

```
string taskCommandLine = String.Format("cmd /c %AZ_BATCH_APP_PACKAGE_TEST1#1.0%\\ImageTest\\TaskApplication.exe");
```

The inside implementation is fairly neat as well.

Please note the reason: 

```
%AZ_BATCH_APP_PACKAGE_TEST1#1.0%\\ImageTest\\TaskApplication.exe"
```

Is because my application package zip contains the TaskApplciaiton.exe under the following structure:

![zip file](https://github.com/Tatsinnit/quick_sample_batchapppkgworking/blob/master/images/test.PNG) ==> ![underlying folder](https://github.com/Tatsinnit/quick_sample_batchapppkgworking/blob/master/images/test1.PNG) => ![main exe file which will get used by this sample](https://github.com/Tatsinnit/quick_sample_batchapppkgworking/blob/master/images/test2.PNG)

To add further: An application package is a .zip file that contains the application binaries and supporting files that are required for your tasks to run the application. Each application package represents a specific version of the application.+ 

You can specify application packages at the pool and task levels. You can specify one or more of these packages and (optionally) a version when you create a pool or task.+ 

•	Pool application packages are deployed to every node in the pool. Applications are deployed when a node joins a pool, and when it is rebooted or reimaged.
Pool application packages are appropriate when all nodes in a pool execute a job's tasks. You can specify one or more application packages when you create a pool, and you can add or update an existing pool's packages. If you update an existing pool's application packages, you must restart its nodes to install the new package.

•	Task application packages are deployed only to a compute node scheduled to run a task, just before running the task's command line. If the specified application package and version is already on the node, it is not redeployed and the existing package is used.
Task application packages are useful in shared-pool environments, where different jobs are run on one pool, and the pool is not deleted when a job is completed. If your job has fewer tasks than nodes in the pool, task application packages can minimize data transfer since your application is deployed only to the nodes that run tasks.

The sample attached contains both pool level level as well the task level demo.

Steps: 

* At first add a new Application Package into my batch account: you can do that via portal. (the git project has test1.zip along with this git sample console app.

* Then open your ```DotNetTurorial``` solution:

* Fill in these info for the batch account credentials or any storage account in use for your credentials correctly: 

* Hit start the ```barebone.cs``` is set as the start project, ** please note you might need to change your *.proj file, because in my local all nugets were getting sourced from ```c:\cxcache```

Please also note, there will be prompt to delete the job and pool, if you want to checkout the return result of this app, please keep the job and pool and then go inside node inside that pool and checkout stdout.txt file for the txt printed. (Note: you probably want to delete job and pool from the portal once you are done.)

The screenshots from my successful run are below:

So I was able to see the ```Test Success``` getting printed in my stdout.txt inside node from the TaskApplication.exe which was part of this application package.

The code used in this sample barebone app is reused fomr the sample existing here: 
https://github.com/Azure/azure-batch-samples/tree/master/CSharp/ArticleProjects/DotNetTutorial.


Other friendly screenshots:

![Files inside nodes with app package avialable](https://github.com/Tatsinnit/quick_sample_batchapppkgworking/blob/master/images/filesinnode.PNG)
![another simple view of files inside node](https://github.com/Tatsinnit/quick_sample_batchapppkgworking/blob/master/images/filesonnode.PNG)
![Success ful run](https://github.com/Tatsinnit/quick_sample_batchapppkgworking/blob/master/images/stdout.PNG)
![This is view from batch explorer](https://github.com/Tatsinnit/quick_sample_batchapppkgworking/blob/master/images/taskranwithexit0.PNG)

