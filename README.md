*Plugins*

This project includes 3 plugins that have been implemented to improve Microsoft Dynamics 365 processes in an Iranian brokerage.
Plugins are as follows:

1- CreateNewTaskFromChangeOfStatePlugin:
This plugin manages tasks based on changes in their state, such as completion or cancellation, and performs associated actions like creating new tasks, updating case statuses, or sending SMS messages.

2- CreateTaskStepFromCasePlugin:
This plugin creates a new task based on the category and subcategory of a case entity. 
It retrieves the appropriate task manager based on the category and subcategory, retrieves the first step of the task manager, and then creates a new task based on that step and the case entity.

3- SetDeadlineOnTaskFromSlaCategoryPlugin:
This plugin checks the SLA category of a task and, if applicable, calculates and sets up to three deadlines based on the activation and duration parameters specified in the SLA category. These deadlines are then assigned to the task instance.
