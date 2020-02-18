# SE-Assignment
Paul Dinesh 10515229-(PaulDinesh) Arden Dias 10510105 -(ar3en-d)
To build either a console application or a Windows Forms application that conforms to the following specification:

Allow the user to select directories on their computers.

For each text file located in a selected directory, you must create another text file that must have the same name as the original, but with the word “sorted” prepended to the file name. (E.g., if the original file was called mydiary.txt, the copy will be called sortedmydiary.txt).

This “sorted” text file’s contents are the words located in the original text file in alphabetical order, with one word/number appearing per line. Any numerical values must be stored in numerical order at the start of the file. In addition, if a given word appears more than once, the frequency count should be stored alongside the entry (E.g., if mydiary.txt contained the following: “I went away for 3 days and 2 nights. I felt cold as the nights were 2.5 degrees centigrade”. Your sorted file would consist of: 2 2.5 3 and as away centigrade cold days degrees felt for I, 2 nights, 2 the went were

Please be aware of sort order. ASCII sorting will place words starting with capital letters ahead of those with lower case. However, you should be sorting in the order a typical dictionary sorts in (you can see this in the above. The word I is between the words for and nights, as per the alphabetical order.)

Other things you will need to consider are: handling financial values: €2.75, temperatures (21.6°C).
Your system must keep a track of all directories that were selected by the user and also all sorted files—where they are and what they are called. This is so that users can ask the system to: a. List all directories that have had text files sorted. b. List all files that have been sorted for a given directory. c. List all files that have been sorted for all directories. d. Allow the user to search sorted files for a given word or number. The system should display all files that contain the searched for word along with the number of times the given word or number is displayed.

The second piece of major functionality that your application must support is the ability to process a text file with a number of calculations present. Assume your input file has the following: 12 + 13 4 / 5 15 – 78.5 12.78 * 3.14 4 % 3 2 ^ 5 Your application should carry out the calculations listed and produce an output file with the following format: 12 + 13 = 25 4 / 5 = 0.8 15 – 78.5 = -63.5 12.78 * 3.14 = 40.13 4 % 3 = 1 2 ^ 5 = 32 Note: all calculations should be rounded to 2 decimal places.

There are edge cases you will need to consider for the calculator. I will not list them here—you should be able to identify these and discuss them in your report.

Your calculation should support the ability to process any number of calculation files located in a given directory. These files should be identified by the extension .calc. Your answers should be output to a file whose name is the current data and time with an extension of .answ.

This means that if a user selects the calculator functionality of your application and selects a directory that contains 3 files with the .calc extension, your application will process each .calc file in turn, but will only produce one .answ file containing the calculations and their respective answers.

You must also provide a report that contains your design, a discussion of the approach you took and why you took it.

Your report also needs to include a class diagram and two sequence diagrams—at least one sequence diagram must cover the indexing mechanism.

In your report ensure you identify who did what—this is extremely important to do.

Finally, prepare a 10-minute presentation that your group will deliver; each member of the group must present. This presentation will be accompanied by a Q&A session.

I expect you to have your projects hosted in GitHub and you will need to make me an administrator for your project team. You will need to create a GitHub account. You can check Robert Green’s video for using GitHub here: https://www.youtube.com/watch?v=c3482qAzZLQ. You will need to set-up a team (check out this video (sorry for the awful music): https://www.youtube.com/watch?v=vIp3Uz4DG2c and/or this one: https://www.youtube.com/watch?v=61WbzS9XMwk). My GitHub account is HD-DBS.

Note: this assignment requires you to produce a solution where you have defined and made use of your own classes and objects as well as those available to you in the .NET class libraries. DO NOT MAKE USE OF ANY OTHER THIRD PARTY TOOLS OR LIBRARIES, INCLUDING Databases, DataTables, etc.
